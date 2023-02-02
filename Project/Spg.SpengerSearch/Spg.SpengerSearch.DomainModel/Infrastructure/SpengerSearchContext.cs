﻿using Bogus;
using Microsoft.EntityFrameworkCore;
using Spg.SpengerSearch.DomainModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.SpengerSearch.DomainModel.Infrastructure
{
    // 1. Von DbContext ableiten
    public class SpengerSearchContext : DbContext
    {
        // 2. Die zu mappenden Tables bzw. Entities definieren
        public DbSet<Shop> Shops => Set<Shop>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<CategoryType> CategoryTypes => Set<CategoryType>();

        // nur zur Erklärung
        public DbSet<CategoryType> CategoryTypes2
        {
            get { return base.Set<CategoryType>(); }
        }


        // 3. Constructors
        public SpengerSearchContext()
        { }
        public SpengerSearchContext(DbContextOptions options)
            : base(options)
        { }

        // 4. 2 Methoden (OnModelCreating, OnConfiguring)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Das muss weg, weil im Source Code gefährlich!!!!!!
            // "Data Source=/123.456.789.456 catalog=DbName UserId=Ich Pwd=Geheim!"
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=SpengerSearch.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Alle zusätzlichen Infos um aus den Entities eine DB zu erstellen.
            //modelBuilder.Entity<Product>().HasKey(new Product().GetType().GetProperties().SingleOrDefault(p => p.Name == "Description").Name);
            modelBuilder.Entity<Product>().HasKey(p => p.Description);
            modelBuilder.Entity<CategoryType>().HasKey(p => p.Key);
            modelBuilder.Entity<Customer>().OwnsOne(p => p.Address);
            modelBuilder.Entity<Shop>().OwnsOne(p => p.Address);

            modelBuilder.Entity<Category>().HasMany(c => c.Products);

            modelBuilder.Entity<Product>().HasIndex(p => new { p.Description, p.Ean13 });

        }


        public void Seed()
        {
            Randomizer.Seed = new Random(125620);

            List<Shop> shops = new Faker<Shop>().Rules((f, s) =>
            {
                s.Name = f.Company.CompanyName();
                s.CompanySuffix = f.Company.CompanySuffix();
            })
            .Generate(10);

            Shops.AddRange(shops); // Generiert 10 Insert-Queries
            SaveChanges(); // Speichert alle Shops in die DB (Tranbsaction)

            string[] categoryNames = new Faker().Commerce.Categories(20);

            List<CategoryType> categoryTypes = new(); // TODO: Durch Faker ersetzen

            List<Category> categories = new Faker<Category>()
                .CustomInstantiator(f =>
                new Category(
                    categoryTypes[1],
                    f.Random.ListItem(shops),
                    f.Commerce.Categories(1).First(),
                    f.Date.Between(DateTime.Now.AddMonths(2), DateTime.Now.AddMonths(12))))
                .Rules((f, c) =>
            {
                //// Mit ArrayElement:
                //c.Name = f.Random.ArrayElement(categoryNames);

                //// Alternative:
                //c.Name = f.Commerce.Categories(1).First();
            })
            .Generate(10)
            .GroupBy(c => c.Name)
            .First()
            .ToList();

            Categories.AddRange(categories);
            SaveChanges();

            //string[] department = new string[] { "HIF", "KIF", "WIT", "HBGM", "HKUI", "AIF", "FIT" };

            List<Customer> customers = new Faker<Customer>().Rules((f, s) =>
            {
                s.Gender = f.Random.Enum<GenderTypes>();
                s.FirstName = f.Name.FirstName(Bogus.DataSets.Name.Gender.Male);
                if (s.Gender == GenderTypes.FEMALE)
                {
                    s.FirstName = f.Name.FirstName(Bogus.DataSets.Name.Gender.Female);
                }
            })
            .Generate(50);

            Customers.AddRange(customers);
            SaveChanges();
        }
    }
}
