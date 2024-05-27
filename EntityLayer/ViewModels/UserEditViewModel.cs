    using EntityLayer.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.ViewModels
{
    public class UserEditViewModel
    {
        public string Id { get; set; } = null!;

        [Required(ErrorMessage = "This field cannot be left empty!")]
        [Display(Name = "Username :")]
        public string UserName { get; set; } = null!;

        [EmailAddress(ErrorMessage = "The email format is incorrect!")]
        [Required(ErrorMessage = "This field cannot be left empty!")]
        [Display(Name = "Email address :")]
        public string Email { get; set; } 

        [Required(ErrorMessage = "This field cannot be left empty!")]
        [Display(Name = "Contact number :")]
        public string Phone { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of birth :")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "City :")]
        public string? City { get; set; }

        [Display(Name = "Profile picture :")]
        public IFormFile? Picture { get; set; }

        [Display(Name = "Gender :")]
        public Gender? Gender { get; set; }

        public string Name { get; set; } = null!;
        public string SurName { get; set; } = null!;
        public int Department_ID { get; set; } 
        public bool IsActive { get; set; }  
    }
}