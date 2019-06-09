using IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DalFactory
{   // 创建dbsession类实例
    public class DbSessionFactory
    {
        public static IDBsession CreateDbsession()
        {
            IDBsession dBSession = CallContext.GetData("dbs") as DBSession;
            if (dBSession == null)
            {
                dBSession = new DBSession();
                CallContext.SetData("dbs", dBSession);
            }
            return dBSession;
        }

    }
}
