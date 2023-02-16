using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.SpengerSearch.DomainModel.Model
{
    public class Category
    {
        public int Id { get; private set; } // wird automatisch PK + Auto Increment
        public string Name { get; set; }
        public DateTime ExiryDate { get; set; }

        public int CategoryTypeNavigationId { get; private set; }
        public CategoryType CategoryTypeNavigation { get; private set; } = default!;

        public int ShopNavigationId { get; private set; }
        public Shop ShopNavigation { get; private set; } = default!;


        private List<Product> _products = new();
        public IReadOnlyList<Product> Products => _products;

        protected Category()
        { }
        public Category(CategoryType categoryTypeNavigation, Shop shop, string name, DateTime exiryDate)
        {
            CategoryTypeNavigation = categoryTypeNavigation;
            Name = name;
            ExiryDate = exiryDate;
            ShopNavigation = shop;
        }
    }
}
