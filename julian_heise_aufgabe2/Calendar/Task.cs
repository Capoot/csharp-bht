using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarLib
{
    public abstract class Task
    {
        public Task() {}

        public Task(string due, string title)
        {
            Due = due;
            Title = title;
        }

        /// <summary>
        /// Demonstration von Constructor Chaining
        /// </summary>
        public Task(string due, string title, Priority priority, string description) : this(due, title) {
            Priority = priority;
            Description = description;
        }

        // Generated Properties

        public string Due
        {
            get;
            set;
        }

        public String Title
        {
            get;
            set;
        }

        public String Description
        {
            get;
            set;
        }

        public Priority Priority
        {
            get;
            set;
        }
    }
}
