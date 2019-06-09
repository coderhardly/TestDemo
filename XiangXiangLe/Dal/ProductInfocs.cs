using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
   public  class ProductInfocs:BaseDal<Model.Products>,IDal.IProduct
    {
         public IQueryable<Model.CategoryModel> DoubleSelet()
        {
            DbContext db = DbcontextFactory.CreateDbcontext();
            var list = db.Set<Model.Products>().Join(db.Set<Model.Categories>(), s => s.pcategoryId, m => m.categoryId, (s, m) =>new Model.CategoryModel {CategotyId=s.pcategoryId,CategotyName=m.cname });
            return list;
        }
    }
}
