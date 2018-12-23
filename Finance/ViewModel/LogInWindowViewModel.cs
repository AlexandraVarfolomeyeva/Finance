using Finance.Helpers;
using Finance.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;

namespace Finance
{
    public class LogInWindowViewModel : BaseViewModel, IRequireViewIdentification
    {
        private readonly RelayCommand _loginCommand;
        private readonly RelayCommand _registrationCommand;
        private string _username;
        private Guid _viewId;
        public Guid ViewID
        {
            get { return _viewId; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; NotifyPropertyChanged("Username"); }
        }
        private int tries = 0 ;
        private bool LogIned = false;
        public ObservableCollection<User> UserSource { get; set; }
        FinancesDBContext db;
        public LogInWindowViewModel()
        {
            db = new FinancesDBContext();
            _loginCommand = new RelayCommand(Login, i => true);
            _registrationCommand = new RelayCommand(Registration);
        }

        public RelayCommand LoginCommand { get { return _loginCommand; } }

        public RelayCommand RegistrationCommand { get { return _registrationCommand; } }



        private void Login(object parameter)
        {

            //var stringList = parameter as Users;
            //clearTextPassword = stringList.pass.Password;
            //Username = stringList.login;

            db.User.Load();
            UserSource = db.User.Local;
            PasswordBox passwordBox = parameter as PasswordBox;
            string clearTextPassword = passwordBox.Password;
            //{
            if ((!LogIned && tries <= 3))
            {
                foreach (User p in UserSource)
                {
                    if ((p.Login == Username) && (p.Password == clearTextPassword))
                    {
                        LogIned = true;
                        MessageBox.Show("Добро пожаловать, " + p.Login + "!");
                        Window2 h = new Window2(p.Id, db);
                        WindowManager.CloseWindow(ViewID);
                        h.Show();
                    }
                }
                if (!LogIned)
                {
                    tries++;
                    MessageBox.Show("Логин и пароль были введены неправильно!");
                }
            }
            //} while (!LogIned && tries <=3);
            if (LogIned == false && tries == 3)
            {
                MessageBox.Show("Вы израсходовали все попытки!");
                System.Windows.Application.Current.Shutdown();
            }

        }

        private void Registration(object parameter)
        {
            bool exists = false;
            PasswordBox passwordBox = parameter as PasswordBox;
            string clearTextPassword = passwordBox.Password;
            db.User.Load();
            UserSource = db.User.Local;


            foreach (User p in UserSource)
            {
                if (p.Login == Username) 
                {
                    exists = true;
                }
            }
            if (exists)
            {
                MessageBox.Show("Выбранный вами логин уже существует!");
            }
            else
            {
                User newUser = new User();
                newUser.Login = Username;
                newUser.Password = clearTextPassword;
                db.User.Add(newUser);
                db.SaveChanges();
                db.User.Load();
                UserSource = db.User.Local;
                MessageBox.Show("Добро пожаловать, " + UserSource[UserSource.IndexOf(newUser)].Login + "!");
                Window2 h = new Window2(UserSource[UserSource.IndexOf(newUser)].Id, db);
                WindowManager.CloseWindow(ViewID);
                h.Show();

            }
               
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

