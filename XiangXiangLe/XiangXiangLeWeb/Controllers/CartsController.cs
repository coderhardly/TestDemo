using Bll;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace XiangXiangLeWeb.Controllers
{
    public class CartsController : Controller
    {
        public CartsBll CartsBll { get; set; }
       public  ProductBll productBll { get; set; }
        public UserInfoService userBll { get; set; }
        // CartsBll CartsBll = new CartsBll();
        // ProductBll productBll = new ProductBll();
        //UserInfoService userBll = new UserInfoService();
    
        // GET: Carts
        public ActionResult CartsIndex()
        {
            int cid = Convert.ToInt32(Session["userId"]);
            var list = CartsBll.GetIndex(cid);
            //list = list.Where(m => m.Carts.cartId == cid).ToList();
            return View(list);
        }
        public ActionResult AddProduct(int pNum,int pId,int?ofUser)
        {
            ofUser= Convert.ToInt32(Session["userId"]);
            if(CartsBll.AddProduct(pNum,pId,ofUser))
            {
                 return Json(new {flag=true}, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new {flag=false}, JsonRequestBehavior.AllowGet);
            }
           
        }
        public ActionResult GetCount()
        {
            int cid = Convert.ToInt32(Session["userId"]);
            int count = CartsBll.GetCount(cid);
            return Json( new { number=count}, JsonRequestBehavior.AllowGet);
        }
     
        public ActionResult DeleteProduct(int pId)
        {
           if( CartsBll.DeleteProduct(pId))
            {
                return RedirectToAction("CartsIndex");
            }
            else
            {
                return JavaScript("alert(失败)");
            }
           
        }
        public ActionResult EmptyCarts()
        {
            int ofuer = Convert.ToInt32(Session["userId"]);
            if (CartsBll.EmptyCarts(ofuer))
            {
                return Json(new { flag = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { flag = false }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult UpdateCount(int pId,int pNum)
        {
            if (CartsBll.UpdateCount(pId, pNum))
            {
                return Json(new { flag = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { flag = false }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult CreateOrder()
        {
            int cid = Convert.ToInt32(Session["userId"]);
            string cookie = HttpUtility.UrlDecode(Request.Cookies["myCookie"].Value, Encoding.GetEncoding("UTF-8"));
            JavaScriptSerializer js = new JavaScriptSerializer();
            var list = js.Deserialize<List<Model.ViewModel.CartsView>>(cookie);
            Model.Users users = new Model.Users();
            List<Model.ViewModel.CartsView> cartsViews = new List<Model.ViewModel.CartsView>();
           Model.ViewModel.CreateOrderView createOrder = new Model.ViewModel.CreateOrderView(users,cartsViews);
            if (list.Any())
            {
                foreach (var item in list)
                {
                    CartsBll.CartsProductChecked(item.ProductId);
                    createOrder.productsList.Add(item);
                 
                }
            }
            Model.Users userInfo = userBll.LoadEntity(m => m.userId == cid).First();
            createOrder.UsersInfo = userInfo;
          
            return View(createOrder);

        }
        public ActionResult UpdateAdress(FormCollection fc)
        {
            int id = Convert.ToInt32(Session["userId"]);
            string name = fc["uName"];
            string tel = fc["uTel"];
            string adress = fc["uAdress"];
            Model.Users users = new Model.Users()
            {
                userId = id,
                roles = "会员",
                upassword = "123456",
                Addressinfo = adress,
                telphone = tel,
                uName = name,

            };

            //传入要修改的字段集合
            List<string> filed = new List<string>()
           {
             "Addressinfo","uName","telphone"
           };

            if (userBll.UpdateEntityFields(users, filed))
            {
                return Json(new { flag = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { flag = false }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}