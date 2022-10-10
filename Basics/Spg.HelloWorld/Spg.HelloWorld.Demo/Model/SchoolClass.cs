using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.HelloWorld.Demo.Model
{
    public class SchoolClass
    {
        public string Name { get; init; } = "3BHIF";

        private int _maxStudents;

        //public SchoolClass(string name)
        //{
        //    Name = name;
        //}

        public SchoolClass()
        { }

        public List<Student> Students { get; set; }

        public int MaxStudents
        {
            get
            {
                return _maxStudents; 
            }
            set 
            {
                if (value > 32)
                {
                    throw new ArgumentException("Schülerzahl zu groß!");
                }
                _maxStudents = value;
            }
        }

        public void SetName(string name)
        {
            Name = name;
        }
    }
}
