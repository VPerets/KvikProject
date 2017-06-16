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

        public List<string> getAllContracts()
        {
            return (from c in datacontext.GetTable<Contracts>()
                   select c.Number).ToList();
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

        public void addCommentary(int GinC, string comm)
        {
            var goodIn = (from g in datacontext.GetTable<GoodsInContract>()
                          where g.id == GinC
                          select g).First();
            goodIn.commentary = comm;
            datacontext.SubmitChanges();
        }

        public void addQuantityLeftInGoods(int q,int GinC)
        {
            var goodIn = (from g in datacontext.GetTable<GoodsInContract>()
                          where g.id == GinC select g).First();
            goodIn.QuantityLeft = goodIn.QuantityLeft - q;
           // datacontext.SubmitChanges();
            double priceBuy = (from g in datacontext.GetTable<Goods>()
                               where g.ID == goodIn.IdGood
                               select g.PriceBuy).First();
            double summ = priceBuy * q;
            var otgruzka = new DateSum
            {
                contract = goodIn.NumberContract,
                Data = DateTime.Now.Date,
                idGood = goodIn.IdGood,
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

        public List<classsAboutGoodsInContract> getGoodsByContract(string num)
        {
            var col = from g in datacontext.GetTable<GoodsInContract>()
                   from go in datacontext.GetTable<Goods>()
                   where g.IdGood == go.ID && g.NumberContract == num
                   select new classsAboutGoodsInContract
                   {
                       countAll = g.Quantity,
                       countLeft = g.QuantityLeft,
                       name = go.Name,
                       PriceSold = g.PriceSold
                   };
            return col.ToList();
        }

        public void addToGinC(string num, int q, double price, int idGood)
        {

            var ginc = new GoodsInContract
            {
                IdGood = idGood,
                NumberContract = num,
                PriceSold = price,
                Quantity = q,
                QuantityLeft = q
            };
            datacontext.GetTable<GoodsInContract>().InsertOnSubmit(ginc);
            datacontext.SubmitChanges();
        
        }
        public List<Goods> getAllGoods()
        {
            return (from g in datacontext.GetTable<Goods>()
                   select g).ToList();
        }
        public List<owners> getAllOwners()
        {
            return (from o in datacontext.GetTable<owners>()
                   select o).ToList();
        }
       
        public List<NewClassForDataGrid> GetClassByContractNumber(string number)
        {
            var coll = from g in datacontext.GetTable<Goods>()
                       from c in datacontext.GetTable<Contracts>()
                       from o in datacontext.GetTable<owners>()
                       from ginc in datacontext.GetTable<GoodsInContract>()
                       where ginc.NumberContract == number && g.ID == ginc.IdGood
                       && c.Number == ginc.NumberContract && c.owner == o.ID
                       select new NewClassForDataGrid
                       {
                           countAll = ginc.Quantity,
                           countLeft = ginc.QuantityLeft,
                           deadLine = c.DeadLine.Value,
                           name = g.Name,
                           commentary = ginc.commentary,
                            idGinC = ginc.id,
                             owner = o.Name
                       };

            return coll.ToList();
        }

        public List<string> GetContractsByContragent(int id)
        {
            return (from c in datacontext.GetTable<Contracts>()
                   where c.Contragent == id
                   select c.Number).ToList();
        }

        public List<Contragents> GetAllContragents()
        {
            return (from co in datacontext.GetTable<Contragents>()
                   select co).ToList();
        }

        public List<Contragents> GetContragents()
        {
            return (from c in datacontext.GetTable<Contracts>()
                    from co in datacontext.GetTable<Contragents>()
                    where c.Contragent == co.ID
                    select co).Distinct().ToList();

        }

        public bool AddContract(string num, int idContr, DateTime dt, DateTime dline, int owner )
        {
            var contract = from c in datacontext.GetTable<Contracts>()
                           where c.Number == num
                           select c;
            if (contract.Count() > 0) return false;

            var newConract = new Contracts { Contragent = idContr, Data = dt.Date, Number = num ,
            DeadLine = dline, owner = owner};
            datacontext.GetTable<Contracts>().InsertOnSubmit(newConract);
            datacontext.SubmitChanges();
            return true;
        }

        public bool AddContragent(string name)
        {
            var contrag = from c in datacontext.GetTable<Contragents>()
                          where c.Name == name
                          select c;
            if (contrag.Count() > 0) return false;

            var newContrag = new Contragents { Name = name };
            datacontext.GetTable<Contragents>().InsertOnSubmit(newContrag);
            datacontext.SubmitChanges(); 

            return true;
        }
    }
}
