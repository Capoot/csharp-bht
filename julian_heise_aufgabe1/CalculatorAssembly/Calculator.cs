using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorAssembly
{
    public class Calculator
    {
        public static int add(int a, int b)
        {
            return a + b;
        }

        public static int addChecked(int a, int b)
        {
            return checked(a + b);
        }

        public static int multiply(int a, int b)
        {
            return a * b;
        }

        public static int multiplyChecked(int a, int b)
        {
            return checked(a * b);
        }

        public static int totalCross(int n)
        {
            int sum = 0;
            foreach(char c in n.ToString().ToCharArray()) {
                sum += int.Parse(c.ToString());
            }
            return sum;
        }
    }
}
