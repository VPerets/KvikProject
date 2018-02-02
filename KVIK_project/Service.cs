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
using MySql.Data.MySqlClient;

namespace KVIK_project
{

    public class Service
    {
        DataContext datacontext;
        static Timer timer;
        DbConnection cn;
        MySqlConnection connMySql = null;
        static int count = 0;
        string connStr = "";

        public Service()
        {
            connStr = "server=mysql.zzz.com.ua" +
                ";user=kvik" +
                ";database=kvik2006" +
                 ";port=3306" +
                ";password=Western2233";
            connMySql = new MySqlConnection(connStr);
            connMySql.Open();

            cn = new System.Data.SqlClient.SqlConnection();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            cn.Open();
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

        public void editPriceSold(int idGinC, double price)
        {
            updateMySql();
            updateDatacontext();

            string command = string.Format("update goodsincontract set priceSold = " + price + " where id =  " + idGinC);
            using (MySqlCommand cmd = new MySqlCommand("update goodsincontract set PriceSold = @Parname where id = @Parname2", connMySql))
            {
                // change MySqlDbType.Double to reflect the real data type in the table.
                cmd.Parameters.Add("@Parname", MySqlDbType.Double).Value = price;
                cmd.Parameters.Add("@Parname2", MySqlDbType.Int16).Value = idGinC;
                cmd.ExecuteNonQuery();
            }

            var t = from g in datacontext.GetTable<GoodsInContract>() where g.id == idGinC select g;
            t.First().PriceSold = price;
            datacontext.SubmitChanges();

        }
        public void open()
        {

            //var tt = datacontext.GetTable<contract_)

            //  updateMySql();
            //  updateDatacontext();

            
            //  datacontext.GetTable<Contracts>().DeleteOnSubmit(t);
            // datacontext.GetTable<GoodsInContract>().InsertOnSubmit(ginc);
            //  datacontext.SubmitChanges();

            //int contract = 0, own = 0;
            //MySqlCommand cmd = new MySqlCommand("select contracts.id as ID from contracts where Number like '%171717%' and Number like '%ПЗ/%' ", connMySql);
            //MySqlDataReader reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    contract = (int)reader["ID"];
            //}

            //updateMySql();
            //cmd = new MySqlCommand("select owners.ID as ID from owners where name like '%ТД%'  ", connMySql);
            // reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    own = (int)reader["ID"];
            //}
            //updateMySql();

            ////string command = string.Format("update contracts set Owner = " + own + " where id =  " + contract);
            ////MySqlCommand MyCommand = new MySqlCommand(command, connMySql);
            ////MyCommand.ExecuteNonQuery();

            ////System.Windows.Forms.MessageBox.Show(own.ToString());
            ////System.Windows.Forms.MessageBox.Show(contract.ToString());

            //////var t = from g in datacontext.GetTable<GoodsInContract>()
            //////        from c in datacontext.GetTable<Contracts>()
            //////        from go in datacontext.GetTable<Goods>()
            //////        from con in datacontext.GetTable<Contragents>()
            //////        where go.Name == "Трубка форсуночна ліва" &&
            //////        go.ID == g.IdGood && g.idContract == c.id && c.Contragent == con.ID && c.Number == "П/НХ-17502/НЮ"
            //////        select g;

            ////var t = from c in datacontext.GetTable<owners>()
            ////        where c.Name.Contains("тд")
            ////        select c;

            ////System.Windows.Forms.MessageBox.Show(t.First().ID.ToString());

            //var t = from g in datacontext.GetTable<Contracts>() where g.id == contract select g;
            //t.First().owner = own;
            //datacontext.SubmitChanges();

            //var idgood = from go in datacontext.GetTable<Goods>()
            //             where go.Name == "Трубка форсуночна права"
            //             select go;
            //t.First().IdGood = idgood.First().ID;
            //datacontext.SubmitChanges();

            //var idcon = from go in datacontext.GetTable<Contracts>()
            //             where go.Number == "П/НХ-17502/НЮ"
            //            select go;
            //System.Windows.Forms.MessageBox.Show(t.First().id.ToString());


            //int maxId = (from c in datacontext.GetTable<GoodsInContract>()
            //             select c.id).Max();


            ////   string command = string.Format($" insert into goodsincontract (id, idGood, idContract, PriceSold, Quantity, QuantityLeft ) " +
            //     $" values({maxId}, {idGood},{id},{price}, {q}, {q} )");

            //  MySqlCommand MyCommand = new MySqlCommand(command, connMySql);
            //  MyCommand.ExecuteNonQuery();
            //using (MySqlCommand cmd = new MySqlCommand("insert into goodsincontract (id, idGood, idContract, PriceSold, Quantity, QuantityLeft ) values(@Parname , @Parname2, @Parname3, @Parname4, @Parname5, @Parname6)", connMySql))
            //{
            //    // change MySqlDbType.Double to reflect the real data type in the table.
            //    cmd.Parameters.Add("@Parname", MySqlDbType.Int16).Value = maxId;
            //    cmd.Parameters.Add("@Parname2", MySqlDbType.Int16).Value = idgood.First().ID;
            //    cmd.Parameters.Add("@Parname3", MySqlDbType.Int16).Value = idcon.First().id;
            //    cmd.Parameters.Add("@Parname4", MySqlDbType.Double).Value = 292.00;
            //    cmd.Parameters.Add("@Parname5", MySqlDbType.Int16).Value = 53;
            //    cmd.Parameters.Add("@Parname6", MySqlDbType.Int16).Value = 0;
            //    cmd.ExecuteNonQuery();
            //}

            // t.First().PriceSold = 292;
            //datacontext.SubmitChanges();


            //System.Windows.Forms.MessageBox.Show(t.First().PriceSold.ToString());
            //  //var t = (from g in datacontext.GetTable<Goods>()
            //  //         where g.Name == "Сідло клапана"
            //  //         select g).First();
            //  //System.Windows.Forms.MessageBox.Show(t.Figure);
            //  //System.Windows.Forms.MessageBox.Show(cn.State.ToString());

            //  var t = (from g in datacontext.GetTable<Contracts>()
            //           where g.Number == "ПР/НХ-171134/НЮ"
            //           select g).First();
            //  //var t = from g in datacontext.GetTable<Contracts>() select g;
            //  // System.Windows.Forms.MessageBox.Show(t.First().Number);
            ////  t.Number = "ПР/НХ-171134/НЮ";
            // // t.Data = new DateTime(2017, 10, 17);
            //  int idd = t.id;


            //  datacontext.SubmitChanges();

            //  string numm = "ПР/НХ-171134/НЮ";
            //  string command = string.Format($"update contracts set number = '{numm}', data = '{new DateTime(2017, 10, 17).Date.ToString("yyyy-MM-dd")}' where id ={idd}");
            //  MySqlCommand MyCommand = new MySqlCommand(command, connMySql);
            //  MyCommand.ExecuteNonQuery();


            //MySqlCommand command = new MySqlCommand();
            //string commandString = "SELECT * FROM owners;";
            //command.CommandText = commandString;
            //command.Connection = connMySql;
            //MySqlDataReader reader;

            //   // command.Connection.Open();
            //    reader = command.ExecuteReader();
            //    string str = "";
            //    while (reader.Read())
            //    {
            //        str += reader["name"] + "\n";
            //    }
            //    reader.Close();

            //System.Windows.Forms.MessageBox.Show(str);


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

            if (connMySql.State == System.Data.ConnectionState.Open)
                connMySql.Clone();
        }

        public void forTimer(object obj)
        {
            if (DateTime.Now.Date.DayOfWeek == DayOfWeek.Friday)
            {
                SendCodeByMail();
            }
        }

        public void deleteFromDateSum(int id) {
            updateDatacontext();
            updateMySql();
            var ds = (from d in datacontext.GetTable<DateSum>()
                      where d.id == id
                      select d).First();
            datacontext.GetTable<DateSum>().DeleteOnSubmit(ds);
            datacontext.SubmitChanges();

            string command = string.Format($"delete from datesum where id = {id}");
            MySqlCommand MyCommand = new MySqlCommand(command, connMySql);
            MyCommand.ExecuteNonQuery();
        }

        public List<DateSum> getForDataGrid1()
        {
            updateDatacontext();
            return (from d in datacontext.GetTable<DateSum>()
                    where d.dateShip >= DateTime.Now.AddDays(-30) select d).ToList();
        }

        public List<contract_> getAllContracts()
        {
            updateDatacontext();

            return (from c in datacontext.GetTable<Contracts>()
                    select new contract_ { number = c.Number, name = c.contract_Name, id = c.id, data = c.Data.Date }).ToList();
        }
        public bool addGoodsToDB(string name, string code, string fig, double buy, bool isOur)
        {
            updateDatacontext();
            updateMySql();

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
                    PriceBuy = buy,
                    isOur = isOur
                };
                datacontext.GetTable<Goods>().InsertOnSubmit(newGood);
                datacontext.SubmitChanges();

                int maxId = (from c in datacontext.GetTable<Goods>()
                             select c.ID).Max();

                string command = string.Format("insert into goods (id, name, numberObl, figure, priceBuy, isOur)" +
                $" values({maxId}, '{name}', '{code}', '{fig}', {buy}, {isOur})");
                MySqlCommand MyCommand = new MySqlCommand(command, connMySql);
                MyCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return false;
        }

        public void addCommentary(int GinC, string comm)
        {
            updateDatacontext();
            updateMySql();

            string command = string.Format($" update goodsincontract set commentary = '{comm}' " +
               $" where id = {GinC}");
            MySqlCommand MyCommand = new MySqlCommand(command, connMySql);
            MyCommand.ExecuteReader();

            var goodIn = (from g in datacontext.GetTable<GoodsInContract>()
                          where g.id == GinC
                          select g).First();
            goodIn.commentary = comm;
            datacontext.SubmitChanges();
        }

        private double getSum()
        {
            updateDatacontext();
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
            updateDatacontext();
            var sum = getSum();
            var sumLeft = (from gi in datacontext.GetTable<GoodsInContract>()
                           select new { sum = gi.QuantityLeft * gi.PriceSold }).Sum(s => s.sum);
            return sum - sumLeft;
        }

        public List<goodPrice> getAllGoodPrice()
        {
            updateDatacontext();
            var col = from g in datacontext.GetTable<Goods>()
                      select new goodPrice { name = g.Name, priceBuy = g.PriceBuy };
            return col.ToList();
        }

        public void editPriceBuy(string name, double New, double old)
        {
            updateDatacontext();
            updateMySql();

            string command = string.Format($" update goods set priceBuy = {New} " +
               $" where name = '{name}'");
            MySqlCommand MyCommand = new MySqlCommand(command, connMySql);
            MyCommand.ExecuteReader();


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
            updateDatacontext();
            var col = from s in datacontext.GetTable<staff>()
                      where s.login == l && s.pass == p
                      select s;
            if (col.Count() == 0) return false;
            return true;
        }

        public boolInt addQuantityLeftInGoods(int q, int GinC, string login, DateTime dateVal)
        {
            updateDatacontext();
            updateMySql();

            var goodIn = (from g in datacontext.GetTable<GoodsInContract>()
                          where g.id == GinC
                          select g).First();

            if (q > goodIn.QuantityLeft || (goodIn.Quantity < (goodIn.QuantityLeft - q)))
                return new boolInt { b = false, q = goodIn.QuantityLeft };

            goodIn.QuantityLeft = goodIn.QuantityLeft - q;
            int quant = goodIn.QuantityLeft;

            string command = string.Format($" update goodsincontract set  QuantityLeft = {quant} " +
               $" where id = {GinC}");
            MySqlCommand MyCommand = new MySqlCommand(command, connMySql);
            MyCommand.ExecuteReader();

            var classTmp = (from g in datacontext.GetTable<Goods>()
                            from gin in datacontext.GetTable<GoodsInContract>()
                            where g.ID == goodIn.IdGood && gin.id == GinC && gin.IdGood == g.ID
                            select new { priceBuy = g.PriceBuy, Good = g.Name, pricsSold = gin.PriceSold }).First();

            double summ = classTmp.priceBuy * q;
            double summ2 = classTmp.pricsSold * q;
            string idContract = (from c in datacontext.GetTable<Contracts>()
                                 where c.id == goodIn.idContract
                                 select c.Number).First();

            var otgruzka = new DateSum
            {
                contract = idContract,
                good = classTmp.Good,
                quant = q,
                Summa = summ,
                summSold = summ2,
                whoIs = login,
                dateShip = dateVal
            };
            datacontext.GetTable<DateSum>().InsertOnSubmit(otgruzka);

            datacontext.SubmitChanges();

            int maxId = (from c in datacontext.GetTable<DateSum>()
                         select c.id).Max();
            updateMySql();
            //command = string.Format($" insert into datesum " +
            //$"(id, dateShip, summa, quant, contract,good, whoIS, summSold)" +
            //$" VALUES ({maxId},'{dateVal.Date.ToString("yyyy-MM-dd")}', {summ}, {q},'{idContract}', '{classTmp.Good}','{login}', {summ2} ) ;");
            //MyCommand = new MySqlCommand(command, connMySql);
            //MyCommand.ExecuteReader();

            using (MySqlCommand cmd = new MySqlCommand(" insert into datesum (id, dateShip, summa, quant, contract,good, whoIS, summSold) values(@Parname , @Parname2, @Parname3, @Parname4, @Parname5, @Parname6, @Parname7, @Parname8)",
                connMySql))
            {
                // change MySqlDbType.Double to reflect the real data type in the table.
                cmd.Parameters.Add("@Parname", MySqlDbType.Int16).Value = maxId;
                cmd.Parameters.Add("@Parname2", MySqlDbType.VarChar).Value = dateVal.Date.ToString("yyyy-MM-dd");
                cmd.Parameters.Add("@Parname3", MySqlDbType.Double).Value = summ;
                cmd.Parameters.Add("@Parname4", MySqlDbType.Int16).Value = q;
                cmd.Parameters.Add("@Parname5", MySqlDbType.VarChar).Value = idContract;
                cmd.Parameters.Add("@Parname6", MySqlDbType.VarChar).Value = classTmp.Good;
                cmd.Parameters.Add("@Parname7", MySqlDbType.VarChar).Value = login;
                cmd.Parameters.Add("@Parname8", MySqlDbType.Double).Value = summ2;
                cmd.ExecuteNonQuery();
            }

            try
            { }
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

        public List<classForSearch> search(string n)
        {
            updateDatacontext();
            var col = from gi in datacontext.GetTable<GoodsInContract>()
                      from g in datacontext.GetTable<Goods>()
                      from o in datacontext.GetTable<owners>()
                      from c in datacontext.GetTable<Contracts>()
                      where gi.idContract == c.id && gi.IdGood == g.ID && g.Name.Contains(n)  && c.owner == o.ID 
                      select new classForSearch
                      {
                         goodName = g.Name,
                         owner = o.Name,
                         number = c.Number,
                         qAll = gi.Quantity, 
                         qLeft = gi.QuantityLeft, 
                         price = gi.PriceSold   
                      };
            return col.ToList();
        }

        public bool addOwner(string name)
        {
            updateDatacontext();
            var owner = from o in datacontext.GetTable<owners>()
                        where o.Name == name
                        select o;
            if (owner.Count() > 0) return false;
            var ownerNew = new owners { Name = name };
            datacontext.GetTable<owners>().InsertOnSubmit(ownerNew);
            datacontext.SubmitChanges();

            int maxId = (from c in datacontext.GetTable<owners>()
                         select c.ID).Max();

            string command = string.Format($" insert into owners (id, name ) " +
               $" values({maxId}, '{name}' )");

            MySqlCommand MyCommand = new MySqlCommand(command, connMySql);
            MyCommand.ExecuteNonQuery();

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
                dateShip = DateTime.Now.Date,
                good = good,
                quant = q,
                Summa = summ
            };
            datacontext.GetTable<DateSum>().InsertOnSubmit(otgruzka);
            datacontext.SubmitChanges();
        }

        public List<classsAboutGoodsInContract> getGoodsByContract(int id)
        {
            updateDatacontext();
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
            updateDatacontext();
            updateMySql();

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

            int maxId = (from c in datacontext.GetTable<GoodsInContract>()
                         select c.id).Max();


            //   string command = string.Format($" insert into goodsincontract (id, idGood, idContract, PriceSold, Quantity, QuantityLeft ) " +
            //     $" values({maxId}, {idGood},{id},{price}, {q}, {q} )");

            //  MySqlCommand MyCommand = new MySqlCommand(command, connMySql);
            //  MyCommand.ExecuteNonQuery();
            using (MySqlCommand cmd = new MySqlCommand("insert into goodsincontract (id, idGood, idContract, PriceSold, Quantity, QuantityLeft ) values(@Parname , @Parname2, @Parname3, @Parname4, @Parname5, @Parname6)", connMySql))
            {
                // change MySqlDbType.Double to reflect the real data type in the table.
                cmd.Parameters.Add("@Parname", MySqlDbType.Int16).Value = maxId;
                cmd.Parameters.Add("@Parname2", MySqlDbType.Int16).Value = idGood;
                cmd.Parameters.Add("@Parname3", MySqlDbType.Int16).Value = id;
                cmd.Parameters.Add("@Parname4", MySqlDbType.Double).Value = price;
                cmd.Parameters.Add("@Parname5", MySqlDbType.Int16).Value = q;
                cmd.Parameters.Add("@Parname6", MySqlDbType.Int16).Value = q;
                cmd.ExecuteNonQuery();
            }
        }



        public List<Goods> getAllGoods()
        {
            updateDatacontext();
            return (from g in datacontext.GetTable<Goods>()
                    select g).ToList();
        }
        public List<owners> getAllOwners()
        {
            updateDatacontext();
            return (from o in datacontext.GetTable<owners>()
                    select o).ToList();
        }

        public List<NewClassForDataGrid> GetClassByContractId(int id)
        {
            updateDatacontext();
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
            updateDatacontext();
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
            updateDatacontext();
            return (from c in datacontext.GetTable<Contracts>()
                    from o in datacontext.GetTable<owners>()
                    where c.Contragent == id && c.owner == o.ID
                    select new contract_ { number = c.Number, name = c.contract_Name, id = c.id, owner = o.Name, data = c.Data.Date }).ToList();
        }

        public List<Contragents> GetAllContragents()
        {
            updateDatacontext();
            return (from co in datacontext.GetTable<Contragents>()
                    select co).ToList();
        }

        public List<Contragents> GetContragents()
        {
            updateDatacontext();
            return (from c in datacontext.GetTable<Contracts>()
                    from co in datacontext.GetTable<Contragents>()
                    where c.Contragent == co.ID
                    select co).Distinct().ToList();

        }

        public bool AddContract(string num, int idContr, DateTime dt, DateTime dline, int owner,
            string comm)
        {
            updateDatacontext();
            updateMySql();

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

            int maxId = (from c in datacontext.GetTable<Contracts>()
                         select c.id).Max();

            string command = string.Format($" insert into contracts (id, Number, Data, Contragent, Owner, deadLine, contract_name ) " +
              $" values({maxId}, '{num}', '{dt.Date.ToString("yyyy-MM-dd")}', {idContr}, {owner}, '{dline.Date.ToString("yyyy-MM-dd")}', '{comm}' )");
            MySqlCommand MyCommand = new MySqlCommand(command, connMySql);
            MyCommand.ExecuteNonQuery();

            return true;
        }

        public bool AddContragent(string name)
        {
            updateDatacontext();
            updateMySql();

            var contrag = from c in datacontext.GetTable<Contragents>()
                          where c.Name == name
                          select c;

            if (contrag.Count() > 0) return false;

            var newContrag = new Contragents { Name = name };
            datacontext.GetTable<Contragents>().InsertOnSubmit(newContrag);

            datacontext.SubmitChanges();

            int maxId = (from c in datacontext.GetTable<Contragents>()
                         select c.ID).Max();

            string command = string.Format($" insert into contragents (id, name) values({maxId},'{name}')");
            MySqlCommand MyCommand = new MySqlCommand(command, connMySql);
            MyCommand.ExecuteReader();

            return true;
        }

        private StringBuilder getSummForAWeek()
        {
            updateDatacontext();
            StringBuilder sb = new StringBuilder();
            double sum = 0;
            DateTime dateMinus7 = DateTime.Now.Date.AddDays(-7);
            var collection = from d in datacontext.GetTable<DateSum>()
                             where d.dateShip > dateMinus7
                             select d;
            foreach (var item in collection)
            {
                sb.Append(item.dateShip.Value.ToShortDateString() + " " + item.good + " "
                    + item.quant + " " + item.Summa);
                sb.Append("\n");
                sum += item.Summa;
            }
            sb.Append(sum.ToString());
            return sb;
        }

        public void editContract(int id, string num, DateTime data) {
            updateDatacontext();
            updateMySql();
            var c = (from co in datacontext.GetTable<Contracts>()
                     where co.id == id select co).First();
            c.Number = num;
            c.Data = data;
            datacontext.SubmitChanges();

            string command = string.Format($" update contracts set  data = '{data.Date.ToString("yyyy-MM-dd")}', number = '{num}' where id = {id} ");
            MySqlCommand MyCommand = new MySqlCommand(command, connMySql);
            MyCommand.ExecuteReader();

        }

        public bool SendCodeByMail()
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

        public void updateDatacontext()
        {
            if (datacontext != null)
            {
                datacontext.Dispose();
                datacontext = new DataContext(cn);
            }
            else
                datacontext = new DataContext(cn);
        }

        public void updateMySql() {
            if (connMySql.State == System.Data.ConnectionState.Open)
            {
                connMySql.Close();
                connMySql = new MySqlConnection(connStr);
                connMySql.Open();
            }
            else if (connMySql.State == System.Data.ConnectionState.Closed) {
                connMySql = new MySqlConnection(connStr);
                connMySql.Open();
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

    public class classForSearch
    {
        public string goodName { get; set; }

        public string number { get; set; }

        public string owner { get; set; }

        public double qAll { get; set; }

        public double qLeft { get; set; }

        public double price { get; set; }
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

        public string owner { get; set; }

        public DateTime data { get; set; }

        public int id { get; set; }
        public override string ToString()
        {
            return string.Format($"{number} {data.ToShortDateString()}");
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