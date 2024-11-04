using System.Resources;

namespace C969_ScheduleTracker;

public class LocalizationManager
{
    private ResourceManager _resourceManager;


    public void SetCulture(string cultureName)
    {
        // implementation
    }

    public string GetString(string key)
    {
        // implementation
        return "Hello";
    }

    public string GetCurrentCulture()
    {
        // implementation
        return "Culture";
    }
}