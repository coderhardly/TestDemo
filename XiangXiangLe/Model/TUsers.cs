using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [MetadataType(typeof(UserMetadata))]
    public partial  class Users
    {
      
        public string RePwd { get; set; }
    }
}
