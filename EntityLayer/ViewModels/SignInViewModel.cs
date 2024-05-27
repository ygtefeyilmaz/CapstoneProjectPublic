using System.ComponentModel.DataAnnotations;

namespace EntityLayer.ViewModels
{
    public class SignInViewModel
    {
        public SignInViewModel()
        { }

        public SignInViewModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        [Required(ErrorMessage = "This field cannot be left empty!")]
        [EmailAddress(ErrorMessage = "The email format is incorrect!")]
        [Display(Name = "Email address :")]
        public string Email { get; set; } = null!;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field cannot be left empty!")]
        [Display(Name = "Password :")]
        [MinLength(6, ErrorMessage = "Your password must be at least 6 characters long!")]
        public string Password { get; set; } = null!;

        [Display(Name = "Remember Me ")]
        public bool RememberMe { get; set; }
    }
}