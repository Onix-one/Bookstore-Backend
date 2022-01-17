using System.ComponentModel.DataAnnotations;

namespace Bookstore.IdentityApi.Dto
{
    public class CreateUserDto : UserDto
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
