using Microsoft.AspNetCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Projekt1.Interface;
using Projekt1.Repository;
using Projekt1.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy", builder =>
    {
        builder.AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins("http://localhost:3000", "https://appname.azurestaticapps.net");
    });

});


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEventService, EventService>();

builder.Services.AddAuthentication()
    .AddCookie(opt =>
    {
        opt.LoginPath = "/account/google";
    })
    .AddGoogle(googleOptions =>
{
    googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
    googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CORSPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();

