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
    [Table("Ticket", Schema = "metro")]
    public class Ticket : BaseEntity<Guid>
    {
        [Required]
        public Guid TicketId { get; set; }
        [ForeignKey("PassengerId")]
        public virtual Passenger Passenger { get; set; }
        [ForeignKey("BookingId")]
        public virtual Booking Booking { get; set; }
        [ForeignKey("TrainId")]
        public virtual Train Train { get; set; }
    }
}
