using System.ComponentModel.DataAnnotations.Schema;

namespace BitirmeProjesiUI.Models.Project
{
    public class UpdateProjectModel
    {
        public int Project_ID { get; set; }

        public string? Project_Name { get; set; } 
        public int Department_ID { get; set; }
        public int Department1_Capacity { get; set; }
        public int DepartmentID2 { get; set; }
        public int Department2_Capacity { get; set; }
        public int DepartmentID3 { get; set; }
        public int Department3_Capacity { get; set; }

        public int DepartmentID4 { get; set; }
        public int Department4_Capacity { get; set; }


        public string? Project_Description { get; set; } 
        public int Instructor_ID { get; set; }


     
     






        public string? Update_ID { get; set; }
        public DateTime Update_Date { get; set; } 
        public bool IsActive { get; set; }
     
    }
}
