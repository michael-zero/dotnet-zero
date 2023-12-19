using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shop;
using Shop.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var key = Encoding.ASCII.GetBytes(Settings.Secret);

    //autenticacao 
    builder.Services.AddAuthentication(x => {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x => {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true; 
        x.TokenValidationParameters = new TokenValidationParameters{
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });


builder.Services.AddResponseCompression(opt => {
    opt.Providers.Add<GzipCompressionProvider>();
    //comprime tudo que for json
    opt.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new [] {"application/json"});
});

//cache em toda aplicação
// builder.Services.AddResponseCaching();

//cors
builder.Services.AddCors();
builder.Services.AddControllers();


// builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine($"Connection String: {connectionString}");


//banco de dados
builder.Services.AddDbContext<DataContext>(opt => opt.
UseSqlServer(
    builder.Configuration
    .GetConnectionString("DefaultConnection")));

// builder.Services.AddScoped<DataContext, DataContext>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shop API V1");
    });
}

app.UseHttpsRedirection();

app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
