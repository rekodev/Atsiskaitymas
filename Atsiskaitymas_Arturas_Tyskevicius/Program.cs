using System.Transactions;

Console.WriteLine($"Sveiki atvyke i mano sukurta zaidima!");

// Zaidimo ciklas, kurio pabaigoje klausiama, ar norite zaisti dar
do
{
    // Zaidimas susideda is 10 zodziu, kurie surasyti masyve zodziai
    string[] zodziai = { "obuolys", "morka", "kriause", "baklazanas", "paprika", "zirniai", "apelsinas", "mandarinas", "bananas", "citrina" };
    Random rnd = new Random();
    int num = rnd.Next(0, zodziai.Length - 1);

    // zodis yra atsitiktinis masyvo zodziai elementas
    string zodis = zodziai[num];
    // Spejimas yra masyvas, kuris susideda is char simboliu, simboliu yra tiek pat kiek zaidimo zodyje yra raidziu. Toliau sukamas ciklas priskirs kiekvienam sio masyvo elementui tarpa " "
    char[] spejimas = new char[zodis.Length];

    int count = 0; // count skaiciuos, kiek teisingu raidziu ivede vartotojas
    int raidziuCount = 0; // raidziuCount skaiciuoja kiek is viso raidziu ivesta, kad zinoti kokios raides kartosis ar nesikartos
    bool spejimoPatikrinimas; // tikrina ar teisingas spejimas
    bool buvusiRaide; // tikrina ar raide buvo panaudota
    int gyvybes = 5; // is viso penkios gyvybes

    string panaudotosRaides = "                                                        "; // Cia sukuriau dideli stringa tarpu, kad uztektu vietos sukeitinet char'us veliau. Zinau, kad tai nera optimaliausias variantas :D

    Console.WriteLine($"\n\nSi karta reikes atspeti zodi, kuris susideda is [{zodis.Length}] raidziu.\nJeigu esate pasiruose, iveskite raide, kad pradeti zaidima.");

    // pradine zodzio reprezentacija, kur nera atspetu raidziu
    for (int i = 0; i < zodis.Length; i++)
    {
        spejimas[i] = ' ';
        Console.Write(spejimas[i] + " ");
    }

    Console.Write("\n"); // Nauja eilute

    for (int j = 0; j < zodis.Length; j++)
    {
        Console.Write("_ ");
    }
    Console.WriteLine($"\n\nJusu gyvybes: {gyvybes}\n");

    // Spejimu ciklas
    while (true)
    {
        spejimoPatikrinimas = false;
        buvusiRaide = false;
        string vartotojoIvestis;
        // Vartotojo ivestis vis kartosis, jeigu vartotojas nieko neives
        do
        {
            Console.Write("Iveskite raide: \n");
            vartotojoIvestis = Console.ReadLine().ToLower(); // pavercia bet kokia ivesta raide i mazaja
            if (vartotojoIvestis != "" && ((vartotojoIvestis[0] >= 97 && vartotojoIvestis[0] <= 122)))
                break;
            else if (vartotojoIvestis != "" && !((vartotojoIvestis[0] >= 97 && vartotojoIvestis[0] <= 122)))
                Console.WriteLine("\nSimbolis nera raide, bandykite dar.\n");
            else
                Console.WriteLine("Negalima nieko neivesti, bandykite dar.\n");
        } while (true);


        var raide = vartotojoIvestis[0]; // vartotojas gali ivesti ka nori, bet mums rupes tik pirma raide
        // ciklas, kuriame spejamos raides
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

        // ciklas, kuriame tikrinama, ar viena is ivestu raidziu jau buvo ivesta
        for (int i = 0; i < panaudotosRaides.Length; i++)
        {
            if (raide == panaudotosRaides[i])
                buvusiRaide = true;
        }

        // jeigu neteisingas spejimas ir raide dar nebuvo panaudota, mazeja gyvybes
        if (spejimoPatikrinimas == false && buvusiRaide == false)
        {
            Console.WriteLine("\nNeteisingas spejimas. Bandykite dar.");
            gyvybes--;
        }

        // jeigu nesvarbu ar teisingas ar neteisingas spejimas, ir raide panaudota, i ekrana isveda, kad raide jau panaudota, gyvybes nemazeja
        else if (spejimoPatikrinimas == false && buvusiRaide == true || buvusiRaide == true && spejimoPatikrinimas == true)
        {
            Console.WriteLine("\nTokia raide jau buvo! Bandykite dar karta.");
        }

        // spejimas - tai masyvas, kuris susideda is char, bet jame nera tarpu, tai cia pridedu tarp masyvo elementu tarpus
        var beTarpu = spejimas;
        var suTarpais = string.Join(" ", beTarpu.ToArray());


        Console.Write("\n"); // Nauja eilute

        // isvedamas spejimu masyvas su tarpais
        Console.Write(suTarpais);

        // cia isvedamos panaudotos raides, jeigu raidziuCount yra 0, reiskias nei viena raide dar nebuvo panaudota
        // kai raidziuCount > 0, ziurime, ar raide jau buvo panaudota, ar ne, jeigu ne - tai prie panaudotu raidziu ekrane prisideda ivesta raide
        if (raidziuCount > 0 && buvusiRaide == false)
        {
            panaudotosRaides = panaudotosRaides.Insert(raidziuCount+raidziuCount, raide.ToString()); // raidziuCount+raidziuCount reiskia, kad raides prisideda vienas prie kitos su tarpu
            raidziuCount++;
            Console.Write($"      Panaudotos raides: {panaudotosRaides.ToLower()}");
        }
        else if (raidziuCount > 0 && buvusiRaide == true)
        {
        
            Console.Write($"      Panaudotos raides: {panaudotosRaides.ToLower()}");
        }

        if (raidziuCount == 0)
        {
            panaudotosRaides = panaudotosRaides.Insert(raidziuCount, raide.ToString());
            raidziuCount++;
            Console.Write($"      Panaudotos raides: {panaudotosRaides.ToLower()}");
        }

        Console.Write("\n"); // Nauja eilute

        for (int j = 0; j < zodis.Length; j++)
        {
            Console.Write("_ ");
        }

        Console.Write("\n"); // Nauja eilute

        Console.Write($"\nJusu gyvybes: {gyvybes}\n\n"); // rodoma, kiek liko gyvybiu, jeigu gyvybes pasiekia 0, zaidimas baigiamas ir skelbiamas pralaimejimas
        
        // isvedamas zaidimo rezultatas
        if (count == zodis.Length)
        {
            Console.WriteLine("Jus laimejote! :)\n");
            break;
        }
        else if (gyvybes == 0)
        {
            Console.WriteLine("Jus pralaimejote :(\n");
            Console.WriteLine($"Sio zaidimo zodis buvo: {zodis}\n");
            break;
        }

    }

    string zaistiDar;

    do
    {
        Console.WriteLine("Norite zaisti dar?\n[y] - Taip\n[n] - Ne");
        zaistiDar = Console.ReadLine();
        if (zaistiDar != "" && (zaistiDar[0] == 78 || zaistiDar[0] == 110))
            break;

        else if (zaistiDar != "" && (zaistiDar[0] == 89 || zaistiDar[0] == 121))
            break;
        
        else if (zaistiDar == "")
            Console.WriteLine("Negalima nieko neivesti, bandykite dar.\n");
        else
            Console.WriteLine("\nIveskite [y] arba [n]\n");


    } while (true);

    if (zaistiDar[0] == 78 || zaistiDar[0] == 110)
    {
        Console.WriteLine("Aciu, kad zaidete!");
        break;
    }

    else if (zaistiDar[0] == 89 || zaistiDar[0] == 121)
            Console.WriteLine("Naujas zaidimas.\n");

} while (true);
