using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace BeanScene2.Models
{
    public class Area
    {
        [Key]
        [Display(Name = "Area ID")]
        [Required(ErrorMessage = "Area ID is required")]
        public int AreaId { get; set; }
        [Display(Name = "Area Name")]
        [Required(ErrorMessage ="Area name is required")]
        [StringLength(50,MinimumLength =1, ErrorMessage ="The Area Name must be between 1 and 50 chars")]
        public string AreaName { get; set; }
        public int Capacity { get; set; }

        //Relationships
        public List<Table>? Tables { get; set; }
    }
}
