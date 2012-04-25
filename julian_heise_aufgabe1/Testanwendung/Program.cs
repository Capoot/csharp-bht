using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CalculatorAssembly;

namespace Testanwendung
{
    class Program
    {
        static void Main(string[] args)
        {
            printHeader();
            calculateUnchecked();
            calculateChecked();
            totalCrossLoop();
        }

        private static void printHeader()
        {
            Console.WriteLine("C# Aufgabe 1 von Julian Heise (s782691), 20.04.2012");
            Console.WriteLine("Verwende Calculator Assembly zum berechnen");
            Console.WriteLine();
        }

        private static void calculateUnchecked()
        {
            Console.WriteLine("Es folgen *unchecked* Rechenoperationen:\n");
            Console.WriteLine("\tint.MaxValue + 1 = {0}", Calculator.add(int.MaxValue, 1));
            Console.WriteLine("\t(int.MaxValue / 2) * 3 = {0}", Calculator.multiply(int.MaxValue / 2, 3));
            Console.WriteLine();
        }

        private static void calculateChecked()
        {
            Console.WriteLine("Es folgen *checked* Rechenoperationen:\n");
            try
            {
                Console.Write("\tint.MaxValue + 1 = ");
                Console.WriteLine(Calculator.addChecked(int.MaxValue, 1));
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Fehler: " + e.Message);
            }
            try
            {
                Console.Write("\t(int.MaxValue / 2) * 3 = ");
                Console.WriteLine(Calculator.multiplyChecked(int.MaxValue / 2, 3));
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Fehler: {0}", e.Message);
            }
        }

        private static void totalCrossLoop()
        {
            while (true)
            {
                Console.WriteLine();
                Console.Write("Bitte geben Sie eine Zahl ein, deren Quersumme berechnet werden soll (0 zum beenden):");
                int n = 0;
                try
                {
                    n = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Ungültige Eingabe: {0}", e.Message);
                    continue;
                }
                if (n == 0)
                {
                    return;
                }
                Console.WriteLine("\tDie Quersumme ist: {0}", Calculator.totalCross(n));
            }
        }
    }
}
