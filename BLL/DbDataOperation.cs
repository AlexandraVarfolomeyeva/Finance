using BLL.Interfaces;
using BLL.Models;
using DAL;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DbDataOperation : IDbCrud
    {
        //паттерн репозиторий
        //Unit of work
        IDbRepos db;
        public DbDataOperation(IDbRepos repos)
        {
            db = repos;
        }
        ObservableCollection<Income> l;
        ObservableCollection<Expenses> p;
        ObservableCollection<Category> c;
        ObservableCollection<Plan> plan;
        ObservableCollection<Purchase> purchase;
        ObservableCollection<Source_of_income> s;
        ObservableCollection<User> user;

        public List<IncomeModel> GetAllIncome()
        {
            l = db.Incomes.GetList();
            return l.Select(i => toIncomeModel(i)).ToList();
        }

        public List<ExpensesModel> GetAllExpenses()
        {
            p = db.ExpensesRep.GetList();
            return p.Select(i => toExpensesModel(i)).ToList();

        }

        public IncomeModel GetIncome(int id)
        {
            return toIncomeModel(db.Incomes.GetItem(id));
        }

        public ExpensesModel GetExpenses(int id)
        {
            return toExpensesModel(db.ExpensesRep.GetItem(id));
        }

        public void CreateIncome(IncomeModel p)
        {
            db.Incomes.Create(toIncome(new Income(), p));
            db.Save();
            GetAllIncome();
        }

        public void UpdateIncome(IncomeModel p)
        {
            Income ph = db.Incomes.GetItem(p.Income_PK);
            db.Incomes.Update(toIncome(ph, p));
            db.Save();
        }

        public void CreateExpenses(ExpensesModel item)
        {
            db.ExpensesRep.Create(toExpenses(new Expenses(), item));
            db.Save();
            GetAllExpenses();
        }

        public void UpdateExpenses(ExpensesModel o)
        {
            Expenses ph = db.ExpensesRep.GetItem(o.Expenses_PK);
            db.ExpensesRep.Update(toExpenses(ph, o));
            db.Save();
        }

        public void DeleteIncome(int id)
        {
            Income o = db.Incomes.GetItem(id);
            if (o != null)
                db.Incomes.Delete(id);
            db.Save();
        }

        public void DeleteExpenses(int id)
        {
            Expenses o = db.ExpensesRep.GetItem(id);
            if (o != null)
                db.ExpensesRep.Delete(id);
            db.Save();
        }


        public List<PlanModel> GetAllPlan()
        {
            plan = db.Plans.GetList();
            return plan.Select(i => toPlanModel(i)).ToList();

        }

        public List<PurchaseModel> GetAllPurchases()
        {
            purchase = db.Purchases.GetList();
            return purchase.Select(i => toPurchaseModel(i)).ToList();
        }

        public List<SourceModel> GetAllSources()
        {
            s = db.Sources.GetList();
            return s.Select(i => toSourceModel(i)).ToList();
        }

        public List<CategoryModel> GetAllCategories()
        {
            c = db.Categories.GetList();
            return c.Select(i => toCategoryModel(i)).ToList();
        }


        public PlanModel GetPlan(int id)
        {
           return toPlanModel(db.Plans.GetItem(id));
        }

        public PurchaseModel GetPurchase(int id)
        {
            return toPurchaseModel(db.Purchases.GetItem(id));
        }

        public SourceModel GetSource(int id)
        {
            return toSourceModel(db.Sources.GetItem(id));
        }

        public CategoryModel GetCategory(int id)
        {
            return toCategoryModel(db.Categories.GetItem(id));
        }


        public void DeletePlan(int id)
        {
            Plan o = db.Plans.GetItem(id);
            if (o != null)
                db.Plans.Delete(id);
            db.Save();
        }

        public void UpdatePlan(PlanModel p)
        {
            Plan ph = db.Plans.GetItem(p.Plan_PK);
            db.Plans.Update(toPlan(ph, p));
            db.Save();
        }

        public void CreatePlan(PlanModel p)
        {
            db.Plans.Create(toPlan(new Plan(), p));
            db.Save();
            GetAllPlan();
        }

        public void DeletePurchase(int id)
        {
            Purchase o = db.Purchases.GetItem(id);
            if (o != null)
                db.Purchases.Delete(id);
            db.Save();
        }

        public void UpdatePurchase(PurchaseModel p)
        {
            Purchase ph = db.Purchases.GetItem(p.Purchase_PK);
            db.Purchases.Update(toPurchase(ph, p));
            db.Save();
        }

        public void CreatePurchase(PurchaseModel p)
        {
            db.Purchases.Create(toPurchase(new Purchase(), p));
            db.Save();
            GetAllPurchases();
        }

        public void DeleteCategory(int id)
        {
            Category o = db.Categories.GetItem(id);
            if (o != null)
                db.Categories.Delete(id);
            db.Save();
        }

        public void UpdateCategory(CategoryModel p)
        {
            Category ph = db.Categories.GetItem(p.Category_PK);
            db.Categories.Update(toCategory(ph, p));
            db.Save();
        }

        public void CreateCategory(CategoryModel p)
        {
            db.Categories.Create(toCategory(new Category(), p));
            db.Save();
            GetAllCategories();
        }

        public void DeleteSource(int id)
        {
            Source_of_income o = db.Sources.GetItem(id);
            if (o != null)
                db.Sources.Delete(id);
            db.Save();
        }

        public void UpdateSource(SourceModel p)
        {
            Source_of_income ph = db.Sources.GetItem(p.Source_of_income_PK);
            db.Sources.Update(toSource(ph, p));
            db.Save();
        }

        public void CreateSource(SourceModel p)
        {
            db.Sources.Create(toSource(new Source_of_income(), p));
            db.Save();
            GetAllSources();
        }

        private IncomeModel toIncomeModel(Income i)
        {
            return new IncomeModel()
            {
                Date = i.Date,
                Income_PK = i.Income_PK,
                Login_FK = i.Login_FK,
                Source_of_the_income_FK = i.Source_of_the_income_FK,
                Sum = i.Sum
            };
        }
        private Income toIncome(Income p, IncomeModel i)
        {
            p.Date = i.Date;
            p.Income_PK = i.Income_PK;
            p.Login_FK = i.Login_FK;
            p.Source_of_the_income_FK = i.Source_of_the_income_FK;
            p.Sum = i.Sum;
            return p;
        }

        private ExpensesModel toExpensesModel(Expenses i)
        {
            return new ExpensesModel()
            {
                Category_FK = i.Category_FK,
                Date_purchase = i.Date_purchase,
                Expenses_PK = i.Expenses_PK,
                Login_FK = i.Login_FK,
                Name_expenses = i.Name_expenses,
                Necessity = i.Necessity,
                Sum_expenses=i.Sum_expenses
            };
        }

        private Expenses toExpenses(Expenses p, ExpensesModel i)
        {
            p.Category_FK = i.Category_FK;
            p.Date_purchase = i.Date_purchase;
            p.Expenses_PK = i.Expenses_PK;
            p.Login_FK = i.Login_FK;
            p.Name_expenses = i.Name_expenses;
            p.Necessity = i.Necessity;
            p.Sum_expenses = i.Sum_expenses;

            return p;
        }

        private PlanModel toPlanModel(Plan i)
        {
            return new PlanModel()
            {
                Category_FK = i.Category_FK,
                Date_From = i.Date_From,
                Date_To = i.Date_To,
                Login_FK = i.Login_FK,
                Expenses = i.Expenses,
                Source_of_income_FK = i.Source_of_income_FK,
                Income = i.Income,
                Plan_PK = i.Plan_PK
            };
        }

        private Plan toPlan(Plan p, PlanModel i)
        {
            p.Category_FK = i.Category_FK;
            p.Date_From = i.Date_From;
            p.Date_To = i.Date_To;
            p.Login_FK = i.Login_FK;
            p.Expenses = i.Expenses;
            p.Source_of_income_FK = i.Source_of_income_FK;
            p.Income = i.Income;
            p.Plan_PK = i.Plan_PK;

            return p;
        }

        private CategoryModel toPlanModel(Category i)
        {
            return new CategoryModel()
            {
                Category_name = i.Category_name,
                Category_PK = i.Category_PK
            };
        }

        private Category toCategory(Category p, CategoryModel i)
        {
            p.Category_PK = i.Category_PK;
            p.Category_name = i.Category_name;
            return p;
        }

        private PurchaseModel toPurchaseModel(Purchase i)
        {
            return new PurchaseModel()
            {
                Login_FK = i.Login_FK,
                Name = i.Name,
                Purchase_PK = i.Purchase_PK
            };
        }

        private Purchase toPurchase(Purchase p, PurchaseModel i)
        {
            p.Login_FK = i.Login_FK;
            p.Name = i.Name;
            p.Purchase_PK = i.Purchase_PK;

            return p;
        }

        private Source_of_income toSource(Source_of_income p, SourceModel i)
        {
            p.Name_Source_of_income = i.Name_Source_of_income;
            p.Source_of_income_PK = i.Source_of_income_PK;

            return p;
        }

        private CategoryModel toCategoryModel(Category i)
        {
            return new CategoryModel()
            {
               Category_name = i.Category_name,
               Category_PK = i.Category_PK
            };
        }

        private SourceModel toSourceModel(Source_of_income i)
        {
            return new SourceModel()
            {
                Name_Source_of_income = i.Name_Source_of_income,
                Source_of_income_PK = i.Source_of_income_PK
            };
        }


    }
}

