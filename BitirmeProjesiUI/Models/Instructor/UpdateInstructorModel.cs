namespace BitirmeProjesiUI.Models.Instructor
{
    public class UpdateInstructorModel
    {
        public int Instructor_ID { get; set; } 
        public string? Instructor_Name { get; set; }
        public string? Instructor_Surname { get; set; }

        public string? Update_ID { get; set; }
        public DateTime Update_Date { get; set; }
        public bool IsActive { get; set; }
    }
}
