using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace KvikLibrary
{
    [Table()]
    public class DateSum
    {
        [Column]
        public DateTime Data { get; set; }
        [Column]
        public double Summa { get; set; } 
    }
}
