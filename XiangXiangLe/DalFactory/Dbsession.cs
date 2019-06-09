using Dal;
using IDal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalFactory
{
    public class DBSession : IDBsession

    {
        public DbContext db
        {
            get { return DbcontextFactory.CreateDbcontext(); }
        }
        /// <summary>
        /// 创建数据访问层实例，将数据访问层与业务层解耦
        /// </summary>
        /// <returns></returns>
        /// 
        private IUserInfo userInfo;
        public IUserInfo CreateUserInfo
        {
            get
            {
                if (userInfo == null)
                {
                    userInfo = AbstrctFactory.CreateUserInstanse();
                }
                return userInfo;
            }
            set { userInfo = value; }
        }

        private IProduct productInfo;
        public IProduct CreateProductInfo
        {
            get
            {
                if (productInfo == null)
                {
                    productInfo = AbstrctFactory.CreateProductInstanse();
                }
                return productInfo  ;
            }
            set { productInfo = value; }
        }

        private Icategory category;
        public Icategory CreateCategoryInfo
        {
            get{
                if (category == null)
                {
                    category= AbstrctFactory.CreateCategoryInstanse();
                }
                return category;
            }
            set
            {
                category = value;
            }
        }

        private ICartsDal cartsDal;
        public ICartsDal CreateCartsInfo
        {
            get
            {
                if (cartsDal == null)
                {
                    cartsDal = AbstrctFactory.CreateCartsInstanse();
                }
                return cartsDal;
            }
            set
            {
                cartsDal = value;
            }
        }

        private IOrdersDal ordersDal;
        public IOrdersDal CreateOrderDal
        {
            get
            {
                if (ordersDal == null)
                {
                    ordersDal = AbstrctFactory.CreateOrdersInstanse();
                }
                return ordersDal;
            }
            set
            {
                ordersDal = value;
            }
        }
        private IOrderDetailDal ordersDetailDal;
        public IOrderDetailDal CreateOrderDeatilDal
        {
            get
            {
                if (ordersDetailDal == null)
                {
                    ordersDetailDal= AbstrctFactory.CreateOrderDetailDal();
                }
                return ordersDetailDal;
            }
            set
            {
                ordersDetailDal = value;
            }
        }
        private IFavoriteDal favoriteDal;
        public IFavoriteDal CreateFavoriteDal
        {
            get
            {
                if (favoriteDal == null)
                {
                    favoriteDal = AbstrctFactory.CreateFavoriteDal();
                }
                return favoriteDal;
            }
            set
            {
                favoriteDal = value;
            }
        }
        private IRemark remarkDal;
        public IRemark CreateRemarkDal
        {
            get
            {
                if (remarkDal == null)
                {
                    remarkDal = AbstrctFactory.CreateRemarkDal();
                }
                return remarkDal;
            }
            set
            {
                remarkDal = value;
            }
        }
        /// <summary>
        /// 有时一次请求涉及多张表的操作，那么可以将数据传递到数据层中，打上相应的标记，最后一次性提交到数据库中。
        /// </summary>
        /// <returns></returns>
        public bool DbSavechang()
        {
            //DbContext db = DbcontextFactory.CreateDbcontext();
            try
            {
                return db.SaveChanges() > 0;
            }
            catch(DbEntityValidationException dbEx)
            {
                throw;
            }
            
        }

    }
}
