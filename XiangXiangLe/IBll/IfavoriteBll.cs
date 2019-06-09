using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBll
{
    public interface IfavoriteBll:IBaseBll<Model.MyFavorite>
    {
        IEnumerable<Model.ViewModel.FavoriteViewModel> GetIndex(int uid);
    }
}
