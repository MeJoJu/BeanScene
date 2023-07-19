using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeanScene2.Models
{
    public class Table
    {
        [Key]
        [Display(Name = "Table ID")]

        public int TableId { get; set; }
        [Display(Name = "Table Name")]

        public string TableName { get; set; }

        //Relationships

        public int AreaId { get; set; }
        [ForeignKey("AreaId")]
        public Area? Area { get; set; }
        public List<Reservation>? Reservations { get; set; }

    }
}
