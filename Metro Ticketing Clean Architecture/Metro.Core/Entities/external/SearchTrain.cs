using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metro.Core.Entities.metro;

namespace Metro.Core.Entities.external
{
    public class SearchTrain
    {
        public virtual Train Train { get; set; }
        public string ArrivalTime { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalStation { get; set; }
        public string DepartureStation { get; set; }
    }
}
