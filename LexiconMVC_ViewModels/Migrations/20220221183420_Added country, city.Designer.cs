﻿// <auto-generated />
using System;
using LexiconMVC_ViewModels.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LexiconMVC_ViewModels.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220221183420_Added country, city")]
    partial class Addedcountrycity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LexiconMVC_ViewModels.Models.City", b =>
                {
                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CityName");

                    b.HasIndex("CountryName");

                    b.ToTable("City");

                    b.HasData(
                        new
                        {
                            CityName = "Bangkok"
                        },
                        new
                        {
                            CityName = "Berlin"
                        },
                        new
                        {
                            CityName = "Bangalore"
                        });
                });

            modelBuilder.Entity("LexiconMVC_ViewModels.Models.Country", b =>
                {
                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CountryName");

                    b.ToTable("Country");

                    b.HasData(
                        new
                        {
                            CountryName = "Bangladesh"
                        },
                        new
                        {
                            CountryName = "Baharain"
                        },
                        new
                        {
                            CountryName = "Spain"
                        });
                });

            modelBuilder.Entity("LexiconMVC_ViewModels.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Edited")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityName");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            Id = 666,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Edited = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Doggy Dog",
                            PhoneNumber = "12345-7899"
                        },
                        new
                        {
                            Id = 999,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Edited = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Kalle Kanin",
                            PhoneNumber = "12345-7585"
                        },
                        new
                        {
                            Id = 123,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Edited = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Hasse Hare",
                            PhoneNumber = "12345-8522"
                        });
                });

            modelBuilder.Entity("LexiconMVC_ViewModels.Models.City", b =>
                {
                    b.HasOne("LexiconMVC_ViewModels.Models.Country", null)
                        .WithMany("Cities")
                        .HasForeignKey("CountryName");
                });

            modelBuilder.Entity("LexiconMVC_ViewModels.Models.Person", b =>
                {
                    b.HasOne("LexiconMVC_ViewModels.Models.City", "City")
                        .WithMany("People")
                        .HasForeignKey("CityName");
                });
#pragma warning restore 612, 618
        }
    }
}
