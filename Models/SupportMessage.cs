using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CodeForProject.Models
{
	public class SupportMessage
	{
		[JsonProperty("id")]
		public string Id { get; set; } = Guid.NewGuid().ToString();

		[Required(ErrorMessage = "Name is required.")]
		[StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
		public string Name { get; set; } = string.Empty;

		[Required(ErrorMessage = "Email is required.")]
		[EmailAddress(ErrorMessage = "Please enter a valid email address.")]
		public string Email { get; set; } = string.Empty;

		[Phone(ErrorMessage = "Please enter a valid phone number.")]
		[Display(Name = "Telephone Number")]
		public string TelephoneNumber { get; set; } = string.Empty;

		[Required(ErrorMessage = "Description is required.")]
		[StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
		public string Description { get; set; } = string.Empty;

		[Required(ErrorMessage = "Please select a complaint type.")]
		[Display(Name = "Complaint Type")]
		public string ComplaintType { get; set; } = string.Empty;

		public DateTime SubmissionDate { get; set; } = DateTime.UtcNow;
	}
}
