using Microsoft.EntityFrameworkCore;
using SistemaTurnos.Data.Implementations;
using SistemaTurnos.Data.Interfaces;
using SistemaTurnos.Services.Implementations;
using SistemaTurnos.Services.Interfaces;
using SitemaTurnos.Data.Implementations;
using SitemaTurnos.Data.Interfaces;
using SitemaTurnos.DBContext;
using SitemaTurnos.Services.Implementations;
using SitemaTurnos.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Practica:

////Añadimos dbContext

builder.Services.AddDbContext<UserDbContext>(DbContextOptions =>
    DbContextOptions.UseSqlite(builder.Configuration["ConnectionStrings:UserDbConnectionString"]));

////Añadimos UserService - ReservationService
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITableService, TableService>();

//Añadimos UserRepository - ReservationRepository
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<ITableRepository, TableRepository>();
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
