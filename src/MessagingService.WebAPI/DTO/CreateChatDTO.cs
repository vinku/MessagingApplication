using MessagingService.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingService.WebAPI.DTO
{
	public class CreateChatDTO
	{
		[MinLength(1, ErrorMessage = "Atleast 2 users required for a chat.")]
		[MaxLength(9, ErrorMessage = "Can't support adding of more than 10 users to a chat.")]
		public List<string> CellNumbers { get; set; }

		public Chat CreateChat()
		{
			Chat chat = new Chat
			{
				ChatId = Guid.NewGuid(),
				LastActivityTime = DateTime.Now
			};
			return chat;
		}
	}
}

