using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{

    public class Contracts
    {
        public Contracts(int i, string num, DateTime d, int contr, string cona, int ow, DateTime dl) {
            this.id = i;
            this.Number = num;
            this.Data = d;
            this.contract_Name = cona;
            this.DeadLine = dl;
            this.owner = ow;
            this.Contragent = contr;
        }

        public int id { get; set; }
     
        public string Number { get; set; }
     
        public DateTime Data { get; set; }
     
        public int Contragent { get; set; }
      
        public string contract_Name { get; set; }
     
        public int owner { get; set; }
       
        public Nullable<System.DateTime> DeadLine { get; set; }

        public override string ToString()
        {
            return String.Format($"{Number}");
        }
    }
}
