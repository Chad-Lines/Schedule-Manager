using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using MySql.Data.MySqlClient;

namespace Schedule_Manager.Forms
{
    public partial class LoginForm : Form
    {
        string labelError = string.Empty;
        string FieldEmpty = string.Empty;
        string LoginError = string.Empty;

        static string spanish = "es-ES";
        static string englishFieldEmpty = "Please enter a Username and Password.";
        static string englishLoginError = "Username or Password is incorrect.";
        static string spanishFieldEmpty = "Por favor ingrese un nombre de usuario y contraseña. ";
        static string spanishLoginError = "Nombre de usuario o contraseña incorrecta.";

        public LoginForm()
        {
            InitializeComponent();
            InitializeForm();       // On form load, we do some quick cleanup
        }

        private void InitializeForm()
        {
            if (CultureInfo.CurrentCulture.Name == spanish) // Checking to see if the local culture settings are set to es-ES (Spanish)...
            {                                               // If so we set all of the text accordingly

                // These are the primary labels and button texts
                lblLogin.Text = "Accesso";
                lblUsername.Text = "Nombre de Usuario";
                lblPassword.Text = "Clave";
                btnLogin.Text = "Accesso";
                btnExit.Text = "Salida";

                // These are the error texts
                FieldEmpty = spanishFieldEmpty;             
                LoginError = spanishLoginError;             
            }
            else
            {
                // If the culture settings are not es-ES, then we default to English
                FieldEmpty = englishFieldEmpty;
                LoginError = englishLoginError;
            }

            lblLoginErr.Text = labelError;  // Set the labelError to default
            lblLoginErr.Hide();             // Hide the error label
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string un = txtUserName.Text;                               // Getting the username from user input
            string pw = txtPassword.Text;                               // Getting the password from user input

            if (string.IsNullOrEmpty(un) || string.IsNullOrEmpty(pw))   // If the username or password fields are empty, then...
            {
                labelError = FieldEmpty;                                // set the error text accordingly, and...
                lblLoginErr.Text = labelError;                          // assign that text to the error lable, and...
                lblLoginErr.Show();                                     // show the error.
            }
            else                                                        // Otherwise (if the fields are NOT empty)...
            {
                AuthenticateUser(un, pw);                               // Attempt to authenticate the user
            }        

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DbManager.DbClose();
            this.Close();   // Close the application
        }

        private void AuthenticateUser(string username, string password)
        {
            // This is the first function I'm writing to access the database, hence the quantity of comments

            MySqlConnection conn = DbManager.DbConnect();
            MySqlCommand cmd = new MySqlCommand(                                                        // Creating a new MySQL command
                $"select userId from user where username = '{username}' and password = '{password}';",  // The text of the command (a query to get the userId)
                conn                                                                                    // Passing in the connection
            );

            try                                                                                         // We're going to attempt to get data from the Datbase with the...
            {                                                                                           // user information provided.
                MySqlDataReader dr = cmd.ExecuteReader();                                               // The MySqlDataReader enables reading a stream of rows from MySQL...
                                                                                                        // But in order to use it, you must execute the MySqlCommand...
                                                                                                        // reader method. Hence the "cmd.ExecuteReader()".
                dr.Read();                                                                              // Here we actually use the MySqlDataReader to capture.
                DbManager.SetUserID((int)dr[0]);                                                        // Setting the user ID
                                                                                                        // The dr[0] returns the first cell of the row
                Calendar cal = new Calendar();                                                          // Here we create the new Calendar view

                // This lambda expression simplifies handling the LoginForm. Although we hide the login form (see below)
                // it is still in memory. When we exit the Calendar form, we want to also exit the Login form. This 
                // lambda accomplishes that. If the cal form is closed, then this (the login form) will close also. 
                cal.FormClosed += (s, args) => this.Close();     
                
                cal.Show();                                                                             // Show the Calendar Form
                this.Hide();                                                                            // Hide this form so it's not lurking in the background
            }

            catch (Exception ex)                                                                        
            {                                                                                           // If the authentication fails, then...
                txtUserName.Clear();                                                                    // Clear the username field
                txtPassword.Clear();                                                                    // Clear the password field
                labelError = LoginError;                                                                // Set the error text appropriately
                lblLoginErr.Text = labelError;                                                          // Assign that text to the error label
                lblLoginErr.Show();                                                                     // Display the error label
                Console.WriteLine(ex.Message);                                                          // Capture the exact error
            }
        }
    }
}
