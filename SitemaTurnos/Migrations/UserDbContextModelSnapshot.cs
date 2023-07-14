﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SitemaTurnos.DBContext;

#nullable disable

namespace SistemaTurnos.Migrations
{
    [DbContext(typeof(UserDbContext))]
    partial class UserDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("SitemaTurnos.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateReservation")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumOfPeople")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ReservStatus")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TableId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("turn")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TableId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateReservation = new DateTime(2023, 7, 14, 22, 53, 33, 599, DateTimeKind.Local).AddTicks(5425),
                            NumOfPeople = 2,
                            ReservStatus = 1,
                            TableId = 1,
                            UserId = 1,
                            turn = 0
                        },
                        new
                        {
                            Id = 2,
                            DateReservation = new DateTime(2023, 7, 15, 22, 53, 33, 599, DateTimeKind.Local).AddTicks(5447),
                            NumOfPeople = 4,
                            ReservStatus = 1,
                            TableId = 2,
                            UserId = 2,
                            turn = 1
                        },
                        new
                        {
                            Id = 3,
                            DateReservation = new DateTime(2023, 7, 16, 22, 53, 33, 599, DateTimeKind.Local).AddTicks(5450),
                            NumOfPeople = 3,
                            ReservStatus = 1,
                            TableId = 3,
                            UserId = 3,
                            turn = 2
                        },
                        new
                        {
                            Id = 4,
                            DateReservation = new DateTime(2023, 7, 17, 22, 53, 33, 599, DateTimeKind.Local).AddTicks(5452),
                            NumOfPeople = 6,
                            ReservStatus = 1,
                            TableId = 4,
                            UserId = 4,
                            turn = 0
                        });
                });

            modelBuilder.Entity("SitemaTurnos.Entities.Restaurant", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Endhour")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumberOfTable")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Phone")
                        .HasColumnType("REAL");

                    b.Property<int>("ReservDuration")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Starthour")
                        .HasColumnType("INTEGER");

                    b.Property<int>("availableTables")
                        .HasColumnType("INTEGER");

                    b.HasKey("Name");

                    b.ToTable("Restaurant");

                    b.HasData(
                        new
                        {
                            Name = "Pizzeria Paradiso",
                            Adress = "paradiso@gmail.com",
                            Endhour = 0,
                            NumberOfTable = 15,
                            Phone = 3415122334.0,
                            ReservDuration = 2,
                            Starthour = 18,
                            availableTables = 0
                        });
                });

            modelBuilder.Entity("SitemaTurnos.Entities.TableRestaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("TablesRestaurant");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capacity = 4
                        },
                        new
                        {
                            Id = 2,
                            Capacity = 3
                        },
                        new
                        {
                            Id = 3,
                            Capacity = 2
                        },
                        new
                        {
                            Id = 4,
                            Capacity = 1
                        });
                });

            modelBuilder.Entity("SitemaTurnos.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "john.doe@example.com",
                            LastName = "Doe",
                            Name = "John",
                            Password = "1234",
                            UserType = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Email = "emma.smith@example.com",
                            LastName = "Smith",
                            Name = "Emma",
                            Password = "1234",
                            UserType = "Client"
                        },
                        new
                        {
                            Id = 3,
                            Email = "michael.johnson@example.com",
                            LastName = "Johnson",
                            Name = "Michael",
                            Password = "1234",
                            UserType = "Client"
                        },
                        new
                        {
                            Id = 4,
                            Email = "sophia.brown@example.com",
                            LastName = "Brown",
                            Name = "Sophia",
                            Password = "1234",
                            UserType = "Admin"
                        },
                        new
                        {
                            Id = 5,
                            Email = "robert.lee@example.com",
                            LastName = "Lee",
                            Name = "Robert",
                            Password = "1234",
                            UserType = "Client"
                        },
                        new
                        {
                            Id = 6,
                            Email = "admin@gmail.com",
                            LastName = "principal",
                            Name = "admin",
                            Password = "1234",
                            UserType = "Admin"
                        },
                        new
                        {
                            Id = 7,
                            Email = "client@example.com",
                            LastName = "principal",
                            Name = "cliente",
                            Password = "1234",
                            UserType = "Client"
                        });
                });

            modelBuilder.Entity("SitemaTurnos.Entities.Reservation", b =>
                {
                    b.HasOne("SitemaTurnos.Entities.TableRestaurant", "Table")
                        .WithMany("Reservations")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SitemaTurnos.Entities.User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Table");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SitemaTurnos.Entities.TableRestaurant", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("SitemaTurnos.Entities.User", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
