using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
   public class OrderDetailBll:BaseService<Model.OrderDetail>,IBll.IOrderDetailBll
    {
        public override void SetDal()
        {
            CurrentDal = this.GetDBsession.CreateOrderDeatilDal;
        }
    }
}
