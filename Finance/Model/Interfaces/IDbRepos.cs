using Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{ 
    public interface IDbRepos 
    {
        //Unit of Work -- паттерн
        IRepository<Income> Incomes { get; }
        IRepository<Expenses> ExpensesRep { get; }
        IRepository<Plan> Plans { get; }
        IRepository<Category> Categories { get; }
        IRepository<Purchase> Purchases { get; }
        IRepository<Source_of_income> Sources { get; }
        IRepository<User> Users { get; }
      
        int Save();
    }
}
