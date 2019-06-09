using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBll
{
   public interface IProductBll:IBaseBll<Model.Products>
    {
        IQueryable<Model.CategoryModel> DoubleSelet();
    }
}
