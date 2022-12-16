//void panaudotosRaides() {
//    Console.WriteLine(" ");
//}

// Zaidimas susideda is 10 zodziu, kurie surasyti masyve zodziai
string[] zodziai = { "obuolys", "morka", "kriause", "baklazanas", "paprika", "zirniai", "apelsinas", "mandarinas", "bananas", "citrina" };
Random rnd = new Random();
int num = rnd.Next(0, zodziai.Length - 1);

// zodis yra atsitiktinis masyvo zodziai elementas
string zodis = zodziai[num];
char[] spejimas = new char[zodis.Length];

int count = 0;
bool spejimoPatikrinimas;
bool buvusiRaide;
int gyvybes = 5;

Console.WriteLine($"Sveiki atvyke i mano sukurta zaidima!\n\nSi karta reikes atspeti zodi, kuris susideda is [{zodis.Length}] raidziu.\nJeigu esate pasiruose, iveskite raide, kad pradeti zaidima.");
//Console.WriteLine(zodis);

// pradine zodzio reprezentacija, kur nera atspetu raidziu
for (int i = 0; i < zodis.Length; i++)
{
    spejimas[i] = ' ';
    Console.Write(spejimas[i] + " ");
}
Console.Write("\n");
for (int j = 0; j < zodis.Length; j++)
{
    Console.Write("_ ");
}
Console.WriteLine($"\n\nJusu gyvybes: {gyvybes}\n");

// Zaidimo ciklas
while (true)
{
    spejimoPatikrinimas = false;
    buvusiRaide = false;
    Console.Write("Iveskite raide: \n");
    string vartotojoIvestis = Console.ReadLine();
    var raide = vartotojoIvestis[0];
    for (int i = 0; i < zodis.Length; i++)
    {
        if (raide == zodis[i] && spejimas[i] == ' ')
        {
            spejimas[i] = raide;
            count++;
            spejimoPatikrinimas = true;
        }
        else if (raide == zodis[i] && raide != ' ')
        {
            buvusiRaide = true;
            spejimoPatikrinimas = true;
        }
    }

    if (spejimoPatikrinimas == false)
    {
        Console.WriteLine("\nNeteisingas spejimas. Bandykite dar.");
        gyvybes--;
    }
    
    if (buvusiRaide == true)
        Console.WriteLine("\nTokia raide jau buvo! Bandykite dar karta.");

    var beTarpu = spejimas;
    var suTarpais = string.Join(" ", beTarpu.ToArray());
    Console.Write("\n");
    Console.Write(suTarpais);
    Console.Write("\n");

    for (int j = 0; j < zodis.Length; j++)
    {
        Console.Write("_ ");
    }

    Console.Write("\n");
    //Console.Write($"\nCOUNTAS: {count}\n");
    Console.Write($"\nJusu gyvybes: {gyvybes}\n\n");

    if (count == zodis.Length)
    {
        Console.WriteLine("\nJus laimejote! :)");
        break;
    }
    else if (gyvybes == 0)
    {
        Console.WriteLine("Jus pralaimejote :(\n");
        Console.WriteLine($"Sio zaidimo zodis buvo: {zodis}\n");
        break;
    }
}



//Console.WriteLine("Norite zaisti dar?");


