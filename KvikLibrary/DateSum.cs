using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace KvikLibrary
{
    [Table()]
    public class DateSum
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int id { get; set; }
        //[Column]
        //public Nullable<System.DateTime> Data { get; set; }
        ////    public DateTime Data { get; set; }
        [Column]
        public double Summa { get; set; }
        [Column]
        public double summSold { get; set; }
        [Column]
        public string good { get; set; }
        [Column]
        public int quant { get; set; }
        [Column]
        public string contract { get; set; }
        [Column]
        public string whoIs { get; set; }
        [Column]
        public Nullable<System.DateTime> dateShip { get; set; }
    }
}
