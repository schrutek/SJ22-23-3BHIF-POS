using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.SpengerSearch.DomainModel.Model
{
    public class Product
    {
        // [Key()] Hat hier nichts verloren =>
        public string Description { get; private set; } = string.Empty; // PK
        public string Ean13 { get; private set; } = string.Empty;
        public int Stock { get; set; }
        public DateTime ExpiryDate { get; private set; }
        public DateTime? DeliveryDate { get; set; }
        public decimal Price { get; set; }

        public Category CategoryNavigation { get; private set; } = default!;

        protected Product()
        { }
        public Product(string name, string ean13, int stock, DateTime expiryDate, DateTime? deliveryDate, decimal price)
        {
            Description = name;
            Ean13 = ean13;
            Stock = stock;
            ExpiryDate = expiryDate;
            DeliveryDate = deliveryDate;
            Price = price;
        }
    }
}
