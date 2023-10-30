using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.Core.Entities.external
{
    public class Report
    {
        public Guid PassengerId { get; set; }
        public string PassengerName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public Guid BookingId { get; set; }
        public double SeatFare { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string SeatNum { get; set; }
    }
}
