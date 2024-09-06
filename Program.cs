using System;

namespace Taschenrechner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wie wollen Sie genannt werden?");
            string name = Console.ReadLine();
            Console.WriteLine("Willkommen " + name);
            bool isContinue = true;
            while (isContinue)
            {

                double resultat = 0;
                double Zahl1 = 0;
                double Zahl2 = 0;

                bool wiederholung2 = false;
                while (!wiederholung2)
                {
                    Console.WriteLine("Gebene Sie die erste Zahl ein");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    string eingabe = Console.ReadLine();
                    Console.ResetColor();   

                    if (double.TryParse(eingabe, out Zahl1))
                    {

                        wiederholung2 = true;
                    }
                    else
                    {
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine("Geben Sie bitte ein Zahl ein! ");
                        Console.ResetColor();

                        wiederholung2 = false;

                    }
                }

          
                bool wiederholung3 = false;
                while (!wiederholung3)
                {
                    Console.WriteLine("Geben Sie die zweite Zahl ein");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    string eingabe2 = Console.ReadLine();
                    Console.ResetColor();

                    if (double.TryParse(eingabe2, out Zahl2))
                    {

                        wiederholung3 = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Geben Sie bitte ein Zahl ein! ");
                        Console.ResetColor();
                        wiederholung3 = false;

                    }
                }
                
                
                bool wiederholung1 = false;
                while (!wiederholung1)
                {
                    Console.WriteLine(name + ", wie wollen Sie rechnen? (+,-,*,/) ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    string rechnung = Console.ReadLine();
                    Console.ResetColor();


                    if (rechnung == "+")
                    {
                        resultat = Zahl1 + Zahl2;
                        wiederholung1 = true;
                    }
                    else if (rechnung == "-")
                    {
                        resultat = Zahl1 - Zahl2;
                        wiederholung1 = true;
                    }
                    else if (rechnung == "*")
                    {
                        resultat = Zahl1 * Zahl2;
                        wiederholung1 = true;
                    }
                    else if (rechnung == "/")
                    {
                        resultat = Zahl1 / Zahl2;
                        wiederholung1 = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Geben Sie bitte eine der gennanten texte ein (+,-,*,/) ");
                        Console.ResetColor();
                        wiederholung1 = false;
                    }

                }
                Console.WriteLine("Ihr Resultat lautet:");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(resultat);
                Console.ResetColor();

                bool wiederholung = false;
                while (!wiederholung)
                {
                    Console.WriteLine(name + ", wollen Sie noch eine Rechnung eingeben? Schreiben Sie bitte Ja oder Nein.");
                    string weiter = Console.ReadLine();

                    if (string.Equals(weiter, "nein", StringComparison.OrdinalIgnoreCase))
                    {
                        isContinue = false;
                        wiederholung = true;
                    }
                    else if (string.Equals(weiter, "ja", StringComparison.OrdinalIgnoreCase))
                    {
                        isContinue = true;
                        wiederholung = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Sie müssen Ja oder Nein schreiben.");
                        Console.ResetColor();
                        wiederholung = false;
                    }
                    
                }
                              
         
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Okey " + name + ", ich wünsche Ihnen noch einen schönen Tag.");
            Console.ResetColor();
        }

    }
}