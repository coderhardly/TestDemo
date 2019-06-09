//using Microsoft.Analytics.Interfaces;
//using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;

namespace Dal
{
  public  class FavoriteDal:BaseDal<Model.MyFavorite>,IDal.IFavoriteDal
    {
        DbContext db = DbcontextFactory.CreateDbcontext();
        public IEnumerable<Model.ViewModel.FavoriteViewModel> GetIndex(int uid)
        {
            var list = db.Set<Model.MyFavorite>().Join(db.Set<Model.Products>(), s => s.productId, m => m.productId, (s, m) => new Model.ViewModel.FavoriteViewModel { OfUser =s.uid, Pname = m.pname, Price = m.price, PUrl = m.pUrl, ProductId = m.productId });
            var list1 = list.Where(m => m.OfUser == uid);//查询某个人的购物车，传入session
            return list1;

        }
    }
}