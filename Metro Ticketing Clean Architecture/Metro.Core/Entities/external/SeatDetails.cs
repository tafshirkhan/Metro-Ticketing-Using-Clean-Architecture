using Metro.Core.Entities.metro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.Core.Entities.external
{
    public class SeatDetails
    {
        public virtual Seat Seat { get; set; }
        public virtual Train Train { get; set; }
        public int Total { get; set; }
    }
}
