using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class GeneralNeeds
    {

        [Key]
        public int GeneralNeeds_ID { get; set; }
        public string? Value { get; set; }
        public string? TextValue { get; set; }


        public string? GeneralNeeds_Description { get; set; }
        public bool IsActive { get; set; }


    }
}
