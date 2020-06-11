using APBD_CAMPAIGN.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;

namespace APBD_CAMPAIGN.DAL
{
    public class AdvertCampaignContext : DbContext
    {
        public AdvertCampaignContext() : base()
        {

        }

        public AdvertCampaignContext(DbContextOptions<AdvertCampaignContext> options) : base(options)
        {

        }

        public DbSet<Banner> Banner { get; set; }

        public DbSet<Building> Building { get; set; }

        public DbSet<Campaign> Campaign { get; set; }

        public DbSet<Client> Client { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Building>(entity =>
            {
                entity.HasData(new Building
                {
                    IdBuilding = 1,
                    Street = "Filtrowa",
                    StreetNumber = 1,
                    City = "Warszawa",
                    Height = 50
                });

                entity.HasData(new Building
                {
                    IdBuilding = 2,
                    Street = "Filtrowa",
                    StreetNumber = 2,
                    City = "Warszawa",
                    Height = 50
                });
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(entity => new
                {
                    entity.IdClient,
                    entity.Login,
                    entity.Email
                });

                entity.HasData(new Client
                {
                    IdClient = 1,
                    FirstName = "Klient1",
                    LastName = "Klient2",
                    Phone = "123123123",
                    Email = "klient1@klient.pl",
                    Login = "klient1_login",
                    Password = "klient1_password"
                });
            });

            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.HasData(new Campaign
                {
                    IdCampaign = 1,
                    IdClient = 1,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    FromIdBuilding = 1,
                    ToIdBuilding = 2,
                    PricePerSquareMeter = 50
                }); ;
            });

            modelBuilder.Entity<Banner>(entity =>
            {
                entity.HasData(new Banner
                {
                    IdAdvertisement = 1,
                    IdCampaign = 1,
                    Area = 50,
                    Name = 5
                });
            });
        }
    }
}
