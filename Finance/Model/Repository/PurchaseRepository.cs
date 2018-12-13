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
    public class PurchaseRepository : IRepository<Purchase>
    {
        private FinancesDBContext db;

        public PurchaseRepository(FinancesDBContext context)
        {
            this.db = context;
        }


        public void Create(Purchase item)
        {
            db.Purchase.Add(item);
        }

        public void Delete(int id)
        {
            Purchase item = db.Purchase.Find(id);
            if (item != null)
                db.Purchase.Remove(item);
        }

        public Purchase GetItem(int id)
        {
            return db.Purchase.Find(id);
        }

        public ObservableCollection<Purchase> GetList()
        {
            return new ObservableCollection<Purchase>(db.Purchase.ToList());
        }

        public void Update(Purchase item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
