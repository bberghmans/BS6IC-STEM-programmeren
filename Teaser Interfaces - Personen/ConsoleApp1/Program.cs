using Sorteer;      // de namenspace van de klasses

Student student1 = new Student() { Voornaam = "Klaas", Achternaam = "Vaak" };
Student student2 = new Student("Truusje", "Toeter");

Personeel personeel1 = new Personeel("Sjaak", "Snuiter");
Personeel personeel2 = new Personeel() { Voornaam = "Henkie", Achternaam = "Snuiter", Personeelsnummer = 5 };

List<Persoon> personen =  new List<Persoon>() { student1, student2, personeel1, personeel2 };

Console.WriteLine("Deze lijst is niet gesorteerd");
foreach (Persoon persoon in personen)
{
    Console.WriteLine($"{persoon.Voornaam} {persoon.Achternaam}");
}

Console.WriteLine();
personen.Sort();
Console.WriteLine("Deze lijst is gesorteerd");
foreach (Persoon persoon in personen)
{
    Console.WriteLine($"{persoon.Voornaam} {persoon.Achternaam}");
}