using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class owners
    {

        public owners(int id, string name) {
            this.ID = id;
            this.Name = name;
        }
        public int ID { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format($"{Name}");
        }
    }
}

