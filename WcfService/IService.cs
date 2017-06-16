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
        List<string> GetContractsByContragent(int id);
        [OperationContract]
        List<NewClassForDataGrid> GetClassByContractNumber(string number);
        [OperationContract]
        void addQuantityLeftInGoods(int q, int GinC);
        [OperationContract]
        List<string> getAllContracts();
        [OperationContract]
        void addToGinC(string num, int q, double price, int idGood);

        [OperationContract]
        bool AddContract(string num, int idContr, DateTime dt, DateTime dl ,int owner);
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
        public override string ToString()
        {
            return string.Format($"{name} {countAll} {countLeft} {deadLine} {commentary}");
        }
        [DataMember]
        public string owner { get; set; }
        [DataMember]
        public int idGinC { get; set; }
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
        //[DataMember]
        //public owners owner { get; set; }
        //[DataMember]
        //public int idGinC { get; set; }
    }
}
