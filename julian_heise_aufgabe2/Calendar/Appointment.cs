using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CalendarLib
{
    public class Appointment
    {
        private string time;
        private string date;

        /// <summary>
        /// Property mit Überprüfung einer Business Rule
        /// </summary>
        public string Date
        {
            get
            {
                return date;
            }
            set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentException("Die Angabe des Datums ist Pflicht");
                }
                if (!Regex.Match(value, @"([0-9]{1,2})\.([0-9]{1,2})\.([0-9]{1,2})?([0-9]{1,2})", RegexOptions.IgnoreCase).Success)
                {
                    throw new FormatException("Datumsformat muss in dd.mm.yyyy oder dd.mm.yy angegeben werden");
                }
                date = value;
            }
        }

        /// <summary>
        /// Property mit Überprüfung einer Business Rule
        /// </summary>
        public string Time
        {
            get
            {
                return time;
            }
            set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentException("Die Angabe der Zeit ist Pflicht");
                }
                if (!Regex.Match(value, @"([0-9]{1,2}):([0-9]{1,2})", RegexOptions.IgnoreCase).Success)
                {
                    throw new FormatException("Zeitformat muss in hh:mm angegeben werden");
                }
                time = value;
            }
        }

        private string title;

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentException("Die Angabe eines Titels ist Pflicht");
                }
                title = value;
            }
        }

        public string Description
        {
            get;
            set;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Date, Time, Title);
        }
    }
}
