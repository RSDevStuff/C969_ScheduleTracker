namespace C969_ScheduleTracker;

public class Logger
{
    private string _fileLocation;
    private string _userName;
    private DateTime _logTime;

    public Logger(string fileLocation, string userName, DateTime logTime)
    {
        _fileLocation = fileLocation;
        _userName = userName;
        _logTime = logTime;
    }

    public void logSuccess(string username, DateTime time)
    {
        MessageBox.Show("Oh no!");
    }

    public void logFailure(string username, DateTime time)
    {
        MessageBox.Show("Nice!");
    }
}