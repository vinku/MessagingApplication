using MessagingService.Domain;
using System;

namespace MessagingService.WebAPI.DTO
{
	public class NewMessageDTO
	{
		public string MessageText { get; set; }

		public Message GetMessageFromDTO()
		{
			Message message = new Message
			{
				MessageId = Guid.NewGuid(),
				MessageText = this.MessageText,
				SentTime = DateTime.Now,
				Status = MessageStatus.Received
			};
			return message;
		}
	}
}
