using Sorteer;      // de namenspace van de klasses

int i = 0;  

Student student1;
student1 = new Student("Truusje", "Toeter");

Student student2 = student1;

student2.Voornaam = "Tokkie";
Console.WriteLine($"{student1.Voornaam} {student1.Achternaam}");

Personeel personeel1 = new Personeel("Sjaak", "Snuiter");

//Student student2 = new Student() { Voornaam = "Klaas", Achternaam = "Vaak" };
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