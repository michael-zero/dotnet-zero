using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Shop;
using Shop.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var key = Encoding.ASCII.GetBytes(Settings.Secret);

//autenticacao 
builder.Services.AddAuthentication(x => {
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
});

builder.Services.AddControllers();


// builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine($"Connection String: {connectionString}");



builder.Services.AddDbContext<DataContext>(opt => opt.
UseSqlServer(
    builder.Configuration
    .GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<DataContext, DataContext>();

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
