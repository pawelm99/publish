using Application;
using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using AutoMapper.Configuration;
using Domain.Interfaction;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Installers
{
    public class MvcInstaller : IInstaller
    {
      
        public void InstallServices(IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            services.AddAplication();
            services.AddInfrastructure();
            services.AddControllers();
        }
    }
}
