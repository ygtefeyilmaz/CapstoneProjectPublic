using System.ComponentModel.DataAnnotations;

namespace EntityLayer.ViewModels
{
    public class ForgetPasswordViewModel
    {
        [Required(ErrorMessage = "This field can not be left empty!")]
        [EmailAddress(ErrorMessage = "The email format is incorrect!")]
        [Display(Name = "Email address :")]
        public string Email { get; set; } = null!;
    }
}