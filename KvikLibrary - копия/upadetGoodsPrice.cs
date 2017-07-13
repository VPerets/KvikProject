using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Threading.Tasks;
using System.Collections;

namespace KvikLibrary
{

    [Table()]
    public class UpdateGoodsPrice
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int ID { get; set; }
        [Column]
        public string good{ get; set; }
        [Column]
        public double oldPrice { get; set; }
        [Column]
        public double newPrice { get; set; }
        [Column]
        public DateTime data { get; set; }
    }
}
