using System.Text.RegularExpressions;

Console.WriteLine("Skriv in produkter. Avsulta med 'exit'");

string[] products = new string[0];

int index = 0;
while (true)
{
    Console.ResetColor();
    Console.Write("Ange produkt: ");
    string input = Console.ReadLine();
    Console.ForegroundColor = ConsoleColor.Red;

    if (input.ToLower().Trim() == "exit")
    {
        break;
    }
    if (input == "")
    {
        Console.WriteLine("Felaktikt format: du får inte ange tomt värde");
    }
    else
    {
        string[] inputArr = input.Split("-");

        if (inputArr.Length == 2)
        {
            string firstPart = inputArr[0];
            string secondPart = inputArr[1];

            if (Regex.IsMatch(firstPart, @"^[a-zA-Z]+$"))
            {
                if (int.TryParse(secondPart, out int value))
                {
                    if (value >= 200 && value <= 500)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Lade till {input} till listan av produkter");
                        Array.Resize(ref products, products.Length + 1);
                        products[index] = input;
                        index++;
                    }
                    else
                    {
                        Console.WriteLine("Felaktikt format: nummeriska delen behöver vara mellan 200 och 500");
                    }

                }
                else
                {
                    Console.WriteLine("Felaktikt format: fel på höger delen av produktnumret");
                }
            }
            else
            {
                Console.WriteLine("Felaktikt format: fel på vänstra delen av produktnumret");
            }

        }
        else
        {
            Console.WriteLine("Felaktikt format: Du måste ha exakt 1 bindestreck");
        }
    }
}
Console.ResetColor();
Console.WriteLine("Du angav följande produkter (sorterade): ");
Array.Sort(products);

foreach (var product in products)
{
    Console.WriteLine("* " + product);
}

Console.ReadKey();