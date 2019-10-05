using MessagingService.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
			// Returns the chat-ids for particular cellNumber.
			var chatIds =
				_context.UserChats
				.Where(uc => uc.UserCellId == cellNumber)
				.OrderByDescending(uc => uc.Chat.LastActivityTime)
				.Select(uc => uc.ChatId).ToList();

			return chatIds;
		}

		public void AddNewuser(User user)
		{
			// ToDo : Remove this method and add a save method which would work for both update and creation of new resource.
			_context.Users.Add(user);
			_context.SaveChanges();
		}

		public bool ValidateChatForuser(string userId, Guid chatId)
		{
			UserChat UserChats =
			_context.UserChats
				.Where(uc => uc.UserCellId == userId && uc.ChatId == chatId)
				.FirstOrDefault();
			return UserChats != null;
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

		public void RecordNewMessage(string userId, Guid chatId, Message message)
		{
			_context.Messages.Add(message);

			// Update the last activity time for the corresponding chat.
			Chat chatForMessage = _context.Chats
				.Where(c => c.ChatId == chatId)
				.FirstOrDefault();
			chatForMessage.LastActivityTime = message.SentTime;
			_context.Chats.Update(chatForMessage);

			_context.ChatMessages.Add(
				new ChatMessage { ChatId = chatId, MessageId = message.MessageId });
			_context.MessageSenders.Add(
				new MessageSender { UserCellId = userId, MessageId = message.MessageId });

			_context.SaveChanges();
		}

		public bool UserIdExists(string cellNumber)
		{
			return GetUserFromCellNumber(cellNumber) != null;
		}

		public Chat GetChatFromId(Guid chatId)
		{
			var chat =
				_context.Chats
				.Include(c => c.UserChats)
				.ThenInclude(uc => uc.User)
				.Where(c => c.ChatId == chatId)
				.FirstOrDefault();
			return chat;
		}

		public List<Message> GetMessagesForChat(Guid chatId)
		{
			var messages =
				_context.Messages
				.Include(m => m.ChatMessage)
				.Where(m => m.ChatMessage.ChatId == chatId)
				.Include(m => m.MessageSender)
				.OrderByDescending(m => m.SentTime)
				.ToList();
			return messages;
		}

		public Message GetMessageFromId(Guid messageId)
		{
			var message =
				_context.Messages
				.Where(m => m.MessageId == messageId)
				.Include(m => m.MessageSender)
				.Include(m => m.ChatMessage)
				.FirstOrDefault();
			return message;
		}
	}
}
