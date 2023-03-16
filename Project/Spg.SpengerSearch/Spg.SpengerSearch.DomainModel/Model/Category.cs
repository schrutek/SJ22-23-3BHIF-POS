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

        public int ShopNavigationId { get; private set; }
        public Shop ShopNavigation { get; private set; } = default!;


        private List<Product> _products = new();
        public IReadOnlyList<Product> Products => _products;

        public Category()
        { }
        public Category(Shop shop, string name, DateTime exiryDate)
        {
            Name = name;
            ExiryDate = exiryDate;
            ShopNavigation = shop;
        }
    }
}
