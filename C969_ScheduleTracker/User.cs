
namespace C969_ScheduleTracker;

public class User
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public User(){}
    public User(int userId, string username, string password)
    {
        UserId = userId;
        Username = username;
        Password = password;
    }
}