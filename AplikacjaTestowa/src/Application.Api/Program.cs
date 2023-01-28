using Application.Core.Repository;
using Application.Infrastructure.Mappers;
using Application.Infrastructure.Repositories;
using Application.Infrastructure.Services;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddScoped<IEventRepository, EventRepository>();
services.AddScoped<IEventService, EventService>();

services.AddScoped<IUserRepository, UserRepository>();
//services.AddScoped<IUserService, UserService>();
services.AddSingleton(AutoMapperConfig.Initialzie());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
