﻿// <auto-generated />
using System;
using APBD_CAMPAIGN.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APBD_CAMPAIGN.Migrations
{
    [DbContext(typeof(AdvertCampaignContext))]
    [Migration("20200613112652_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APBD_CAMPAIGN.Models.Banner", b =>
                {
                    b.Property<int>("IdAdvertisement")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Area")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<int>("IdCampaign")
                        .HasColumnType("int");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6, 2)");

                    b.HasKey("IdAdvertisement");

                    b.HasIndex("IdCampaign");

                    b.ToTable("Banner");

                    b.HasData(
                        new
                        {
                            IdAdvertisement = 1,
                            Area = 50m,
                            IdCampaign = 1,
                            Name = 5,
                            Price = 0m
                        });
                });

            modelBuilder.Entity("APBD_CAMPAIGN.Models.Building", b =>
                {
                    b.Property<int>("IdBuilding")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<int>("StreetNumber")
                        .HasColumnType("int");

                    b.HasKey("IdBuilding");

                    b.ToTable("Building");

                    b.HasData(
                        new
                        {
                            IdBuilding = 1,
                            City = "Warszawa",
                            Street = "Filtrowa",
                            StreetNumber = 1
                        },
                        new
                        {
                            IdBuilding = 2,
                            City = "Warszawa",
                            Street = "Filtrowa",
                            StreetNumber = 2
                        });
                });

            modelBuilder.Entity("APBD_CAMPAIGN.Models.Campaign", b =>
                {
                    b.Property<int>("IdCampaign")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FromIdBuilding")
                        .HasColumnType("int");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<decimal>("PricePerSquareMeter")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ToIdBuilding")
                        .HasColumnType("int");

                    b.HasKey("IdCampaign");

                    b.HasIndex("FromIdBuilding");

                    b.HasIndex("IdClient");

                    b.HasIndex("ToIdBuilding");

                    b.ToTable("Campaign");

                    b.HasData(
                        new
                        {
                            IdCampaign = 1,
                            EndDate = new DateTime(2020, 6, 13, 13, 26, 51, 601, DateTimeKind.Local).AddTicks(252),
                            FromIdBuilding = 1,
                            IdClient = 1,
                            PricePerSquareMeter = 50m,
                            StartDate = new DateTime(2020, 6, 13, 13, 26, 51, 593, DateTimeKind.Local).AddTicks(8025),
                            ToIdBuilding = 2
                        });
                });

            modelBuilder.Entity("APBD_CAMPAIGN.Models.Client", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdClient");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("Login")
                        .IsUnique()
                        .HasFilter("[Login] IS NOT NULL");

                    b.ToTable("Client");

                    b.HasData(
                        new
                        {
                            IdClient = 1,
                            Email = "klient1@klient.pl",
                            FirstName = "Klient1",
                            LastName = "Klient2",
                            Login = "klient1_login",
                            Password = "klient1_password",
                            Phone = "123123123"
                        });
                });

            modelBuilder.Entity("APBD_CAMPAIGN.Models.Banner", b =>
                {
                    b.HasOne("APBD_CAMPAIGN.Models.Campaign", "Campaign")
                        .WithMany("Banners")
                        .HasForeignKey("IdCampaign")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("APBD_CAMPAIGN.Models.Campaign", b =>
                {
                    b.HasOne("APBD_CAMPAIGN.Models.Building", "FromBuilding")
                        .WithMany("FromBuildings")
                        .HasForeignKey("FromIdBuilding")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APBD_CAMPAIGN.Models.Client", "Client")
                        .WithMany("Campaigns")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APBD_CAMPAIGN.Models.Building", "ToBuilding")
                        .WithMany("ToBuildings")
                        .HasForeignKey("ToIdBuilding")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
