using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonsApp.Application.Contracts.Persistance;
using PersonsApp.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsApp.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PersonsAppDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("PersonsAppDb")));

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonConnectionRepository, PersonConnectionRepository>();
            services.AddScoped<IPhoneNumberRepository, PhoneNumberRepository>();

            return services;
        }
    }
}
