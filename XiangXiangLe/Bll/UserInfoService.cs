//using Microsoft.Analytics.Interfaces;
//using Microsoft.Analytics.Types.Sql;
using IBll;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Bll
{
    public class UserInfoService : BaseService<Model.Users>, IUserInfoBll
    {
        public override void SetDal()
        {
            CurrentDal = this.GetDBsession.CreateUserInfo;

        }
        public bool DeleteEntitys(List<int> list)
        {
            var userInfoList = this.GetDBsession.CreateUserInfo.LoadEntity(c => list.Contains(c.userId));
            if (userInfoList != null)
                foreach (Users u in userInfoList)
                {
                    this.GetDBsession.CreateUserInfo.deleteEntity(u);
                }

            return this.GetDBsession.DbSavechang();
        }
        public bool UpdateImage(Model.Users user, string url)
        {
            if (this.GetDBsession.CreateUserInfo.UpdateImage(user, url))
            {
                return this.GetDBsession.DbSavechang();
            }
            else
            {
                return false;
            }
        }
    }
}