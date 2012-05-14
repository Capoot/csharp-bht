using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarLib
{
    public class Date : Appointment
    {
        public string Location
        {
            get;
            set;
        }

        public string ContactPerson
        {
            get;
            set;
        }

        public override string ToString()
        {
            return base.ToString() + " (Verabredung)";
        }
    }
}
