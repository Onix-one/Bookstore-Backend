using System.ComponentModel.DataAnnotations;

namespace Bookstore.IdentityApi.Dto
{
    public class ChangePasswordDto
    {
        [Required]
        public string Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field cannot be empty")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "This field cannot be empty")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
    }
}
