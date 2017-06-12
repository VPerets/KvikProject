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
        List<Contracts> GetContractsByContragent(int id);
        [OperationContract]
        List<NewClassForDataGrid> GetClassByContractNumber(string number);
        [OperationContract]
        void addQuantityLeftInGoods(int q, string number, int idGood);
        [OperationContract]
        int addQuantityLeftInGoods1(int q, string number, int idGood);
        [OperationContract]
        bool AddContract(string num, int idContr, DateTime dt);
        [OperationContract]
        bool AddContragent(string name);
        [OperationContract]
        List<Contragents> GetAllContragents();
    }

    [DataContract]
    public class NewClassForDataGrid
    {
        [DataMember]
        public int idGood { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public int countAll { get; set; }
        [DataMember]
        public int CountLeft { get; set; }
    }
}
