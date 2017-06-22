using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Threading.Tasks;

namespace KvikLibrary
{
    [Table()]
    public class staff
    {
        [Column(IsPrimaryKey = true)]
        public int id { get; set; }
        [Column]
        public string login { get; set; }
        [Column]
        public string pass { get; set; }
    }
}
