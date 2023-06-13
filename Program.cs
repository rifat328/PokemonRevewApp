using Microsoft.EntityFrameworkCore;
using PokemonRevewApp;
using PokemonRevewApp.Data;
using PokemonRevewApp.Interfaces;
using PokemonRevewApp.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// inject seed 
builder.Services.AddTransient<Seed>();
builder.Services.AddScoped<IPokemonRepository,PokemonRepository>();
// pulled back and loaded connection string from appsettings.json file 
builder.Services.AddDbContext<DataContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);
void SeedData(IHost app)
{
    var scopedFactor = app.Services.GetService<IServiceScopeFactory>();
    
    using(var scope= scopedFactor.CreateScope())
    {
        var service=scope.ServiceProvider.GetService<Seed> ();
        service.SeedDataContext();
    }
}
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
