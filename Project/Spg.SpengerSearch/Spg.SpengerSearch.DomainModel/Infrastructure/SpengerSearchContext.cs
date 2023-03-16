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
            modelBuilder.Entity<Product>().HasKey(p => new { p.Description, p.Ean13 } );
            modelBuilder.Entity<CategoryType>().HasKey(p => p.Key);
            modelBuilder.Entity<Customer>().OwnsOne(p => p.Address);
            modelBuilder.Entity<Shop>().OwnsOne(p => p.Address);

            //modelBuilder.Entity<Category>().HasMany(c => c.Products);
            //modelBuilder.Entity<Product>().HasOne(p => p.CategoryNavigation);

            modelBuilder.Entity<Product>().HasIndex(p => new { p.Description, p.Ean13 });
        }


        public void Seed()
        {
            Randomizer.Seed = new Random(125620);

            List<Shop> shops = new Faker<Shop>().Rules((f, s) =>
            {
                s.Name = f.Company.CompanyName();
                s.CompanySuffix = f.Company.CompanySuffix();
                s.CatchPhrase = f.Company.CatchPhrase();
                s.Bs = f.Company.Bs();
                s.Address = new Address()
                {
                    City = f.Address.City(),
                    BuildingNumber =
                    f.Address.BuildingNumber(),
                    StreetName =
                    f.Address.StreetName(),
                    Zip = f.Address.ZipCode()
                };
            })
            .Generate(10);

            Shops.AddRange(shops);      // Generiert 10 Insert-Queries
            SaveChanges();              // Speichert alle Shops in die DB (Tranbsaction)

            string[] categoryNames = new Faker().Commerce.Categories(200);

            List<Category> categories = new Faker<Category>()
                .CustomInstantiator(f =>
                new Category(
                    f.Random.ListItem(shops),
                    f.Random.ArrayElement(categoryNames),
                    f.Date.Between(DateTime.Now.AddMonths(2), DateTime.Now.AddMonths(12))))
                .Rules((f, c) =>
            {

            })
            .Generate(200)
            //.GroupBy(c => c.Name)
            //.First()
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
                s.LastName = f.Name.LastName();
                s.EMail = f.Internet.Email();
                s.SocialSecurityNumber = f.Random.Int(111111, 999999).ToString();
                s.RegistrationDateTime = DateTime.Now;
                s.Address = new Address()
                {
                    City = f.Address.City(),
                    BuildingNumber = f.Address.BuildingNumber(),
                    StreetName = f.Address.StreetName(),
                    Zip = f.Address.ZipCode()
                };
            })
            .Generate(50);

            Customers.AddRange(customers);
            SaveChanges();

            List<Product> products = new Faker<Product>().CustomInstantiator(f => new Product(
                    f.Commerce.ProductName(),
                    f.Commerce.Ean13(),
                    f.Random.Int(0, 200),
                    f.Date.Between(DateTime.Now.AddDays(5), DateTime.Now.AddDays(60)),
                    f.Date.Between(DateTime.Now.AddDays(2), DateTime.Now.AddDays(30)),
                    f.Random.Decimal(5M, 900M),
                    f.Random.ListItem(categories)
                )).Rules((f, s) => { })
                .Generate(1000)
                .ToList();

            Products.AddRange(products);
            SaveChanges();
        }
    }
}
