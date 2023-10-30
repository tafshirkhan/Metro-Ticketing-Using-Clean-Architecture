using Metro.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.Core.Entities.metro
{
    [Table("Booking", Schema = "metro")]
    public class Booking : BaseEntity<Guid>
    {
        [Required]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
        public string Status { get; set; }
        [Required]
        public string SeatNumber { get; set; }
        [ForeignKey("TrainId")]
        public virtual Train Train { get; set; }
        [ForeignKey("PassengerId")]
        public virtual Passenger Passenger { get; set; }
        [ForeignKey("SeatId")]
        public virtual Seat Seat { get; set; }

    }
}
