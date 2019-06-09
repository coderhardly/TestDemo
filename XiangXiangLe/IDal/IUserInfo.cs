using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDal
{
   public interface IUserInfo : IbaseDal<Users>
    {
        bool UpdateImage(Model.Users user, string url);
    }
}
