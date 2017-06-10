using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Configuration;
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

        public void addGoodsToDB(string name, string code, string fig, double buy)
        {
            Goods newGood = new Goods { CodeUZP = "123456", Figure = "12345",
                Name = "КПК-1", PriceBuy = 18000 };
            datacontext.GetTable<Goods>().InsertOnSubmit(newGood);
            datacontext.SubmitChanges();
        }
    }
}
