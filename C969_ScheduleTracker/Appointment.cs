

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
        public int AppointmentId {get; set; }

        public Appointment(){}
        public Appointment(string customerName, DateTime date, DateTime start, DateTime end, string type, int assignedUser,
            int assignedCustomer, int appointmentId)
        {
            Customer = customerName;
            Date = date;
            Start = start;
            End = end;
            Type = type;
            UserId = assignedUser;
            CustomerId = assignedCustomer;
            AppointmentId = appointmentId;
        }

        public override string ToString()
        {
            return
                $"Appointment Info\nDate:{Date.ToShortDateString()}\nStart:{Start.ToShortTimeString()}\nEnd:{End.ToShortTimeString()}\nType:{Type}\nCustomerId:{CustomerId.ToString()}\nUserId:{UserId.ToString()}\n";
        }
    }
}

