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
    [Table("Passenger", Schema = "metro")]
    public class Passenger : BaseEntity<Guid>
    {
        [Required]
        public Guid PassengerId { get; set; }
        [Required]
        [MaxLength(30)]
        public string PassengerName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [MaxLength(10)]
        public string Gender { get; set; }
    }
}
