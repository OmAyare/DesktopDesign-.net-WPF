using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDesign.Models 
{
    public class DetailsModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
          private void OnPropertyChanged(string propertyName)
           {
             if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
           }

        private int ID;

        public int id
        {
            get { return ID; }
            set { ID = value; OnPropertyChanged("id"); }
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; OnPropertyChanged("FirstName"); }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; OnPropertyChanged("LastName"); }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        private string company_name;

        public string Company_Name
        {
            get { return company_name; }
            set { company_name = value; OnPropertyChanged("Company_Name"); }
        }

        private int phone_no;

        public int Phone_No
        {
            get { return phone_no; }
            set { phone_no = value; OnPropertyChanged("Phone_No"); }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged("Email"); }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; OnPropertyChanged("Address"); }
        }

        private string City;

        public string city
        {
            get { return City; }
            set { City = value; OnPropertyChanged("city"); }
        }

        private string State;

        public string state
        {
            get { return State; }
            set { State = value; OnPropertyChanged("state"); }
        }


    }
}
