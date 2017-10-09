using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Threading.Tasks;
using System.Collections;

namespace WindowsFormsApplication1
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

    public class Goods
    {
        public Goods(int i, string n, string num, string fig, double pri, bool isour)
        {
            this.ID = i;
            this.isOur = isour;
            this.Figure = fig;
            this.Name = n;
            this.numberObl = num;
            this.PriceBuy = pri;
        }
        public int ID { get; set; }

        public string Name { get; set; }

        public string numberObl { get; set; }

        public string Figure { get; set; }

        public double PriceBuy { get; set; }

        public bool isOur { get; set; }

        public override string ToString()
        {
            return string.Format($"{Name}");
        }
    }
}
