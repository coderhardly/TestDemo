using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDal
{
   public interface IProduct:IbaseDal<Model.Products>
    {
        IQueryable<Model.CategoryModel> DoubleSelet();
    }
}
