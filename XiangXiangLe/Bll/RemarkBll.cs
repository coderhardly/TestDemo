using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
   public class RemarkBll:BaseService<Model.Remark>,IBll.IRemarkBll
    {
        public override void SetDal()
        {
            CurrentDal = this.GetDBsession.CreateRemarkDal;

        }
    }
}
