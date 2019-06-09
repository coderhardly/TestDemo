using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class CartsBll:BaseService<Model.Carts>,IBll.IcartsBll
    {
        public override void SetDal()
        {
            CurrentDal = this.GetDBsession.CreateCartsInfo;
        }
        public bool AddProduct(int num, int pId,int?id)
        {
            bool flag = this.GetDBsession.CreateCartsInfo.AddProduct(num, pId,id);
            if(flag)
            {
              return  this.GetDBsession.DbSavechang();
            }
            else
            {
                return false;
            }
            
        }
       public int GetCount(int cid)
        {
            return this.GetDBsession.CreateCartsInfo.GetCount(cid);
        }

      public IEnumerable<Model.ViewModel.CartsView> GetIndex(int cid)
        {
            return this.GetDBsession.CreateCartsInfo.GetIndex(cid);
        }
        public bool DeleteProduct(int? pid)
        {
            if (this.GetDBsession.CreateCartsInfo.DeleteProduct(pid))
            {
                return this.GetDBsession.DbSavechang();
            }
            else
            {
                return false;
            }
        }
        public  bool UpdateCount(int pid, int number)
        {
            if (this.GetDBsession.CreateCartsInfo.UpdateCount(pid,number))
            {
                return this.GetDBsession.DbSavechang();
            }
            else
            {
                return false;
            }

        }
        public bool EmptyCarts(int ofUser)
        {
            if(this.GetDBsession.CreateCartsInfo.EmptyCarts(ofUser))
            {
                return this.GetDBsession.DbSavechang();
            }
            else
            {
                return false;
            }
        }
       public bool CartsProductChecked(int productId)
        {
            if (this.GetDBsession.CreateCartsInfo.CartsProductChecked(productId))
            {
                return this.GetDBsession.DbSavechang();
            }
            else
            {
                return false;
            }
        }

    }
}
