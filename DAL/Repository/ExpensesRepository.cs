using DAL;
using DAL.Interfaces;
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
        private Model1 db;

        public ExpensesRepository(Model1 context)
        {
            this.db = context;
        }

        public ExpensesRepository()
        {
           
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

        public void GetAll()
        {
            Model1 db = new Model1();
            return db.Expenses.Select(i => new Expenses
            {
                Expenses_PK = i.Expenses_PK
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
