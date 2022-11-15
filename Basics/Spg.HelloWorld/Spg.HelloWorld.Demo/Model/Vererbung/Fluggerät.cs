using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.HelloWorld.Demo.Model.Vererbung
{
    public abstract class Fluggerät
    {
        public int AnzahlPassagiere { get; set; }
        public int AnzahlFenster { get; set; }
        public int Spannweite { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ErfinderName { get; set; } = string.Empty;
        public string Hersteller { get; set; } = string.Empty;

        public Fluggerät(string hersteller, int anzahlPassagiere)
        {
            Hersteller = hersteller;
            AnzahlFenster = anzahlPassagiere;
        }

        public abstract void Starten();

        public abstract void Landen();

        public void TreibstoffEinfüllen()
        {
            // Tankstöppel öffnen
            // Sprit einfüllen
            // Bezahlen
        }

        public virtual string Aufenthaltsort()
        {
            return "Universum";
        }
    }
}
