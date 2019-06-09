using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace XiangXiangLeWeb.Auth
{
    public class AuthenticationAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.RequestContext.HttpContext.Request.IsAuthenticated)
            {
                if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new JsonResult()
                    {
                        Data = new
                        {
                            Status = -1,
                            Message = "验证不通过",
                        }
                    };
                }
                else
                {
                    FormsAuthentication.RedirectToLoginPage();
                }
            }

            else
            {
                //1.登录状态获取用户信息（自定义保存的用户）
                var cookie = filterContext.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];

                //2.使用 FormsAuthentication 解密用户凭据
                var ticket = FormsAuthentication.Decrypt(cookie.Value);
                Model.Users loginUser = new Model.Users();

                //3. 直接解析到用户模型里去，有没有很神奇
                loginUser = new JavaScriptSerializer().Deserialize<Model.Users>(ticket.UserData);

                //4. 将要使用的数据放到ViewData 里，方便页面使用
                filterContext.Controller.ViewData["UserName"] = loginUser.uName;

                filterContext.Controller.ViewData["UserID"] = loginUser.userId;
               
               
            }
            base.OnActionExecuting(filterContext);
        }
    }
}