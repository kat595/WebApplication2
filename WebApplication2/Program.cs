using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using NLog.Web;
using WebApplication2;
using WebApplication2.Middleware;
using WebApplication2.Services.UserServices;
using WebApplication2.Services.TipServices;
using WebApplication2.Services.OddServices;
using WebApplication2.Services.MatchServices;
using WebApplication2.Services.LeagueServices;
using WebApplication2.Services.League_scoreServices;
using WebApplication2.Services.League_founderServices;
using WebApplication2.Services.FootballerServices;
using WebApplication2.Services.Footballer_statServices;
using WebApplication2.Services.ClubServices;
using WebApplication2.Entities;


var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TiproomDbContext>();
builder.Services.AddScoped<UserSeeder>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITipService, TipService>();
builder.Services.AddScoped<IOddService, OddService>();
builder.Services.AddScoped<IMatchService, MatchService>();
builder.Services.AddScoped<ILeagueService, LeagueService>();
builder.Services.AddScoped<ILeague_scoreService, League_scoreService>();
builder.Services.AddScoped<ILeague_founderService, League_founderService>();
builder.Services.AddScoped<IFootballerService, FootballerService>();
builder.Services.AddScoped<IFootballer_statService, Footballer_statService>();
builder.Services.AddScoped<IClubService, ClubService>();
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontEndClient", builder =>
        builder.AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins("http://localhost:4200")
    
    );
});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors("FrontEndClient");
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TipRoom API");
});

app.UseAuthorization();

app.MapControllers();

app.Run();
