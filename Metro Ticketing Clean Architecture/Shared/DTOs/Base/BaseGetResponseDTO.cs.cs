using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs.Base
{
    public record BaseGetResponseDTO<TKey> where TKey : struct
    {
        public TKey Id { get; set; }
    }
}
