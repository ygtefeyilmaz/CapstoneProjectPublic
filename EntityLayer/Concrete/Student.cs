using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Student:IdentityUser
    {
        [Key]
        public int Student_ID { get; set; }
       
        public string? Student_Name { get; set; }
        public string? Student_SurName { get; set; }

        public int Department_ID { get; set; } //öğretmenin çalıştığı departman
        [ForeignKey("Department_ID")]
        public virtual Department? Department { get; set; }
         
        public int Team_ID { get; set; }
        [ForeignKey("Team_ID")]
        public virtual Team? Team { get; set; }


        #region genel bilgiler
        public string? Create_ID { get; set; }
        public DateTime Create_Date { get; set; }
        public string? Update_ID { get; set; }
        public DateTime Update_Date { get; set; }
        public bool IsDelete { get; set; }
        public string? IsDelete_ID { get; set; }
        public DateTime IsDelete_Date { get; set; }
        public bool IsActive { get; set; }
        #endregion
    }
}
