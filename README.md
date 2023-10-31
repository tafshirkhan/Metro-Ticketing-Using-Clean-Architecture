# Metro-Ticketing-Using-Clean-Architecture

Metro ticketing service using clean architecture &amp; CQRS pattern

Under blank solution:
Create a new folder as src.

---

### Step - 1:

---

Under src:
Create 4 new project as Class Library:
1)Metro.Application
2)Metro.Core
3)Metro.Infrastructure
4)Shared

And Create a new project as Web API:
1)Metro.API

---

#### Step - 2:

---

Add Project References:

#Metro.Application:
=>Metro.Core.
=>Shared.

#Metro.Infrastructure:
=>Metro.Application.

#Metro.API:
=>Metro.Application.
=>Metro.Infrastructure.
=>Shared.

---

#### Step - 3:

---

Now we need to install some NuGet packages into different projects.

#Metro.Application:
Install below nuget packages:
=>AutoMapper.
=>AutoMapper.Extensions.Microsoft.DependencyInjection.
=>Dapper.
=>FluentValidation.
=>FluentValidation.DependencyInjectionExtensions.
=>MediatR.
=>MediatR.Extensions.Microsoft.DependencyInjection.
=>Microsoft.Extensions.DependencyInjection.Abstraction.
=>Newtonsoft.Json.

#Metro.Core:
Install below nuget packages:
=>Dapper.
=>Microsoft.EntityFrameworkCore.

#Metro.Infrastructure:
Install below nuget packages:
=>Dapper.
=>Microsoft.EntityFrameworkCore.
=>Microsoft.EntityFrameworkCore.Relational.
=>Microsoft.EntityFrameworkCore.SqlServer.
=>Microsoft.EntityFrameworkCore.Tools.
=>Microsoft.Extensions.Options.ConfigurationExtensions.
=>System.Data.SqlClient.

#Shared:
Install below nuget packages:
=>MediatR.
=>MediatR.Extensions.Microsoft.DependencyInjection.

#Metro.Infrastructure:
Install below nuget packages:
=>FluentValidation.AspNetCore.
=>Microsoft.EntityFrameworkCore.Design.
=>Newtonsoft.Json.

---

#### Step - 4:

---

# Working with Metro.Core:

Under Metro.Core create a new folder as #Entities.
Under #Entities create a folder as #Base which will contains the
BaseEntity.cs class:
**BaseEntity.cs**

public class BaseEntity<TKey> where TKey : struct
{
public TKey Id { get; set; }
public Guid CreatedBy { get; set; }
public DateTime CreatedDate { get; set; } = DateTime.Now;
public string AuthorizeStatus { get; set; } = "U";
public bool IsDeleted { get; set; } = false;
public Guid? AuthorizedBy { get; set; }
public DateTime? AuthorizedDate { get; set; }
public Guid? LastModifiedBy { get; set; }
public DateTime? LastModifiedDate { get; set; }
}

Under #Entities create a another folder as #metro which will contains all the required classes for our business.

---

#### Step - 5:

---

# Working with Shared:

Under #Shared create two folder as #Commands & #DTOs
Under #DTOs folder create your required folder for you business entities class:
First create a folder as #Base:
Under #Base folder create a class as

**#BaseGetResponseDTO.cs:**

namespace Shared.DTOs
{
public record BaseGetResponseDTO<TKey> where TKey : struct
{
public TKey Id { get; set; }
}
}
&

**#BasePostResponseDTO.cs:**

namespace Shared.DTOs
{
public record BasePostResponseDTO<TKey, TEntity>
where TKey : struct
where TEntity : class
{
public TKey Id { get; set; }
public bool Success { get; set; }
public string Message { get; set; }
public TEntity? Entity { get; set; }
}
}

Now next setp by step create you required folders based on the business entities and for those entity class create those classes such as:
=>CreateRequestDTO.cs
=>GetResponseDTO.cs
=>PostResponseDTO.cs
=>ListGetResponseDTO.cs
Based on the requirments create those classes for your business entity.

Under #Commands folder create your required folder for you business entities class and for those entity class create those classes such as:
=>CreateCommand.cs.
=>UpdateCommand.cs.
=>DeleteCommand.cs.

---

#### Step - 6:

---

# Working with Metro.Infrastructure:

---

As we will use #dapper so first we will need to create #dapper repositories and data acces.
For this create a new folder as #Configs under Infrastructure layer.
Under #Configs create two classes as:

**#ConnectionString.cs:**

namespace Metro.Infrastructure.Configs
{
public class ConnectionString
{
public string MetroDbConnection { get; set; }
}
}
AND

**#MetroSettings.cs:**

namespace Metro.Infrastructure.Configs;
public class MetroSettings
{
public ConnectionString? ConnectionString { get; set; }
}

Next under Infrastructure layer create a new folder as #Persistence:
Next Persistence folder create a another folder as #EfConfiguration:
Under EfConfiguration create a class as

**BaseTypeConfiguration.cs:**

using Metro.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Metro.Infrastructure.Persistence.EfConfiguration
{
public class BaseTypeConfiguration<TItem> : IEntityTypeConfiguration<TItem> where TItem : BaseEntity<Guid>
{
public virtual void Configure(EntityTypeBuilder<TItem> builder)
{
builder.HasKey(x => x.Id);
builder.Property(x => x.AuthorizeStatus).HasMaxLength(5);
builder.Property(x => x.AuthorizedBy).HasMaxLength(100);
builder.Property(x => x.CreatedBy).HasMaxLength(100);
builder.Property(x => x.LastModifiedBy).HasMaxLength(100);
}
}
}

Next step under Persistence folder create a new class as,

**DbConnector.cs:**

using Metro.Infrastructure.Configs;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Data;

namespace Metro.Infrastructure.Persistence
{
public class DbConnector
{
private readonly IConfiguration \_configuration;
private readonly MetroSettings \_settings;
protected DbConnector(IConfiguration configuration, IOptions<MetroSettings> settings)
{
\_configuration = configuration;
\_settings = settings.Value;
}

                        public IDbConnection CreateConnection()
                        {
                            string _connectionString = _settings.ConnectionString.MetroDbConnection;
                            return new SqlConnection(_connectionString);
                        }
        }

}

Next step under Persistence folder create a new class as,

**MetroDbContext.cs:**

using metros = Metro.Core.Entities.metro;
using Microsoft.EntityFrameworkCore;
using Metro.Core.Entities.metro;
using System.Reflection;

namespace Metro.Infrastructure.Persistence
{
public class MetroDbContext : DbContext
{
public MetroDbContext(DbContextOptions<MetroDbContext> options) : base(options)
{

                }
                //tables
                public DbSet<metros.Train> Trains { get; set; } = null;
                public DbSet<metros.Ticket> Tickets { get; set; } = null;
                public DbSet<metros.Seat> Seats { get; set; } = null;
                public DbSet<metros.Passenger> Passengers { get; set; } = null;
                public DbSet<metros.Booking> Bookings { get; set; } = null;
                public DbSet<metros.Transaction> Transactions { get; set; } = null;
                public DbSet<metros.BankCredential> BankCredentials { get; set; } = null;
                public DbSet<metros.User> Users { get; set; } = null;


                protected override void OnModelCreating(ModelBuilder builder)
                {
                    builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

                    var cascadeFKs = builder.Model.GetEntityTypes()
                        .SelectMany(t => t.GetForeignKeys())
                        .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

                    foreach(var fk in cascadeFKs)
                        fk.DeleteBehavior = DeleteBehavior.ClientNoAction;

                    base.OnModelCreating(builder);
                }
            }

        }

Next step under Persistence folder create a new class as,

**DbFactory.cs:**

using Microsoft.EntityFrameworkCore;

namespace Metro.Infrastructure.Persistence
{
public class DbFactory : IDisposable
{
private bool \_disposed;
private readonly Func<MetroDbContext> \_instanceFunc;
private DbContext \_dbContext;

        public DbContext DbContext => _dbContext ??= _instanceFunc.Invoke();

        public DbFactory(Func<MetroDbContext> dbContextFactory)
        {
            _instanceFunc = dbContextFactory;
        }
        public void Dispose()
        {
            if( _disposed || _dbContext == null) return;
            _disposed = true;
            _dbContext.Dispose();
        }
    }

}
Next step under Infrastructure layer create a new folder as #Repository;
Under #Repository folder create two new folder as #Command & #Query.

Under #Command folder create an another folder as #Base.
Under #Base folder create a class as:

CommadRepository.cs:

Before implementing this CommadRepository.cs class let's first do some works into #Metro.Application layer

Into the #Contracts folder of #Metro.Application layer create a new folder as #Repositories.
Under Repositories create two new folders as #Command & #Query.
Under #Command create a another folder as #Base and Base create a new interface as,

ICommandRepository.cs:

using System.Linq.Expressions;

namespace Metro.Application.Contracts.Repositories.Command.Base
{
public interface ICommandRepository<TEntity> where TEntity : class
{
/// <summary>
/// Insert data using EF
/// </summary>
/// <param name="entity"></param>
/// <returns></returns>
Task<TEntity> InsertAsync(TEntity entity);
/// <summary>
/// Insert multiple data using EF
/// </summary>
/// <param name="entity"></param>
/// <returns></returns>
Task<IEnumerable<TEntity>> InsertAsync(IEnumerable<TEntity> entity);
/// <summary>
/// Update data using EF
/// </summary>
/// <param name="entity"></param>
/// <returns></returns>
Task<TEntity> UpdateAsync(TEntity entity);
/// <summary>
/// Update Multiple data using EF
/// </summary>
/// <param name="entity"></param>
/// <returns></returns>
Task<IEnumerable<TEntity>> UpdateAsync(IEnumerable<TEntity> entity);
/// <summary>
/// Delete data using EF
/// </summary>
/// <param name="entity"></param>
/// <returns></returns>
Task DeleteAsync(TEntity entity);
/// <summary>
/// Delete multiple data using EF
/// </summary>
/// <param name="entity"></param>
/// <returns></returns>
Task DeleteAsync(IEnumerable<TEntity> entity);

        Task<TEntity> DeleteAsync(object id);
        /// <summary>
        /// Get data using EF
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(object id);
        // <summary>
        /// Get data using EF
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> FindAsync<T>(Expression<Func<TEntity, bool>> predicate) where T : class;
    }

}

Next under #Command folder create your required Interface for your business entities such as,

ITrainCommandRepository.cs:

using Metro.Application.Contracts.Repositories.Command.Base;
using Metro.Core.Entities.metro;

namespace Metro.Application.Contracts.Repositories.Command
{
public interface ITrainCommandRepository : ICommandRepository<Train>
{
}
}

Also do the same things into #Query folder.
Under #Query folder create a new folde as #Base.
Under Base create a new Interface as.

IQueryRepository.cs:

AND

IMultipleResultQueryRepository.cs:

Next under #Query folder create your required Interface for your business entities such as,

ITrainQueryRepository.cs.

Now again move into the Infrastructure layer: and implements the remaining CommadRepository:

CommadRepository.cs:

using Metro.Application.Contracts.Repositories.Command.Base;
using Metro.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Metro.Infrastructure.Repository.Command.Base
{
public class CommadRepository<TEntity> : IDisposable, ICommandRepository<TEntity> where TEntity : class
{
private readonly DbFactory \_dbFactory;
private DbSet<TEntity> \_dbSet;

        public CommadRepository(DbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        protected DbSet<TEntity> DbSet
        {
            get => _dbSet ??= _dbFactory.DbContext.Set<TEntity>();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));
            DbSet.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(IEnumerable<TEntity> entity)
        {
           if(entity==null)
                throw new ArgumentNullException(nameof(entity));
           DbSet.RemoveRange(entity);
           await Task.CompletedTask;
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));
            await DbSet.AddAsync(entity);
            return entity;

        }

        public async Task<IEnumerable<TEntity>> InsertAsync(IEnumerable<TEntity> entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));
            await DbSet.AddRangeAsync(entity);
            return entity;
        }
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));
            DbSet.Update(entity);
            await Task.CompletedTask;
            return entity;
        }

        public async Task<IEnumerable<TEntity>> UpdateAsync(IEnumerable<TEntity> entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            DbSet.UpdateRange(entity);
            await Task.CompletedTask;
            return entity;
        }

        public async Task<TEntity> DeleteAsync(object id)
        {
            if(id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var data = await DbSet.FindAsync(id);
            if(data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            DbSet.Remove(data);
            await Task.CompletedTask;
            return data;
        }

        public void Dispose()
        {
            _dbFactory.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<TEntity> GetAsync(object id)
        {
            return await DbSet.FindAsync(id);
        }
        public async Task<IEnumerable<TEntity>> FindAsync<T>(Expression<Func<TEntity, bool>> predicate) where T : class
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

    }

}

Next into the #Command folder create our required CommandRepository classes based on our business entities.
For our cases we are createing,

TrainCommandRepository.cs:

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

#### Step - 7:

---

# Working with Metro.Application:

Under Metro.Application create 4 new folder as:
=>CommandHandlers
=>Common
=>Contracts
=>Queries
