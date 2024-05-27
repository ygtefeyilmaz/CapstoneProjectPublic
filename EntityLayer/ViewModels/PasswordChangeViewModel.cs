using System.ComponentModel.DataAnnotations;

namespace EntityLayer.ViewModels
{
    public class PasswordChangeViewModel
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field cannot be left empty!")]
        [Display(Name = "Current Password :")]
        [MinLength(6, ErrorMessage = "Your password must be at least 6 characters long!")]
        public string PasswordOld { get; set; } = null!;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field cannot be left empty!")]
        [Display(Name = "New Password :")]
        [MinLength(6, ErrorMessage = "Your password must be at least 6 characters long!")]
        public string PasswordNew { get; set; } = null!;

        [DataType(DataType.Password)]
        [Compare(nameof(PasswordNew), ErrorMessage = "Passwords do not match!")]
        [Required(ErrorMessage = "This field cannot be left empty!")]
        [Display(Name = "Confirm New Password :")]
        [MinLength(6, ErrorMessage = "Your password must be at least 6 characters long!")]
        public string PasswordNewConfirm { get; set; } = null!;
    }
}