using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XiangXiangLeWeb.ViewModel
{
    public class CartsView
    {
        IEnumerable<Model.Products> Products { get; set; }
        Model.Carts Carts { get; set; }
    }
}