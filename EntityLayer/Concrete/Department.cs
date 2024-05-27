using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Department
    {

        [Key]
        public int Department_ID { get; set; } 
        public string? Department_Name { get; set; }

        //ssadsa

         

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
