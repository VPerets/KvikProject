using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using KvikLibrary;

namespace WcfService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        List<DateSum> getForDataGrid1();

        [OperationContract]
        int getCount();

        [OperationContract ]
        bool checkLoginPass(string l, string p);

        [OperationContract]
        void close();

        [OperationContract]
        bool addGoodsToDB(string name, string code, string fig, double buy);

        [OperationContract]
        List<Contragents> GetContragents();

        [OperationContract]
        List<contract_> GetContractsByContragent(int id);

        [OperationContract]
        bool addOwner(string name);

        [OperationContract]
        List<NewClassForDataGrid> GetClassByContractId(int id);

        [OperationContract]
        List<NewClassForDataGrid2> GetClassByContractId2(int id);

        [OperationContract]
        boolInt addQuantityLeftInGoods(int q, int GinC, string log);

        [OperationContract]
        List<contract_> getAllContracts();

        [OperationContract]
        void addToGinC(int id, int q, double price, int idGood);

        [OperationContract]
        bool AddContract(string num, int idContr, DateTime dt, DateTime dl ,int owner, string comm);

        [OperationContract]
        bool AddContragent(string name);

        [OperationContract]
        List<Contragents> GetAllContragents();

        [OperationContract]
        List<owners> getAllOwners();

        [OperationContract]
        List<Goods> getAllGoods();

        [OperationContract]
        List<classsAboutGoodsInContract> getGoodsByContract(int GinC);

        [OperationContract]
        void addCommentary(int ginc, string comm);

        [OperationContract]
        List<goodPrice> getAllGoodPrice();

        [OperationContract]
        void editPriceBuy(string name, double newPr, double old);

        [OperationContract]
        double getTotalSum();

        [OperationContract]
        double getLeftSum();
    }

    public class SortClass<T> : IComparer<T>
    where T : goodPrice
    {
        public int Compare(T x, T y)
        {
            return x.name.CompareTo(y.name);
        }
    }

    [DataContract]
    public class goodPrice
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public double priceBuy { get; set; }
        public override string ToString()
        {
            return string.Format($"{name} {priceBuy}");
        }
    }

    [DataContract]
    public class boolInt
    {
        [DataMember]
        public int q { get; set; }
        [DataMember]
        public bool b { get; set; }
    }

    [DataContract]
    public class NewClassForDataGrid
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public int countAll { get; set; }
        [DataMember]
        public int countLeft { get; set; }
        [DataMember]
        public string commentary { get; set; }
        [DataMember]
        public DateTime deadLine { get; set; }
        [DataMember]
        public int idGinC { get; set; }
        [DataMember]
        public string code { get; set; }
        [DataMember]
        public string figure { get; set; }
        [DataMember]
        public double priceSold { get; set; }
        public override string ToString()
        {
            return string.Format($"{name} {countAll} {countLeft} {deadLine} {commentary}");
        }
    }

    [DataContract]
    public class NewClassForDataGrid2
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public int countAll { get; set; }
        [DataMember]
        public int countLeft { get; set; }
        [DataMember]
        public string commentary { get; set; }
        [DataMember]
        public string code { get; set; }
        [DataMember]
        public string figure { get; set; }
        [DataMember]
        public double priceSold { get; set; }
        public override string ToString()
        {
            return string.Format($"{name} {countAll} {countLeft} {commentary}");
        }
    }

    [DataContract]
    public class contract_
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string number { get; set; }
        [DataMember]
        public int id { get; set; }
        public override string ToString()
        {
            return string.Format($"{number}");
        }
    }
    [DataContract]
    public class classsAboutGoodsInContract
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public int countAll { get; set; }
        [DataMember]
        public int countLeft { get; set; }
        [DataMember]
        public double PriceSold { get; set; }
        public override string ToString()
        {
            return string.Format($"{name} Всего:{countAll} Осталось:{countLeft} Продажа:{PriceSold}");
        }
    }
}
