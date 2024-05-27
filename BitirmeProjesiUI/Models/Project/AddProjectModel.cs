namespace BitirmeProjesiUI.Models.Project
{
    public class AddProjectModel
    {
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



        public string? Create_ID { get; set; }
        public DateTime Create_Date { get; set; }
        
        public bool IsActive { get; set; }
        
    }
}
