using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class ClassRepository : IRepository<Class>
    {
        private AirlineTicketsContext db;

        public ClassRepository(AirlineTicketsContext context)
        {
            this.db = context;
        }

        public IEnumerable<Class> GetAll()
        {
            return db.Class;
        }

        public Class Get(int id)
        {
            return db.Class.Find(id);
        }

        public void Create(Class classObject)
        {
            db.Class.Add(classObject);
        }

        public void Update(Class classObject)
        {
            db.Entry(classObject).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
        }
        public IEnumerable<Class> Find(Func<Class, Boolean> predicate)
        {
            return db.Class.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            var classObject = db.Class.Find(id);
            if (classObject != null)
                db.Class.Remove(classObject);
        }
    }
}
