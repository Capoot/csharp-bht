using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarLib
{
    public class Calendar
    {
        private List<Appointment> appointments = new List<Appointment>();
        private List<Task> tasks = new List<Task>();

        public List<Appointment> Appointments
        {
            get
            {
                return appointments;
            }
        }

        public List<Task> Tasks
        {
            get
            {
                return tasks;
            }
        }
    }
}
