using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using SistemaTurnos.Enums;
using SitemaTurnos.Entities;
using SitemaTurnos.Enums;

namespace SitemaTurnos.DBContext
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<TableRestaurant> TablesRestaurant { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Table)
                .WithMany(m => m.Reservations)
                .HasForeignKey(r => r.TableId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant
                {
                    NumberOfTable = 15,
                    Name = "Pizzeria Paradiso",
                    Adress = "paradiso@gmail.com",
                    Phone = 3415122334,
                    Starthour = 18,
                    Endhour = 0,
                    ReservDuration = 2
                });

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    Password = "1234",
                    UserType = "Admin"
                },
                new User
                {
                    Id = 2,
                    Name = "Emma",
                    LastName = "Smith",
                    Email = "emma.smith@example.com",
                    Password = "1234",
                    UserType = "Client"
                },
                new User
                {
                    Id = 3,
                    Name = "Michael",
                    LastName = "Johnson",
                    Email = "michael.johnson@example.com",
                    Password = "1234",
                    UserType = "Client"
                },
                new User
                {
                    Id = 4,
                    Name = "Sophia",
                    LastName = "Brown",
                    Email = "sophia.brown@example.com",
                    Password = "1234",
                    UserType = "Admin"
                },
                new User
                {
                    Id = 5,
                    Name = "Robert",
                    LastName = "Lee",
                    Email = "robert.lee@example.com",
                    Password = "1234",
                    UserType = "Client"
                },
                new User
                {
                    Id = 6,
                    Name = "admin",
                    LastName = "principal",
                    Email = "admin@gmail.com",
                    Password = "1234",
                    UserType = "Admin"
                },
                new User
                {
                    Id = 7,
                    Name = "cliente",
                    LastName = "principal",
                    Email = "client@example.com",
                    Password = "1234",
                    UserType = "Client"
                });

            modelBuilder.Entity<Reservation>().HasData(
                new Reservation
                   {
                   Id = 1,
                   DateReservation = DateTime.Now.AddDays(1),
                   NumOfPeople = 2,
                   ReservStatus = Disponibility.Reservado,
                   turn = Turns.Turn18,
                   TableId = 1,
                   UserId = 1
                },
                new Reservation
                {
                    Id = 2,
                    DateReservation = DateTime.Now.AddDays(2),
                    NumOfPeople = 4,
                    ReservStatus = Disponibility.Reservado,
                    turn = Turns.Turn20,
                    TableId = 2,
                    UserId = 2
                },
                new Reservation
                {
                    Id = 3,
                    DateReservation = DateTime.Now.AddDays(3),
                    NumOfPeople = 3,
                    ReservStatus = Disponibility.Reservado,
                    turn = Turns.Turn22,
                    TableId = 3,
                    UserId = 3
                },
                new Reservation
                {
                    Id = 4,
                    DateReservation = DateTime.Now.AddDays(4),
                    NumOfPeople = 6,
                    ReservStatus = Disponibility.Reservado,
                    turn = Turns.Turn18,
                    TableId = 4,
                    UserId = 4
                }
            );

            modelBuilder.Entity<TableRestaurant>().HasData(
                new TableRestaurant
                { 
                    Id = 1,
                    Capacity = 4,
                },
                new TableRestaurant 
                { 
                    Id = 2,
                    Capacity = 3,
                },
                new TableRestaurant
                { 
                    Id = 3,
                    Capacity = 2,
                },
                new TableRestaurant
                { 
                    Id = 4,
                    Capacity = 1
                }
            );

            base.OnModelCreating(modelBuilder);
        }

    }
}
