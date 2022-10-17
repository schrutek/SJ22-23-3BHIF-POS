using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.HelloWorld.Demo.Model
{
    public enum Genders 
    {
        Male= 12,
        Female = 13, 
        Other = 99
    }

    public partial class Student : EntityBase
    {
        private string _name;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Genders Gender { get; set; } // 0=Male, 1=Female, 2=Other
        
        public string Kuerzel 
        {
            get
            {
                return LastName?[..3]?.ToUpper() ?? string.Empty;
            }

        }

        public int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set 
            {
                if (value >= 0)
                {
                    myVar = value;
                }
            }
        }
    }
}
