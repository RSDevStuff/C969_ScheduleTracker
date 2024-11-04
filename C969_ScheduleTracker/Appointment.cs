using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mysqlx.Resultset;


namespace C969_ScheduleTracker
{
    public class Appointment
    {
        public DateTime Date { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Type { get; set; }
        public User AssignedUser { get; set; }
        public Customer AssignedCustomer { get; set; }

        public Appointment(DateTime date, DateTime start, DateTime end, string type, User assignedUser,
            Customer assignedCustomer)
        {
            Date = date;
            Start = start;
            End = end;
            Type = type;
            AssignedUser = assignedUser;
            AssignedCustomer = assignedCustomer;
        }
    }
}

