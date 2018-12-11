using DAL;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class DBReposSQL : IDbRepos
    {
        private Model1 db;
        private IncomeRepository incomeRepository;
        private ExpensesRepository expensesRepository;

        public DBReposSQL()
        {
            db = new Model1();
        }

        public IRepository<IncomeRepository> Incomes
        {
            get
            {
                if (incomeRepository == null)
                    incomeRepository = new IncomeRepository(db);
                return incomeRepository;
            }
        }

       
        public IRepository<Expenses> ExpensesRep => throw new NotImplementedException();

        public IRepository<Plan> Plans => throw new NotImplementedException();

        public IRepository<Category> Categories => throw new NotImplementedException();

        public IRepository<Purchase> Purchases => throw new NotImplementedException();

        public IRepository<Source_of_income> Sources => throw new NotImplementedException();

        public IRepository<User> Users => throw new NotImplementedException();

        IRepository<Income> IDbRepos.Incomes => throw new NotImplementedException();

        public int Save()
        {
            return db.SaveChanges();
        }

    }
}
