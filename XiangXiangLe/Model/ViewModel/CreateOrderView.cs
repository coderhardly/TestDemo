using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
   public  class CreateOrderView
    {
      public  Users UsersInfo { get; set; }
        public List<CartsView> productsList { get; set; }
        public CreateOrderView(Users users, List<CartsView> cartsViews)
        {
            UsersInfo = users;
            productsList = cartsViews;
        }
    }
}
