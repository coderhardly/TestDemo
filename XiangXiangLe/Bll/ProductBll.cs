using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
   public class ProductBll:BaseService<Model.Products>,IBll.IProductBll
    {
        public override void SetDal()
        {
            CurrentDal = this.GetDBsession.CreateProductInfo;

        }
        //连接查询产品表和分类表
        public IQueryable<Model.CategoryModel> DoubleSelet()
        {
            var pro = this.GetDBsession.CreateProductInfo;
            var list = pro.DoubleSelet();
            return list;
        }
    }
}
