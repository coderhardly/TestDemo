using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
   public class UserMetadata
    { 
        [Required(ErrorMessage ="账号是必须的")]
       
        public string userId { get; set; }
        [Required]
        public string uName { get; set; }
       
        [Display(Name ="密码")]
       
        public string upassword { get; set; }


       
        //[Compare("upassword",ErrorMessage ="密码不一致")]
        public string RePwd { get; set; }
        [StringLength(2)]
        public string usex { get; set; }
       
        [Display( Name ="手机号")]
        [Required(ErrorMessage ="手机号是必须的")]
        public string telphone { get; set; }
        [Email]
        public string umail { get; set; }
        public string uphoto { get; set; }
        public string roles { get; set; }
        public string @lock { get; set; }
       
    }
}
