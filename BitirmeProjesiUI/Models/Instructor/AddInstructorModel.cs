namespace BitirmeProjesiUI.Models.Instructor
{
    public class AddInstructorModel
    {
        public string? Instructor_Name { get; set; }
        public string? Instructor_Surname { get; set; }

        public string? Create_ID { get; set; }
        public DateTime Create_Date { get; set; }
        public bool IsActive { get; set; }
    }
}
