namespace BitirmeProjesiUI.Models.Team
{
    public class AddTeamModel
    {
       
        public string? Team_Name { get; set; }
        public int AssignedProjectID { get; set; } //takım hangi projeye atandı(optimizasyon engineden gelen sonuç oraya yazılacak)      
        public int Department_ID { get; set; }
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
        public string studentID1 { get; set; }
        public string studentID2 { get; set; }
        public string studentID3 { get; set; }


       
        public string? Create_ID { get; set; }
        public DateTime Create_Date { get; set; }
      
        public bool IsActive { get; set; }
      
    }
}
