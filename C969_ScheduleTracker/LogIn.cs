namespace C969_ScheduleTracker
{
    public partial class LogIn : Form
    {
        public int UserID {get; set; }
        public string UserName {get; set; }
        private LocalizationManager _localizationManager;
        public LogIn()
        {
            InitializeComponent();
            _localizationManager = new LocalizationManager();
            LoadLocalization();
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            Logger logger = new Logger();
            string username = userNameTextBox.Text;
            string password = userPwTextBox.Text;
            string errorMessage = "";
            string errorLabel = "";

            if (!String.IsNullOrWhiteSpace(username) && !String.IsNullOrWhiteSpace(password))
            {
                var query = DbManager.GetAuthenticationString(username.Trim());
                var result = DbManager.ExecuteQueryToBindingList<User>(query);

                if (result.Count > 0 && password == result[0].Password.ToString())
                {
                    logger.logSuccess(username, DateTime.Now.ToUniversalTime());

                    // Grab the user ID to bring it to the Manager Form
                    UserID = result[0].UserId;
                    UserName = result[0].Username;

                    DialogResult = DialogResult.OK;
                    Close();
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
                        case "en":
                            errorMessage = _localizationManager.GetString("ErrorMessage");
                            errorLabel = _localizationManager.GetString("ErrorLabel");
                            break;
                    }
                    MessageBox.Show(errorMessage, errorLabel, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    logger.logFailure(username, DateTime.Now.ToUniversalTime());
                    userPwTextBox.Clear();
                    userNameTextBox.Select();
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
