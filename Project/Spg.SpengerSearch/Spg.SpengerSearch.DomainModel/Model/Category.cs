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

        public CategoryType CategoryTypeNavigation { get; private set; } = default!;

        private List<Product> _products = new();
        public IReadOnlyList<Product> Products => _products;

        protected Category()
        { }
        public Category(int id, CategoryType categoryTypeNavigation, string name, DateTime exiryDate)
        {
            Id = id;
            CategoryTypeNavigation = categoryTypeNavigation;
            Name = name;
            ExiryDate = exiryDate;
        }

    }
}
