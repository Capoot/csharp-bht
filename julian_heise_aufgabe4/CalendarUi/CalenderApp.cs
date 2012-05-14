using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CalendarLib;

namespace CalendarUi
{
    class CalenderApp
    {
        #region Singleton

        private static CalenderApp INSTANCE;

        public static CalenderApp Instance
        {
            get
            {
                if (INSTANCE == null)
                {
                    INSTANCE = new CalenderApp();
                }
                return INSTANCE;
            }
        }

        private CalenderApp() { }

        #endregion

        #region Events

        public delegate void AppointmentsChangedHandler(object sender, EventArgs e);
        public event AppointmentsChangedHandler AppointmentsChanged;

        private void fireAppointmentsChanged(EventArgs args)
        {
            if (AppointmentsChanged != null)
            {
                AppointmentsChanged(this, args);
            }
        }

        #endregion

        private List<Appointment> appointments = new List<Appointment>();
        private List<Task> tasks = new List<Task>();

        public Appointment[] Appointments
        {
            get
            {
                return appointments.ToArray();
            }
        }

        public Task[] Tasks
        {
            get
            {
                return tasks.ToArray();
            }
        }

        public void AddAppointment(Appointment a)
        {
            appointments.Add(a);
            fireAppointmentsChanged(EventArgs.Empty);
        }

        public void RemoveAppointment(Appointment a)
        {
            appointments.Remove(a);
            fireAppointmentsChanged(EventArgs.Empty);
        }

        public void AddTask(Task t)
        {
            tasks.Add(t);
        }

        public void RemoveTask(Task t)
        {
            tasks.Remove(t);
        }

        internal void InvalidateAppointments()
        {
            fireAppointmentsChanged(EventArgs.Empty);
        }
    }
}
