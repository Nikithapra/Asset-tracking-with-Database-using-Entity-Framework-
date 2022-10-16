
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using entity_example;
//creating obj for DBcontext

namespace entity_example
{
    public class MyDBContext : DbContext
    {
       // creating Table for Asset
        public DbSet<Asset> Assetnew1 { get; set; }
        //Connection string to connect to database
        string connectionString = " Server = (localdb)\\MSSQLLocalDB;Database=Employee";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             // We tell the app to use the connectionstring.
           optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //uncomment to load text data
            modelBuilder.Entity<Asset>().HasData(new Asset
            {
                Id = 2,
                Ptype = "Mobile",
                PBrand = "Samsung",
                PModel = "S10",
                POffices = "Spain",
                PPurcdate = DateTime.Parse("2020-05-02"),

                PPrice = 6000,
                PCurrency = "EUR",
                locPrice = 6179,
            }); ;

            modelBuilder.Entity<Asset>().HasData(new Asset
            {
                Id=3,
                Ptype = "Mobile",
                PBrand = "Iphone",
                PModel = "I20",
                POffices = "Spain",
                PPurcdate = DateTime.Parse("3-11-2019"),
                PPrice = 4000,
                PCurrency = "EUR",
                locPrice = 4030,
            });

            modelBuilder.Entity<Asset>().HasData(new Asset
            {
                Id=4,
                Ptype = "Computer",
                PBrand = "Azure",
                PModel = "AX2",
                POffices = "Sweden",
                PPurcdate = DateTime.Parse("2-1-2020"),
                PPrice = 7000,
                PCurrency = "SEK",
                locPrice = 79468,
            });

            modelBuilder.Entity<Asset>().HasData(new Asset
            {
                Id =5,
                Ptype = "Mobile",
                PBrand = "Lava",
                PModel = "LX2",
                POffices = "Sweden",
                PPurcdate = DateTime.Parse("11-2-2020"),
                PPrice = 7000,
                PCurrency = "SEK",
                locPrice = 79468,
            });



        }

    }

}




















