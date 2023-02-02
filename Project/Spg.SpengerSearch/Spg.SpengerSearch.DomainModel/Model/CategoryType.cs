using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.SpengerSearch.DomainModel.Model
{
    public class CategoryType
    {
        public string Key { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        private List<Category> _categories = new();
        public IReadOnlyList<Category> Categories => _categories;
    }
}
