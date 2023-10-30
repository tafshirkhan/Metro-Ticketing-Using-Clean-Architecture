using Shared.DTOs.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs.Ticket;

public record TicketGetResponseDTO : BaseGetResponseDTO<Guid>
{
    public Guid TicketId { get; set; }
    public Guid PassengerId { get; set; }
    public string PassengerName { get; set; }
    public Guid BookingId { get; set; }
    public Guid TrainId { get; set; }
    public string TrainName { get; set; }
}

