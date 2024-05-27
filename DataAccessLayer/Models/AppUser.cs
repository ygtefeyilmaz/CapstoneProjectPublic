
using EntityLayer.Concrete;
using EntityLayer.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class AppUser : IdentityUser
    {
        public string? City { get; set; }
        public string? Picture { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender? Gender { get; set; }

        [ForeignKey("Branch_ID")]
        public int Branch_ID { get; set; }

        [ForeignKey("Department_ID")]
        public int Department_ID { get; set; } //user departmanı


        [ForeignKey("Team_ID")]
        public int Team_ID { get; set; }


        public string? Name { get; set; }
        public string? SurName { get; set; }
        public bool IsActive { get; set; }

    }
}