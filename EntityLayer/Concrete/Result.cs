using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Result//hangi takım hangi projeye atandığının sonucunu gösterecek
    {
        [Key]
        public int Result_ID { get; set; }


        public int Team_ID { get; set; }
        [ForeignKey("Team_ID")]
        public virtual Team? Team { get; set; }
        //public string? Team_Name { get; set; }



        public int Project_ID { get; set; }
        [ForeignKey("Project_ID")]
        public virtual Project? Project { get; set; }
        //public string? Project_Name { get; set; }

        public string? Student_ID { get; set; }
 
    }
}
