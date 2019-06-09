//using Microsoft.Analytics.Interfaces;
//using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Bll
{
   public class FavoriteBll : BaseService<Model.MyFavorite>, IBll.IfavoriteBll
    {
        public override void SetDal()
        {
            CurrentDal = this.GetDBsession.CreateFavoriteDal;

        }
       public IEnumerable<Model.ViewModel.FavoriteViewModel> GetIndex(int uid)
        {
            return this.GetDBsession.CreateFavoriteDal.GetIndex(uid);
        }
    }
}