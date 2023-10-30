using Metro.Core.Entities.Base;
using Metro.Core.Entities.metro;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.Core.Entities.external
{
    public class TicketDetails : BaseEntity<Guid>
    {
        public virtual Booking Booking { get; set; }
        public virtual Train Train { get; set; }
        public virtual Passenger Passenger { get; set; }
        public string Status { get; set; }
        public string SeatNumber { get; set; }

    }
}
