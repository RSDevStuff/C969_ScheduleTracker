using System.Globalization;
using System.Resources;

namespace C969_ScheduleTracker;

public class LocalizationManager
{
    private ResourceManager _resourceManager;

    public LocalizationManager()
    {
        _resourceManager = new ResourceManager("C969_ScheduleTracker.Strings", typeof(LocalizationManager).Assembly);
        SetCulture(CultureInfo.CurrentCulture.Name);
    }

    public void SetCulture(string cultureName)
    {
        CultureInfo culture = new CultureInfo(cultureName);
        Thread.CurrentThread.CurrentUICulture = culture;
        Thread.CurrentThread.CurrentCulture = culture;
    }

    public string GetString(string key)
    {
        // Return the language specific string we need for the login menu
        return _resourceManager.GetString(key);
    }

    public string GetCurrentCulture()
    {
        // Return the name of the currently set culture name
        return Thread.CurrentThread.CurrentCulture.Name;
    }
}