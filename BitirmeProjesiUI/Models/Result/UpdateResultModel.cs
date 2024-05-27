using System.ComponentModel.DataAnnotations.Schema;

namespace BitirmeProjesiUI.Models.Result
{
    public class UpdateResultModel
    {
        public int Result_ID { get; set; } 
        public int Team_ID { get; set; }  
        public int Project_ID { get; set; }
        public string? Student_ID { get; set; }
        public string? Update_ID { get; set; }
        public DateTime Update_Date { get; set; } 
        public bool IsActive { get; set; } 
    }
}
