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
    [Table("BankCredential", Schema = "metro")]
    public class BankCredential : BaseEntity<Guid>
    {
        [Required]
        [MaxLength(30)]
        public string BankName { get; set; }
        [Required]
        [MaxLength(17)]
        public string CardNumber { get; set; }
        public bool isActive { get; set; }
    }
}
