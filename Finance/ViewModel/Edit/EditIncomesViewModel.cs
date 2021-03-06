﻿using DAL;
using Finance.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Finance.ViewModel
{
    public class EditIncomesViewModel : BaseViewModel
    {
        bool? dr;
        public bool? DialogResult { get { return dr; } set { dr = value; } }

        FinancesDBContext dbContext;
        public Income CurrentIncome { get; set; }
        public ObservableCollection<Source_of_income> IncomeSourceList { get; set; }
        public RelayCommand ApplyChangesCommand { get; set; }

        public EditIncomesViewModel(FinancesDBContext dbContext, Income income, int Id)
        {
            this.dbContext = dbContext;
            IncomeSourceList = dbContext.Source_of_income.Local;
            if (income != null)
            {
                CurrentIncome = income;
                ApplyChangesCommand = new RelayCommand(UpdateIncome, CanExe);
            }
            else
            {
                CurrentIncome = new Income();
                CurrentIncome.Date = DateTime.Now;
                ApplyChangesCommand = new RelayCommand(AddIncome, CanExe);
            }
            dbContext.User.Load();
            //User t = new User();
            //ObservableCollection<User> Users;
            //Users = dbContext.User.Local;
            //foreach (User p in Users)
            //{
            //    if (p.Id == Id) t = p;
            //}
            //CurrentIncome.User = t;
            CurrentIncome.LoginId = Id;
        }

        private void AddIncome(object parameter)
        {
            try
            {
                DialogResult = true;
                dbContext.Income.Add(CurrentIncome);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void UpdateIncome(object parameter)
        {
            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool CanExe(object parameter)
        {
            return !(CurrentIncome == null) && CurrentIncome.Sum > 0 && CurrentIncome.Source_of_income != null;
        }
    }
}
