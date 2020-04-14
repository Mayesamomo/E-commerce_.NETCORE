using CarWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace CarWebApp.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            //seed Genres
            modelBuilder.Entity<Manufacturer>().HasData(new Manufacturer { ManufacturerId = 1, ManufacturerName = "Mercedes", Description = "Mercedes-Benz is a German global automobile marque and a division of Daimler AG. Mercedes-Benz is known for luxury vehicles, vans, trucks, buses, coaches and ambulances. The headquarters is in Stuttgart, Baden-Württemberg. The name first appeared in 1926 under Daimler-Benz" });
            modelBuilder.Entity<Manufacturer>().HasData(new Manufacturer { ManufacturerId = 2, ManufacturerName = "Toyota", Description = "Toyota Motor Corporation is a Japanese multinational automotive manufacturer headquartered in Toyota, Aichi, Japan. In 2017, Toyota's corporate structure consisted of 364,445 employees worldwide and, as of December 2019, was the tenth-largest company in the world by revenue." });
            modelBuilder.Entity<Manufacturer>().HasData(new Manufacturer { ManufacturerId = 3, ManufacturerName = "BMW", Description = "Bayerische Motoren Werke AG, translated in English as Bavarian Motor Works, commonly referred to as BMW, is a German multinational company which produces luxury vehicles and motorcycles." });


            //seed Books
            modelBuilder.Entity<Car>().HasData(new Car
            {
                CarId = 1,
                Name = "GLB 250",
                Model = "AMG GT 63",
                Description = "the best car ",
                ImageUrl = "https://cdn.pixabay.com/photo/2018/04/10/19/44/auto-3308549_1280.jpg",
                Released = new DateTime(2020, 01, 30, 0, 0, 0),
                Instock = true,
                Price = 32800,
                ManufacturerId = 1
            });

            modelBuilder.Entity<Car>().HasData(new Car
            {
                CarId = 2,
                Name = "Camry",
                Model = "platinum Hybrid",
                Description = "one of the best out there",
                ImageUrl = "https://cdn.motor1.com/images/mgl/RRonw/s1/toyota-camry-returning-to-uk.jpg",
                Released = new DateTime(2020, 02, 15, 0, 0, 0),
                Instock = true,
                Price = 39750,
                ManufacturerId = 2
            });

            modelBuilder.Entity<Car>().HasData(new Car
            {
                CarId = 3,
                Name = "BMW 201",
                Model = "BMW 1 Series",
                Description = "another great car by BWM",
                ImageUrl = "https://www.bmw.ie/content/dam/bmw/marketIE/bmw_ie/images/medium-teaser-201-THE1.jpg",
                Released = new DateTime(2020, 03, 15, 0, 0, 0),
                Instock = true,
                Price = 31240,
                ManufacturerId = 3
            });
        }
    }
}
