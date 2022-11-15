using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.HelloWorld.Demo.Model.Vererbung
{
    public class Heissluftballon : Fluggerät
    {
        public override void Landen()
        {
            throw new NotImplementedException();
        }

        public override void Starten()
        {
            throw new NotImplementedException();
        }

        public new void TreibstoffEinfüllen()
        {
            // Gasflasche tauschen
        }
    }
}
