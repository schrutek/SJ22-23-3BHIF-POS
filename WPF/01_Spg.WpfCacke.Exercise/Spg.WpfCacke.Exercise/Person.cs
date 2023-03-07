using System;
using System.Collections.Generic;
using System.Text;

namespace Spg.WpfCacke.Exercise
{
    public class Person
    {
        public string FirstName { get; }
        public string LastName { get; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
