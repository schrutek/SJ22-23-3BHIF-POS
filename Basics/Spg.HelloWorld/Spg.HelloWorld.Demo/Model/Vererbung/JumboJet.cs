using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.HelloWorld.Demo.Model.Vererbung
{
    public class JumboJet : Fluggerät
    {
        public override void Starten()
        {
            // beschleunigt auf 350kmh, langsames abheben
        }

        public override void Landen()
        {
            // reduziert langsam geschwindigkeit auf 0
        }
    }
}
