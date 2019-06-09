using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bll;
namespace XiangXiangLe.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        UserInfoService userBll = new UserInfoService();
        public ActionResult Index()
        {    
            return View();
        }
    }
}