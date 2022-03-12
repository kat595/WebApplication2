using System.Reflection;
using WebApplication2;
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

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
