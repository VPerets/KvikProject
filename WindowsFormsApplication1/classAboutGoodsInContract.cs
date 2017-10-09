using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class classAboutGoodsInContract
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
