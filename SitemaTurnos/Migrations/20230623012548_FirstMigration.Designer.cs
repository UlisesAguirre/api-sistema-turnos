﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SitemaTurnos.DBContext;

#nullable disable

namespace SitemaTurnos.Migrations
{
    [DbContext(typeof(UserDbContext))]
    [Migration("20230623012548_FirstMigration")]
    partial class FirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.7");

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
                            UserType = "Manager"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
