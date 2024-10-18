using System;

namespace Rechner
{
    class Program
    {
        static void Main(string[] args)
        {
            ColoredPrint("Wie wollen Sie genannt werden?", ConsoleColor.Cyan);
            string name = Console.ReadLine();
            ColoredPrint($"Willkommen {name}", ConsoleColor.Cyan);

            bool wiederholen = true;

            while (wiederholen)
            {
                string eingabe = GetUserInput(name);
                if (TryParseUserInput(eingabe, out double zahl1, out double zahl2, out char operatorSymbol))
                {
                    double ergebnis = BerechneErgebnis(zahl1, zahl2, operatorSymbol);
                    if (operatorSymbol != '/' || zahl2 != 0)
                    {
                        ColoredPrint($"{name}, Ihr Ergebnis lautet: {ergebnis}", ConsoleColor.Green);
                    }
                }

                wiederholen = GetUserRepeat(name);
            }

            ColoredPrint("Vielen Dank für die Nutzung des Rechners!", ConsoleColor.Cyan);
        }

        static string GetUserInput(string name)
        {
            ColoredPrint($"{name}, geben Sie bitte Ihre Rechnung ein:", ConsoleColor.Cyan);
            return Console.ReadLine();
        }

        static bool TryParseUserInput(string eingabe, out double zahl1, out double zahl2, out char operatorSymbol)
        {
            zahl1 = 0;
            zahl2 = 0;
            operatorSymbol = ' ';
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
                ColoredPrint("Ungültige Eingabe. Bitte versuchen Sie es erneut.", ConsoleColor.Red);
            }

            return gefunden;
        }

        static double BerechneErgebnis(double zahl1, double zahl2, char operatorSymbol)
        {
            double ergebnis = 0;

            switch (operatorSymbol)
            {
                case '+':
                    ergebnis = zahl1 + zahl2;
                    break;
                case '-':
                    ergebnis = zahl1 - zahl2;
                    break;
                case '*':
                    ergebnis = zahl1 * zahl2;
                    break;
                case '/':
                    if (zahl2 == 0)
                    {
                        ColoredPrint("Fehler: Division durch 0 ist nicht erlaubt.", ConsoleColor.Red);
                    }
                    else
                    {
                        ergebnis = zahl1 / zahl2;
                    }
                    break;
                default:
                    ColoredPrint("Ungültiger Operator. Bitte versuchen Sie es erneut.", ConsoleColor.Red);
                    break;
            }

            return ergebnis;
        }

        static bool GetUserRepeat(string name)
        {
            bool ungültigeAntwort = true;
            bool wiederholen = false;

            while (ungültigeAntwort)
            {
                ColoredPrint($"{name}, wollen Sie noch eine Rechnung eingeben? (Ja oder Nein)", ConsoleColor.Cyan);
                string weiter = Console.ReadLine();

                if (string.Equals(weiter, "nein", StringComparison.OrdinalIgnoreCase))
                {
                    wiederholen = false;
                    ungültigeAntwort = false;
                }
                else if (string.Equals(weiter, "ja", StringComparison.OrdinalIgnoreCase))
                {
                    wiederholen = true;
                    ungültigeAntwort = false;
                }
                else
                {
                    ColoredPrint("Sie müssen 'Ja' oder 'Nein' schreiben.", ConsoleColor.Red);
                }
            }

            return wiederholen;
        }

        static void ColoredPrint(string text, ConsoleColor color)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = currentColor;
        }

        static void RainbowPrint(string text)
        {
            ConsoleColor[] rainbowColors = {
                ConsoleColor.Red,
                ConsoleColor.Yellow,
                ConsoleColor.Green,
                ConsoleColor.Cyan,
                ConsoleColor.Blue,
                ConsoleColor.Magenta
            };

            int colorIndex = 0;

            foreach (char c in text)
            {
                Console.ForegroundColor = rainbowColors[colorIndex];
                Console.Write(c);
                colorIndex = (colorIndex + 1) % rainbowColors.Length;
            }

            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
