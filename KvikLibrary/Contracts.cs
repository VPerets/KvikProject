using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Threading.Tasks;

namespace KvikLibrary
{
    [Table()]
    public class Contracts
    {
        [Column(IsPrimaryKey = true)]
        public string Number { get; set; }
        [Column]
        public DateTime Data { get; set; }
        [Column]
        public int Contragent { get; set; }
    }
}
