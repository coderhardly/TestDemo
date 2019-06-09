using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using IBll;
using Bll;
using System.Web.Security;
using System.Web.Script.Serialization;
using XiangXiangLeWeb.Auth;

namespace XiangXiangLeWeb.Controllers
{
    public class RegisterController : Controller
    { public   IUserInfoBll userbll { get; set; }
       //IBll.IUserInfoBll userbll = new UserInfoService();
        // GET: Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Users users)
        {
            users.telphone = "1111111";
            users.userId = Convert.ToInt32(users.userId);
            users.createTime = DateTime.Now;
            users.roles = "会员";
            users.uName = "张三";
            users.umail = null;
            users.usex = "男";
            users.uphoto = "userDefault.jpg";
            users.@lock = "正常";
           
            string validatecode = Request["txtverifcode"];
            var checkmember = userbll.LoadEntity(u => u.userId == users.userId).FirstOrDefault();
            string code = Session["ValidateCode"].ToString();
            
            if ((string.Compare(code,validatecode,true)!=0))
            {
                return Content("<script>alert('验证码错误')</script>");
            }
            else
            {
               
                if(checkmember!=null)
                {
                    return JavaScript("alert('该用户已存在')");
                }
                else
                {
                    
                        userbll.addEntity(users);
                    return Redirect("/Register/Login");
                
                    
                 
             
                }
            }
           
        }
        public ActionResult Login()
        {
            HttpCookie cookie = Request.Cookies["UserLogin"];
            if (cookie != null)
            {
                ViewBag.UserName = cookie.Values["userId"];
                ViewBag.PassWord = cookie.Values["passWord"];

            }
            return View();
        }
        [HttpPost]
        //[Authentication]
        public ActionResult Login(FormCollection fc)
        {
            int uid = int.Parse(fc["uName"]);
            string password =(fc["uPassword"]);
            var isCheck = fc["ck"];
            string validatecode = fc["txtverifcode"];
            //int m = users.userId;
            var checkmember = userbll.LoadEntity(u => u.userId ==uid).FirstOrDefault();
            string code = Session["ValidateCode"].ToString();
           int a= string.Compare(code, validatecode, true);
            JavaScriptSerializer serial = new JavaScriptSerializer();
            if (validatecode != code)
            {
                return Content("<script>alert('验证码错误')</script>");
            }
            else
            {
               
                
                    if (checkmember != null)
                    {
                        if (checkmember.upassword == password)
                        {
                        Session["userId"] = checkmember.userId;
                        Session["uname"] = checkmember.uName;
                        Session["uphoto"] = checkmember.uphoto;
                        //Users users1 = new Users()
                        //{
                        //    userId = checkmember.userId,
                        //    uName = checkmember.uName,
                        //    upassword = checkmember.upassword,
                        //    uphoto=checkmember.uphoto,
                        //};
                        ////生成票据
                        //FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1,
                        //    users1.uName,
                        //    DateTime.Now,
                        //    DateTime.Now.AddHours(1),
                        //    false,
                        //    serial.Serialize(users1)
                        //    );

                        //string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                        //添加到客户端
                        if (isCheck == "true")
                        {
                            HttpCookie authCookie = new HttpCookie("UserLogin");
                            authCookie.Values["userId"] = checkmember.userId.ToString();
                            authCookie.Values["passWord"] = checkmember.upassword;
                            authCookie.Expires = DateTime.Now.AddDays(12);
                            System.Web.HttpContext.Current.Response.Cookies.Add(authCookie);
                        }
                        if (checkmember.roles == "会员")
                            {
                            return Json(new { result = 1 });
                            }
                            else
                            {
                            return Json(new { result = 0 });
                        }
                       
                        }
                        else
                        {
                        return Json(new { result = -1 });
                    }
                    }
                    else
                    {
                    return Json(new { result = -1});
                }
             
               
            }
           
        }
        public void logOut()
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

    }
}