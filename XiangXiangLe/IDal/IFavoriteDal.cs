﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDal
{
   public  interface IFavoriteDal : IbaseDal<Model.MyFavorite>
    {
        IEnumerable<Model.ViewModel.FavoriteViewModel> GetIndex(int uid);
    }
}
