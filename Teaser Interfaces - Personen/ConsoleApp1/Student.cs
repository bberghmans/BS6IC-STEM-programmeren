using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteer
{
    internal class Student: Persoon
    {
        public Student(string voornaam, string achternaam) : base(voornaam, achternaam) { }
        public Student() : base() { }

        public string Klas { get; set; }
    }
}
