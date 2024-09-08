using H10_Geheugenmanagement;

Random Random = new Random();   

Mens mama =  new Mens(Random);
mama.Geslacht = Mens.Geslachten.Vrouw;
mama.MaxLengte = 180;
mama.Oogkleur = Mens.KleurOgen.Groen;
mama.ToonInfo();

Mens papa = new Mens(Random) { Geslacht = Mens.Geslachten.Man, MaxLengte = 169, Oogkleur = Mens.KleurOgen.Blauw };
papa.ToonInfo();

Mens baby = mama.PlantVoort(papa);
baby.ToonInfo();