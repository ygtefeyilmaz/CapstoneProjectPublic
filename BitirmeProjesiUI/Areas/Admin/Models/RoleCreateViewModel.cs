using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesi.Areas.Admin.Models
{
    public class RoleCreateViewModel
    {

        [Required(ErrorMessage = "This field cannot be left empty!")]
        [Display(Name = "Role name :")]
        public string Name { get; set; }
    }
}
