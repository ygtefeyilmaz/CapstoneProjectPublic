using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Graph
    {

        [Key]
        public int Graph_ID { get; set; }
        public string? z1 { get; set; }
        public string? z2 { get; set; }
        public string? z3 { get; set; }
        public string? z4 { get; set; }
        public string? z5 { get; set; }
        public string? z6 { get; set; }
        public string? z7 { get; set; }
        public string? z8 { get; set; }
        public string? z9 { get; set; }
        public string? z10 { get; set; }
        public string? z11 { get; set; }

        public string? NullProject { get; set; }
        public DateTime Years { get; set; }
    }
}
