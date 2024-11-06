﻿using System;
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
        public string Customer {get; set; }
        public DateTime Date { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Type { get; set; }
        public int UserId { get; set; }
        public int CustomerId { get; set; }

        public Appointment(){}
        public Appointment(string customerName, DateTime date, DateTime start, DateTime end, string type, int assignedUser,
            int assignedCustomer)
        {
            Customer = customerName;
            Date = date;
            Start = start;
            End = end;
            Type = type;
            UserId = assignedUser;
            CustomerId = assignedCustomer;
        }
    }
}

