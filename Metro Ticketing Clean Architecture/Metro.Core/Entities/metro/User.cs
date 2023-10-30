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
    [Table("User", Schema = "metro")]
    public class User : BaseEntity<Guid>
    {
        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
        [Required]
        [MaxLength(12)]
        public string Mobile { get; set; }
        [Required]
        [MaxLength(20)]
        public string Password { get; set; }
        [Required]
        [MaxLength(10)]
        public string Role { get; set; }
        //public virtual ICollection<BankCredential> BankCredential { get; set; } = null;
        //public virtual ICollection<Ticket> Tickets { get; set; } = null;
    }
}
