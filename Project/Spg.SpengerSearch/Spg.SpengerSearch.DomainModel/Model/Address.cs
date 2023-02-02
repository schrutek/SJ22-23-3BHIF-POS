using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.SpengerSearch.DomainModel.Model
{
    public class Address
    {
        public string StreetName { get; set; } = string.Empty;
        public string BuildingNumber { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;

        public Address()
        { }
        public Address(string streetName, string buildingNumber, string zip)
        {
            StreetName = streetName;
            BuildingNumber = buildingNumber;
            Zip = zip;
        }

        // Gute Idee, vermeidet NullreferenzException, in unserem Fall verlassen
        // wir uns aber auf die Vollständigkeit der DB.
        //public Address GetEmpty() 
        //{
        //    return new Address();
        //}
    }
}
