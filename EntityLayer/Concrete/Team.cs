using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Team
    {
        [Key]
        public int Team_ID { get; set; }
        public string? Team_Name { get; set; }
        public int AssignedProjectID { get; set; } //takım hangi projeye atandı(optimizasyon engineden gelen sonuç oraya yazılacak)      
        public int Department_ID { get; set; } //öğretmenin çalıştığı departman
        [ForeignKey("Department_ID")]
        public virtual Department? Department { get; set; }





        public int Team_Capacity { get; set; } //max 3 kayıt olabilir drop down 
        public string? Team_Description { get; set; }
         

        public int projectChoice1 { get; set; }
        public int projectChoice2 { get; set; }
        public int projectChoice3 { get; set; }
        public int projectChoice4 { get; set; }
        public int projectChoice5 { get; set; }
        public int projectChoice6 { get; set; }
        public int projectChoice7 { get; set; }
        public int projectChoice8 { get; set; }
        public int projectChoice9 { get; set; }
        public int projectChoice10 { get; set; }
        public string? studentID1 { get; set; }
        public string? studentID2 { get; set; }
        public string? studentID3 { get; set; }


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
