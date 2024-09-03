using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteer
{
    internal class Persoon : IComparable<Persoon>
    {
        public string Voornaam {  get; set; }
        public string Achternaam { get; set; }

        public Persoon(string voornaam, string achternaam)
        {
            Voornaam = voornaam;
            Achternaam = achternaam;
        }

        public Persoon()
        { }

        public int CompareTo(Persoon other)
        {
            int compare_achternaam = this.Achternaam.CompareTo(other.Achternaam);

            // wanneer de achternamen verschillend zijn, geef het resultaat terug van de vergelijking van de achternamen
            if (compare_achternaam != 0) return compare_achternaam;

            // we weten dat de achternamen gelijk zijn (anders kunnen we hier niet terecht komen),
            // dus geef direct het resultaat terug van de vergelijking van de voornamen.
            return this.Voornaam.CompareTo(other.Voornaam);

        }
    }
}
