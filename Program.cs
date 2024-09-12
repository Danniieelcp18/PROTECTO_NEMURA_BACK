
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using PROYECTO_NEMURA.DataBase;

var builder = WebApplication.CreateBuilder(args);


// conexion con la base de datos
Env.Load();
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
var dbDatabaseName = Environment.GetEnvironmentVariable("DB_DATABASE");
var dbUser = Environment.GetEnvironmentVariable("DB_USERNAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

var mySqlConnection = $"server={dbHost};port={dbPort};database={dbDatabaseName};uid={dbUser};password={dbPassword}";
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(mySqlConnection, ServerVersion.Parse("8.0.20-mysql")));

builder.Services.AddCors(options =>
{
options.AddPolicy("AllowSpecificOrigin",
    builder =>
    {
        builder.WithOrigins("http://127.0.0.1:5173", "http://localhost:5173")
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials();
    });
});
/* 
builder.Services.AddControllersWithViews(); */

// Add services to the container.

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
/* 
app.UseHttpsRedirection(); */
app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
