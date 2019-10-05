using MessagingService.Domain;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MessagingService.WebAPI.DTO
{
	[DataContract]
	public class ChatDTO
	{
		[DataMember]
		private Guid chatId;
		[DataMember]
		private DateTime lastActivityDateTime;
		[DataMember]
		private List<UserDTO> chatParticipants;

		public static ChatDTO ChatDTOFromChat(Chat chat)
		{
			ChatDTO chatDTO = new ChatDTO();
			chatDTO.chatParticipants = new List<UserDTO>();

			chatDTO.chatId = chat.ChatId;
			chatDTO.lastActivityDateTime = chat.LastActivityTime;
			foreach (UserChat userChat in chat.UserChats)
			{
				chatDTO.chatParticipants.Add(UserDTO.UserDTOFromUser(userChat.User));
			}

			return chatDTO;
		}
	}
}
