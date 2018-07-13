using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTouristik.PlugIn.OVH_V3.Search.LM;

namespace QTouristik.PlugIn.OVH_V10.Search.DP
{
    public class GeneralDataProvider<T> where T : class
    {

        private OHV_V3_SearchEntities GetModelContainer()
        {

            return new OHV_V3_SearchEntities();
        }

        public int GetCount()
        {
            using (var context = GetModelContainer())
            { 
                return context.Set<T>().Count();
            }
        }


        public T AddEntity(T entity)
        {

            using (var context = GetModelContainer())
            {
                try
                {
                    context.Entry(entity).State = System.Data.Entity.EntityState.Added;
                    context.SaveChanges();
                    return entity;
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {

                        }
                    }
                }
            }

            return null;


        }

        public List<T> AddEntity(List<T> listEntity)
        {
            using (var context = GetModelContainer())
            {
                foreach (T entity in listEntity)
                {
                    context.Entry(entity).State = System.Data.Entity.EntityState.Added;
                    context.SaveChanges();
                }
                return listEntity;
            }
        }

        public List<T> UpdateEntity(List<T> listEntity)
        {
            using (var context = GetModelContainer())
            {
                foreach (T entity in listEntity)
                {
                    context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
                return listEntity;
            }
        }

        public void UpdateEntity(T entity)
        {
            using (var context = GetModelContainer())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }

        }

        public T GetFirstOrDefault(System.Linq.Expressions.Expression<Func<T, bool>> func)
        {
            using (var context = GetModelContainer())
            {
                return context.Set<T>().FirstOrDefault(func);
            }

        }

        public List<T> GetList(System.Linq.Expressions.Expression<Func<T, bool>> func)
        {
            using (var context = GetModelContainer())
            {
                return context.Set<T>().Where(func).ToList();

            }

        }

        public void Delete(System.Linq.Expressions.Expression<Func<T, bool>> func)
        {
            using (var context = GetModelContainer())
            {
                var list = context.Set<T>().Where(func).ToList();

                foreach (var item in list)
                {
                    context.Set<T>().Remove(item);
                }

                context.SaveChanges();
            }
        }




    }
}
