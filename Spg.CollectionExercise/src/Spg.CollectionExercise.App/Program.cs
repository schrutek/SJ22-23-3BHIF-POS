using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ExCollection.App
{
    public class Klasse
    {
        // TODO: Erstelle ein Property Schuelers, welches alle Schüler der Klasse in einer
        //       Liste speichert.
        public string Name { get; set; } = string.Empty;
        public string KV { get; set; } = string.Empty;

        private List<Schueler> _schuelers = new(); // Backing Field
        public IReadOnlyList<Schueler> Schuelers 
        { 
            get 
            { 
                return _schuelers; 
            } 
        }

        /// <summary>
        /// Fügt den Schüler zur Liste hinzu und setzt das Property KlasseNavigation
        /// des Schülers korrekt auf die aktuelle Instanz.
        /// </summary>
        /// <param name="s"></param>
        public void AddSchueler(Schueler s)
        {
            // Nur wenn der Schüler nicht null ist
            if (s is not null)
            {
                // Nur wenn der Schüler noch nicht in dieser Klasse ist
                foreach (Schueler item in _schuelers)
                {
                    if (item.Id == s.Id)
                    {
                        throw new ArgumentException("Schüler ist bereits in der Klasse vorhanden!");
                    }
                }
                // Mit LinQ
                if (_schuelers.Any(item => item.Id == s.Id))
                {
                    throw new ArgumentException("Schüler ist bereits in der Klasse vorhanden!");
                }
                // KlasseNavigation des Schülers korrekt auf die aktuelle Instanz setzen
                s.KlasseNavigation = this;
                // Schüler hinzufügen
                _schuelers.Add(s);
            }
        }

        public void RemoveSchueler(Schueler s)
        {
            _schuelers.Remove(s);
        }
    }
    public class Schueler
    {
        // TODO: Erstelle ein Proeprty KlasseNavigation vom Typ Klasse, welches auf
        //       die Klasse des Schülers zeigt.
        // Füge dann über das Proeprty die Zeile
        // [JsonIgnore]
        // ein, damit der JSON Serializer das Objekt ausgeben kann.
        public int Id { get; set; }
        public string Zuname { get; set; } = string.Empty;
        public string Vorname { get; set; } = string.Empty;
        
        [JsonIgnore]
        public Klasse KlasseNavigation { get; set; } = default!;

        /// <summary>
        /// Ändert die Klassenzugehörigkeit, indem der Schüler
        /// aus der alten Klasse, die in KlasseNavigation gespeichert ist, entfernt wird.
        /// Danach wird der Schüler in die neue Klasse mit der korrekten Navigation eingefügt.
        /// </summary>
        /// <param name="k"></param>
        public void ChangeKlasse(Klasse k)
        {
            if (k is not null)
            {
                KlasseNavigation?.RemoveSchueler(this);
                //KlasseNavigation = k;
                k.AddSchueler(this);
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Klasse> klassen = new Dictionary<string, Klasse>();
            klassen.Add("3AHIF", new Klasse() { Name = "3AHIF", KV = "KV1" });
            klassen.Add("3BHIF", new Klasse() { Name = "3BHIF", KV = "KV2" });
            klassen.Add("3CHIF", new Klasse() { Name = "3CHIF", KV = "KV3" });
            klassen["3AHIF"].AddSchueler(new Schueler() { Id = 1001, Vorname = "VN1", Zuname = "ZN1" });
            klassen["3AHIF"].AddSchueler(new Schueler() { Id = 1002, Vorname = "VN2", Zuname = "ZN2" });
            klassen["3AHIF"].AddSchueler(new Schueler() { Id = 1003, Vorname = "VN3", Zuname = "ZN3" });
            klassen["3BHIF"].AddSchueler(new Schueler() { Id = 1011, Vorname = "VN4", Zuname = "ZN4" });
            klassen["3BHIF"].AddSchueler(new Schueler() { Id = 1012, Vorname = "VN5", Zuname = "ZN5" });
            klassen["3BHIF"].AddSchueler(new Schueler() { Id = 1013, Vorname = "VN6", Zuname = "ZN6" });


            //klassen["3AHIF"].Schuelers.Add(new Schueler() { Id = 10000, Vorname = "asdasd", Zuname = "asdasd"});
            //klassen["3AHIF"].Schuelers = new List<Schueler>() { new Schueler() };

            Schueler s = klassen["3AHIF"].Schuelers[0];
            Console.WriteLine($"s sitzt in der Klasse {s.KlasseNavigation.Name} mit dem KV {s.KlasseNavigation.KV}.");
            Console.WriteLine("3AHIF vor ChangeKlasse:");
            Console.WriteLine(JsonConvert.SerializeObject(klassen["3AHIF"].Schuelers));
            s.ChangeKlasse(klassen["3BHIF"]);
            Console.WriteLine("3AHIF nach ChangeKlasse:");
            Console.WriteLine(JsonConvert.SerializeObject(klassen["3AHIF"].Schuelers));
            Console.WriteLine("3BHIF nach ChangeKlasse:");
            Console.WriteLine(JsonConvert.SerializeObject(klassen["3BHIF"].Schuelers));
            Console.WriteLine($"s sitzt in der Klasse {s.KlasseNavigation.Name} mit dem KV {s.KlasseNavigation.KV}.");


        }
    }
}