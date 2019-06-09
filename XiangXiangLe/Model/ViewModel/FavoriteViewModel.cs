using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
   public class FavoriteViewModel
    {
        public int OfUser { get; set; }
        public int ProductId { set; get; }
        public string PUrl { set; get; }
        public int Price { get; set; }
        //public int Pcount { get; set; }
        public string Pname { get; set; }
    }
}
