using Bookstore.Databases;
using Bookstore.Repositories;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database Connection
string connection = builder.Configuration.GetConnectionString("mysqldbcredential");
builder.Services.AddDbContextPool<MySQLDatabase>(options =>
    options.UseMySql(connection, ServerVersion.AutoDetect(connection)));

builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<BookRepository>();
builder.Services.AddScoped<CourseRepository>();
builder.Services.AddScoped<TransactionRepository>();

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