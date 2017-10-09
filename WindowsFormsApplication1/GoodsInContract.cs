using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace WindowsFormsApplication1
{
  
    public class GoodsInContract
    {
        public GoodsInContract(int i, int idg, int idco, int q, int ql, double pr, string comm) {
            this.id = i;
            this.idContract = idco;
            this.IdGood = idg;
            this.PriceSold = pr;
            this.Quantity = q;
            this.QuantityLeft = ql;
            this.commentary = comm;
        }
      
        public int id { get; set; }
      
        public int IdGood { get; set; }
     
        public int idContract { get; set; }
      
        public int Quantity { get; set; }
       
        public int QuantityLeft { get; set; }
       
        public double PriceSold { get; set; }
       
        public string commentary { get; set; }
    }
}
