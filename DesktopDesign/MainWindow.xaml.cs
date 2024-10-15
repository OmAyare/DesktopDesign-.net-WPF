using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopDesign
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TogglePasswordVisibility(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Visibility == Visibility.Visible)
            {
                // Show the password as plain text
                VisiblePasswordBox.Text = PasswordBox.Password;
                PasswordBox.Visibility = Visibility.Collapsed;
                VisiblePasswordBox.Visibility = Visibility.Visible;
            }
            else
            {
                // Hide the password
                PasswordBox.Password = VisiblePasswordBox.Text;
                PasswordBox.Visibility = Visibility.Visible;
                VisiblePasswordBox.Visibility = Visibility.Collapsed;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string username = txtUsername.Text;
            string password = PasswordBox.Password;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                 string query = "SELECT COUNT(1) FROM Login WHERE UserName = @UserName AND Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserName", username);
                command.Parameters.AddWithValue("@Password", password);
                connection.Open();
                int count = Convert.ToInt32(command.ExecuteScalar());

                if (count == 1)
                {
                    Details details = new Details();
                    details.Show();
                    this.Close(); 
                
                }

           }
       }
    }
}

