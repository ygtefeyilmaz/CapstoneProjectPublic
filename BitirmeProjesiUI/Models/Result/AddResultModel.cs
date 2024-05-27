using System.ComponentModel.DataAnnotations.Schema;

namespace BitirmeProjesiUI.Models.Result
{
    public class AddResultModel
    {
        public int Result_ID { get; set; } 
        public int Team_ID { get; set; } 
        public int Project_ID { get; set; }
        public string? Student_ID { get; set; }
        public string? Create_ID { get; set; } 
        public bool IsActive { get; set; } 
    }
}
