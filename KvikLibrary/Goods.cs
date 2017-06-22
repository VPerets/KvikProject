using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Threading.Tasks;

namespace KvikLibrary
{
    [Table()]
    public class Goods
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int ID { get; set; }
        [Column]
        public string Name { get; set; }
        [Column]
        public string numberObl { get; set; }
        [Column]
        public string Figure { get; set; }
        [Column]
        public double PriceBuy { get; set; }
        public override string ToString()
        {
            return string.Format($"{Name}");
        }
    }
}
