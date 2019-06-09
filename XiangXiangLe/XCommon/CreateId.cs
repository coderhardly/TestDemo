using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommon
{
   public class CreateId
    {
        public static string CreateNum()
        {
            string sarNum = DateTime.Now.ToString("yyyyMMdd");
            Random random = new Random();
            sarNum += random.Next(10, 99);
            return sarNum;
        }
    }
}
