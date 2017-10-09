using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class contract_
    {
        public contract_(string n, string num, string ow, int i)
        {
            this.owner = ow;
            this.number = num;
            this.name = n;
            this.id = i;
        }
        public string name { get; set; }

        public string number { get; set; }

        public string owner { get; set; }

        public int id { get; set; }
        public override string ToString()
        {
            return string.Format($"{number}");
        }
    }
}
