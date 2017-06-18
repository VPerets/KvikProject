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
        bool addGoodsToDB(string name, string code, string fig, double buy);

        [OperationContract]
        List<Contragents> GetContragents();

        [OperationContract]
        List<contract_> GetContractsByContragent(int id);

        [OperationContract]
        List<NewClassForDataGrid> GetClassByContractNumber(string number);

        [OperationContract]
        void addQuantityLeftInGoods(int q, int GinC);

        [OperationContract]
        List<contract_> getAllContracts();

        [OperationContract]
        void addToGinC(string num, int q, double price, int idGood);

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
        List<classsAboutGoodsInContract> getGoodsByContract(string GinC);

        [OperationContract]
        void addCommentary(int ginc, string comm);

        [OperationContract]
        List<goodPrice> getAllGoodPrice();

        [OperationContract]
        void editPriceBuy(string name, double pr);

        [OperationContract]
        double getTotalSum();

        [OperationContract]
        double getLeftSum();
    }

    public interface IServiceUser
    {

        [OperationContract]
        List<Contragents> GetContragents();

        [OperationContract]
        List<contract_> GetContractsByContragent(int id);

        [OperationContract]
        List<NewClassForDataGrid> GetClassByContractNumber(string number);

        [OperationContract]
        void addQuantityLeftInGoods(int q, int GinC);

        [OperationContract]
        List<contract_> getAllContracts();

        [OperationContract]
        void addCommentary(int ginc, string comm);

        [OperationContract]
        List<goodPrice> getAllGoodPrice();

        [OperationContract]
        void editPriceBuy(string name, double pr);
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
        public override string ToString()
        {
            return string.Format($"{name} {countAll} {countLeft} {deadLine} {commentary}");
        }
    }
    [DataContract]
    public class contract_
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string number { get; set; }
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
