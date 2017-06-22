using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WcfService;
using KvikLibrary;
using System.ServiceModel;
using System.Configuration;

namespace KVIK_project
{
    public partial class AddGood : Form
    {
        public string name;
        public string code;
        public string figure;
        public double buy;
        private ChannelFactory<IService> myChannelFactory = null;
        public bool added = false;
        private IService service;

        public AddGood()
        {
            InitializeComponent();
            this.FormClosing += AddGood_FormClosing;
            this.Load += AddGood_Load;
            this.FormClosing += AddGood_FormClosing1;
        }

        private void AddGood_FormClosing1(object sender, FormClosingEventArgs e)
        {
            myChannelFactory.Close();
        }

        private void AddGood_Load(object sender, EventArgs e)
        {
            var myBinding = new WSHttpBinding();
            var Uri = new Uri(ConfigurationManager.ConnectionStrings["WcfConnectionString"].ConnectionString);
            var myEndpoint = new EndpointAddress(Uri);

            myChannelFactory = new ChannelFactory<IService>(myBinding, myEndpoint);

        }

        private void AddGood_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            name = this.tbName.Text;
            figure = this.tbFigure.Text;
            code = this.tbCode.Text;
            double b;
            if (Double.TryParse(this.tbPriceBuy.Text, out b))
                buy = b;
            else
            {
                MessageBox.Show("Ввести корректное значение цены покупки");
                return;
            }

            bool bool_ = service.addGoodsToDB(name, code, figure, buy);

            if (bool_ == false)
            {
                MessageBox.Show("Продукт с таким чертежем уже существует");
                return;
            }
            added = true;
            this.tbName.Text = "";
            this.tbPriceBuy.Text = "";
            this.tbCode.Text = "";
            this.tbFigure.Text = "";
        }
    }
}
