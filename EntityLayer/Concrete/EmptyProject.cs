using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class EmptyProject
    {
        [Key]
        public int EmptyProject_ID { get; set; }



        public int Project_ID { get; set; } //öğretmenin çalıştığı departman
        [ForeignKey("Project_ID")]
        public virtual Project? Project { get; set; }





    }
}
