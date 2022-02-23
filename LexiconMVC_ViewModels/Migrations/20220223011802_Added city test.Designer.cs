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
    [Migration("20220223011802_Added city test")]
    partial class Addedcitytest
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
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.HasKey("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("City");

                    b.HasData(
                        new
                        {
                            CityId = 7,
                            CityName = "Bangkok"
                        },
                        new
                        {
                            CityId = 8,
                            CityName = "Berlin"
                        },
                        new
                        {
                            CityId = 9,
                            CityName = "Bangalore"
                        });
                });

            modelBuilder.Entity("LexiconMVC_ViewModels.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Country");

                    b.HasData(
                        new
                        {
                            CountryId = 117,
                            CountryName = "Bangladesh"
                        },
                        new
                        {
                            CountryId = 118,
                            CountryName = "Baharain"
                        },
                        new
                        {
                            CountryId = 119,
                            CountryName = "Spain"
                        });
                });

            modelBuilder.Entity("LexiconMVC_ViewModels.Models.Language", b =>
                {
                    b.Property<int>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LanguageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("LanguageId");

                    b.ToTable("Language");

                    b.HasData(
                        new
                        {
                            LanguageId = 123,
                            LanguageName = "Chinese",
                            PersonId = 0
                        },
                        new
                        {
                            LanguageId = 124,
                            LanguageName = "Portuguese",
                            PersonId = 0
                        },
                        new
                        {
                            LanguageId = 125,
                            LanguageName = "Spanish",
                            PersonId = 0
                        },
                        new
                        {
                            LanguageId = 126,
                            LanguageName = "Finnish",
                            PersonId = 0
                        },
                        new
                        {
                            LanguageId = 127,
                            LanguageName = "Esperanto",
                            PersonId = 0
                        });
                });

            modelBuilder.Entity("LexiconMVC_ViewModels.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CurrentCityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Edited")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CurrentCityId");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            Id = 666,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrentCityId = 7,
                            Edited = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Doggy Dog",
                            PhoneNumber = "12345-7899"
                        },
                        new
                        {
                            Id = 999,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrentCityId = 8,
                            Edited = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Kalle Kanin",
                            PhoneNumber = "12345-7585"
                        },
                        new
                        {
                            Id = 123,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrentCityId = 9,
                            Edited = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Hasse Hare",
                            PhoneNumber = "12345-8522"
                        });
                });

            modelBuilder.Entity("LexiconMVC_ViewModels.Models.PersonLanguage", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.HasKey("PersonId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("PersonLanguage");
                });

            modelBuilder.Entity("LexiconMVC_ViewModels.Models.City", b =>
                {
                    b.HasOne("LexiconMVC_ViewModels.Models.Country", null)
                        .WithMany("Cities")
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("LexiconMVC_ViewModels.Models.Person", b =>
                {
                    b.HasOne("LexiconMVC_ViewModels.Models.City", "City")
                        .WithMany("People")
                        .HasForeignKey("CurrentCityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LexiconMVC_ViewModels.Models.PersonLanguage", b =>
                {
                    b.HasOne("LexiconMVC_ViewModels.Models.Language", "Language")
                        .WithMany("People")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LexiconMVC_ViewModels.Models.Person", "Person")
                        .WithMany("Languages")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
