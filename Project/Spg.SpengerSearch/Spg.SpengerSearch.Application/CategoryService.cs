using Microsoft.EntityFrameworkCore;
using Spg.SpengerSearch.DomainModel.Infrastructure;
using Spg.SpengerSearch.DomainModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.SpengerSearch.CoreApplication
{
    public class CategoryService
    {
        private readonly SpengerSearchContext _db;

        public CategoryService(SpengerSearchContext db)
        {
            _db = db;
        }

        public List<Category> ListCategories(int shopId)
        {
            var result = _db
                .Categories
                .Where(c => c.ShopNavigationId == shopId)
                .ToList();

            return result;
        }
    }
}
