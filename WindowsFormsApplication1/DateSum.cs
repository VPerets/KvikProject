using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace WindowsFormsApplication1
{
    public class DateSum
    {
        public DateSum(int i, double sum, double sums, string g, int q, string co, string w, DateTime d) {
            this.id = i;
            this.good = g;
            this.Summa = sum;
            this.summSold = sums;
            this.whoIs = w;
            this.quant = q;
            this.contract = co;
            this.dateShip = d;
        }
        public int id { get; set; }
      
        public double Summa { get; set; }
    
        public double summSold { get; set; }
       
        public string good { get; set; }
       
        public int quant { get; set; }
      
        public string contract { get; set; }
      
        public string whoIs { get; set; }
    
        public Nullable<System.DateTime> dateShip { get; set; }
    }
}
