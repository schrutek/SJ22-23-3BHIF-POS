using Microsoft.EntityFrameworkCore;
using Spg.SpengerSearch.DomainModel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.SpengerSearch.WpfFrontEnd.Helpers
{
    public static class DatabaseUtilities
    {
        public static DbContextOptions GenerateDbOptions()
        {
            DbContextOptionsBuilder options = new DbContextOptionsBuilder();
            options.UseSqlite("Data Source=SpengerSearch.db");

            return options.Options;
        }

        public static SpengerSearchContext GenerateDbAndSeed()
        {
            SpengerSearchContext db = new SpengerSearchContext(GenerateDbOptions());
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            db.Seed();
            return db;
        }
    }
}
