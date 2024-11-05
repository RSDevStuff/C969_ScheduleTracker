namespace C969_ScheduleTracker
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            LogIn loginForm = new LogIn();
            if (loginForm.ShowDialog() == DialogResult.OK) // Only continue if login is successful
            {
                // Run the main ManagerForm after a successful login
                Application.Run(new ManagerForm());
            }
        }
    }
}