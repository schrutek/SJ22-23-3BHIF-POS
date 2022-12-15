using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.SpengerSearch.DomainModel.Model
{
    public class Category
    {
        public int Id { get; } // wird automatisch PK + Auto Increment
        public CategoryType CategoryTypeNavigation { get; set; } = default!;
        public string Name { get; set; }
        public DateTime ExiryDate { get; set; }

        private List<Product> _products = new();
        public IReadOnlyList<Product> Products => _products;
    }
}
