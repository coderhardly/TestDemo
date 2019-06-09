using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class BaseDal<T> where T : class, new()
    {
        //DbContext db = new Model.CountrySideHappyEntities();
        DbContext db = DbcontextFactory.CreateDbcontext();
       
        public IQueryable<T> LoadEntity(System.Linq.Expressions.Expression<Func<T, bool>> whereLamda)
        {
            return db.Set<T>().Where(whereLamda);
        }
        public IQueryable<T> LoadPageEntity<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLamda, Expression<Func<T, s>> orderLamda, bool isAsc)
        {
            var temp = db.Set<T>().Where(whereLamda);

            totalCount = temp.Count();
            if (isAsc)
            {
                temp = temp.OrderBy(orderLamda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                temp = temp.OrderByDescending(orderLamda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            return temp;
        }
        public bool updateEntity(T entity)
        {
            db.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            return true;
        }
        public bool UpdateEntityFields( T entity,List<string> fileds)
        {
            if (fileds != null)
            {
                DbEntityEntry<T> entry = db.Entry<T>(entity);
                entry.State = System.Data.Entity.EntityState.Unchanged;
                foreach (var t in fileds)
                {
                    entry.Property(t).IsModified = true;
                   
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool deleteEntity(T entity)
        {
            DbEntityEntry entry = db.Entry<T>(entity);
            entry.State = System.Data.Entity.EntityState.Deleted;
            //return db.SaveChanges() > 0;
            return true;
        }
        public bool addEntity(T entity)
        {
            db.Entry<T>(entity).State = System.Data.Entity.EntityState.Added;
            
            return true;
        }
        public int ExeCuteProducre(int orderId, int userId, string address, string userPhone, int subtotal, int totalMoney)
        {
            SqlParameter[] parameter = new SqlParameter[5];
            parameter[0] = new SqlParameter("@OrderId", orderId);
            parameter[1] = new SqlParameter("@UserId", userId);
            parameter[2] = new SqlParameter("@Address", address);
            parameter[3] = new SqlParameter("@UserPhone", userPhone);
            //parameter[4] = new SqlParameter("@Subtotal", subtotal);
            parameter[4] = new SqlParameter("@TotalMoney", totalMoney);



            int i = db.Database.ExecuteSqlCommand("exec Usp_ComPleteOrder1 @OrderId,@UserId,@Address,@UserPhone,@TotalMoney", parameter);
            return i;
        }

    }
}
