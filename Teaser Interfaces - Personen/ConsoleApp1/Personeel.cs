using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteer
{
    internal class Personeel: Persoon
    {
        public Personeel(string voornaam, string achternaam) : base(voornaam, achternaam) { }
        public Personeel() : base() { } 

        public int Personeelsnummer {  get; set; }
    }
}
