using kolokwium2.Data;
using kolokwium2.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add controllers functionality
builder.Services.AddControllers();
// Dependency injection for AnimalsRepository
builder.Services.AddScoped<IDataService,DataService>();
builder.Services.AddDbContext<DataContext>(
    options => options.UseSqlServer("Name=ConnectionStrings:Default"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

