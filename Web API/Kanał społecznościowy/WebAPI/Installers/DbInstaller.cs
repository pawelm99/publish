using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Installers
{
    public class DbInstaller : IInstaller
    {
        

        public void InstallServices(IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<MovieContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("MoviesCS")));
        }
    }
}
