using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class OrderBll:BaseService<Model.Orders>,IBll.IOrdersBll
    {
        public override void SetDal()
        {
            CurrentDal = this.GetDBsession.CreateOrderDal;

        }
    }
}
