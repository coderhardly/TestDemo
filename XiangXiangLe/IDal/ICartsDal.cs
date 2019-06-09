using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace IDal
{
   public  interface ICartsDal:IbaseDal<Model.Carts>
    {
        bool AddProduct(int num, int pId,int?id);
        int GetCount(int cid);
        IEnumerable<Model.ViewModel.CartsView> GetIndex(int cid);
        bool DeleteProduct(int? pid);
        bool UpdateCount(int pid, int number);
        bool EmptyCarts(int ofUser);
        bool CartsProductChecked(int productId);
        //string ShoppingCartId { get; set; }
        //string GetCartId(HttpContextBase context);

    }
}
