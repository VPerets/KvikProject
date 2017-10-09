using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{ 
    public class staff
    {
        public staff(int i, string log, string pass) {
            this.id = id;
            this.login = log;
            this.pass = pass;
        }
        public int id { get; set; }

        public string login { get; set; }

        public string pass { get; set; }
    }
}
