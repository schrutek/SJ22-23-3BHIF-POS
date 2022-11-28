using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.HelloWorld.Demo.Delegates
{
    public class OldSchool
    {
        public delegate bool OldSchoolDelegate(int a, int b);
        public delegate string OldSchoolDelegate2(string msg);

        /// <summary>
        /// Diese Methode hat den Nachteil, dass der Vergleich fix gecodet ist.
        /// Möchte ich auf != vergleichen, muss ich die Methode ändern.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool GreatMethodForNearlyEverything(OldSchoolDelegate handler, OldSchoolDelegate2 msgHandler, int x, int y)
        {
            // ...
            // 1000 Zeilen Code (z.B. irgendweche Vorbereitungen werden duhgeführt)
            // ...

            bool result = handler(x, y);
            Console.WriteLine(msgHandler("asdasdasdasd"));

            // ...
            // 1000 Zeilen Code (z.B. result wird irgendwie verarbeitet)
            // ...

            return result;
        }

        public bool CompareEqual(int x, int y)
        {
            return (x == y);
        }

        public bool CompareGreater(int x, int y)
        {
            return x > y;
        }

        public bool CompareGreater2(int x, int y, string msg)
        {
            return x > y;
        }

        public string WriteHelloWorld(string msg)
        {
            return "Hello World! MSG:" + msg;
        }
        public void DoSomeWork()
        {
            bool result = GreatMethodForNearlyEverything(CompareEqual, WriteHelloWorld, 5, 5);

            Console.WriteLine(result);
        }
    }
}
