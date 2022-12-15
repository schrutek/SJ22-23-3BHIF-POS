using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.SpengerSearch.DomainModel.Model
{
    public class Product
    {
        public string Name { get; private set; } = string.Empty; // PK
        public string Ean13 { get; set; } = string.Empty;
        public int Stock { get; set; }
        public DateTime ExpiaryDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public decimal Price { get; set; }

        public Category CategoryNavigation { get; set; } = default!;
    }
}
