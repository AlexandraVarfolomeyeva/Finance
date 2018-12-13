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
    public class PlanRepository : IRepository<Plan>
    {
        private FinancesDBContext db;

    public PlanRepository(FinancesDBContext context)
    {
        this.db = context;
    }


    public void Create(Plan item)
    {
        db.Plan.Add(item);
    }

    public void Delete(int id)
    {
        Plan item = db.Plan.Find(id);
        if (item != null)
            db.Plan.Remove(item);
    }

    public Plan GetItem(int id)
    {
        return db.Plan.Find(id);
    }

    public ObservableCollection<Plan> GetList()
    {
        return new ObservableCollection<Plan>(db.Plan.ToList());
    }

    public void Update(Plan item)
    {
        db.Entry(item).State = EntityState.Modified;
    }
}
}
