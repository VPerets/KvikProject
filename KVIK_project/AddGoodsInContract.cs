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
        private IService service = null;
        private ChannelFactory<IService> myChannelFactory = null;
        public bool added = false;
        public int id;
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

            this.service = myChannelFactory.CreateChannel();
            this.listView1.View = View.List;
            this.comboGoods.Items.AddRange(service.getAllGoods().ToArray());
            this.comboBoxContracts.Items.AddRange(service.getAllContracts().ToArray());
        }

        private void comboBoxContracts_SelectedIndexChanged(object sender, EventArgs e)
        {          
            id = (comboBoxContracts.SelectedItem as contract_).id;
            updateList(id);
        }

        public void updateList(int id)
        {
            if (this.listView1.Items.Count != 0) this.listView1.Items.Clear();
            var col = service.getGoodsByContract(id);
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
            string quantity = this.tbKol.Text;
            string price = this.tbPrice.Text;
            if (quantity.Contains('.') )
             quantity = quantity.Replace('.', ',');
            if (price.Contains('.'))
                price = price.Replace('.', ',');
            int q;
            bool b = Int32.TryParse(quantity, out q);
            double pr;
            bool b1 = Double.TryParse(price, out pr);
            MessageBox.Show(pr.ToString());
            if (!b ) { MessageBox.Show("Ввести корректное значение количества");return; }
            if (!b1) { MessageBox.Show("Ввести корректное значение цены"); return; }
            service.addToGinC(id, q, pr, g.ID);
            this.tbPrice.Text = "";
            this.tbKol.Text = "";
            this.comboGoods.SelectedIndex = -1;
            added = true;
            updateList(id);
        }
                    
    }
}

