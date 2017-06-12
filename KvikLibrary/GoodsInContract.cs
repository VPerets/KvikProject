using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace KvikLibrary
{
    [Table()]
    public class GoodsInContract
    {
        [Column (IsDbGenerated = true, IsPrimaryKey = true)]
        public int id { get; set; }
        [Column]
        public int IdGood { get; set; }
        [Column]
        public string NumberContract { get; set; }
        [Column]
        public int Quantity { get; set; }
        [Column]
        public int QuantityLeft { get; set; }
        [Column]
        public double PriceSold { get; set; }
    }
}
