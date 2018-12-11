using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
   public interface IDbCrud
    {
        List<IncomeModel> GetAllIncome();
        List<ExpensesModel> GetAllExpenses();
        List<PlanModel> GetAllPlan();
        List<PurchaseModel> GetAllPurchases();
        List<SourceModel> GetAllSources();
        List<CategoryModel> GetAllCategories();

        IncomeModel GetIncome(int id);
        ExpensesModel GetExpenses(int id);
        PlanModel GetPlan(int id);
        PurchaseModel GetPurchase(int id);
        SourceModel GetSource(int id);
        CategoryModel GetCategory(int id);


        void CreateIncome(IncomeModel p);
        void UpdateIncome(IncomeModel p);
        void DeleteIncome(int id);

        void DeleteExpenses(int id);
        void UpdateExpenses(ExpensesModel p);
        void CreateExpenses(ExpensesModel p);


        void DeletePlan(int id);
        void UpdatePlan(PlanModel p);
        void CreatePlan(PlanModel p);


        void DeletePurchase(int id);
        void UpdatePurchase(PurchaseModel p);
        void CreatePurchase(PurchaseModel p);


        void DeleteCategory(int id);
        void UpdateCategory(CategoryModel p);
        void CreateCategory(CategoryModel p);

        void DeleteSource(int id);
        void UpdateSource(SourceModel p);
        void CreateSource(SourceModel p);
    }
}
