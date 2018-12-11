using DAL;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repository
{
    public class IncomeRepository : IRepository<Income>
    {
        private Model1 db;


        public IncomeRepository(Model1 context)
        {
            this.db = context;
        }

        public void Create(Income item)
        {
            db.Income.Add(item);
        }

        public void Delete(int id)
        {
            Income income = db.Income.Find(id);
            if (income != null)
                db.Income.Remove(income);
        }

        public List<Income> GetAll()
        {
            Model1 db = new Model1();
            return db.Income.Select(i => new Income
            {
                Income_PK = i.Income_PK
            }).ToList();
        }

        public Income GetItem(int id)
        {
          return  db.Income.Find(id);
        }

        public ObservableCollection<Income> GetList()
        {
            return new ObservableCollection<Income>(db.Income.ToList());
        }

        public void Update(Income item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        
    }
}
