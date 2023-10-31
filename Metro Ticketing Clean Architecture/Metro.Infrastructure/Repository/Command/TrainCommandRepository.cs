using Metro.Application.Contracts.Repositories.Command;
using Metro.Core.Entities.metro;
using Metro.Infrastructure.Persistence;
using Metro.Infrastructure.Repository.Command.Base;

namespace Metro.Infrastructure.Repository.Command;

public class TrainCommandRepository : CommadRepository<Train>, ITrainCommandRepository
{
    public TrainCommandRepository(DbFactory dbFactory) : base(dbFactory)
    {
    }
}
