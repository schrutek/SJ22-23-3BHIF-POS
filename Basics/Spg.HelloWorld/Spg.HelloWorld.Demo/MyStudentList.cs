using Spg.HelloWorld.Demo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.HelloWorld.Demo
{
    public class MyStudentList<T> : List<T> where T : Student, new()
    {
        public T this[string firstName] 
        {
            get
            {
                foreach (var item in this)
                {
                    if (item.FirstName == firstName)
                    {
                        return item;
                    }
                }
                return new T();
            }
        }
    }
}
