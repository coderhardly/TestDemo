using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDal
{
    public interface IDBsession
    {
        IUserInfo CreateUserInfo { get; set; }
        IProduct CreateProductInfo { get; set; }
        Icategory CreateCategoryInfo { get; set; }
         ICartsDal CreateCartsInfo { get; set; }
        IOrdersDal CreateOrderDal { get; set; }
         IOrderDetailDal CreateOrderDeatilDal { get; set; }
        IRemark CreateRemarkDal { get; set; }
        IFavoriteDal CreateFavoriteDal { get; set; }
        bool DbSavechang();
    }
}