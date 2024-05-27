using EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations.Schema;

namespace BitirmeProjesiUI.Models.Student
{
    public class UpdateStudentModel
    {
        public int Student_ID { get; set; } 
        public string? Student_Name { get; set; }
        public string? Student_SurName { get; set; } 
        public int Department_ID { get; set; }  
        public int Team_ID { get; set; } 
        public string? Update_ID { get; set; }
        public DateTime Update_Date { get; set; } 
        public bool IsActive { get; set; }
       
    }
}
