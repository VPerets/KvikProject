using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Configuration;
using System.Linq;
using System.Text;
using KvikLibrary;

namespace WcfService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple,
       InstanceContextMode = InstanceContextMode.Single,
       IncludeExceptionDetailInFaults = true)]

    public class Service : IService
    {
        DataContext datacontext; 

        public Service()
        {
            DbConnection cn = new System.Data.SqlClient.SqlConnection();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            datacontext = new DataContext(cn);
        }

        public bool addGoodsToDB(string name, string code, string fig, double buy)
        {
            var NameTemp = from g in datacontext.GetTable<Goods>()
                              where g.Figure == fig
                              select g;
            if (NameTemp.Count() > 0) return false;

            Goods newGood = new Goods { CodeUZP = code, Figure = fig,
                Name = name, PriceBuy = buy };
            datacontext.GetTable<Goods>().InsertOnSubmit(newGood);
            datacontext.SubmitChanges();
            return true;
        }

        public void addQuantityLeftInGoods(int q, string number, int idGood)
        {
            var goodIn = (from g in datacontext.GetTable<GoodsInContract>()
                         where g.NumberContract == number && g.IdGood == idGood
                         select g).First();
            goodIn.QuantityLeft = goodIn.QuantityLeft - q;
           // datacontext.SubmitChanges();
            double priceBuy = (from g in datacontext.GetTable<Goods>()
                               where g.ID == idGood
                               select g.PriceBuy).First();
            double summ = priceBuy * q;
            var otgruzka = new DateSum
            {
                contract = number,
                Data = DateTime.Now.Date,
                idGood = idGood,
                quant = q,
                Summa = summ
            };
            datacontext.GetTable<DateSum>().InsertOnSubmit(otgruzka);
            datacontext.SubmitChanges();
            //  addToDateSumOtgruz(q, number, idGood);
        }

        private void addToDateSumOtgruz(int q, string num, int idGood)
        {
            double priceBuy = (from g in datacontext.GetTable<Goods>()
                               where g.ID == idGood
                               select g.PriceBuy).First();
            double summ = priceBuy * q;
            var otgruzka = new DateSum
            {
                contract = num,
                Data = DateTime.Now.Date,
                idGood = idGood,
                quant = q,
                Summa = summ
            };
            datacontext.GetTable<DateSum>().InsertOnSubmit(otgruzka);
            datacontext.SubmitChanges();
        }
        public int addQuantityLeftInGoods1(int q, string number, int idGood)
        {
            var goodIn = (from g in datacontext.GetTable<GoodsInContract>()
                          where g.NumberContract == number && g.IdGood == idGood
                          select g).First();
            goodIn.QuantityLeft = goodIn.QuantityLeft - q;
            datacontext.SubmitChanges();
            return goodIn.QuantityLeft;
        }
        public List<NewClassForDataGrid> GetClassByContractNumber(string number)
        {
            var coll = from g in datacontext.GetTable<Goods>()
                       from ginc in datacontext.GetTable<GoodsInContract>()
                       where ginc.NumberContract == number && g.ID == ginc.IdGood
                       select new NewClassForDataGrid
                       {
                           countAll = ginc.Quantity,
                           CountLeft = ginc.QuantityLeft,
                           name = g.Name,
                           idGood = g.ID  
                       };
            return coll.ToList();
        }

        public List<Contracts> GetContractsByContragent(int id)
        {
            return (from c in datacontext.GetTable<Contracts>()
                   where c.Contragent == id
                   select c).ToList();
        }

        public List<Contragents> GetContragents()
        {
            return (from c in datacontext.GetTable<Contracts>()
                    from co in datacontext.GetTable<Contragents>()
                    where c.Contragent == co.ID
                    select co).Distinct().ToList();

        }
    }
}
