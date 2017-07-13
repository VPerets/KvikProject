using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Threading.Tasks;

namespace KvikLibrary
{
    [Table()]
    public class Contragents
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int ID { get; set; }
        [Column]
        public string Name { get; set; }
        public override string ToString()
        {
            return string.Format($"{Name}");
        }
    }
}

