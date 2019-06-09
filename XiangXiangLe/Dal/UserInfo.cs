using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class UserInfo : BaseDal<Model.Users>, IDal.IUserInfo
    {
       public bool UpdateImage(Model.Users user ,string url)
        {
            if (user != null)
            {
                user.uphoto = url;
                return true;
            }
            else
            {
                return false;
            }

         

        }
    }
}
