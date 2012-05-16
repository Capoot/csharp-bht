using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarLib
{
    public class PrivateTask : Task
    {
        public PrivateTask(string due, string title) : base(due, title){}

        public PrivateTask(string due, string title, Priority priority, string description)
            : base(due, title, priority, description) { }

        public string Icon
        {
            get { return "house.png"; }
        }
    }
}
