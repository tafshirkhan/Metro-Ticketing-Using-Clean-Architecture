using Metro.Application.Contracts.Repositories.Command.Base;
using Metro.Core.Entities.metro;

namespace Metro.Application.Contracts.Repositories.Command
{
    public interface ITrainCommandRepository : ICommandRepository<Train>
    {
    }
}
