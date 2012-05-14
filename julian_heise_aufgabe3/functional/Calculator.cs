using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace functional
{
    class Calculator
    {
        private Dictionary<string, Func<int, int, int>> operations = new Dictionary<string, Func<int, int, int>>
        {
            {"add", (a, b) => checked(a + b) },
            {"sub", (a, b) => checked(a - b) },
            {"mul", (a, b) => checked(a * b) },
            {"div", (a, b) => checked(a / b) },
            {"mod", (a, b) => checked(a % b) },

            // *** Erweiterung um zusätzliche Rechenoperationen ***

            // Potenz
            {"pow", (a, b) => checked((int)Math.Pow(a, b)) },

            // Konkatenation zweier Zahlen
            {"conc", (a, b) => checked(int.Parse(a + "" +b)) }
        };

        public int eval(int left, string op, int right)
        {
            Func<int, int, int> function = operations[op];
            return function(left, right);
        }

        public void addOperator(string name, Func<int, int, int> function)
        {
            operations.Add(name, function);
        }
    }
}
