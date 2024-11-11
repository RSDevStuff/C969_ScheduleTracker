using System.ComponentModel;
using System.Security.Authentication;

namespace C969_ScheduleTracker
{
    public partial class LogIn : Form
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        private LocalizationManager _localizationManager;
        public LogIn()
        {
            InitializeComponent();
            _localizationManager = new LocalizationManager();
            LoadLocalization();
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            string username = userNameTextBox.Text;
            string password = userPwTextBox.Text;
            string errorLabel = "";
            switch (_localizationManager.GetCurrentCulture().Substring(0, 2))
            {
                case "fr":
                case "es":
                case "en":
                    errorLabel = _localizationManager.GetString("ErrorLabel");
                    break;
                default:
                    errorLabel = "Authentication failed.";
                    break;
            }
            try
            {
                authenticateUser(username, password);
            }
            catch (AuthenticationException ex)
            {
                MessageBox.Show(ex.Message, errorLabel, MessageBoxButtons.OK, MessageBoxIcon.Hand);
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

        public void authenticateUser(string username, string password)
        {
            Logger logger = new Logger();
            var errorMessage = "";

            if (!String.IsNullOrWhiteSpace(username) && !String.IsNullOrWhiteSpace(password))
            {
                var query = DbManager.GetAuthenticationString(username.Trim());
                var result = (BindingList<User>)DbManager.ExecuteQuery(query, typeof(User));

                if (result.Count > 0 && password == result[0].Password)
                {
                    // Log successful log in
                    logger.logSuccess(username, DateTime.Now.ToUniversalTime());

                    // Grab the user ID
                    UserID = result[0].UserId;
                    UserName = result[0].Username;

                    // Close form with success
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    // Set error message and label based on localization.
                    switch (_localizationManager.GetCurrentCulture().Substring(0, 2))
                    {
                        case "fr":
                        case "es":
                        case "en":
                            errorMessage = _localizationManager.GetString("ErrorMessage");
                            break;
                        default:
                            errorMessage = "Authentication failed.";
                            break;
                    }

                    // Log failed login attempt.
                    logger.logFailure(username, DateTime.Now.ToUniversalTime());

                    // Clear the text boxes.
                    userPwTextBox.Clear();
                    userNameTextBox.Select();

                    // Throw exception
                    throw new AuthenticationException(errorMessage);
                }
            }
            else
            {
                // Clear the text boxes
                userNameTextBox.Clear();
                userPwTextBox.Clear();

                // Set error message and title
                switch (_localizationManager.GetCurrentCulture().Substring(0, 2))
                {
                    case "fr":
                    case "es":
                    case "en":
                        errorMessage = _localizationManager.GetString("BlankMessage");
                        break;
                    default:
                        errorMessage = "Username and password fields cannot be empty.";
                        break;
                }

                throw new AuthenticationException(errorMessage);
            }
        }

        private void userPwTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                signInButton.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
