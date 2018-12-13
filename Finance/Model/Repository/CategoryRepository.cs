using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Finance;

namespace DAL.Repository
{
   public class CategoryRepository : IRepository<Category>
    {
        private FinancesDBContext db;

        public CategoryRepository(FinancesDBContext context)
        {
            this.db = context;
        }


        public void Create(Category item)
        {
            db.Category.Add(item);
        }

        public void Delete(int id)
        {
            Category item = db.Category.Find(id);
            if (item != null)
                db.Category.Remove(item);
        }

        public Category GetItem(int id)
        {
            return db.Category.Find(id);
        }

        public ObservableCollection<Category> GetList()
        {
            return new ObservableCollection<Category>(db.Category.ToList());
        }

        public void Update(Category item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
