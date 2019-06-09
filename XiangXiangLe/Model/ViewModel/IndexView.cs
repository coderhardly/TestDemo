using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Model.ViewModel
{
    public class IndexView
    {
        public IEnumerable<Model.Products> Product1 { get; set; }
        public IEnumerable<Model.Products> Product2 { get;set; }
        public IEnumerable<Model.Products> Product3 { get; set; }
        public IEnumerable<Model.Products> Product4 { set; get; }
        public Model.CategoryModel Categories1 { get; set; }
        public Model.CategoryModel Categories3 { get; set; }
    }
}