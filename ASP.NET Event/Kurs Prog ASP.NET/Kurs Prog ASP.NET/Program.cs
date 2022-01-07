using Evento.Core.Repositories;
using Evento.Infrastructure.Mappers;
using Evento.Infrastructure.Repositories;
using Evento.Infrastructure.Services;
using Evento.Infrastructure.Settings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



/*   builder.Services.AddAuthorization(auth =>
     {
         auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                 .RequireAuthenticatedUser()
                 .Build());
     });*/






System.Configuration.Configuration config =
               System.Configuration.ConfigurationManager.OpenExeConfiguration(
               ConfigurationUserLevel.None) as Configuration;

//builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("jwt"));
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddMvc().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.WriteIndented = true;
    
});
builder.Services.AddAuthorization();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IEventService,EventServices>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddSingleton<IJwtHandler,JwtHandler>();
builder.Services.AddSingleton(AutoMapperConfig.Initial());


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(o =>
    {
        IISServerOptions iISServerOptions = new IISServerOptions();
        iISServerOptions.AutomaticAuthentication = true;
        var serviceProvider = builder.Services.BuildServiceProvider();
        var JwTservice = serviceProvider.GetService<IOptions<JwtSettings>>();
        o.TokenValidationParameters = new TokenValidationParameters
        {
            
            ValidIssuer = JwTservice.Value.Issuer,
            ValidateAudience = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwTservice.Value.Key))
        };
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    



}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors();

app.UseAuthentication();

app.UseRouting();
app.UseAuthorization();


app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.UseMvc();

app.Run();

