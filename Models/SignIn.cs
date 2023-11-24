using System.ComponentModel.DataAnnotations;

namespace Tanuj.BookStore.Models
{
    public class SignIn
    {
        [Required, EmailAddress]                             // data annotation
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
