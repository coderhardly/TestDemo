using System;
using System.Linq;
using System.Web.Mvc;
using XCommon;

using PagedList;

namespace XiangXiangLeWeb.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public IBll.IOrdersBll ordersBll { get; set; }
       public IBll.IOrderDetailBll orderDetailBll { get; set; }
        public IBll.IcartsBll cartsBll { get; set; }

        //IBll.IOrdersBll ordersBll = new Bll.OrderBll();
        //IBll.IOrderDetailBll orderDetailBll = new Bll.OrderDetailBll();
        //IBll.IcartsBll cartsBll = new Bll.CartsBll();
        int orderNum = Convert.ToInt32(CreateId.CreateNum());

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CompleteOrder()
        {
            string cusTel = Request["CusTel"];
            string cusName = Request["CusName"];
            string cusAdress = Request["CusAdress"];
            int totalPrice = Convert.ToInt32(Request["TotalPrice"]);
            
            Model.Orders orders = new Model.Orders()
            {
                orderId = orderNum,
                orderAccount =totalPrice,
                userId = Convert.ToInt32(Session["userId"]),
                orderState = "未完成",
                adress = cusAdress,
                CreateTime = DateTime.Now.ToLocalTime(),
                userPhone = cusTel
            };
           int i= ordersBll.ExeCuteProducre(orderNum, Convert.ToInt32(Session["userId"]), cusAdress, cusTel, 0, totalPrice);
            if (i>0)
            {
                return Json(new { flag1 = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { flag1 = false }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult SelectOrder(int?pageIndex)
        {
            int _userId = Convert.ToInt32(Session["userId"]);
            var list = ordersBll.LoadEntity(m => m.userId == _userId&&m.orderState=="未完成").ToList();
            var totalCount = list.Count();
            int page = pageIndex ?? 1;
            foreach(var item in list)
            {
                item.OrderDetail=orderDetailBll.LoadEntity(m => m.order_no == item.orderId).ToList();
            }
            IPagedList<Model.Orders> pList= list.AsQueryable().ToPagedList(page, 4);
            return View(pList);
        }
        public ActionResult OrderDetail(int Id)
        {
          
            var orderDetailItem = orderDetailBll.LoadEntity(m => m.Pid == Id).First();
            var orderItem = ordersBll.LoadEntity(m => m.orderId == orderDetailItem.order_no).First();
            var orderDetailView = new Model.ViewModel.OrderDetailsView(orderItem, orderDetailItem);
            return View(orderDetailView);
        }

    }
}