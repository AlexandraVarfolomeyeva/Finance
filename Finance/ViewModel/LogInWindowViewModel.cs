using Finance.Model.Entities;
using Finance.Model.Interfaces;
using Finance.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Finance
{
   public class LogInWindowViewModel : BaseViewModel, IRequireViewIdentification
    {
        private readonly RelayCommand _loginCommand;
        private readonly RelayCommand _registrationCommand;
        private string _username;
        private string _status;

        public LogInWindowViewModel()
        {
            _viewId = Guid.NewGuid();
            _loginCommand = new RelayCommand(Login, i => true);
            _registrationCommand = new RelayCommand(Registration);
        }

        public RelayCommand LoginCommand { get { return _loginCommand; } }

        public RelayCommand LogoutCommand { get { return _registrationCommand; } }

        public string Username
        {
            get { return _username; }
            set { _username = value; NotifyPropertyChanged("Username"); }
        }
        public string Status
        {
            get { return _status; }
            set { _status = value; NotifyPropertyChanged("Status"); }
        }

        private void Login(object parameter)
        {
            PasswordBox passwordBox = parameter as PasswordBox;
            string clearTextPassword = passwordBox.Password;
            try
            {
                //User user = _authenticationService.AuthenticateUser(Username, clearTextPassword);

                //Update UI
                NotifyPropertyChanged("AuthenticatedUser");
                NotifyPropertyChanged("IsAuthenticated");
                _loginCommand.RaiseCanExecuteChanged();
                _registrationCommand.RaiseCanExecuteChanged();
                //Username = string.Empty; //reset
                //passwordBox.Password = string.Empty; //reset
                //Status = string.Empty;
                _IsAuthenticated = true;
                WindowManager.CloseWindow(ViewID);

            }
            catch (UnauthorizedAccessException)
            {
                Status = "Login failed! Please provide some valid credentials.";
            }
            catch (Exception ex)
            {
                Status = string.Format("ERROR: {0}", ex.Message);
            }
        }

        private bool CanLogin(object parameter)
        {
            return !IsAuthenticated;
        }

        private bool _IsAuthenticated = false;
        public bool IsAuthenticated
        {
            get { return _IsAuthenticated; }
        }
        private Guid _viewId;
        public Guid ViewID
        {
            get { return _viewId; }
        }

        private void Registration(object parameter)
        {
            NotifyPropertyChanged("AuthenticatedUser");
            NotifyPropertyChanged("IsAuthenticated");
            _loginCommand.RaiseCanExecuteChanged();
            _registrationCommand.RaiseCanExecuteChanged();
        }


        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
