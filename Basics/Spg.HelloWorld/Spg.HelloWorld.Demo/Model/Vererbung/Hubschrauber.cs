using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.HelloWorld.Demo.Model.Vererbung
{
    public abstract class Hubschrauber : Fluggerät
    {
        public Hubschrauber()
            : this("unknown")
        { }
        public Hubschrauber(string hersteller)
            : base(hersteller, 12)
        { }
        public Hubschrauber(string hersteller, int anzahlPassagiere)
            : base(hersteller, anzahlPassagiere)
        { }

        //public void Starten()
        //{
        //    // senkrecht nach oben
        //}

        public override void Landen()
        {
            // landet senkrecht nach unten
        }

        public new string Aufenthaltsort()
        {
            return "Planet Erde, Koordinaten: 1.1258741 ; 8.3256987";
        }
    }
}
