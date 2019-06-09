using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class DbcontextFactory
    {
        /// <summary>
        /// 线程内创建唯一上下文实例
        /// </summary>
        /// <returns></returns>
        public static Model.CountrySideHappyEntities2 CreateDbcontext()
        {
         Model.CountrySideHappyEntities2 db = CallContext.GetData("db1") as Model.CountrySideHappyEntities2;
            if (db == null)
            {
                db = new Model.CountrySideHappyEntities2();
                CallContext.SetData
                ("db1", db);
            }

            return db;

        }

    }
}
