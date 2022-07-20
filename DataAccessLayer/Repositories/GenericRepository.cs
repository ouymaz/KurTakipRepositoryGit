using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            using var ent = new Context();

            ent.Remove(t);
            ent.SaveChanges();
        }

        public T GetByID(int id)
        {
            using var ent = new Context();

            return ent.Set<T>().Find(id);
        }

        public List<T> GetListAll()
        {
            using var ent = new Context();

            return ent.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            using var ent = new Context();

            ent.Add(t);
            ent.SaveChanges();
        }

        public void RangeInsert(List<T> ts)
        {
            using var ent = new Context();

            ent.AddRange(ts);
            ent.SaveChanges();
        }

        public void Update(T t)
        {
            using var ent = new Context();

            ent.Update(t);
            ent.SaveChanges();
        }
    }
}
