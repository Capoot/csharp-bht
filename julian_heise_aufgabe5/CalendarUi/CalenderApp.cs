using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CalendarLib;
using System.Text.RegularExpressions;

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

        private CalenderApp() {
            AppointmentType = AppointmentTypeFilter.None;
        }

        #endregion

        #region Events

        public delegate void AppointmentsChangedHandler();
        public event AppointmentsChangedHandler AppointmentsChanged;

        private void fireAppointmentsChanged()
        {
            if (AppointmentsChanged != null)
            {
                AppointmentsChanged();
            }
        }

        public delegate void TasksChangedHandler();
        public event TasksChangedHandler TasksChanged;

        private void fireTasksChanged()
        {
            if (TasksChanged != null)
            {
                TasksChanged();
            }
        }

        #endregion

        private List<Appointment> appointments = new List<Appointment>();
        private List<Task> tasks = new List<Task>();

        private string appointmentfilter = ".*";
        private string taskfilter = ".*";

        private AppointmentTypeFilter appTypeFilter;
        public AppointmentTypeFilter AppointmentType
        {
            get
            {
                return appTypeFilter;
            }
            set
            {
                appTypeFilter = value;
                InvalidateAppointments();
            }
        }

        private TaskTypeFilter taskTypeFilter;
        public TaskTypeFilter TaskType
        {
            get
            {
                return taskTypeFilter;
            }
            set
            {
                taskTypeFilter = value;
                InvalidateTasks();
            }
        }

        public Appointment[] Appointments
        {
            get
            {
                IEnumerable<Appointment> preFiltered = appointments;
                // Linq Abfragen zum Vorfiltern der Termine nach Klassentyp
                if (AppointmentType == AppointmentTypeFilter.Date)
                {
                    preFiltered = from appointment in this.appointments
                                      where appointment is Date
                                      select appointment;
                }
                else if (AppointmentType == AppointmentTypeFilter.Deadline)
                {
                    preFiltered = from appointment in this.appointments
                                  where appointment is Deadline
                                  select appointment;
                }
                // Linq Abfrage für das Filtern von Terminen
                // Das Prädikat für die Auswahl setzt sich aus mehreren Kriterien zusammen
                // und ist in der Methode appointmentIsMatch(appointment, appointmentfilter)
                // untergebracht.
                var items = from appointment in preFiltered
                            where appointmentIsMatch(appointment, appointmentfilter)
                            select appointment;
                return items.ToArray();
            }
        }

        private bool appointmentIsMatch(Appointment appointment, string filter)
        {
            bool match = false;
            match |= Regex.IsMatch(appointment.Title, filter, RegexOptions.IgnoreCase);
            match |= Regex.IsMatch(appointment.Description, filter, RegexOptions.IgnoreCase);
            match |= Regex.IsMatch(appointment.Date, filter, RegexOptions.IgnoreCase);
            return match;
        }

        public Task[] Tasks
        {
            get
            {
                IEnumerable<Task> preFiltered = tasks;
                // Linq Abfragen zum Vorfiltern der Aufgaben nach Klassentyp
                if (TaskType == TaskTypeFilter.BusinessTask)
                {
                    preFiltered = from task in this.tasks
                                  where task is BusinessTask
                                  select task;
                }
                else if (TaskType == TaskTypeFilter.PrivateTask)
                {
                    preFiltered = from task in this.tasks
                                  where task is PrivateTask
                                  select task;
                }
                // Linq Abfrage für das Filtern von Aufgaben
                // Das Prädikat für die Auswahl setzt sich aus mehreren Kriterien zusammen
                // und ist in der Methode taskIsMatch(task, taskfilter)
                // untergebracht.
                var items = from task in preFiltered
                            where taskIsMatch(task, taskfilter)
                            select task;
                return items.ToArray();
            }
        }

        private bool taskIsMatch(Task task, string filter)
        {
            bool match = false;
            match |= Regex.IsMatch(task.Title, filter, RegexOptions.IgnoreCase);
            match |= Regex.IsMatch(task.Description, filter, RegexOptions.IgnoreCase);
            match |= Regex.IsMatch(task.Due, filter, RegexOptions.IgnoreCase);
            return match;
        }

        public void AddAppointment(Appointment a)
        {
            appointments.Add(a);
            fireAppointmentsChanged();
        }

        public void RemoveAppointment(Appointment a)
        {
            appointments.Remove(a);
            fireAppointmentsChanged();
        }

        public void AddTask(Task t)
        {
            tasks.Add(t);
            fireTasksChanged();
        }

        public void RemoveTask(Task t)
        {
            tasks.Remove(t);
            fireTasksChanged();
        }

        internal void InvalidateAppointments()
        {
            fireAppointmentsChanged();
        }

        internal void InvalidateTasks()
        {
            fireTasksChanged();
        }

        public void FilterAppointments(string filter)
        {
            this.appointmentfilter = filter;
            InvalidateAppointments();
        }

        public void FilterTasks(string filter)
        {
            this.taskfilter = filter;
            InvalidateTasks();
        }
    }

    public enum AppointmentTypeFilter
    {
        None,
        Date,
        Deadline
    }

    public enum TaskTypeFilter
    {
        None,
        PrivateTask,
        BusinessTask
    }
}
