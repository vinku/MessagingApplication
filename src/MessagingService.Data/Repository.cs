using MessagingService.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MessagingService.Data
{
	public class Repository
	{
		private MessaginContext _context;

		public Repository(MessaginContext context)
		{
			_context = context;
			_context.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking;
		}

		public User GetUserFromCellNumber(string cellNumber)
		{
			var user =
				_context.Users
				.FirstOrDefault(s => s.UserCellId == cellNumber);
			return user;
		}

		public List<Guid> GetChatsForUser(string cellNumber)
		{
			// Returns the chat-ids for particular cellNumber. Querying UserChats instead of Chats to avoid a join.
			var chatIds =
				_context.UserChats
				.Where(uc => uc.UserCellId == cellNumber)
				.Select(uc => uc.ChatId).ToList();

			return chatIds;
		}

		public void AddNewuser(User user)
		{
			// ToDo : Remove this method and add a save method which would work for both update and creation of new resource.
			_context.Users.Add(user);
			_context.SaveChanges();
		}

		public void AddChat(List<string> userIds, Chat chat)
		{
			_context.Chats.Add(chat);
			foreach (string userId in userIds)
			{
				_context.UserChats.Add(
					new UserChat { UserCellId = userId, ChatId = chat.ChatId });
			}
			_context.SaveChanges();
		}

		public bool UseridExists(string cellNumber)
		{
			return GetUserFromCellNumber(cellNumber) != null;
		}

		public Chat GetChats(Guid chatId)
		{
			var chat = _context.Chats
				.Where(c => c.ChatId == chatId)
				.FirstOrDefault();
			return chat;
		}
	}
}
