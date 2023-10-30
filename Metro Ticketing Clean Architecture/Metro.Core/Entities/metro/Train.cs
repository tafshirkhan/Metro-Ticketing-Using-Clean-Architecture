using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metro.Core.Entities.Base;

namespace Metro.Core.Entities.metro
{
    [Table("Train", Schema = "metro")]
    public class Train : BaseEntity<Guid>
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public string ArrivalTime { get; set; }
        [Required]
        public string DepartureTime { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime ArrivalDate { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime DepartureDate { get; set; }
        [Required]
        [MaxLength(30)]
        public string ArrivalStation { get; set; }
        [Required]
        [MaxLength(30)]
        public string DepartureStation { get; set; }
        [Required]
        [MaxLength(30)]
        public double Distance { get; set; }
        [Required]
        public bool isActive { get; set; }
        //public ICollection<Seat> seats { get; set; }
    }
}
