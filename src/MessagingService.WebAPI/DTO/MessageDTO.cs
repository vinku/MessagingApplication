using MessagingService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MessagingService.WebAPI.DTO
{
	[DataContract]
	public class MessageDTO
	{
		[DataMember]
		private Guid messageId;
		[DataMember]
		private string messageText;
		[DataMember]
		private string messageSenderId;
		[DataMember]
		private string chatId;
		[DataMember]
		private DateTime messageSentDateTime;

		public static MessageDTO GetMessageDTOFromMessage(Message message)
		{
			MessageDTO messageDTO = new MessageDTO();
			messageDTO.messageId = message.MessageId;
			messageDTO.messageText = message.MessageText;
			messageDTO.messageSenderId = message.MessageSender.UserCellId;
			messageDTO.chatId = message.ChatMessage.ChatId.ToString();
			messageDTO.messageSentDateTime = message.SentTime;

			return messageDTO;
		}

		public static List<MessageDTO> MessageDTOsForChat(List<Message> messages)
		{
			List<MessageDTO> messageDTOs = new List<MessageDTO>();
			foreach(Message message in messages)
			{
				MessageDTO messageDTO = new MessageDTO();
				messageDTO.messageId = message.MessageId;
				messageDTO.messageText = message.MessageText;
				messageDTO.messageSenderId = message.MessageSender.UserCellId;
				messageDTO.chatId = message.ChatMessage.ChatId.ToString();
				messageDTO.messageSentDateTime = message.SentTime;
				messageDTOs.Add(messageDTO);
			}

			return messageDTOs;
		}

	}
}
