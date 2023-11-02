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
   
    public class Seat : BaseEntity<Guid>
    {
        [ForeignKey("TrainId")]
        public virtual Train Train { get; set; }
        [Required]
        public int TotalSeat { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public double SeatFare { get; set; }
    }
}
