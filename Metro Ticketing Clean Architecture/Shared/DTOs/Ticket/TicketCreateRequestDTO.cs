using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs.Ticket;
public record TicketCreateRequestDTO
{
    public Guid Id { get; set; }
    public Guid TicketId { get; set; }
    public Guid PassengerId { get; set; }
    public Guid BookingId { get; set; }
    public Guid TrainId { get; set; }
}
