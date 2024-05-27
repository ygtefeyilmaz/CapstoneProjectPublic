using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Instructor //hangi öğretmen hangi projede görevli ise 
    {

        [Key]
        public int Instructor_ID { get; set; }
       
        public string? Instructor_Name { get; set; }
        public string? Instructor_Surname { get; set; }

        //public int Department_ID { get; set; } //öğretmenin çalıştığı departman
        //[ForeignKey("Department_ID")]
        //public virtual Department? Department { get; set; }
     

        //public int Project_ID { get; set; }
        //[ForeignKey("Project_ID")]
        //public virtual Project? Project { get; set; }

         

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
