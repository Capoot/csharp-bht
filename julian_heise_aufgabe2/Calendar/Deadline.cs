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
    }
}
