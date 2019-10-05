using MessagingService.Data;
using MessagingService.Domain;
using MessagingService.WebAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MessagingWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		Repository _repo;

		public UsersController(Repository repo)
		{
			_repo = repo;
		}

		// GET api/users
		[HttpGet]
		public IActionResult Get()
		{
			return NotFound();
		}

		// GET api/users/5
		[HttpGet("{id}", Name = "GetIndividualUser")]
		public IActionResult Get(string id)
		{
			UserDTO retDTO = UserDTO.UserDTOFromUser(_repo.GetUserFromCellNumber(id), includeLastSeenInformation: true);
			return Ok(retDTO);
		}

		// POST api/users
		[HttpPost]
		public IActionResult Post([FromBody] CreateUserDTO userDTO)
		{
			if (userDTO == null)
			{
				ModelState.AddModelError("Description", "Can not deserialize the body.");
			}

			User user = userDTO.GetUserFromDTO();
			if (_repo.UserIdExists(user.UserCellId))
			{
				ModelState.AddModelError("Description", "User with same cell number already exists, can't add it any more.");
			}


			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			// the creation time is the last seen time for now.
			user.LastSeenTime = DateTime.Now;
			_repo.AddNewuser(user);

			return CreatedAtRoute("GetIndividualUser",
				new { id = user.UserCellId },
				user);  // It's good to return the object created as a response to header.
		}

		// PUT api/users/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
			throw new NotImplementedException();
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			throw new NotImplementedException();
		}
	}
}
