using Microsoft.EntityFrameworkCore;
using Spg.SpengerSearch.DomainModel.Infrastructure;
using Spg.SpengerSearch.DomainModel.Model;

namespace Spg.SpengerSearch.DomainModel.Test
{
    public class DataBaseTests
    {
        private SpengerSearchContext GenerateDb()
        {
            DbContextOptionsBuilder options = new DbContextOptionsBuilder();
            options.UseSqlite("Data Source=SpengerSearch_Test.db");

            // Act
            SpengerSearchContext db = new SpengerSearchContext(options.Options);
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            return db;
        }

        [Fact]
        public void Generate_Database()
        {
            // Arrange
            DbContextOptionsBuilder options = new DbContextOptionsBuilder();
            //options.UseSqlite("Data Source=[serverip/port/instanz] [databasename] user id=[username] password=[geheim!]");
            options.UseSqlite("Data Source=./../../../SpengerSearch.db");

            // Act
            SpengerSearchContext db = new SpengerSearchContext(options.Options);
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            // Assert (wird nicht benötigt)
        }

        [Fact]
        public void Shop_Create_One_Tuple_Success_Test()
        {
            // Arrange (wir müssen den Datensatz vorbereiten)
            SpengerSearchContext db = GenerateDb();
            Shop entity = new Shop("KG", "SpengerShop", "Hier", "WhatEver", "BS", new Address("Spengergasse", "20-24", "1050"));

            // Act (wir wollen einen Datensatz anlegen)
            db.Add(entity); //OK
            db.SaveChanges();

            // Assert (wir wollen prüpfen, ob der Datenbsatz in der DB gelandet ist)
            int actual = db.Shops.Count();
            Assert.Equal(actual, 1);
        }
    }
}