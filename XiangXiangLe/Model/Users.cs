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
    
    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            this.Orders = new HashSet<Orders>();
            this.Praise = new HashSet<Praise>();
            this.Remark = new HashSet<Remark>();
        }
    
        public int userId { get; set; }
        public string uName { get; set; }
        public string upassword { get; set; }
        public string usex { get; set; }
        public string telphone { get; set; }
        public string umail { get; set; }
        public string uphoto { get; set; }
        public string roles { get; set; }
        public string @lock { get; set; }
        public Nullable<System.DateTime> createTime { get; set; }
        public Nullable<int> Hot { get; set; }
        public string Addressinfo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Praise> Praise { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Remark> Remark { get; set; }
    }
}
