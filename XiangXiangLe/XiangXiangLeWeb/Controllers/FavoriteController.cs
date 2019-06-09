using Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XCommon;

namespace XiangXiangLeWeb.Controllers
{
    public class FavoriteController : Controller
    {
        public FavoriteBll favoriteBll { get; set; }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddFavorite(int pId)
        {
            Model.MyFavorite myFavorite = new Model.MyFavorite()
            {
                    id = Convert.ToInt32(XCommon.CreateId.CreateNum()),
                     productId = pId,
                     uid = Convert.ToInt32(Session["userId"]),
            };
            bool flag = favoriteBll.addEntity(myFavorite);
            if (flag)
            {
                return Json(new {flag = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { flag=false}, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DelFavorite(int pId)
        {
            var entity = favoriteBll.LoadEntity(m => m.productId == pId).FirstOrDefault();
          bool flag= favoriteBll.deleteEntity(entity);
            if (flag)
            {
                return Json(new { flag = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { flag = false }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult FavoriteIndex()
        {
            int cid = Convert.ToInt32(Session["userId"]);
            var list = favoriteBll.GetIndex(cid);
            return View(list);
        }
    }
}