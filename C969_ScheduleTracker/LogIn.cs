namespace C969_ScheduleTracker
{
    public partial class LogIn : Form
    {
        private LocalizationManager _localizationManager;
        public LogIn()
        {
            InitializeComponent();
            _localizationManager = new LocalizationManager();
            LoadLocalization();
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            Logger logger = new Logger("C://Pizza");
            string username = userNameTextBox.Text;
            string password = userPwTextBox.Text;
            string errorMessage = "Incorrect username or password.";
            string errorLabel = "Invalid Sign In";

            if (!String.IsNullOrWhiteSpace(username) && !String.IsNullOrWhiteSpace(password))
            {
                var query = DbManager.GetAuthenticationString(username.Trim());

                if (DbManager.ExecuteQueryToList(query).Count > 0 && password == DbManager.ExecuteQueryToList(query)[0]["password"].ToString())
                {
                    logger.logSuccess(username, DateTime.Now);
                    Hide();
                    ManagerForm mangerForm = new ManagerForm();
                    mangerForm.Show();

                }
                else
                {
                    switch (_localizationManager.GetCurrentCulture().Substring(0, 2))
                    {
                        case "fr":
                            errorMessage = _localizationManager.GetString("ErrorMessage");
                            errorLabel = _localizationManager.GetString("ErrorLabel");
                            break;
                        case "es":
                            errorMessage = _localizationManager.GetString("ErrorMessage");
                            errorLabel = _localizationManager.GetString("ErrorLabel");
                            break;
                    }
                    MessageBox.Show(errorMessage, errorLabel, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    userNameTextBox.BackColor = Color.IndianRed;
                    userPwTextBox.BackColor = Color.IndianRed;
                    logger.logFailure(username, DateTime.Now);
                }
            }
            else
            {
                userNameTextBox.Clear();
                userPwTextBox.Clear();
            }
        }

        private void LoadLocalization()
        {
            string currentCulture = _localizationManager.GetCurrentCulture();
            locationLabel.Text = $"Location: {currentCulture}";

            // Load localized strings
            userNameLabel.Text = _localizationManager.GetString("UsernameLabel");
            passwordLabel.Text = _localizationManager.GetString("PasswordLabel");
            signInButton.Text = _localizationManager.GetString("SignInButton");
            exitButton.Text = _localizationManager.GetString("ExitButton");
            loginTitleLabel.Text = _localizationManager.GetString("LoginTitle");
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
