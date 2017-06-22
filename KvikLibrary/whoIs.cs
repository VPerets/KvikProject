using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Threading.Tasks;

namespace KvikLibrary
{
    [Table()]
    public class whoIs
    {
        [Column(IsPrimaryKey = true)]
        public int idDateSum { get; set; }
        [Column]
        public string login_ { get; set; }
      
    }
}
