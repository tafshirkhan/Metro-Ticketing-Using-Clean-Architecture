using Metro.Application.Contracts;
using Metro.Application.Contracts.Repositories;
using Metro.Application.Contracts.Repositories.Command.Base;
using Metro.Application.Contracts.Repositories.Query.Base;
using Metro.Infrastructure.Configs;
using Metro.Infrastructure.Persistence;
using Metro.Infrastructure.Repository;
using Metro.Infrastructure.Repository.Command.Base;
using Metro.Infrastructure.Repository.Query.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MetroSettings>(configuration);
            var serviceProvider = services.BuildServiceProvider();
            var opt = serviceProvider.GetRequiredService<IOptions<MetroSettings>>().Value;
            
            //For SQLServer Connection
            services.AddDbContext<MetroDbContext>(options =>
            {
                //options.UseSqlServer(opt.ConnectionString.MetroDbConnection, sqlServerOptionsAction: sqlOptions =>
                //{ 

                //});
                options.UseSqlServer(configuration.GetConnectionString("MetroDbConnection"), sqlServerOptionsAction: sqlOptions =>
                {

                });
            });
            services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
            services.AddScoped(typeof(IMultipleResultQueryRepository<>), typeof(MultipleResultQueryRepository<>));
            services.AddScoped(typeof(ICommandRepository<>), typeof(CommadRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<Func<MetroDbContext>>((provider) => provider.GetService<MetroDbContext>);
            services.AddScoped<DbFactory>();
            services.AddRepositories();
            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services;
        }
    }
}
