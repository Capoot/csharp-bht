using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace functional
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();

            while (true)
            {
                printHeader();

                string input = readInput();
                int left;
                int right;
                string op;

                try
                {
                    validate(input);
                    parse(input, out left, out right, out op);
                    Console.WriteLine(calc.eval(left, op, right));
                }
                catch (Exception e)
                {
                    Console.WriteLine("\n\nFehler: {0}", e.Message);
                }

                Console.WriteLine("\n*** Weiter mit beliebiger Taste, <ESC> zum Beenden ***");
                if (Console.ReadKey().KeyChar == 27)
                {
                    exit();
                }
            }
            
        }

        /// <summary>
        /// Schreibt die Überschrift und den Hilfetext auf die Konsole
        /// </summary>
        private static void printHeader()
        {
            Console.Clear();
            Console.WriteLine("*** Funktionaler Rechner (von Julian Heise, s782691) ***");
            Console.WriteLine("Bitte eine Formel eingeben in der Form (zahl)(operator)(zahl)");
            Console.WriteLine("Unterstützte Operatoren: ");
            Console.WriteLine("\t+, -, *, /, %");
            Console.WriteLine("\ta>b (a hoch b)");
            Console.WriteLine("\ta.b (konkateniert a mit b, Bsp: 1.1=11)");
            Console.WriteLine();
            Console.WriteLine("Die Eingabe von \"=\" oder <ENTER> startet die Berechnung.");
            Console.WriteLine("<ESC> zum beenden");
            Console.WriteLine();
        }

        /// <summary>
        /// Liest die Eingabe zeichenweise von der Konsole
        /// </summary>
        private static string readInput()
        {
            StringBuilder builder = new StringBuilder();
            do
            {
                char character = Console.ReadKey().KeyChar;
                // Escape
                if ((int)character == 27)
                {
                    exit();
                }
                // Backspace
                if ((int)character == 8)
                {
                    removeCharFrom(builder);
                    continue;
                }
                // Enter
                if ((int)character == 13)
                {
                    builder.Append("=");
                    Console.Write(builder.ToString());
                }
                else
                {
                    builder.Append(character);
                }
            } while (!builder.ToString().EndsWith("="));
            return builder.ToString();
        }

        /// <summary>
        /// Helfer für das Löschen eines Zeichens wenn der User Backspace drückt
        /// </summary>
        private static void removeCharFrom(StringBuilder builder)
        {
            try
            {
                builder.Remove(builder.ToString().Length - 1, 1);
            }
            catch (ArgumentOutOfRangeException)
            {
                // ignorieren. benutzer hat backspace gedrückt
            }
        }

        private static void exit()
        {
            Console.WriteLine("\n\nBye bye");
            Environment.Exit(0);
        }

        /// <summary>
        /// Prüft per Regex, ob Eingabestring gültig
        /// </summary>
        private static void validate(string input)
        {
            Regex regex = new Regex(@"\s*([0-9]+)\s*([\*/\+\-%>\.])\s*([0-9]+)\s*=");
            if (!regex.IsMatch(input, 0))
            {
                throw new FormatException("Akzeptiere nur mathematische Formeln mit einem Operator. Platzhalter sind nicht erlaubt!");
            }
        }

        /// <summary>
        /// Zerlegt den Eingabestring in seine Bestandteile
        /// </summary>
        private static void parse(string input, out int left, out int right, out string op)
        {
            input.Trim();
            int index = 0;
            left = readNumber(input, ref index);
            op = readOperator(input, ref index);
            right = readNumber(input, ref index);
        }

        /// <summary>
        /// Wandelt den Operator aus der Eingabe in den richtigen Key fürs Dictionary um
        /// </summary>
        private static string readOperator(string input, ref int index)
        {
            char op = input[index++];
            switch (op)
            {
                case '*': { return "mul"; }
                case '+': { return "add"; }
                case '-': { return "sub"; }
                case '/': { return "div"; }
                case '%': { return "mod"; }
                case '>': { return "pow"; }
                case '.': { return "conc"; }
                default:
                {
                    throw new FormatException("Ungültiger Operator: " + op);
                }
            }
        }

        /// <summary>
        /// Parsed eine int Zahl aus der Eingabe
        /// </summary>
        private static int readNumber(string input, ref int index)
        {
            StringBuilder builder = new StringBuilder();
            while (char.IsDigit(input[index]))
            {
                builder.Append(input[index]);
                index++;
            }
            return int.Parse(builder.ToString());
        }
    }
}
