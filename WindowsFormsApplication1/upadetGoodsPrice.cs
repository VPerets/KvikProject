using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Threading.Tasks;
using System.Collections;

namespace WindowsFormsApplication1
{

    public class UpdateGoodsPrice
    {
        public UpdateGoodsPrice(int i, string g, double pr, double newp, DateTime d ) {
            this.data = d;
            this.good = g;
            this.ID = i;
            this.newPrice = newp;
            this.oldPrice = pr;
        }
       
        public int ID { get; set; }
       
        public string good{ get; set; }
      
        public double oldPrice { get; set; }
       
        public double newPrice { get; set; }
       
        public DateTime data { get; set; }
    }
}
