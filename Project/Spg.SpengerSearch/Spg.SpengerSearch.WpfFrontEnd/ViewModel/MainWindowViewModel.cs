using Bogus.DataSets;
using Microsoft.EntityFrameworkCore;
using Spg.SpengerSearch.CoreApplication;
using Spg.SpengerSearch.DomainModel.Infrastructure;
using Spg.SpengerSearch.DomainModel.Model;
using Spg.SpengerSearch.WpfFrontEnd.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace Spg.SpengerSearch.WpfFrontEnd.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private readonly SpengerSearchContext _db;
        private readonly CategoryService _categoryService;

        /// <summary>
        /// Konstruktor beopmmt DBContext und CategoryService injected (Dependency Injection)
        /// </summary>
        /// <param name="db"></param>
        /// <param name="categoryService"></param>
        public MainWindowViewModel(SpengerSearchContext db, CategoryService categoryService)
        {
            // Alte Variante: Ohne Dependency Injection
            //_db = new SpengerSearchContext(DatabaseUtilities.GenerateDbOptionsProductive());
            
            // Mit Dependency Injection
            _db = db;
            _categoryService = categoryService;
            LoadShops();
        }

        private void LoadShops() 
        {
            Shops = _db.Shops.ToList();
        }

        private void LoadCategories(string categoryName, bool doOrder)
        {
            IQueryable<Category> result = _db.Categories;           // => select * from categories

            if (!string.IsNullOrEmpty(categoryName))
            {
                result = result.Where(c => c.Name == categoryName); // => select * from categories where name = 'home'
            }

            if (doOrder)
            {
                result = result.OrderByDescending(c => c.Id);       // select * from categories c name = 'home' orderby id desc
            }

            result = result.Include(c => c.ShopNavigation);         // select * from categories c, shops s where c.shopid = s.id and name = 'home' orderby id desc

            Categories = result.ToList();
        }

        public List<Shop> Shops { get; private set; } = new();

        public List<Category> Categories
        {
            get { return _categories; }
            set 
            {
                _categories = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Categories)));
            }
        }
        private List<Category> _categories = new();

        public Shop SelectedShop
        {
            get { return _selectedShop; }
            set 
            {
                _selectedShop = value;

                // Alte Variante: Ohne separaten Service
                //Categories = _db
                //    .Categories
                //    .Where(c => c.ShopNavigationId == _selectedShop.Id)
                //    .Include(c => c.Products)
                //    .OrderByDescending(c => c.Id)
                //    .ToList();

                // Bessere Variante: Mit separatem Service
                Categories = _categoryService.ListCategories(_selectedShop.Id);

                if (PropertyChanged is not null
                    && Categories is not null)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedShop)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CategoryCount)));
                }
            }
        }
        private Shop _selectedShop = default!;

        public List<Product> Products 
        {
            get { return _products; }
            set
            {
                _products = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Products)));
            } 
        }
        private List<Product> _products = new();

        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set 
            {
                _selectedCategory = value;
                Products = _db.Products.Where(p => p.CategoryNavigation.Id == _selectedCategory.Id).ToList();
                if (PropertyChanged is not null
                    && Products is not null)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedCategory)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ProductCount)));
                }
            }
        }
        private Category _selectedCategory = default!;

        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set 
            { 
                _selectedProduct = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedProduct)));
                // DB load??
            }
        }
        private Product _selectedProduct = default!;


        private int _categoryCount;

        public int CategoryCount 
            => _categories?.Count ?? 0;

        public int ProductCount
            => _products?.Count ?? 0;

        public void Create(Shop newShop)
        {
            // TODO: ExceptionHandling, Validation
            _db.Shops.Add(newShop);
            _db.SaveChanges();
        }

        public int Update(Shop newShop)
        {
            // TODO: ExceptionHandling, Validation
            _db.Shops.Update(newShop);
            return _db.SaveChanges();
        }
    }
}
