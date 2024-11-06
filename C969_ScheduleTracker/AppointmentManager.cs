using System.ComponentModel;

namespace C969_ScheduleTracker;

public static class AppointmentManager
{
    private static BindingList<Appointment> _allAppointments = new BindingList<Appointment>();
    public static BindingList<Appointment> AllAppointments => _allAppointments;


    public static void LoadAppointmentsFromDb(BindingList<Appointment> appointments)
    {
        _allAppointments.Clear();
        foreach (var appointment in appointments)
        {
            _allAppointments.Add(appointment);
        }
    }
    public static void AddAppointment(Appointment appointment)
    {
        _allAppointments.Add(appointment);
    }

    public static void RemoveAppointment(Appointment appointment)
    {
        _allAppointments.Remove(appointment);
    }

    public static BindingList<Appointment> GetAppointmentByUserId(int userId)
    {
        //Implementation
        return new BindingList<Appointment>(_allAppointments.Where(appointment => appointment.UserId == userId).ToList());
    }

    public static BindingList<Appointment> GetAppointmentByUserIdAndDate(int userId, DateTime startDate, DateTime endDate)
    {
        return new BindingList<Appointment>(_allAppointments.Where(appointment => appointment.Start >= startDate && appointment.Start <= endDate).ToList());
    }
}