using MessagingService.Data;
using MessagingService.Domain;
using MessagingService.WebAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MessagingService.WebAPI.Controllers
{
	[Route("api/users/{userId}/[controller]")]
	[ApiController]
	public class ChatsController : ControllerBase
	{
		private Repository _repo;

		public ChatsController(Repository repo)
		{
			this._repo = repo;
		}

		// GET: api/users/{userId}/chats
		[HttpGet]
		public IActionResult Get(string userId)
		{
			if (!_repo.UserIdExists(userId))
			{
				ModelState.AddModelError("Description", "cellNumber " + userId + " is not registered.");
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			return Ok(_repo.GetChatsForUser(userId));
		}

		// GET: api/users/{userId}/chats/{chatId}
		[HttpGet("{chatId}", Name = "GetIndividualChat")]
		public IActionResult Get(string userId, Guid chatId)
		{
			if (!_repo.UserIdExists(userId))
			{
				ModelState.AddModelError("Description", "cellNumber " + userId + " is not registered.");
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			return Ok(ChatDTO.ChatDTOFromChat(_repo.GetChatFromId(chatId)));
		}

		// POST: api/users/{userId}/chats/
		[HttpPost]
		public IActionResult Post(string userId, [FromBody] CreateChatDTO chatDTO)
		{
			chatDTO.CellNumbers.Add(userId);
			foreach (string cellNumber in chatDTO.CellNumbers)
			{
				if (!_repo.UserIdExists(cellNumber))
				{
					ModelState.AddModelError("Description", "cellNumber " + cellNumber + " is not registered");
					break;
				}
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			Chat chat = chatDTO.CreateChat();
			_repo.AddChat(chatDTO.CellNumbers, chat);

			// Can't send the chat object directly because that would lead to recursive reference.
			// See : https://stackoverflow.com/a/52615003. Hence using _repo.GetChats.
			return CreatedAtRoute("GetIndividualChat",
				new { userId, chatId = chat.ChatId.ToString() },
				ChatDTO.ChatDTOFromChat(_repo.GetChatFromId(chat.ChatId)));
		}

		// PUT: api/Messages/5
		[HttpPut("{chatId}")]
		public void Put(int id, [FromBody] string value)
		{
			throw new NotImplementedException();
		}

		// DELETE: api/ApiWithActions/5
		[HttpDelete("{chatId}")]
		public void Delete(int id)
		{
			throw new NotImplementedException();
		}
	}
}
