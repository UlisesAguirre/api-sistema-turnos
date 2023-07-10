using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using SitemaTurnos.Entities;
using SitemaTurnos.Enums;

namespace SitemaTurnos.DBContext
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<TableRestaurant> TablesRestaurant { get; set; }
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                    UserType = "Manager"
                });

            modelBuilder.Entity<Reservation>().HasData(
                new Reservation
                   {
                   Id = 1,
                   DateReservation = DateTime.Now.AddDays(1),
                   NumOfPeople = 2,
                   ReservStatus = Disponibility.Reservado,
                   IdTable = 1,
                   IdClient = 1
                },
                new Reservation
                {
                    Id = 2,
                    DateReservation = DateTime.Now.AddDays(2),
                    NumOfPeople = 4,
                    ReservStatus = Disponibility.Reservado,
                    IdTable = 2,
                    IdClient = 2
                },
                new Reservation
                {
                    Id = 3,
                    DateReservation = DateTime.Now.AddDays(3),
                    NumOfPeople = 3,
                    ReservStatus = Disponibility.Reservado,
                    IdTable = 3,
                    IdClient = 3
                },
                new Reservation
                {
                    Id = 4,
                    DateReservation = DateTime.Now.AddDays(4),
                    NumOfPeople = 6,
                    ReservStatus = Disponibility.Reservado,
                    IdTable = 4,
                    IdClient = 4
                }
            );

            modelBuilder.Entity<TableRestaurant>().HasData(
                new TableRestaurant
                { 
                    Id = 1,
                    Capacity = 4,
                    Disponibility = Disponibility.Disponible
                },
                new TableRestaurant 
                { 
                    Id = 2,
                    Capacity = 3,
                    Disponibility = Disponibility.Cancelado
                },
                new TableRestaurant
                { 
                    Id = 3,
                    Capacity = 2,
                    Disponibility = Disponibility.Reservado
                },
                new TableRestaurant
                { 
                    Id = 4,
                    Capacity = 1,
                    Disponibility = Disponibility.Cancelado
                }
            );

            modelBuilder.Entity<Reservation>()
                .HasMany(x => x.Users)
                .WithMany(x => x.ReservationsDone)
                .UsingEntity(j => j
                    .ToTable("UsersReservations")
                    .HasData(new[]
                        {
                            new { UsersId = 1, ReservationsDoneId = 1},
                            new { UsersId = 1, ReservationsDoneId = 2},
                            new { UsersId = 4, ReservationsDoneId = 3},

                        }
                    ));

            modelBuilder.Entity<Reservation>()
                .HasMany(x => x.TablesRestaurant)
                .WithMany(x => x.ReservationsAssigned)
                .UsingEntity(j => j
                    .ToTable("TablesReservation")
                    .HasData(new[]
                        {
                            new { TablesRestaurantId = 1, ReservationsAssignedId = 1},
                            new { TablesRestaurantId = 1, ReservationsAssignedId = 2},
                            new { TablesRestaurantId = 2, ReservationsAssignedId = 3},

                        }
                    ));

            base.OnModelCreating(modelBuilder);
        }

    }
}
