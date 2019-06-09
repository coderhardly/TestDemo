using Dal;
using Model;
//using Microsoft.Analytics.Interfaces;
//using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IBll
{
    public interface IUserInfoBll : IBaseBll<Users>
    {
        bool DeleteEntitys(List<int> s);
        bool UpdateImage(Model.Users user, string url);
    }
}