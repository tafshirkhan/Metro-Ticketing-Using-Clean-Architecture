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
