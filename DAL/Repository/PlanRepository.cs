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
    public class PlanRepository : IRepository<Plan>
    {
        private Model1 db;

    public PlanRepository(Model1 context)
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
