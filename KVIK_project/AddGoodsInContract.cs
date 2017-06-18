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
    public partial class AddGoodsInContract : Form
    {
        public IService service = null;
        public bool added = false;
        public string number;
        public ChannelFactory<IService> myChannelFactory = null;
        public AddGoodsInContract()
        {
            InitializeComponent();
            this.Load += AddGoodsInContract_Load;
            this.FormClosing += AddGoodsInContract_FormClosing;
        }

        private void AddGoodsInContract_FormClosing(object sender, FormClosingEventArgs e)
        {
            myChannelFactory.Close();
        }

        private void AddGoodsInContract_Load(object sender, EventArgs e)
        {
            var myBinding = new BasicHttpBinding();
            var Uri = new Uri(ConfigurationManager.ConnectionStrings["WcfConnectionString"].ConnectionString);
            var myEndpoint = new EndpointAddress(Uri);

            myChannelFactory = new ChannelFactory<IService>(myBinding, myEndpoint);

            service = myChannelFactory.CreateChannel();
            this.listView1.View = View.List;
            this.comboGoods.Items.AddRange(service.getAllGoods().ToArray());
            this.comboBoxContracts.Items.AddRange(service.getAllContracts().ToArray());
        }

        private void comboBoxContracts_SelectedIndexChanged(object sender, EventArgs e)
        {          
            number = (comboBoxContracts.SelectedItem as contract_).number;
            updateList(number);
        }

        public void updateList(string number)
        {
            if (this.listView1.Items.Count != 0) this.listView1.Items.Clear();
            var col = service.getGoodsByContract(number);
            for (int i = 0; i < col.Count; i++)
            {
                this.listView1.Items.Add(col[i].ToString());
            }
        }
        private void buttonAddGoodsToContract_Click(object sender, EventArgs e)
        {
            if (this.comboBoxContracts.SelectedIndex == -1 || this.comboGoods.SelectedIndex == -1
                || this.tbKol.Text == "" || this.tbPrice.Text == "")
                return;
            
            Goods g = this.comboGoods.SelectedItem as Goods;
            int q = Int32.Parse(this.tbKol.Text);
            double pr = Double.Parse(this.tbPrice.Text);
            service.addToGinC(number, q, pr, g.ID);
            this.tbPrice.Text = "";
            this.tbKol.Text = "";
            this.comboGoods.SelectedIndex = -1;
            added = true;
            updateList(number);
        }
                    
    }
}

