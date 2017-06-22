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
using System.Net.Mail;
using System.Net;
using System.Threading;

namespace WcfService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.

    [ServiceBehavior(
        InstanceContextMode = InstanceContextMode.Single,
        IncludeExceptionDetailInFaults = true)]

    public class Service : IService
    {
        DataContext datacontext;
        static Timer timer;
        DbConnection cn;
       // static int count = 0;

        public Service()
        {
            cn = new System.Data.SqlClient.SqlConnection();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            datacontext = new DataContext(cn);
            
            int hour = DateTime.Now.Hour;
        //    long ticks = (18- hour)*1000*60*60;
            long ticks = (10- hour) * 1000 * 60 * 60;
            timer = new Timer(forTimer, null, 1000, 300000);
            //if (count == 0)
            //{
            //    count++;
            //    timer = new Timer(forTimer, null, 1000, 300000);
            //}
            //timer. += OnTimedEvent;
            //timer.AutoReset = true;
            //timer.Enabled = true;            
        }
        public int getCount() { return 0; }

        public void close()
        {
            //datacontext.Dispose();
            //cn.Close();
        }

        public void forTimer(object obj)
        {
            if (DateTime.Now.Date.DayOfWeek  == DayOfWeek.Thursday)
            {
                SendCodeByMail();
            }            
        }

        public List<contract_> getAllContracts()
        {
            return (from c in datacontext.GetTable<Contracts>()
                   select new contract_ { number = c.Number, name = c.contract_Name, id = c.id }).ToList();
        }
        public bool addGoodsToDB(string name, string code, string fig, double buy)
        {
            var NameTemp = from g in datacontext.GetTable<Goods>()
                              where g.Figure == fig
                              select g;
            if (NameTemp.Count() > 0) return false;

            Goods newGood = new Goods { numberObl = code, Figure = fig,
                Name = name, PriceBuy = buy};
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
        private double getSum()
        {
            var sum = (from gi in datacontext.GetTable<GoodsInContract>()
                       select new { sum = gi.Quantity * gi.PriceSold }).Sum(s => s.sum);
            return sum;
        }

        public double getTotalSum()
        {
            return getSum();
        }

        public double getLeftSum()
        {
            var sum = getSum();
            var sumLeft = (from gi in datacontext.GetTable<GoodsInContract>()
                           select new { sum = gi.QuantityLeft * gi.PriceSold }).Sum(s => s.sum);
            return sum - sumLeft;
        }

        public List<goodPrice> getAllGoodPrice()
        {
            var col = from g in datacontext.GetTable<Goods>()
                      select new goodPrice { name = g.Name, priceBuy = g.PriceBuy };
            return col.ToList();
        }

        public void editPriceBuy(string name, double pr)
        {
            var good = (from g in datacontext.GetTable<Goods>()
                        where g.Name == name
                        select g).First();
            good.PriceBuy = pr;
            datacontext.SubmitChanges();

        }
        public bool checkLoginPass(string l, string p)
        {
            var col = from s in datacontext.GetTable<staff>()
                      where s.login == l && s.pass == p
                      select s;
            if (col.Count() == 0) return false;
            return true;
        }

        public boolInt addQuantityLeftInGoods(int q,int GinC, string login)
        {
            var goodIn = (from g in datacontext.GetTable<GoodsInContract>()
                          where g.id == GinC  select g).First();

            if (q > goodIn.QuantityLeft || (goodIn.Quantity < ( goodIn.QuantityLeft - q)))
            return new boolInt { b = false, q = goodIn.QuantityLeft };

            goodIn.QuantityLeft = goodIn.QuantityLeft - q;
            int quant = goodIn.QuantityLeft;
            var classTmp = (from g in datacontext.GetTable<Goods>()
                               where g.ID == goodIn.IdGood
                               select new { priceBuy = g.PriceBuy, Good = g.Name }).First();

            double summ = classTmp.priceBuy * q;

            var otgruzka = new DateSum
            {
                contract = (from c in datacontext.GetTable<Contracts>()
                            where c.id == goodIn.idContract
                            select c.Number).First(),
                Data = DateTime.Now.Date,
                good = classTmp.Good,
                quant = q,
                Summa = summ,
                whoIs = login  
            };
            datacontext.GetTable<DateSum>().InsertOnSubmit(otgruzka);
            // datacontext.SubmitChanges();

            try
            {
                datacontext.SubmitChanges();
            }
            catch (ChangeConflictException)
            {
                {
                    try
                    {
                        goodIn = (from g in datacontext.GetTable<GoodsInContract>()
                                      where g.id == GinC
                                      select g).First();

                        if (q > goodIn.QuantityLeft || (goodIn.Quantity < (goodIn.QuantityLeft - q)))
                            return new boolInt { b = false, q = goodIn.QuantityLeft };

                        goodIn.QuantityLeft = goodIn.QuantityLeft - q;
                        datacontext.SubmitChanges();
                    }
                    catch (ChangeConflictException)
                    {
                        Console.WriteLine("Конфликт повторился, откатываемся.");
                    }
                }
            }

            //try
            //{
            //    datacontext.SubmitChanges();
            //}
            //catch (ChangeConflictException)
            //{
            //    datacontext.ChangeConflicts.ResolveAll(RefreshMode.KeepChanges);
            //    {
            //        try
            //        {
            //            datacontext.SubmitChanges();
            //        }
            //        catch (ChangeConflictException)
            //        {
            //            Console.WriteLine("Конфликт повторился, откатываемся.");
            //        }
            //    }
            //}

            return new boolInt { q = quant, b = true };
        }

        public bool addOwner(string name)
        {
            var owner = from o in datacontext.GetTable<owners>()
                        where o.Name == name select o;
            if (owner.Count() > 0) return false;
            var ownerNew = new owners { Name = name };
            datacontext.GetTable<owners>().InsertOnSubmit(ownerNew);
            datacontext.SubmitChanges();
            return true;
        }

        private void addToDateSumOtgruz(int q, string num, string good)
        {
            double priceBuy = (from g in datacontext.GetTable<Goods>()
                               where g.Name == ""
                               select g.PriceBuy).First();
            double summ = priceBuy * q;
            var otgruzka = new DateSum
            {
                contract = num,
                Data = DateTime.Now.Date,
                good = good,
                quant = q,
                Summa = summ
            };
            datacontext.GetTable<DateSum>().InsertOnSubmit(otgruzka);
            datacontext.SubmitChanges();
        }

        public List<classsAboutGoodsInContract> getGoodsByContract(int id)
        {
            var col = from g in datacontext.GetTable<GoodsInContract>()
                   from go in datacontext.GetTable<Goods>()
                   where g.IdGood == go.ID && g.idContract == id
                   select new classsAboutGoodsInContract
                   {
                       countAll = g.Quantity,
                       countLeft = g.QuantityLeft,
                       name = go.Name,
                       PriceSold = g.PriceSold
                   };
            return col.ToList();
        }

        public void addToGinC(int id, int q, double price, int idGood)
        {
            var ginc = new GoodsInContract
            {
                IdGood = idGood,
                idContract = id,
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
       
        public List<NewClassForDataGrid> GetClassByContractId(int id)
        {
            var coll = from g in datacontext.GetTable<Goods>()
                       from c in datacontext.GetTable<Contracts>()
                       from o in datacontext.GetTable<owners>()
                       from ginc in datacontext.GetTable<GoodsInContract>()
                       where ginc.idContract == id && g.ID == ginc.IdGood
                        && c.owner == o.ID && c.id == id
                       select new NewClassForDataGrid
                       {
                           countAll = ginc.Quantity,
                           countLeft = ginc.QuantityLeft,
                            priceSold = ginc.PriceSold, 
                           deadLine = c.DeadLine.Value,
                           name = g.Name,
                           commentary = ginc.commentary,
                           idGinC = ginc.id,
                           code = g.numberObl, 
                            figure = g.Figure 
                       };

            return coll.ToList();
        }

        public List<NewClassForDataGrid2> GetClassByContractId2(int id)
        {
            var coll = from g in datacontext.GetTable<Goods>()
                       from c in datacontext.GetTable<Contracts>()
                       from o in datacontext.GetTable<owners>()
                       from ginc in datacontext.GetTable<GoodsInContract>()
                       where ginc.idContract == id && g.ID == ginc.IdGood
                       && c.id == id && c.owner == o.ID
                       select new NewClassForDataGrid2
                       {
                           countAll = ginc.Quantity,
                           countLeft = ginc.QuantityLeft,
                           name = g.Name,
                           commentary = ginc.commentary,
                           priceSold = ginc.PriceSold,
                           code = g.numberObl,
                           figure = g.Figure
                       };

            return coll.ToList();
        }
        public List<contract_> GetContractsByContragent(int id)
        {
            return (from c in datacontext.GetTable<Contracts>()
                   where c.Contragent == id
                   select new contract_{ number = c.Number, name = c.contract_Name, id = c.id}).ToList();
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

        public bool AddContract(string num, int idContr, DateTime dt, DateTime dline, int owner,
            string comm)
        {
            var contract = from c in datacontext.GetTable<Contracts>()
                           where c.Number == num
                           select c;
            if (contract.Count() > 0) return false;

            var newConract = new Contracts { Contragent = idContr, Data = dt.Date, Number = num ,
            DeadLine = dline, owner = owner, contract_Name = comm};
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

        private StringBuilder  getSummForAWeek()
        {
            StringBuilder sb = new StringBuilder();
            double sum = 0;
            DateTime dateMinus7 = DateTime.Now.Date.AddDays(-7); 
            var collection = from d in datacontext.GetTable<DateSum>()
                      where d.Data > dateMinus7
                      select d;
            foreach (var item in collection)
            {
                sb.Append(item.Data.Value.ToShortDateString() + " " + item.good + " " 
                    + item.quant + " " + item.Summa);
                sb.Append("\n");
                sum += item.Summa;
            }
            sb.Append(sum.ToString());
            return sb;
        }

        private  bool SendCodeByMail()
        {
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("vitaliia.perets@gmail.com");
            // кому отправляем
            MailAddress to = new MailAddress("80501903813vs@gmail.com");
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Отгрузка на " + DateTime.Now.Date.ToShortDateString();
            // текст письма
            m.Body = getSummForAWeek().ToString();
            // письмо представляет код html
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("vitaliia.perets@gmail.com", "Perets2233")
            };

            try
            {
                smtp.Send(m);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
