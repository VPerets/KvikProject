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

namespace AppClient
{

    public class Service
    {
        DataContext datacontext;
        static Timer timer;
        DbConnection cn;
        static int count = 0 ;
        
        public Service()
        {
           
            cn = new System.Data.SqlClient.SqlConnection();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            int hour = DateTime.Now.Hour;
            //    long ticks = (18- hour)*1000*60*60;
         //   long ticks = (10 - hour) * 1000 * 60 * 60;
           // timer = new Timer(forTimer, null, 1000, 84000000);
            //if (count == 0)
            //{
            //    count++;
            //    timer = new Timer(forTimer, null, 1000, 300000);
            //}
            //timer. += OnTimedEvent;
            //timer.AutoReset = true;
            //timer.Enabled = true;            
        }
        public int getCount() { return count; }

        public void open()
        {
           // count++;
        }
        public void close()
        {
            //count--;
            //if (count == 0)
            //{
            //    datacontext.Dispose();
            //    cn.Dispose();
            //}
            if (datacontext != null)
            {
                datacontext.Dispose();
                cn.Dispose();
            }
        }

        public void forTimer(object obj)
        {
            if (DateTime.Now.Date.DayOfWeek == DayOfWeek.Friday)
            {
                SendCodeByMail();
            }
        }
        public List<DateSum> getForDataGrid1()
        {
            if (datacontext != null)
            {
                datacontext.Dispose();
                datacontext = new DataContext(cn);
            }
            else
                datacontext = new DataContext(cn);
            return (from d in datacontext.GetTable<DateSum>()
                    select d).ToList();
        }

        public List<contract_> getAllContracts()
        {
            if (datacontext != null)
            {
                datacontext.Dispose();
                datacontext = new DataContext(cn);
            }
            else
                datacontext = new DataContext(cn);

            return (from c in datacontext.GetTable<Contracts>()
                    select new contract_ { number = c.Number, name = c.contract_Name, id = c.id }).ToList();
        }
        public bool addGoodsToDB(string name, string code, string fig, double buy)
        {
            if (datacontext != null)
            {
                datacontext.Dispose();
                datacontext = new DataContext(cn);
            }
            else
                datacontext = new DataContext(cn);
            try
            {
                var NameTemp = from g in datacontext.GetTable<Goods>()
                               where g.Figure == fig
                               select g;
                if (NameTemp.Count() > 0) return false;

                Goods newGood = new Goods
                {
                    numberObl = code,
                    Figure = fig,
                    Name = name,
                    PriceBuy = buy
                };
                datacontext.GetTable<Goods>().InsertOnSubmit(newGood);
                datacontext.SubmitChanges();
              
                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        
            return false;
        }

        public void addCommentary(int GinC, string comm)
        {
            if (datacontext != null)
            {
                datacontext.Dispose();
                datacontext = new DataContext(cn);
            }
            else
                datacontext = new DataContext(cn);
            var goodIn = (from g in datacontext.GetTable<GoodsInContract>()
                          where g.id == GinC
                          select g).First();
            goodIn.commentary = comm;
            datacontext.SubmitChanges();
        }
        private double getSum()
        {
            if (datacontext != null)
            {
                datacontext.Dispose();
                datacontext = new DataContext(cn);
            }
            else
                datacontext = new DataContext(cn);
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
            if (datacontext != null)
            {
                datacontext.Dispose();
                datacontext = new DataContext(cn);
            }
            else
                datacontext = new DataContext(cn);
            var sum = getSum();
            var sumLeft = (from gi in datacontext.GetTable<GoodsInContract>()
                           select new { sum = gi.QuantityLeft * gi.PriceSold }).Sum(s => s.sum);
            return sum - sumLeft;
        }

        public List<goodPrice> getAllGoodPrice()
        {
            if (datacontext != null)
            {
                datacontext.Dispose();
                datacontext = new DataContext(cn);
            }
            else
                datacontext = new DataContext(cn);
            var col = from g in datacontext.GetTable<Goods>()
                      select new goodPrice { name = g.Name, priceBuy = g.PriceBuy };
            return col.ToList();
        }

        public void editPriceBuy(string name, double New, double old)
        {
            if (datacontext != null)
            {
                datacontext.Dispose();
                datacontext = new DataContext(cn);
            }
            else
                datacontext = new DataContext(cn);
            var good = (from g in datacontext.GetTable<Goods>()
                        where g.Name == name
                        select g).First();
            good.PriceBuy = New;

            var update = new UpdateGoodsPrice { data = DateTime.Now.Date, good = name, newPrice = New, oldPrice = old };
            datacontext.GetTable<UpdateGoodsPrice>().InsertOnSubmit(update);

            datacontext.SubmitChanges();

        }
        public bool checkLoginPass(string l, string p)
        {
            if (datacontext != null)
            {
                datacontext.Dispose();
                datacontext = new DataContext(cn);
            }
            else
                datacontext = new DataContext(cn);
            var col = from s in datacontext.GetTable<staff>()
                      where s.login == l && s.pass == p
                      select s;
            if (col.Count() == 0) return false;
            return true;
        }

        public boolInt addQuantityLeftInGoods(int q, int GinC, string login)
        {
            if (datacontext != null)
            {
                datacontext.Dispose();
                datacontext = new DataContext(cn);
            }
            else
                datacontext = new DataContext(cn);
            var goodIn = (from g in datacontext.GetTable<GoodsInContract>()
                          where g.id == GinC
                          select g).First();

            if (q > goodIn.QuantityLeft || (goodIn.Quantity < (goodIn.QuantityLeft - q)))
                return new boolInt { b = false, q = goodIn.QuantityLeft };

            goodIn.QuantityLeft = goodIn.QuantityLeft - q;
            int quant = goodIn.QuantityLeft;
            var classTmp = (from g in datacontext.GetTable<Goods>()
                            from gin in datacontext.GetTable<GoodsInContract>()
                            where g.ID == goodIn.IdGood && gin.id == GinC && gin.IdGood == g.ID
                            select new { priceBuy = g.PriceBuy, Good = g.Name, pricsSold = gin.PriceSold }).First();

            double summ = classTmp.priceBuy * q;
            double summ2 = classTmp.pricsSold * q;
            var otgruzka = new DateSum
            {
                contract = (from c in datacontext.GetTable<Contracts>()
                            where c.id == goodIn.idContract
                            select c.Number).First(),
                Data = DateTime.Now.Date,
                good = classTmp.Good,
                quant = q,
                Summa = summ,
                summSold = summ2,
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
            if (datacontext != null)
            {
                datacontext.Dispose();
                datacontext = new DataContext(cn);
            }
            else
                datacontext = new DataContext(cn);
            var owner = from o in datacontext.GetTable<owners>()
                        where o.Name == name
                        select o;
            if (owner.Count() > 0) return false;
            var ownerNew = new owners { Name = name };
            datacontext.GetTable<owners>().InsertOnSubmit(ownerNew);
            datacontext.SubmitChanges();
            return true;
        }

        private void addToDateSumOtgruz(int q, string num, string good)
        {
            if (datacontext != null)
            {
                datacontext.Dispose();
                datacontext = new DataContext(cn);
            }
            else
                datacontext = new DataContext(cn);
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
            if (datacontext != null)
            {
                datacontext.Dispose();
                datacontext = new DataContext(cn);
            }
            else
                datacontext = new DataContext(cn);
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
            if (datacontext != null)
            {
                datacontext.Dispose();
                datacontext = new DataContext(cn);
            }
            else
                datacontext = new DataContext(cn);
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
            if (datacontext != null)
            {
                datacontext.Dispose();
                datacontext = new DataContext(cn);
            }
            else
                datacontext = new DataContext(cn);
            return (from g in datacontext.GetTable<Goods>()
                    select g).ToList();
        }
        public List<owners> getAllOwners()
        {
            if (datacontext != null)
            {
                datacontext.Dispose();
                datacontext = new DataContext(cn);
            }
            else
                datacontext = new DataContext(cn);
            return (from o in datacontext.GetTable<owners>()
                    select o).ToList();
        }

        public List<NewClassForDataGrid> GetClassByContractId(int id)
        {
            if (datacontext != null)
            {
                datacontext.Dispose();
                datacontext = new DataContext(cn);
            }
            else
                datacontext = new DataContext(cn);

            var coll = from g in datacontext.GetTable<Goods>()
                       from c in datacontext.GetTable<Contracts>()
                       from o in datacontext.GetTable<owners>()
                       from ginc in datacontext.GetTable<GoodsInContract>()
                       where ginc.idContract == id && g.ID == ginc.IdGood
                        && c.owner == o.ID && c.id == id && g.isOur == true
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
            if (datacontext != null)
            {
                datacontext.Dispose();
                datacontext = new DataContext(cn);
            }
            else
                datacontext = new DataContext(cn);
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
            if (datacontext != null)
            {
                datacontext.Dispose();
                datacontext = new DataContext(cn);
            }
            else
                datacontext = new DataContext(cn);
            return (from c in datacontext.GetTable<Contracts>()
                    where c.Contragent == id
                    select new contract_ { number = c.Number, name = c.contract_Name, id = c.id }).ToList();
        }

        public List<Contragents> GetAllContragents()
        {
            if (datacontext != null)
            {
                datacontext.Dispose();
                datacontext = new DataContext(cn);
            }
            else
                datacontext = new DataContext(cn);
            return (from co in datacontext.GetTable<Contragents>()
                    select co).ToList();
        }

        public List<Contragents> GetContragents()
        {
            if (datacontext != null)
            {
                datacontext.Dispose();
                datacontext = new DataContext(cn);
            }
            else
                datacontext = new DataContext(cn);
            return (from c in datacontext.GetTable<Contracts>()
                    from co in datacontext.GetTable<Contragents>()
                    where c.Contragent == co.ID
                    select co).Distinct().ToList();

        }

        public bool AddContract(string num, int idContr, DateTime dt, DateTime dline, int owner,
            string comm)
        {
            if (datacontext != null)
            {
                datacontext.Dispose();
                datacontext = new DataContext(cn);
            }
            else
                datacontext = new DataContext(cn);
            var contract = from c in datacontext.GetTable<Contracts>()
                           where c.Number == num
                           select c;
            if (contract.Count() > 0) return false;

            var newConract = new Contracts
            {
                Contragent = idContr,
                Data = dt.Date,
                Number = num,
                DeadLine = dline,
                owner = owner,
                contract_Name = comm
            };
            datacontext.GetTable<Contracts>().InsertOnSubmit(newConract);
            datacontext.SubmitChanges();
            return true;
        }

        public bool AddContragent(string name)
        {
            if (datacontext != null)
            {
                datacontext.Dispose();
                datacontext = new DataContext(cn);
            }
            else
                datacontext = new DataContext(cn);
            var contrag = from c in datacontext.GetTable<Contragents>()
                          where c.Name == name
                          select c;
            if (contrag.Count() > 0) return false;

            var newContrag = new Contragents { Name = name };
            datacontext.GetTable<Contragents>().InsertOnSubmit(newContrag);
            datacontext.SubmitChanges();

            return true;
        }

        private StringBuilder getSummForAWeek()
        {
            if (datacontext != null)
            {
                datacontext.Dispose();
                datacontext = new DataContext(cn);
            }
            else
                datacontext = new DataContext(cn);
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

        private bool SendCodeByMail()
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
    public class SortClass<T> : IComparer<T>
    where T : goodPrice
    {
        public int Compare(T x, T y)
        {
            return x.name.CompareTo(y.name);
        }
    }


    public class goodPrice
    {

        public string name { get; set; }

        public double priceBuy { get; set; }
        public override string ToString()
        {
            return string.Format($"{name} {priceBuy}");
        }
    }


    public class boolInt
    {

        public int q { get; set; }

        public bool b { get; set; }
    }


    public class NewClassForDataGrid
    {

        public string name { get; set; }

        public int countAll { get; set; }

        public int countLeft { get; set; }

        public string commentary { get; set; }

        public DateTime deadLine { get; set; }

        public int idGinC { get; set; }

        public string code { get; set; }

        public string figure { get; set; }

        public double priceSold { get; set; }
        public override string ToString()
        {
            return string.Format($"{name} {countAll} {countLeft} {deadLine} {commentary}");
        }
    }


    public class NewClassForDataGrid2
    {

        public string name { get; set; }

        public int countAll { get; set; }

        public int countLeft { get; set; }

        public string commentary { get; set; }

        public string code { get; set; }

        public string figure { get; set; }

        public double priceSold { get; set; }
        public override string ToString()
        {
            return string.Format($"{name} {countAll} {countLeft} {commentary}");
        }
    }

    public class contract_
    {

        public string name { get; set; }

        public string number { get; set; }

        public int id { get; set; }
        public override string ToString()
        {
            return string.Format($"{number}");
        }
    }

    public class classsAboutGoodsInContract
    {

        public string name { get; set; }

        public int countAll { get; set; }

        public int countLeft { get; set; }

        public double PriceSold { get; set; }
        public override string ToString()
        {
            return string.Format($"{name} Всего:{countAll} Осталось:{countLeft} Продажа:{PriceSold}");
        }
    }
}