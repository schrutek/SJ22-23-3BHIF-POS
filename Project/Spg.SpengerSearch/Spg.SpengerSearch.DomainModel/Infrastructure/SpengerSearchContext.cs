using Bogus;
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
            Randomizer.Seed = new Random(140237);

            List<Shop> shops = new Faker<Shop>().Rules((f, s) =>
            {
                s.Name = f.Company.CompanyName();
                s.CompanySuffix = f.Company.CompanySuffix();
            })
            .Generate(10)
            .ToList();
        }
    }
}
