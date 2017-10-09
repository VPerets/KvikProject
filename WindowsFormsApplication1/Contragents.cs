using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Contragents
    {
        public Contragents(int i, string n) {
            this.ID = i;
            this.Name = n;
        }
        public int ID { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format($"{Name}");
        }
    }
}

