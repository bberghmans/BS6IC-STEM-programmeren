using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H10_Geheugenmanagement
{
    internal class Mens
    {
        public Mens(Random randomizer)
        {
            Randomizer = randomizer;
        }

        public enum Geslachten { Man, Vrouw }
        public enum KleurOgen { Groen = 0, Blauw = 1, Bruin = 2};
        
        Random Randomizer;
        public int MaxLengte { get; set; }
        public Geslachten Geslacht {get; set;}
        public KleurOgen Oogkleur { get; set;}
        public Mens PlantVoort(Mens dePapa)
        {
            if (Geslacht == Geslachten.Vrouw && dePapa.Geslacht == Geslachten.Man)
            {
                // We creeeren een nieuw Mens object in de heap
                Mens baby = new Mens(Randomizer);

                // We kiezen het geslacht van de baby willekeurig
                if (Randomizer.Next(2) == 0)
                    baby.Geslacht = Geslachten.Vrouw;
                else
                    baby.Geslacht = Geslachten.Man;

                if (Randomizer.NextDouble() < 0.1)
                {
                    // In 10% van de gevallen is de oogkleur willekeurig
                    // LET OP zorg dat elke mogelijke waarde van Next bepaald is door enum
                    // Eventueel kan je Enum.IsDefined() gebruiken om te checken of de enum waarde bestaat
                    baby.Oogkleur = (KleurOgen)Randomizer.Next(3);
                }
                else 
                {
                    if (Randomizer.Next(2) == 0)
                        baby.Oogkleur = this.Oogkleur;
                    else
                        baby.Oogkleur = dePapa.Oogkleur;
                }
                
                baby.MaxLengte = (MaxLengte + dePapa.MaxLengte)/2;

                return baby;
            }
            return null;
        }

        public void ToonInfo()
        {
            Console.WriteLine($"{MaxLengte/100.0:N2}m, {(Geslacht==Geslachten.Vrouw ? "Vrouw" : "Man")}");
        }
    }
}
