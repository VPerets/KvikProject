using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Threading.Tasks;
using System.Collections;

namespace KvikLibrary
{

   public class sortClass<T> : IComparer<T>
        where T : Goods
    {
        public int Compare(T x, T y)
        {
            Goods g1 = x as Goods;
            Goods g2 = y as Goods;

            return (g1.Name.CompareTo(g2.Name));

        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }

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
        [Column]
        public bool isOur { get; set; }
        public override string ToString()
        {
            return string.Format($"{Name}");
        }
    }
}
