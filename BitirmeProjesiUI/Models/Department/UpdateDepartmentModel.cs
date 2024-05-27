namespace BitirmeProjesiUI.Models.Department
{
    public class UpdateDepartmentModel
    {
        public int Department_ID { get; set; }
        public string? Department_Name { get; set; }


         
       
        public string? Update_ID { get; set; }
        public DateTime Update_Date { get; set; } 
        public bool IsActive { get; set; }
        
    }
}
