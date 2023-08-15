using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserSupportSystem.Data.DB;
using UserSupportSystem.Data.Engines;
using UserSupportSystem.Data.Engines.Interfaces;

namespace UserSupportSystem.Data
{
    public static class DataServiceConfiguration
    {
        public static void ConfigureDataHelper(this IServiceCollection serviceCollection,IConfiguration Configuration)
        {
            serviceCollection.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Connection")));
            serviceCollection.AddScoped<IRequestEngine, RequestEngine>();
        }
    }
}
