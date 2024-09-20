using System;

namespace Rechner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Wie wollen Sie genannt werden?");
            string name = Console.ReadLine();
            Console.WriteLine($"Wilkommen {name}");

            bool wiederholen = true;
            double ergebnis = 0;

            while (wiederholen)
            {
                Console.ForegroundColor = ConsoleColor.Cyan; 
                Console.WriteLine("Geben Sie bitte Ihre Rechnung ein (z.B. 12 + 5):");
                string eingabe = Console.ReadLine();

                double zahl1 = 0, zahl2 = 0;
                char operatorSymbol = ' ';
                bool gefunden = false;

                foreach (char c in eingabe)
                {
                    if (c == '+' || c == '-' || c == '*' || c == '/')
                    {
                        operatorSymbol = c;
                        string[] teile = eingabe.Split(c);
                        if (teile.Length == 2 && double.TryParse(teile[0], out zahl1) && double.TryParse(teile[1], out zahl2))
                        {
                            gefunden = true;
                            break;
                        }
                    }
                }

                if (!gefunden)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ungültige Eingabe. Bitte versuchen Sie es erneut.");
                    continue; 
                }

                switch (operatorSymbol)
                {
                    case '+':
                        ergebnis = zahl1 + zahl2;
                        break;
                    case '*':
                        ergebnis = zahl1 * zahl2;
                        break;
                    case '-':
                        ergebnis = zahl1 - zahl2;
                        break;
                    case '/':
                        if (zahl2 == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red; 
                            Console.WriteLine("Fehler: Division durch 0 ist nicht erlaubt.");
                        }
                        else
                        {
                            ergebnis = zahl1 / zahl2;
                        }
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red; 
                        Console.WriteLine("Ungültiger Operator. Bitte versuchen Sie es erneut.");
                        break;
                }

                
                if (operatorSymbol != '/' || zahl2 != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green; 
                    Console.WriteLine($"{name}, Ihr Ergebnis lautet: {ergebnis}");
                }

                
                bool ungültigeAntwort = true;
                while (ungültigeAntwort)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan; 
                    Console.WriteLine($"{name}, wollen Sie noch eine Rechnung eingeben? (Ja oder Nein)");
                    string weiter = Console.ReadLine();

                    if (string.Equals(weiter, "nein", StringComparison.OrdinalIgnoreCase))
                    {
                        wiederholen = false;
                        ungültigeAntwort = false; 
                    }
                    else if (string.Equals(weiter, "ja", StringComparison.OrdinalIgnoreCase))
                    {
                        ungültigeAntwort = false; 
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Sie müssen 'Ja' oder 'Nein' schreiben.");
                    }
                }
            }

            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Vielen Dank für die Nutzung des Rechners!");

            
            Console.ResetColor();
        }
    }
}