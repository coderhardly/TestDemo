//using Microsoft.Analytics.Interfaces;
//using Microsoft.Analytics.Types.Sql;
using DalFactory;
using IDal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Bll
{
    public abstract class BaseService<T> where T : class, new()
    {
        public IDBsession GetDBsession
        {
            get { return DbSessionFactory.CreateDbsession(); }
        }
        public IbaseDal<T> CurrentDal { get; set; }
        public abstract void SetDal();
        public BaseService()
        {
            SetDal();
        }
        public IQueryable<T> LoadEntity(System.Linq.Expressions.Expression<Func<T, bool>> whereLamda)
        {
            return CurrentDal.LoadEntity(whereLamda);
        }
        public IQueryable<T> LoadPageEntity<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLamda, Expression<Func<T, s>> orderLamda, bool isAsc)
        {
            return CurrentDal.LoadPageEntity<s>(pageIndex, pageSize, out totalCount, whereLamda, orderLamda, isAsc);
        }
        public bool updateEntity(T entity)
        {
            CurrentDal.updateEntity(entity);
            return this.GetDBsession.DbSavechang();
        }
        public bool deleteEntity(T entity)
        {
            CurrentDal.deleteEntity(entity);

            return this.GetDBsession.DbSavechang();

        }
        public bool addEntity(T entity)
        {
            CurrentDal.addEntity(entity);
            return this.GetDBsession.DbSavechang();
        }
        public bool UpdateEntityFields(T entity,List<string> fileds)
        {
            CurrentDal.UpdateEntityFields(entity,fileds);
            return this.GetDBsession.DbSavechang();
        }
       public int ExeCuteProducre(int orderId, int userId, string address, string userPhone, int subtotal, int totalMoney)
        {
          return   CurrentDal.ExeCuteProducre( orderId,  userId,  address,  userPhone, subtotal, totalMoney);
        }
    }
}