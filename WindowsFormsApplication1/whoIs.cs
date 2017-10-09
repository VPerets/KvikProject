using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class whoIs
    {
        public whoIs(int i, string lo) {
            this.idDateSum = i;
            this.login_ = lo;
        }
        public int idDateSum { get; set; }

        public string login_ { get; set; }
      
    }
}
