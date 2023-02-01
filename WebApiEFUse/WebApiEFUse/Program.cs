using Microsoft.EntityFrameworkCore;
using WebApiEFExample.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//defined the name of the context class to be added. In our cases it is ApplicationDbContext.
//states that we are using SQL Server as our Database Provider.
//mentions the Connection string name that we have already defined in appsettings.json.
builder.Services.AddDbContext<ApplicationContext>(options =>
options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection"),
    m=>m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));

//Binds the Concrete Class and the Interface into our Application Container.
builder.Services.AddScoped<IApplicationContext>(provider => provider.GetService<ApplicationContext>()!);
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
