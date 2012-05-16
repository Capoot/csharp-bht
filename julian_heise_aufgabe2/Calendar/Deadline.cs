using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarLib
{
    public class Deadline : Appointment
    {
        public string Project
        {
            get;
            set;
        }

        public override string ToString()
        {
            return base.ToString() + " (Deadline)";
        }

        public string Icon
        {
            get { return "date.png"; }
        }
    }
}
