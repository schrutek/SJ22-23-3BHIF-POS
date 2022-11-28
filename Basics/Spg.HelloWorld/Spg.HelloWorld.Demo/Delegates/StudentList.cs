using Spg.HelloWorld.Demo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.HelloWorld.Demo.Delegates
{
    //public delegate bool FilterHandler(Student s);
    
    public class StudentList : List<Student>
    {
        public List<Student> Filter(Func<Student, bool> handler)
        {
            List<Student> resultList = new();
            foreach (Student s in this)
            {
                if (handler(s))
                {
                    resultList.Add(s);
                }
            }
            return resultList;
        }
    }
}
