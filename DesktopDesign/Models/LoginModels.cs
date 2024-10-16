using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDesign.Models
{
    public class LoginModels : INotifyPropertyChanged
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

        private string username;

        public string UserName
        {
            get { return username; }
            set { username = value; OnPropertyChanged("UserName"); }
        }

        private string password;

        public string PassWord
        {
            get { return password; }
            set { password = value; OnPropertyChanged("PassWord"); }
        }



    }
}
