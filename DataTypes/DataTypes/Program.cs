uint A = 0b001001;          // binaire weergave
Console.WriteLine($"De variabele A = {A}");

uint B = 0xA2;              // hexadecimale weergave
Console.WriteLine($"De variabele B = {B}");

uint C = A | B;             // bitwise OR
Console.WriteLine($"De variabele C = {C}");

uint D = ~C;                // bitwise complement
Console.WriteLine($"De variabele D = {D}");

int E = (int)C;             // type casting
Console.WriteLine($"De variabele E = {E}");

int F = ~E;                 // bitwise complement (zie regel 10)
Console.WriteLine($"De variabele F = {F}");

uint G = A >> 2;            // bit shift (wat is de wiskundige operator?)
Console.WriteLine($"De variabele G = {G}");

uint H = A << 3;            // bit shift (wat is de wiskundige operator?)
Console.WriteLine($"De variabele H = {H}");