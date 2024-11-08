using System.ComponentModel;
using Org.BouncyCastle.Asn1.Mozilla;

namespace C969_ScheduleTracker;

public static class Validation
{
    // Validate a DateTime can be converted from string
    public static bool ValidateDateTime(DateTime selectedDate, out string errorMessage)
    {
        DateTime currentDate = DateTime.Now;

        // Provide flexibility for the scheduled time
        if (selectedDate < currentDate.AddMinutes(-15))
        {
            errorMessage = $"DateTime: {selectedDate.ToLocalTime()}. No time travelling allowed!";
            return false;
        }
        else
        {
            errorMessage = "";
            return true;
        }
    }

    // Validate appointment times, to make sure there's no clash within a list of existing appointments
    public static bool ValidateAppointmentTime(DateTime start, DateTime end, BindingList<Appointment> appointments, out string errorMessage, string appointmentId)
    {
        foreach (var appointment in appointments)
        {
            DateTime existingStartTime = appointment.Start;
            DateTime existingEndTime = appointment.End;
            if (appointment.AppointmentId.ToString() == appointmentId)
            {
                continue;
            }

            if (start >= existingStartTime && start < existingEndTime)
            {
                errorMessage = $"Spot Taken! Cannot schedule appointment between {existingStartTime.ToLocalTime()}-{existingEndTime.ToLocalTime()}";
                return true;
            }

            if (end > existingStartTime && end <= existingEndTime)
            {
                errorMessage = $"Spot Taken! Cannot schedule appointment between {existingStartTime.ToLocalTime()}-{existingEndTime.ToLocalTime()}";
                return true;
            }

            if (start < existingStartTime && end > existingEndTime)
            {
                errorMessage = $"Spot Taken! Cannot schedule appointment between {existingStartTime.ToLocalTime()}-{existingEndTime.ToLocalTime()}";
                return true;
            }
        }

        errorMessage = "";
        return false;
    }

    // Validate customerID exists, given a customer name.
    public static bool ValidateCustomerId(int customerId, BindingList<Customer> customers, out string customerName, out string errorMessage)
    {
        foreach (var customer in customers)
        {
            if (customer.CustomerId == customerId)
            {
                errorMessage = "";
                customerName = customer.Name;
                return true;
            }
        }
        errorMessage = "Invalid customer ID. Does this customer exist?";
        customerName = "";
        return false;
    }

    // Make sure a string is not null or empty
    public static bool ValidateString(string input, out string errorMessage)
    {
        if (string.IsNullOrEmpty(input))
        {
            errorMessage = "Please enter a valid string.";
            return false;
        }

        errorMessage = "";
        return true;
    }

    // Make sure an integer is valid and greater than zero
    public static bool ValidateInteger(string input, out int value, out string errorMessage)
    {
        if (int.TryParse(input, out value))
        {
            if (value > 0)
            {
                errorMessage = "";
                return true;
            }
            else
            {
                errorMessage = "Value must be larger than 0.";
                return false;
            }
        }

        value = 0;
        errorMessage = "Please enter a valid integer.";
        return false;
    }

}