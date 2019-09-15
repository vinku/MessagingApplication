using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MessagingService.Data;
using MessagingService.Domain;
using Microsoft.AspNetCore.Rewrite.Internal.UrlActions;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;

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
		public ActionResult Get()
		{
			return NotFound();
		}

		// GET api/users/5
		[HttpGet("{id}", Name = "GetIndividualUser")]
		public ActionResult Get(string id)
		{
			return Ok(_repo.GetUserFromCellNumber(id));
		}

		// POST api/users
		[HttpPost]
		public ActionResult Post([FromBody] User user)
		{
			if (_repo.UseridExists(user.UserCellId))
			{
				return Conflict("User with same cell number already exists, can't add it any more");
			}

			// NOTE: there has to be a way to validate a phone number (OTP verification). For our case, we assue the cell number has to be a 10 digit string.
			if (user.UserCellId.Length != 10)
			{
				return BadRequest("Phone number must be a 10-digit number");
			}

			// the creation time is the last seen time for now.
			user.LastSeenTime = DateTime.Now;
			_repo.AddNewuser(user);
			return CreatedAtRoute("GetIndividualUser", new
				{ id = user.UserCellId }, user);
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
