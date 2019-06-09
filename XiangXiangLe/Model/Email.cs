//using Microsoft.Analytics.Interfaces;
//using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace Model
{
   public class EmailAttribute:RegularExpressionAttribute
    {
   public EmailAttribute() : base(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")
        {

        }
       
    }
}