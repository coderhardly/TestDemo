//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderDetail
    {
        public int OrderDetail_Id { get; set; }
        public int Pid { get; set; }
        public int p_price { get; set; }
        public string pname { get; set; }
        public int pnum { get; set; }
        public Nullable<int> subtotal { get; set; }
        public Nullable<int> order_no { get; set; }
        public string pUrl { get; set; }
    
        public virtual Orders Orders { get; set; }
        public virtual Products Products { get; set; }
    }
}
