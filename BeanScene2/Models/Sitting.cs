using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeanScene2.Models
{
    public class Sitting
    {
        [Key]
        [Display(Name = "Sitting ID")]

        public int SittingId { get; set; }
        [Display(Name = "Sitting Type")]

        public string SittingType { get; set; }

        //Relationships
        
        public List<Reservation>? Reservations { get; set; }
    }
}
