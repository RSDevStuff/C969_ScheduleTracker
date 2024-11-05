namespace C969_ScheduleTracker;

public class Logger
{
    private string _fileLocation;

    public Logger()
    {
        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        _fileLocation = Path.Combine(documentsPath, "ScheduleTrackerLogs", "ScheduleTrackerLog.txt");
        Directory.CreateDirectory(Path.GetDirectoryName(_fileLocation));
    }

    public void logSuccess(string username, DateTime time)
    {
        using (StreamWriter writer = File.AppendText(_fileLocation))
        {
            writer.WriteLine($"INFO: {time}: Sign in succeeded with Username[{username}]");
        }
    }

    public void logFailure(string username, DateTime time)
    {
        using (StreamWriter writer =File.AppendText(_fileLocation))
        {
            writer.WriteLine($"ERROR: {time}: Sign in failed with Username[{username}]");
        }
    }
}