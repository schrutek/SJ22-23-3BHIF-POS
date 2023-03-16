using Spg.SpengerSearch.DomainModel.Infrastructure;
using Spg.SpengerSearch.DomainModel.Model;
using Spg.SpengerSearch.WpfFrontEnd.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.SpengerSearch.WpfFrontEnd.ViewModel
{
    public class MainWindowViewModel
    {
        SpengerSearchContext _db;
        
        public MainWindowViewModel()
        {
            _db = new SpengerSearchContext(DatabaseUtilities.GenerateDbOptions());
            LoadCategories();
        }

        private void LoadCategories()
        {
            Categories = _db.Categories.ToList();
        }

        public List<Shop> Shops { get; private set; }

        public List<Category> Categories { get; private set; } = new();
    }
}
