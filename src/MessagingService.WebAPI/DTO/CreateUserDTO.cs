using MessagingService.Domain;
using System.ComponentModel.DataAnnotations;

namespace MessagingService.WebAPI.DTO
{
	// Represents the information the client needs to send while creating an object.
	public class CreateUserDTO
	{
		[Required(ErrorMessage = "Missing Name.")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Missing Cellnumber.")]
		[StringLength(maximumLength: 10, MinimumLength = 10, ErrorMessage = "The length of phone number should be 10.")]
		public string CellNumber { get; set; }

		// TODO: automapper can do this.
		public User GetUserFromDTO()
		{
			User user = new User
			{
				Name = Name,
				UserCellId = CellNumber
			};
			return user;
		}
	}
}
