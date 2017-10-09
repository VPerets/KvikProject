using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Threading;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{

    public class Service
    {

        static Timer timer;
        MySqlConnection connMySql = null;
        static int count = 0;
        string connStr = "";
        string option = "Convert Zero Datetime=True";
        public Service()
        {
            connStr = "server=mysql.zzz.com.ua" +
                ";user=kvik" +
                ";database=kvik2006" +
                 ";port=3306" +
                ";password=Western2233;" + option;
            connMySql = new MySqlConnection(connStr);
            connMySql.Open();

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

            if (connMySql.State == System.Data.ConnectionState.Open)
                connMySql.Clone();
        }

        //public void forTimer(object obj)
        //{
        //    if (DateTime.Now.Date.DayOfWeek == DayOfWeek.Friday)
        //    {
        //        SendCodeByMail();
        //    }
        //}

        public List<DateSum> getForDataGrid1()
        {
            updateMySql();
            List<DateSum> dates = new List<DateSum>();
            MySqlCommand cmd = new MySqlCommand("select id, summa, summSold, good, quant, contract, whoIs, dateShip as ds from datesum",
                connMySql);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dates.Add(new DateSum((int)reader["id"], (double)reader["summa"], (double)reader["summSold"], (string)reader["good"], 
                    (int)reader["quant"], (string)reader["contract"], (string)reader["whoIs"], (DateTime)reader["ds"]));
            }
            return dates;
        }


        public bool addGoodsToDB(string name, string code, string fig, double buy, bool isOur)
        {
            //updateDatacontext();
            updateMySql();

            try
            {
                using (MySqlCommand cmd = new MySqlCommand("insert into goods2 (name, numberObl ,figure, priceBuy, isOur ) values(@Parname , @Parname2, @Parname3, @Parname4, @Parname5)", connMySql))
                {
                    // change MySqlDbType.Double to reflect the real data type in the table.
                    cmd.Parameters.Add("@Parname", MySqlDbType.String).Value = name;
                    cmd.Parameters.Add("@Parname2", MySqlDbType.String).Value = code;
                    cmd.Parameters.Add("@Parname3", MySqlDbType.String).Value = fig;
                    cmd.Parameters.Add("@Parname4", MySqlDbType.Double).Value = buy;
                    cmd.Parameters.Add("@Parname5", MySqlDbType.Bit).Value = isOur;

                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return false;
        }

        public void addCommentary(int GinC, string comm)
        {
            //updateDatacontext();
            //updateMySql();

            //string command = string.Format($" update goodsincontract set commentary = '{comm}' " +
            //   $" where id = {GinC}");
            //MySqlCommand MyCommand = new MySqlCommand(command, connMySql);
            //MyCommand.ExecuteReader();

            //var goodIn = (from g in datacontext.GetTable<GoodsInContract>()
            //              where g.id == GinC
            //              select g).First();
            //goodIn.commentary = comm;
            //datacontext.SubmitChanges();
        }
        private double getSum()
        {
            updateMySql();
            double sum = 0;
            MySqlCommand cmd = new MySqlCommand("select sum(t.summm) as s from " +
            "(SELECt goodsincontract.PriceSold * goodsincontract.Quantity as summm from goodsincontract )t", connMySql);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                sum = (double)reader["s"];
            }
            return sum;
        }

        public double getTotalSum()
        {
            return getSum();
        }

        public double getLeftSum()
        {
            updateMySql();
            double sum = 0;
            MySqlCommand cmd = new MySqlCommand("select sum(t.summm) as s from " +
            "(SELECt goodsincontract.PriceSold * (goodsincontract.Quantity - goodsincontract.QuantityLeft) as summm from goodsincontract )t", connMySql);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                sum = (double)reader["s"];
            }
            return sum;
        }

        //    public List<goodPrice> getAllGoodPrice()
        //    {
        //        updateDatacontext();
        //        var col = from g in datacontext.GetTable<Goods>()
        //                  select new goodPrice { name = g.Name, priceBuy = g.PriceBuy };
        //        return col.ToList();
        //    }

        //    public void editPriceBuy(string name, double New, double old)
        //    {
        //        updateDatacontext();
        //        updateMySql();

        //        string command = string.Format($" update goods set priceBuy = {New} " +
        //           $" where name = '{name}'");
        //        MySqlCommand MyCommand = new MySqlCommand(command, connMySql);
        //        MyCommand.ExecuteReader();


        //        var good = (from g in datacontext.GetTable<Goods>()
        //                    where g.Name == name
        //                    select g).First();
        //        good.PriceBuy = New;

        //        var update = new UpdateGoodsPrice { data = DateTime.Now.Date, good = name, newPrice = New, oldPrice = old };
        //        datacontext.GetTable<UpdateGoodsPrice>().InsertOnSubmit(update);

        //        datacontext.SubmitChanges();

        //    }
        public bool checkLoginPass(string l, string p)
        {
            
            return true;
        }

        public boolInt addQuantityLeftInGoods(int q, int GinC, string login, DateTime dateVal)
        {
            updateMySql();

            string command = string.Format($"update goodsincontract set  QuantityLeft = goodsincontract.QuantityLeft - {q} where id = {GinC} ");
            MySqlCommand MyCommand = new MySqlCommand(command, connMySql);
            MyCommand.ExecuteReader();

            command = string.Format($"select goodsincontract.whoIs,  goods.priceBuy,goods.name as goodName, contracts.number as num, goodsincontract.PriceSold from" +
                $"(select idgood as ig from goodsincontract where goodsincontract.id = {GinC})t, " +
                $"goods inner join goodsincontract on goods.id = goodsincontract.idGood where goods.id = t.ig " +
                " inner join contracts on contracts.id = goodsincontract.idContract " +
                $"and goodsincontract.id = {GinC}");
            MyCommand = new MySqlCommand(command, connMySql);
            MySqlDataReader reader = MyCommand.ExecuteReader();
            double sum2 = 0, sum = 0;
            string gName = "", num = " ";
            while (reader.Read())
            {
                sum = (double)reader["priceBuy"] * q;
                sum2 = (double)reader["PriceSold"] * q;
                gName = reader["goodName"].ToString();
                num = reader["num"].ToString();
            }

            command = string.Format($"insert into datesum (Data, summa, quant, contract, good, whoIs, SummaSold) values " +
                $"('{dateVal}', {sum}, {q}, '{num}', '{gName}', '{login}', {sum2}) ");

            command = string.Format($"select  QuantityLeft from goodsincontract where id = {GinC} ");
            MyCommand = new MySqlCommand(command, connMySql);
            reader = MyCommand.ExecuteReader();
            int quant = 0;
            while (reader.Read()) quant = (int)reader["QuantityLeft"];
            return new boolInt { q = quant, b = true };
        }

        public bool addOwner(string name)
        {
            updateMySql();
                     
            string command = string.Format($" insert into owners ( name ) " +
               $" values('{name}' )");

            MySqlCommand MyCommand = new MySqlCommand(command, connMySql);
            MyCommand.ExecuteNonQuery();

            return true;
        }

        //    private void addToDateSumOtgruz(int q, string num, string good)
        //    {
        //        if (datacontext != null)
        //        {
        //            datacontext.Dispose();
        //            datacontext = new DataContext(cn);
        //        }
        //        else
        //            datacontext = new DataContext(cn);
        //        double priceBuy = (from g in datacontext.GetTable<Goods>()
        //                           where g.Name == ""
        //                           select g.PriceBuy).First();
        //        double summ = priceBuy * q;
        //        var otgruzka = new DateSum
        //        {
        //            contract = num,
        //            dateShip = DateTime.Now.Date,
        //            good = good,
        //            quant = q,
        //            Summa = summ
        //        };
        //        datacontext.GetTable<DateSum>().InsertOnSubmit(otgruzka);
        //        datacontext.SubmitChanges();
        //    }

        public List<classAboutGoodsInContract> getGoodsByContract(int id)
        {

            return new List<classAboutGoodsInContract>();
        }

        public void addToGinC(int id, int q, double price, int idGood)
        {
          
            updateMySql();
       
            using (MySqlCommand cmd = new MySqlCommand("insert into goodsincontract ( idGood, idContract, PriceSold, Quantity, QuantityLeft ) values( @Parname2, @Parname3, @Parname4, @Parname5, @Parname6)", connMySql))
            {
                // change MySqlDbType.Double to reflect the real data type in the table.
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
            updateMySql();
            List<Goods> goods = new List<Goods>();
            MySqlCommand cmd = new MySqlCommand("select * from goods", connMySql);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                goods.Add(new Goods((int)reader["id"], reader["name"].ToString(), reader["numberObl"].ToString(), reader["figure"].ToString(), (double)reader["priceBuy"], (bool)reader["isOur"]));
            }
            return goods;
        }

        public List<owners> getAllOwners()
        {
            updateMySql();
            List<owners> owns = new List<owners>();
            MySqlCommand cmd = new MySqlCommand("select * from owners", connMySql);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                owns.Add(new owners(Int32.Parse(reader["id"].ToString()), reader["name"].ToString()));
            }
            return owns;
        }

        public List<NewClassForDataGrid> GetClassByContractId(int id)
        {
            updateMySql();
            List<NewClassForDataGrid> contrs = new List<NewClassForDataGrid>();
            MySqlCommand cmd = new MySqlCommand("select goods.name as name, goodsincontract.Quantity as quan, " +
            "goodsincontract.QuantityLeft as qleft, goodsincontract.commentary, contracts.Number as num, " +
            " goodsincontract.PriceSold as pr, goodsincontract.id as id, contracts.deadLine as dl, " + 
            "goods.figure as fig, goods.numberObl as code from goods inner join goodsincontract on " +
            "goods.id = goodsincontract.idGood inner join contracts on contracts.id = goodsincontract.idContract " +
            "where contracts.id = " + id, connMySql);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //  System.Windows.Forms.MessageBox.Show(reader["dl"].ToString());
                //System.Windows.Forms.MessageBox.Show(ddt.ToString());
              //  DateTime ddd = DateTime.Parse(reader["dl"].ToString());
                contrs.Add(new NewClassForDataGrid(reader["name"].ToString(), (int)(reader["quan"]), (int)(reader["qleft"]),
                    reader["commentary"].ToString(), (DateTime)reader["dl"],
                    (int)(reader["id"]), reader["code"].ToString(),
                    reader["fig"].ToString(), (double)reader["pr"]));
            }
            return contrs;
        }

        //    public List<NewClassForDataGrid2> GetClassByContractId2(int id)
        //    {
        //        updateDatacontext
        //        var coll = from g in datacontext.GetTable<Goods>()
        //                   from c in datacontext.GetTable<Contracts>()
        //                   from o in datacontext.GetTable<owners>()
        //                   from ginc in datacontext.GetTable<GoodsInContract>()
        //                   where ginc.idContract == id && g.ID == ginc.IdGood
        //                   && c.id == id && c.owner == o.ID
        //                   select new NewClassForDataGrid2
        //                   {
        //                       countAll = ginc.Quantity,
        //                       countLeft = ginc.QuantityLeft,
        //                       name = g.Name,
        //                       commentary = ginc.commentary,
        //                       priceSold = ginc.PriceSold,
        //                       code = g.numberObl,
        //                       figure = g.Figure
        //                   };

        //        return coll.ToList();
        //    }
        public List<contract_> GetContractsByContragent(int id)
        {
            updateMySql();
            List<contract_> contrs = new List<contract_>();
            MySqlCommand cmd = new MySqlCommand("select contracts.id as id, contract_name, Number, owners.name as owner from contracts inner join owners on owners.id = contracts.Owner where Contragent = " + id, connMySql);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                contrs.Add(new contract_(reader["contract_name"].ToString(), reader["Number"].ToString(), reader["owner"].ToString(), (int)reader["id"]));
            }
            return contrs;
        }


        public List<Contracts> getAllContracts()
        {
            updateMySql();
            List<Contracts> contrs = new List<Contracts>();
            MySqlCommand cmd = new MySqlCommand("select * from contracts", connMySql);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                contrs.Add(new Contracts((int)reader["id"], reader["Number"].ToString(), (DateTime)reader["Data"],
                    (int)reader["Contragent"], reader["contract_name"].ToString(), (int)reader["Owner"], (DateTime)reader["deadLine"]));
            }
            return contrs;
        }

        public List<Contragents> GetAllContragents()
        {
            updateMySql();
            List<Contragents> contrs = new List<Contragents>();
            MySqlCommand cmd = new MySqlCommand("select * from contragents", connMySql);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                contrs.Add(new Contragents(Int32.Parse(reader["id"].ToString()), reader["name"].ToString()));
            }
            return contrs;
        }

        public List<Contragents> GetContragents()
        {
            updateMySql();
            List<Contragents> contrs = new List<Contragents>();
            MySqlCommand cmd = new MySqlCommand("select * from contragents", connMySql);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                contrs.Add(new Contragents(Int32.Parse(reader["id"].ToString()), reader["name"].ToString()));
            }
            return contrs;

        }

        public bool AddContract(string num, int idContr, DateTime dt, DateTime dline, int owner,
            string comm)
        {
            //updateDatacontext();
            //updateMySql();

            //var contract = from c in datacontext.GetTable<Contracts>()
            //               where c.Number == num
            //               select c;
            //if (contract.Count() > 0) return false;

            //var newConract = new Contracts
            //{
            //    Contragent = idContr,
            //    Data = dt.Date,
            //    Number = num,
            //    DeadLine = dline,
            //    owner = owner,
            //    contract_Name = comm
            //};
            //datacontext.GetTable<Contracts>().InsertOnSubmit(newConract);
            //datacontext.SubmitChanges();

            //int maxId = (from c in datacontext.GetTable<Contracts>()
            //             select c.id).Max();

            //string command = string.Format($" insert into contracts (id, Number, Data, Contragent, Owner, deadLine, contract_name ) " +
            //  $" values({maxId}, '{num}', '{dt.Date.ToString("yyyy-MM-dd")}', {idContr}, {owner}, '{dline.Date.ToString("yyyy-MM-dd")}', '{comm}' )");
            //MySqlCommand MyCommand = new MySqlCommand(command, connMySql);
            //MyCommand.ExecuteNonQuery();

            return true;
        }

        public bool AddContragent(string name)
        {
            //updateDatacontext();
            //updateMySql();

            //var contrag = from c in datacontext.GetTable<Contragents>()
            //              where c.Name == name
            //              select c;

            //if (contrag.Count() > 0) return false;

            //var newContrag = new Contragents { Name = name };
            //datacontext.GetTable<Contragents>().InsertOnSubmit(newContrag);

            //datacontext.SubmitChanges();

            //int maxId = (from c in datacontext.GetTable<Contragents>()
            //             select c.ID).Max();

            //string command = string.Format($" insert into contragents (id, name) values({maxId},'{name}')");
            //MySqlCommand MyCommand = new MySqlCommand(command, connMySql);
            //MyCommand.ExecuteReader();

            return true;
        }

        //    private StringBuilder getSummForAWeek()
        //    {
        //        updateDatacontext();
        //        StringBuilder sb = new StringBuilder();
        //        double sum = 0;
        //        DateTime dateMinus7 = DateTime.Now.Date.AddDays(-7);
        //        var collection = from d in datacontext.GetTable<DateSum>()
        //                         where d.dateShip > dateMinus7
        //                         select d;
        //        foreach (var item in collection)
        //        {
        //            sb.Append(item.dateShip.Value.ToShortDateString() + " " + item.good + " "
        //                + item.quant + " " + item.Summa);
        //            sb.Append("\n");
        //            sum += item.Summa;
        //        }
        //        sb.Append(sum.ToString());
        //        return sb;
        //    }

        //    public bool SendCodeByMail()
        //    {
        //        // отправитель - устанавливаем адрес и отображаемое в письме имя
        //        MailAddress from = new MailAddress("vitaliia.perets@gmail.com");
        //        // кому отправляем
        //        MailAddress to = new MailAddress("80501903813vs@gmail.com");
        //        // создаем объект сообщения
        //        MailMessage m = new MailMessage(from, to);
        //        // тема письма
        //        m.Subject = "Отгрузка на " + DateTime.Now.Date.ToShortDateString();
        //        // текст письма
        //        m.Body = getSummForAWeek().ToString();
        //        // письмо представляет код html
        //        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
        //        {
        //            EnableSsl = true,
        //            DeliveryMethod = SmtpDeliveryMethod.Network,
        //            UseDefaultCredentials = false,
        //            Credentials = new NetworkCredential("vitaliia.perets@gmail.com", "Perets2233")
        //        };

        //        try
        //        {
        //            smtp.Send(m);

        //            return true;
        //        }
        //        catch
        //        {
        //            return false;
        //        }
        //    }

        //    public void updateDatacontext()
        //    {
        //        if (datacontext != null)
        //        {
        //            datacontext.Dispose();
        //            datacontext = new DataContext(cn);
        //        }
        //        else
        //            datacontext = new DataContext(cn);
        //    }

        public void updateMySql()
        {
            if (connMySql.State == System.Data.ConnectionState.Open)
            {
                connMySql.Close();
                connMySql = new MySqlConnection(connStr);
                connMySql.Open();
            }
            else if (connMySql.State == System.Data.ConnectionState.Closed)
            {
                connMySql = new MySqlConnection(connStr);
                connMySql.Open();
            }

        }
        //}
        //public class SortClass<T> : IComparer<T>
        //where T : goodPrice
        //{
        //    public int Compare(T x, T y)
        //    {
        //        return x.name.CompareTo(y.name);
        //    }
        //}

        //public class goodPrice
        //{

        //    public string name { get; set; }

        //    public double priceBuy { get; set; }
        //    public override string ToString()
        //    {
        //        return string.Format($"{name} {priceBuy}");
        //    }
        //}


        public class boolInt
        {

            public int q { get; set; }

            public bool b { get; set; }
        }


        public class NewClassForDataGrid
        {
            public NewClassForDataGrid(string n, int all, int lef, string com, DateTime d, int idc, string code, string fig, double pr)
            {
                this.name = n;
                this.countAll = all;
                this.countLeft = lef;
                this.commentary = com;
                this.deadLine = d.Date;
                this.idGinC = idc;
                this.code = code;
                this.figure = fig;
                this.priceSold = pr;
            }

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


        //public class NewClassForDataGrid2
        //{

        //    public string name { get; set; }

        //    public int countAll { get; set; }

        //    public int countLeft { get; set; }

        //    public string commentary { get; set; }

        //    public string code { get; set; }

        //    public string figure { get; set; }

        //    public double priceSold { get; set; }
        //    public override string ToString()
        //    {
        //        return string.Format($"{name} {countAll} {countLeft} {commentary}");
        //    }
        //}
    }
}