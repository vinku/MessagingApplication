using MessagingService.Data;
using MessagingService.Domain;
using MessagingService.WebAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MessagingService.WebAPI.Controllers
{
	[Route("api/users/{userId}/chats/{chatId}/[controller]")]
	[ApiController]
	public class MessagesController : ControllerBase
	{
		Repository _repo;

		public MessagesController(Repository repo)
		{
			_repo = repo;
		}

		// GET: api/users/{userId}/chats/{chatId}/messages
		[HttpGet]
		public IActionResult Get(string userId, Guid chatId)
		{
			this.Validations(userId, chatId);
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			return Ok(MessageDTO.MessageDTOsForChat(_repo.GetMessagesForChat(chatId)));
		}

		// GET: api/users/{userId}/chats/{chatId}/messages/{messageId}
		[HttpGet("{messageId}", Name = "IndividualMessage")]
		public IActionResult Get(string userId, Guid chatId, Guid messageId)
		{
			this.Validations(userId, chatId);
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			return Ok(MessageDTO.GetMessageDTOFromMessage(_repo.GetMessageFromId(messageId)));
		}

		// POST: api/users/{userId}/chats/{chatId}/messages
		[HttpPost]
		public IActionResult Post(string userId, Guid chatId, [FromBody] NewMessageDTO newMessageDTO)
		{
			this.Validations(userId, chatId);
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			Message message = newMessageDTO.GetMessageFromDTO();
			_repo.RecordNewMessage(userId, chatId, message);
			return Ok();
		}

		// PUT: api/Messages/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
			throw new NotImplementedException();
		}

		// DELETE: api/ApiWithActions/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		private void Validations(string userId, Guid chatId)
		{
			if (!_repo.UserIdExists(userId))
			{
				ModelState.AddModelError("Description", "cellNumber " + userId + " is not registered.");
			}

			if (!_repo.ValidateChatForuser(userId, chatId))
			{
				ModelState.AddModelError("Description", "Invalid chat " + chatId + " for user " + userId + ".");
			}
		}
	}
}
