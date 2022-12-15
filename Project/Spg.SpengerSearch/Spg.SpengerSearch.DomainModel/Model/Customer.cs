using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.SpengerSearch.DomainModel.Model
{
    public enum GenderTypes { NA = 0, FEMALE = 1, MALE = 2 }

    public class Customer
    {
        public Customer(GenderTypes gender, string firstName, string lastName, string eMail, DateTime? registrationDateTime, string socialSecurityNumber)
        {
            Gender = gender;
            FirstName = firstName;
            LastName = lastName;
            EMail = eMail;
            RegistrationDateTime = registrationDateTime;
            SocialSecurityNumber = socialSecurityNumber;
        }

        public GenderTypes Gender { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EMail { get; private set; } = string.Empty;
        public DateTime? RegistrationDateTime { get; private set; }
        public string SocialSecurityNumber { get; private set; } = string.Empty;
    }
}
