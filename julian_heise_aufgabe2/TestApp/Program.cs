using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CalendarLib;

namespace TestApp
{
    class Program
    {
        private static Calendar calendar;

        static void Main(string[] args)
        {
            calendar = new Calendar();

            while (true)
            {
                int action;
                printMenu();
                readInt("Wählen Sie eine Aktion aus: ", out action);

                switch (action)
                {
                    case 1:
                    {
                        listAppointments();
                        break;
                    }
                    case 2:
                    {
                        createAppointment();
                        break;
                    }
                    case 3:
                    {
                        listTasks();
                        break;
                    }
                    case 4:
                    {
                        createTask();
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("Auf Wiedersehen!");
                        Environment.Exit(0);
                        break;
                    }
                }
            }
        }

        private static void printMenu()
        {
            Console.Clear();
            Console.WriteLine("*** Terminplaner Hauptmenü ***");
            Console.WriteLine("(1) Termine anzeigen");
            Console.WriteLine("(2) Termin erstellen");
            Console.WriteLine("(3) Aufgaben anzeigen");
            Console.WriteLine("(4) Aufgabe erstellen");
            Console.WriteLine("(5) Beenden");
        }

        private static void createTask()
        {
            Console.Clear();
            Console.WriteLine("*** Neue Aufgabe ***");

            int type;
            while (true)
            {
                readInt("Geschäftlich (1) oder privat (2): ", out type);
                if (type == 1 || type == 2)
                {
                    break;
                }
                Console.WriteLine("Ungültige Eingabe. Bitte geben Sie 1 oder 2 ein.");
            }

            string[] data = new string[5];
            Priority priority;
            readTaskProperties(out data[0], out data[1], out data[2], out priority);

            if (type == 1)
            {
                readBusinessTaskProperties(out data[3], out data[4]);
                // Erzeugen durch Constructor Chaining
                calendar.Tasks.Add(
                    new BusinessTask(data[0], data[1], data[2], priority, data[3], data[4]));
                return;
            }

            if (type == 2)
            {
                readPrivateTaskProperties();
                // Erzeugen durch Constructor Chaining
                calendar.Tasks.Add(
                    new PrivateTask(data[2], data[0], priority, data[1]));
            }
        }

        private static void readTaskProperties(out string title, out string description, out string due, out Priority priority)
        {
            Console.Write("Titel: ");
            title = Console.ReadLine();
            Console.Write("Beschreibung: ");
            description = Console.ReadLine();
            Console.Write("Fälligkeitsdatum: ");
            due = Console.ReadLine();
            while (true)
            {
                int prio;
                readInt("Priorität (1 = niedrig, 2 = normal, 3 = hoch): ", out prio);
                if (prio == 1)
                {
                    priority = Priority.Low;
                    break;
                }
                if (prio == 2)
                {
                    priority = Priority.Normal;
                    break;
                }
                if (prio == 3)
                {
                    priority = Priority.High;
                    break;
                }
                Console.WriteLine("Ungültige Eingabe. Bitte geben Sie 1, 2 oder 3 ein.");
            }
        }

        private static void readPrivateTaskProperties()
        {
        }

        private static void readBusinessTaskProperties(out string company, out string contactPerson)
        {
            Console.Write("Auftraggeber: ");
            company = Console.ReadLine();
            Console.Write("Kontaktperson: ");
            contactPerson = Console.ReadLine();
        }

        /// <summary>
        /// Diese Methode demonstriert die Verwendung von Parameterlisten (params keyword)
        /// </summary>
        private static void listTasks()
        {
            foreach (Task task in calendar.Tasks)
            {
                Console.Clear();
                if (task is BusinessTask)
                {
                    Console.WriteLine("*** Geschäftliche Aufgabe ***");
                }
                if (task is PrivateTask)
                {
                    Console.WriteLine("*** Private Aufgabe ***");
                }

                ConsoleUtil.printKeyValueList(
                    new KeyValuePair<string, string>("Titel", task.Title),
                    new KeyValuePair<string, string>("Beschreibung", task.Description),
                    new KeyValuePair<string, string>("Fälligkeitsdatum", task.Due),
                    new KeyValuePair<string, string>("Priorität", task.Priority.ToString()));

                if (task is BusinessTask)
                {
                    BusinessTask b = (BusinessTask)task;
                    ConsoleUtil.printKeyValueList(
                        new KeyValuePair<string, string>("Auftraggeber", b.Company),
                        new KeyValuePair<string, string>("Kontaktperson", b.ContactPerson));
                }

                Console.WriteLine("\nBeliebige Taste drücken, um nächsten Termin anzuzeigen...");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Diese Methode demonstriert die Verwendung von Parameterlisten (params keyword)
        /// </summary>
        private static void listAppointments()
        {
            foreach (Appointment app in calendar.Appointments)
            {
                Console.Clear();
                if(app is Date)
                {
                    Console.WriteLine("*** Date ***");
                }
                if (app is Deadline)
                {
                    Console.WriteLine("*** Deadline ***");
                }
                
                ConsoleUtil.printKeyValueList(
                    new KeyValuePair<string, string>("Titel", app.Title),
                    new KeyValuePair<string, string>("Beschreibung", app.Description),
                    new KeyValuePair<string, string>("Datum", app.Date),
                    new KeyValuePair<string, string>("Uhrzeit", app.Time));

                if (app is Date)
                {
                    Date d = (Date)app;
                    ConsoleUtil.printKeyValueList(
                        new KeyValuePair<string, string>("Ort", d.Location),
                        new KeyValuePair<string, string>("Kontaktperson", d.ContactPerson));
                }
                if (app is Deadline)
                {
                    Deadline d = (Deadline)app;
                    ConsoleUtil.printKeyValueList(
                        new KeyValuePair<string, string>("Projekt", d.Project));
                }

                Console.WriteLine("\nBeliebige Taste drücken, um nächsten Termin anzuzeigen...");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Diese Methode demonstriert Objekt-Initialisierer
        /// </summary>
        private static void createAppointment()
        {
            Console.Clear();
            Console.WriteLine("*** Neuen Termin Erstellen ***");
           
            int type;
            while (true)
            {
                readInt("Date (1) oder Deadline (2): ", out type);
                if (type == 1 || type == 2)
                {
                    break;
                }
                Console.WriteLine("Ungültige Eingabe. Bitte geben Sie 1 oder 2 ein.");
            }

            string[] data = new string[6];
            readAppointmentProperties(out data[0], out data[1], out data[2], out data[3]);

            if (type == 1)
            {
                readDateProperties(out data[4], out data[5]);
                // Erzeugen durch Objekt-Initialisierer
                calendar.Appointments.Add(
                    new Date
                    {
                        Title = data[0],
                        Description = data[1],
                        Date = data[2],
                        Time = data[3],
                        Location = data[4],
                        ContactPerson = data[5]
                    });
                return;
            }

            if (type == 2)
            {
                readDeadlineProperties(out data[4]);
                calendar.Appointments.Add(
                    new Deadline
                    {
                        Title = data[0],
                        Description = data[1],
                        Date = data[2],
                        Time = data[3],
                        Project = data[4]
                    });
            }
        }

        /// <summary>
        /// Diese Methode demonstriert einen out parameter
        /// </summary>
        /// <param name="message"></param>
        /// <param name="value"></param>
        private static void readInt(string message, out int value)
        {
            while (true)
            {
                try
                {
                    Console.Write(message);
                    value = int.Parse(Console.ReadLine());
                    return;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Bitte wiederholen Sie die Eingabe");
                }
            }
        }

        /// <summary>
        /// Diese Methode demonstriert mehrere out Parameter
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="date"></param>
        /// <param name="time"></param>
        private static void readAppointmentProperties(out string title, out string description, out string date, out string time)
        {
            Console.Write("Titel: ");
            title = Console.ReadLine();
            Console.Write("Beschreibung: ");
            description = Console.ReadLine();
            Console.Write("Datum: ");
            date = Console.ReadLine();
            Console.Write("Uhrzeit: ");
            time = Console.ReadLine();
        }
        
        private static void readDateProperties(out string location, out string contactPerson)
        {
            Console.Write("Ort: ");
            location = Console.ReadLine();
            Console.Write("Kontaktperson: ");
            contactPerson = Console.ReadLine();
        }

        private static void readDeadlineProperties(out string project)
        {
            Console.Write("Projekt: ");
            project = Console.ReadLine();
        }
    }
}
