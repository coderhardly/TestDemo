using Dal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using XCommon;


namespace Dal
{
    public class CartsDal:BaseDal<Model.Carts>,IDal.ICartsDal
    {
        DbContext db = DbcontextFactory.CreateDbcontext();
        /// <summary>
        /// 创建购物车页面
        /// cid为备注购物车属于谁
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public IEnumerable <Model.ViewModel.CartsView> GetIndex(int cid)
        {
            var list = db.Set<Model.Carts>().Join(db.Set<Model.Products>(), s => s.pId, m => m.productId, (s, m) => new Model.ViewModel.CartsView{ OfUser=(int)s.ofUser,Pcount=s.pcount,Pname=m.pname,Price=m.price,PUrl=m.pUrl,ProductId=m.productId});
            var list1 = list.Where(m => m.OfUser == cid);//查询某个人的购物车，传入session
                return list1;
            
        }
        /// <summary>
        /// 添加商品到购物车
        /// </summary>
        /// <param name="num"></param>
        /// <param name="pId"></param>
        /// <param name="cid"></param>
        /// <returns></returns>
        
        public bool AddProduct(int num, int pId,int?ofUser)
        {
           
            Model.Products products = db.Set<Model.Products>().SingleOrDefault(m => m.productId == pId);
            if (products == null)
            {
                return false;
            }
            else
            {    //购物车是否已存在此商品
                var existProduct = db.Set<Model.Carts>().SingleOrDefault(m => m.pId == pId&&m.ofUser==ofUser);
                if (existProduct == null)
                {
                   int ofUsers = Convert.ToInt32(ofUser);
                    existProduct = new Model.Carts
                    {
                        cartId =Convert.ToInt32( CreateId.CreateNum()),
                        pId = pId,
                        pcount = num,
                        ofUser=ofUsers,
                        IsChecked=0

                    };
                    addEntity(existProduct);
                }
                else
                {
                    existProduct.pcount = existProduct.pcount + num;
                }
                return true;
            }
        }
        /// <summary>
        /// 获取购物车里面商品的数量
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public int  GetCount(int cid)
        {
            var list = db.Set<Model.Carts>().Where(m => m.ofUser==cid);
            int count = 0;
            foreach(var u in list)
            {
                count = count + u.pcount;
            }
            return count;
        }
        /// <summary>
        /// 删除某件商品
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
       public bool DeleteProduct(int?pid)
        { var list = LoadEntity(m => m.pId == pid);
            if(list==null)
            {
                return false;
            }
            else
            {
                foreach (var u in list)
                {
                    deleteEntity(u);
                }
                return true;
            }
            
           
        }
          public bool EmptyCarts(int ofUser)
        {
            var list = LoadEntity(m => m.ofUser == ofUser);
            if(list==null)
            {
                return false;
            }
            else
            {
                foreach(var u in list)
                {
                    deleteEntity(u);
                }
                return true;
            }

        }
        /// <summary>
        /// 更新某件商品的数量
        /// </summary>
        /// <returns></returns>
        public bool UpdateCount(int pid,int number)
        {
            Model.Carts carts = LoadEntity(m => m.pId == pid).FirstOrDefault();
            if(carts!=null)
            {
                carts.pcount = number;
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool CartsProductChecked(int productId)
        {
            Model.Carts carts = LoadEntity(m => m.pId == productId).FirstOrDefault();
            if (carts != null)
            {
                carts.IsChecked =1;
                return true;
            }
            else
            {
                return false;
            }
        }
       

    }
}
      
    

