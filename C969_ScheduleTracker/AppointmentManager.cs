using System.ComponentModel;

namespace C969_ScheduleTracker;

public class AppointmentManager
{
    private static BindingList<Appointment> _allAppointments = new BindingList<Appointment>();
    public static BindingList<Appointment> AllAppointments => _allAppointments;

    public static void AddAppointment(Appointment appointment)
    {
        //Implementation
    }

    public static void RemoveAppointment(Appointment appointment)
    {
        //Implementation
    }

    public static BindingList<Appointment> GetAppointmentByUserId(User user)
    {
        //Implementation
        return new BindingList<Appointment>(_allAppointments.Where(appointment => appointment.AssignedUser == user).ToList());
    }
}