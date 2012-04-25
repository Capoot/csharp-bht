using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApp
{
    public class ConsoleUtil
    {
        public static void printKeyValueList(params KeyValuePair<string, string>[] items)
        {
            foreach(KeyValuePair<string, string> item in items)
            {
                Console.WriteLine("{0}: {1}", item.Key, item.Value);
            }
        }
    }
}
