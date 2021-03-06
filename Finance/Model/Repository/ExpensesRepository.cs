﻿using DAL;
using DAL.Interfaces;
using Finance;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ExpensesRepository : IRepository<Expenses>
    {
        private FinancesDBContext db;

        public ExpensesRepository(FinancesDBContext context)
        {
            this.db = context;
        }


        public void Create(Expenses item)
        {
            db.Expenses.Add(item);
        }

        public void Delete(int id)
        {
            Expenses expenses = db.Expenses.Find(id);
            if (expenses != null)
                db.Expenses.Remove(expenses);
        }

        public List<Expenses> GetAll()
        {
            return db.Expenses.Select(i => new Expenses
            {
                Id = i.Id
            }).ToList();
        }

        public Expenses GetItem(int id)
        {
            return db.Expenses.Find(id);
        }

        public ObservableCollection<Expenses> GetList()
        {
            return new ObservableCollection<Expenses>(db.Expenses.ToList());
        }

        public void Update(Expenses item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
