using System.ComponentModel.DataAnnotations;

namespace EntityLayer.ViewModels
{
    public class SignUpViewModel
    {
        public SignUpViewModel()
        {
        }

        public SignUpViewModel(string userName, string email, string phone, string password)
        {
            UserName = userName;
            Email = email;
            Phone = phone;
            Password = password;
        }

        [Required(ErrorMessage = "User Name cannot be empty.")]
        [Display(Name = "User Name :")]
        public string UserName { get; set; } = null!;

        [EmailAddress(ErrorMessage = "Wrong Email Format")]
        [Required(ErrorMessage = "Email cannot be empty.")]
        [Display(Name = "Email :")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Phone cannot be empty")]
        [Display(Name = "Phone :")]
        public string Phone { get; set; } = null!;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password cannot be empty")]
        [Display(Name = "Password :")]
        [MinLength(6, ErrorMessage = "Minimum 6 characters")]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Passwords don't match")]
        [Required(ErrorMessage = "Cannot be empty")]
        [Display(Name = "Password again :")]
        [MinLength(6, ErrorMessage = "Minimum 6 characters")]
        public string PasswordConfirm { get; set; } = null!;

        public string Name { get; set; } = null!;
        public string SurName { get; set; } = null!;
        public int Department_ID { get; set; }
        public bool IsActive { get; set; }
    }
}