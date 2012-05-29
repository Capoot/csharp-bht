using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace adows
{
    class AdoSqlConsole
    {
        private static string promt;

        static void Main(string[] args)
        {
            MySqlConnection connection = null;

            try
            {
                connection = login();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(-1);
            }

            Console.WriteLine("Connected!");

            while (true)
            {
                string statement = doPromt();
                if (statement.ToLower() == "bye" || statement.ToLower() == "exit" || statement.ToLower() == "logout")
                {
                    break;
                }
                if (statement == "")
                {
                    continue;
                }
                try
                {
                    execute(statement, connection);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            connection.Close();
            Console.WriteLine("Disconnected!");
        }

        private static void execute(string statement, MySqlConnection connection)
        {
            MySqlCommand c = connection.CreateCommand();
            c.CommandText = statement;

            if (statement.ToLower().StartsWith("select"))
            {
                printResults(c.ExecuteReader());
            }
            else
            {
                c.ExecuteNonQuery();
            }
        }

        private static void printResults(MySqlDataReader r)
        {
            while (r.Read())
            {
                for (int i = 0; i < r.FieldCount; i++)
                {
                    Console.Write(r[i]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            r.Close();
        }

        private static string doPromt()
        {
            Console.Write(promt);
            return Console.ReadLine();
        }

        private static MySqlConnection login()
        {
            string server;
            string uid;
            string pw;

            Console.Write("Server: ");
            server = Console.ReadLine();
            Console.Write("UID: ");
            uid = Console.ReadLine();
            Console.Write("Password: ");
            
            ConsoleKeyInfo c;
            StringBuilder b = new StringBuilder();
            while(true)
            {
                c = Console.ReadKey();
                if (c.Key == ConsoleKey.Enter)
                {
                    break;
                }
                b.Append(c.ToString());
            }
            pw = b.ToString();

            string loginData;
            if (pw == "")
            {
                loginData = string.Format("SERVER={0};UID={1};", server, uid);
            }
            else
            {
                loginData = string.Format("SERVER={0};UID={1};PASSWORD={2}", server, uid, pw);
            }

            MySqlConnection connection;
            connection = new MySqlConnection(loginData);
            connection.Open();
            promt = string.Format("{1}@{0} >> ", server, uid);
            return connection;
        }        
    }
}
