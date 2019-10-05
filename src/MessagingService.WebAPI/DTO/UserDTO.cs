using MessagingService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MessagingService.WebAPI.DTO
{
	[DataContractAttribute]
	public class UserDTO
	{
		[DataMember]
		private string cellNumber;
		[DataMember]
		private string name;
		[DataMember]
		private DateTime lastSeenTime;

		public static UserDTO UserDTOFromUser(User user, bool includeLastSeenInformation = false)
		{
			UserDTO userDTO = new UserDTO();
			userDTO.cellNumber = user.UserCellId;
			userDTO.name = user.Name;
			if (includeLastSeenInformation)
			{
				userDTO.lastSeenTime = user.LastSeenTime;
			}
			return userDTO;
		}
	}
}
