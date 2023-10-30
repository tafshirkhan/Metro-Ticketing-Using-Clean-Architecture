using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Commands.Train;

public class DeleteTrainCommand :IRequest<object>
{
    public Guid Id { get; set; }
	public DeleteTrainCommand(Guid id)
	{
		Id = id;
	}
}
