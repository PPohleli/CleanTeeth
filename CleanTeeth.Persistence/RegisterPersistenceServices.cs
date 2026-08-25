using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Persistence
{
    public static class RegisterPersistenceServices
    {

        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<CleanTeethDbContext>(options => options.UseSqlServer("name=CleanTeethConnectionString"));

            return services;
        }
    }
}
