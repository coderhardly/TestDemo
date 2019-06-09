
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Model.ViewModel
{
   public class ProductRemarkView
    {
       public Products products { get; set; }
        public IEnumerable<Remark> remarks { get; set; }
        public Carts carts;
        public IQueryable<MyFavorite> myFavorite { get; set; }
    }
    
    }
