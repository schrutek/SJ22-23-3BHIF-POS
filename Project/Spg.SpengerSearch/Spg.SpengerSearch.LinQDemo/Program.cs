using Microsoft.EntityFrameworkCore;
using Spg.SpengerSearch.DomainModel.Infrastructure;

DbContextOptionsBuilder options = new DbContextOptionsBuilder();
options.UseSqlite("Data Source=./../../../SpengerSearch.db");

SpengerSearchContext db = new SpengerSearchContext();
db.Database.EnsureDeleted();
db.Database.EnsureCreated();
db.Seed();

// SELECT * FROM shops
var result01 = db.Shops.ToList();

// SELECT * FROM shops WHERE Id = 12
//var result02 = db.Shops.Single(s => s.Id == 12);
var result03 = db.Shops.SingleOrDefault(s => s.Id == 4711)
    ?? new Spg.SpengerSearch.DomainModel.Model.Shop("", "", "", "", "", default!);

var result04 = db.Shops.Where(s => s.Id == 12).FirstOrDefault();

var result05 = db.Products.Where(p => p.Description.ToLower().StartsWith("a"));

var result06 = db.Products.Any(p => p.DeliveryDate > new DateTime(2022, 01, 01));
