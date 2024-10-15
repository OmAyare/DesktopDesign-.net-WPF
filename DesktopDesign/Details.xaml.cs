using DataManager;
using System;
using System.Collections.Generic;
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
using Models;
using DataManager;
using System.Windows.Controls.Primitives;

namespace DesktopDesign
{
    /// <summary>
    /// Interaction logic for Details.xaml
    /// </summary>
    /// 
    public partial class Details : Window
    {
        DataManager.DetailsManager detailsManager;
        SqlHelper dbHelper = new SqlHelper();

        public Details()
        {
            detailsManager = new DetailsManager();
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string firstName = Firsttxt.Text;
            string lastName = Lasttxt.Text;
            string fullName = $"{firstName} {lastName}";

            DetailsModel company = new DetailsModel();
            company.Name = fullName;
            company.Company_Name = Companytxt.Text;
            company.Phone_No = Convert.ToInt32(Phonetxt.Text);
            company.Email = Emailtxt.Text;
            company.Address = Addresstxt.Text;
            company.city = Citytxt.Text;
            company.state = statetxt.Text;

            bool result = await detailsManager.AddEmployee(company);
            if (result == true)
            {
                MessageBox.Show("Record Inserted Successfully");
            }
            else
            {
                MessageBox.Show("Failed to Insert Record");
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                // Check if the current text is the placeholder text
                if (textBox.Text == "Enter your firstname" ||
                    textBox.Text == "Enter your lastname" ||
                    textBox.Text == "Enter company name" ||
                    textBox.Text == "+(245) 451 45123" ||
                    textBox.Text == "example@gmail.com" ||
                    textBox.Text == "Address1" ||
                    textBox.Text == "Enter your city")
                {
                    textBox.Text = string.Empty;   // Clear the placeholder text
                    textBox.Foreground = Brushes.Black;  // Change text color to black
                }
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                // Restore placeholder text if the textbox is empty
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    if (textBox.Name == "Firsttxt")
                        textBox.Text = "Enter your firstname";
                    else if (textBox.Name == "Lasttxt")
                        textBox.Text = "Enter your lastname";
                    else if (textBox.Name == "Companytxt")
                        textBox.Text = "Enter company name";
                    else if (textBox.Name == "Phonetxt")
                        textBox.Text = "+(245) 451 45123";
                    else if (textBox.Name == "Emailtxt")
                        textBox.Text = "example@gmail.com";
                    else if (textBox.Name == "Addresstxt")
                        textBox.Text = "Address1";
                    else if (textBox.Name == "Citytxt")
                        textBox.Text = "Enter your city";

                    textBox.Foreground = Brushes.Gray;  // Reset text color to gray
                }
            }
        }
    }
}
