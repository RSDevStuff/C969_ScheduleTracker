namespace C969_ScheduleTracker;

public class Logger
{
    private string _fileLocation;

    public Logger(string fileLocation)
    {
        _fileLocation = fileLocation;
    }

    public void logSuccess(string username, DateTime time)
    {
        MessageBox.Show($"Oh no! You've succeeded at {time}, {username}!");
    }

    public void logFailure(string username, DateTime time)
    {
        MessageBox.Show($"Nice! You got blocked at {time} {username}.");
    }
}