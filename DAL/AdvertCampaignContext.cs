using APBD_CAMPAIGN.Models;
using Microsoft.EntityFrameworkCore;
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

            var building1 = new Building
            {
                IdBuilding = 1,
                Street = "Filtrowa",
                StreetNumber = 1,
                City = "Warszawa",
                Height = 50
            };

            var building2 = new Building
            {
                IdBuilding = 2,
                Street = "Filtrowa",
                StreetNumber = 2,
                City = "Warszawa",
                Height = 50
            };

            var client = new Client
            {
                IdClient = 1,
                FirstName = "Klient1",
                LastName = "Klient2",
                Phone = "123123123",
                Email = "klient1@klient.pl",
                Login = "klient1_login",
                Password = "klient1_password"
            };

            var campaign = new Campaign
            {
                IdCampaign = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                PricePerSquareMeter = 50,
                IdClient = client.IdClient,
                FromIdBuilding = building1.IdBuilding,
                ToIdBuilding = building2.IdBuilding
            };

            var banner = new Banner
            {
                IdAdvertisement = 1,
                IdCampaign = campaign.IdCampaign,
                Area = 50,
                Name = 5
            };

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasIndex(entity => entity.Email).IsUnique();
                entity.HasIndex(entity => entity.Login).IsUnique();

                entity.HasData(client);
            });

            modelBuilder.Entity<Building>(entity =>
            {
                entity.HasData(building1);
                entity.HasData(building2);
            });

            modelBuilder.Entity<Banner>(entity =>
            {
                entity.HasData(banner);
            });


            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.HasData(campaign);
            });
        }
    }
}
