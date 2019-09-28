using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessagingService.Data;
using MessagingService.Domain;
using MessagingService.WebAPI.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration.UserSecrets;

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
			if (!_repo.UseridExists(userId))
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
			if (!_repo.UseridExists(userId))
			{
				ModelState.AddModelError("Description", "cellNumber " + userId + " is not registered.");
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			return Ok(_repo.GetChats(chatId));
		}

		// POST: api/users/{userId}/chats/
		[HttpPost]
		public IActionResult Post(string userId, [FromBody] CreateChatDTO chatDTO )
		{
			chatDTO.CellNumbers.Add(userId);
			foreach (string cellNumber in chatDTO.CellNumbers)
			{
				if(!_repo.UseridExists(cellNumber))
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
				_repo.GetChats(chat.ChatId));
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
