using Metro.Core.Entities.Base;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.Core.Entities.metro
{
    [Table("Transaction", Schema = "metro")]
    public class Transaction : BaseEntity<Guid>
    {
        [ForeignKey("BookingId")]
        public virtual Booking Booking { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public double TotalFare { get; set; }
        public string TransactionStatus { get; set; }
        public ICollection<Ticket> Tickets { get; set; } = null;
    }
}
