using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarLib
{
    public class BusinessTask : Task
    {
        public BusinessTask(string title, string description, string due, Priority priority, string company, string contactPerson) : base(title, due, priority, description)
        {
            Company = company;
            ContactPerson = contactPerson;
        }

        public string Company
        {
            get;
            set;
        }

        public string ContactPerson
        {
            get;
            set;
        }

        public string Icon
        {
            get { return "user_gray.png"; }
        }
    }
}
