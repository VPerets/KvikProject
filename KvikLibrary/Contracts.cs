﻿using System;
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
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int id { get; set; }
        [Column]
        public string Number { get; set; }
        [Column]
        public DateTime Data { get; set; }
        [Column]
        public int Contragent { get; set; }
        [Column]
        public string contract_Name { get; set; }
        [Column]
        public int owner { get; set; }
        [Column]
        public Nullable<System.DateTime> DeadLine { get; set; }
        public override string ToString()
        {
            return String.Format($"{Number}");
        }
    }
}
