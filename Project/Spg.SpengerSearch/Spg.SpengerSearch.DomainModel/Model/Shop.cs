using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.SpengerSearch.DomainModel.Model
{
    public class Shop
    {
        protected Shop()
        { }
        public Shop(string companySuffix, string name, string location, string catchPhrase, string bs, Address address)
        {
            CompanySuffix = companySuffix;
            Name = name;
            Location = location;
            CatchPhrase = catchPhrase;
            Bs = bs;
            Address = address;
        }

        public int Id{ get; private set; } // Id..PK ; int,long .. AutoIncrement
        public string CompanySuffix { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string CatchPhrase { get; set; } = string.Empty;
        public string Bs { get; set; } = string.Empty;
        public Address Address { get; set; } = default!;
    }
}
