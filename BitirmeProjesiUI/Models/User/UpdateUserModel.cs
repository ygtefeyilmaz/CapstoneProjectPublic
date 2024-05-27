
using EntityLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesiUI.Models.User
{
    public class UpdateUserModel
    {
        public string Id { get; set; } = null!;

        [Required(ErrorMessage = "Kullanıcı Ad alanı boş bırakılamaz.")]
        [Display(Name = "Kullanıcı Adı :")]
        public string UserName { get; set; } = null!;

        [EmailAddress(ErrorMessage = "Email formatı yanlıştır.")]
        [Required(ErrorMessage = "Email alanı boş bırakılamaz.")]
        [Display(Name = "Email :")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon alanı boş bırakılamaz.")]
        [Display(Name = "Telefon :")]
        public string Phone { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Doğrum tarihi :")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Şehir :")]
        public string? City { get; set; }

        [Display(Name = "Profil resmi :")]
        public IFormFile? Picture { get; set; }

        [Display(Name = "Cinsiyet :")]
        public Gender? Gender { get; set; }

        public string Name { get; set; } = null!;
        public string SurName { get; set; } = null!;
        public int Department_ID { get; set; }
        public bool IsActive { get; set; }
    }
}
