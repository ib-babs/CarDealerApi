using CarDealerApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//Console.WriteLine(builder.Configuration.GetSection("CarDbConnection"));
// Add services to the container.
builder.Services.AddDbContext<CarDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["ConnectionString:CarDbConnection"]);
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
