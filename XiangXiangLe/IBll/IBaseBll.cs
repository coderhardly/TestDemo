//using Microsoft.Analytics.Interfaces;
//using Microsoft.Analytics.Types.Sql;
using IDal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace IBll
{
    public interface IBaseBll<T> where T : class, new()
    {
        IDBsession GetDBsession { get; }
        IbaseDal<T> CurrentDal { get; set; }
        IQueryable<T> LoadEntity(System.Linq.Expressions.Expression<Func<T, bool>> whereLamda);
        IQueryable<T> LoadPageEntity<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLamda, Expression<Func<T, s>> orderLamda, bool isAsc);
        bool updateEntity(T entity);
        bool deleteEntity(T entity);
        bool addEntity(T entity);
        bool UpdateEntityFields(T entity, List<string> fileds);
        int ExeCuteProducre(int orderId, int userId, string address, string userPhone, int subtotal, int totalMoney);
    }
}