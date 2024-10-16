using DesktopDesign.Models;
using MvvmDemo.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDesign.ViewModels
{
    public class DetailsViesModels : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        DetailsServices detailsService;

        public DetailsViesModels()
        { 
            detailsService = new DetailsServices();
            CurrentEmployee = new DetailsModel();
            saveCommand = new RelayCommand(Save);
        
        }

        private DetailsModel currentEmployee;

        public DetailsModel CurrentEmployee
        {
            get { return currentEmployee; }
            set { currentEmployee = value; OnPropertyChanged("CurrentEmployee"); }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        private RelayCommand saveCommand;

        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
        }

        public void Save()
        {
            try
            {
                var IsSaved = detailsService.Add(CurrentEmployee);
                if (IsSaved)
                    Message = "Employee Saved";
                else
                    Message = "Save Operation Failed";
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

    }
}
