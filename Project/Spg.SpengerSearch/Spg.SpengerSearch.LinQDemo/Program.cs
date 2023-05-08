using Microsoft.EntityFrameworkCore;
using Spg.SpengerSearch.DomainModel.Infrastructure;
using Spg.SpengerSearch.DomainModel.Model;
using System;
using System.Collections.Generic;

DbContextOptionsBuilder options = new DbContextOptionsBuilder();
options.UseSqlite("Data Source=./../../../SpengerSearch.db");

SpengerSearchContext db = new SpengerSearchContext();
db.Database.EnsureDeleted();
db.Database.EnsureCreated();
//db.Seed();

// SELECT * FROM shops
List<Shop> result01 = db.Shops.ToList();
result01.Where(s => s.Id == 12);

// SELECT * FROM shops WHERE Id = 12
//var result02 = db.Shops.Single(s => s.Id == 12);
var result03 = db.Shops.SingleOrDefault(s => s.Id == 4711)
    ?? new Spg.SpengerSearch.DomainModel.Model.Shop("", "", "", "", "", default!);

var result04 = db.Shops.Where(s => s.Id == 12).FirstOrDefault();

var result05 = db.Products.Where(p => p.Name.ToLower().StartsWith("a"));

var result06 = db.Products.Any(p => p.DeliveryDate > new DateTime(2022, 01, 01));

//IQueryable<Shop> result07 = Queryable.Where(result01, s => s.Id == 12);
List<Shop> shops = MyLinQ.Where(result01, s => s.Id == 12);

public static class MyLinQ
{
    public static List<Shop> Where(List<Shop> source, Func<Shop, bool> predicate)
    {
        List<Shop> result = new();
        foreach (Shop item in source)
        {
            if (predicate(item))
            {
                result.Add(item);
            }
        }
        return result;
    }
}
