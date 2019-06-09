using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
   public class OrderDetailsView
    {
        public Model.OrderDetail OrderDetail { get; set; }
        public Model.Orders Orders { get; set; }
        public OrderDetailsView( Orders orders,OrderDetail orderDetail)
        {
            OrderDetail = orderDetail;
            Orders = orders;
        }
    }
}
