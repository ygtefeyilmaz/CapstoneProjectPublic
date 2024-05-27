using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Project
    {
        [Key]
        public int Project_ID { get; set; }
        
        public string? Project_Name { get; set; }

        public int Department_ID { get; set; }
        [ForeignKey("Department_ID")]
        public virtual Department? Department { get; set; }

        public int Department1_Capacity { get; set; }

        public int DepartmentID2 { get; set; }
        public int Department2_Capacity { get; set; }

        public int DepartmentID3 { get; set; }
        public int Department3_Capacity { get; set; }

        public int DepartmentID4 { get; set; }
        public int Department4_Capacity { get; set; }


        public int Instructor_ID { get; set; }
        [ForeignKey("Instructor_ID")]
        public virtual Instructor Instructor { get; set; }

        public string? Project_Description { get; set; }

      
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
