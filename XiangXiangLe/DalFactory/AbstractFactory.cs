using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DalFactory
{
    public class AbstrctFactory
    {
        private static readonly string assemlyName = ConfigurationManager.AppSettings["assemlyPath"];
        private static readonly string nameSpacepath = ConfigurationManager.AppSettings["nameSpace"];
        //创建Dal层UserInfo实例
        public static IDal.IUserInfo CreateUserInstanse()
        {
            string fullName = nameSpacepath + ".UserInfo";
            return CreateInstance(fullName) as IDal.IUserInfo;

        }

        public static IDal.IProduct CreateProductInstanse()
        {
            string fullName = nameSpacepath + ".ProductInfocs";
            return CreateInstance(fullName) as IDal.IProduct;

        }
        public static IDal.Icategory CreateCategoryInstanse()
        {
            string fullName= nameSpacepath + ".CategoryDal";
            return CreateInstance(fullName) as IDal.Icategory;
        }
        public static IDal.ICartsDal CreateCartsInstanse()
        {
            string fullName = nameSpacepath + ".CartsDal";
            return CreateInstance(fullName) as IDal.ICartsDal;
        }
        public static IDal.IOrdersDal CreateOrdersInstanse()
        {
            string fullName = nameSpacepath + ".OrderDal";
            return CreateInstance(fullName) as IDal.IOrdersDal;
        }
        public static IDal.IOrderDetailDal CreateOrderDetailDal()
        {
            string fullName = nameSpacepath + ".OrderDetailDal";
            return CreateInstance(fullName) as IDal.IOrderDetailDal;
        }
        public static IDal.IRemark CreateRemarkDal()
        {
            string fullName = nameSpacepath + ".RemarkDal";
            return CreateInstance(fullName) as IDal.IRemark;
        }
        public static Object CreateInstance(string fullName)
        {
            return Assembly.Load(assemlyName).CreateInstance(fullName);
        }
        public static IDal.IFavoriteDal CreateFavoriteDal()
        {
            string fullName = nameSpacepath + ".FavoriteDal";
            return CreateInstance(fullName) as IDal.IFavoriteDal;
        }


    }
}
