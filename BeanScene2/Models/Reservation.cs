using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeanScene2.Models
{
    public class Reservation
    {
        [Key]
        [Display(Name = "Reservation ID")]

        public int ReservationId { get; set; }
        [Display(Name = "Sitting Date")]

        public DateTime SittingDate { get; set; }
        [Display(Name = "Start Time")]

        public DateTime StartTime { get; set; }
        [Display(Name = "End Time")]

        public DateTime EndTIme { get; set; }
        [Display(Name = "Number of Guest")]

        public int NumberOfGuest { get; set; }
        [Display(Name = "Reservation Status")]

        public string ReservationStatus { get; set; }

        //Relationships
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }

        public int SittingId { get; set; }
        [ForeignKey("SittingId")]
        public Sitting? Sitting { get; set; }

        public int TableId { get; set; }
        [ForeignKey("TableId")]
        public Table? Table { get; set; }

    }
}
