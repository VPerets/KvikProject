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

namespace AppClient2
{
    public partial class Form1 : Form
    {
        private IService service = null;
        private ChannelFactory<IService> myChannelFactory = null;
        private List<Contragents> contragents = new List<Contragents>();
        private Contragents SelectedContr;
        private List<Contragents> contragentsTemp = new List<Contragents>();
        private List<Goods> allGoods = new List<Goods>();
        private bool loading = true;
        private string login = "";
        private double oldPrice = 0;

        public Form1()
        {
            InitializeComponent();
           
            this.Load += Form1_Load;
            this.FormClosing += Form1_FormClosing;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            service.close();
            if (myChannelFactory != null)
                this.myChannelFactory.Close();
        }

        private void UpdateComboContragents()
        {
            this.contragents = service.GetContragents();
            if (this.comboBox1.Items.Count != 0) this.comboBox1.Items.Clear();
            this.comboBox1.Items.Add("Все");
            this.comboBox1.Items.AddRange(this.contragents.ToArray());
            this.comboBox1.SelectedIndex = 0;
        }

        private void updateAfterEditPrice()
        {
            var goodPrice = service.getAllGoodPrice();
            if (lvGoodsPrices.Items.Count != 0) this.lvGoodsPrices.Items.Clear();
            for (int i = 0; i < goodPrice.Count; i++)
            {
                this.lvGoodsPrices.Items.Add(goodPrice[i]);
            }
        }

        private void UpdateForFill()
        {
            if (dataGridView1.Rows.Count != 0) this.dataGridView1.Rows.Clear();
            if (this.contragentsTemp.Count != 0) this.contragentsTemp.Clear();
        }

        private void UpdateAllAll()
        {
            UpdateComboContragents();
            FillDataGrid();
        }

        private void FillDataGrid(int temp = 0)
        {
            if (temp != 1)
            {
                UpdateForFill();
                this.contragentsTemp.AddRange(this.contragents.ToArray());
            }
            else
            {
                UpdateForFill();
                this.contragentsTemp.Add(SelectedContr);
            }

            int rowsCount = 0;

            for (int i = 0; i < contragentsTemp.Count; i++)
            {
                this.dataGridView1.Rows.Add(new DataGridViewRow());
                this.dataGridView1.Rows[rowsCount].Cells["total"].Value = contragentsTemp[i].Name;
                this.dataGridView1.Rows[rowsCount].Cells["total"].Style.Font
                    = new Font("Arial", 14);
                for (int c = 0; c < this.dataGridView1.Rows[0].Cells.Count; c++)
                {
                    this.dataGridView1.Rows[rowsCount].Cells[c].Style.BackColor = Color.FromArgb(240, 188, 99);
                    this.dataGridView1.Rows[rowsCount].Cells[c].ReadOnly = true;
                }
                rowsCount++;
                var contracts = service.GetContractsByContragent(contragentsTemp[i].ID);
                for (int j = 0; j < contracts.Count; j++)
                {
                    this.dataGridView1.Rows.Add(new DataGridViewRow());
                    this.dataGridView1.Rows[rowsCount].Cells["code"].Value =
                            "Договор № " + contracts[j].number;
                    this.dataGridView1.Rows[rowsCount].Cells["name"].Value = contracts[j].name;
                    this.dataGridView1.Rows[rowsCount].Cells["code"].Style.Font
                    = new Font("Arial", 12);
                    this.dataGridView1.Rows[rowsCount].Cells["name"].Style.Font
                  = new Font("Arial", 10);
                    for (int c1 = 0; c1 < this.dataGridView1.Rows[0].Cells.Count; c1++)
                    {
                        this.dataGridView1.Rows[rowsCount].Cells[c1].Style.BackColor = Color.FromArgb(83, 242, 51);
                        this.dataGridView1.Rows[rowsCount].Cells[c1].ReadOnly = true;
                    }

                    rowsCount++;

                    List<NewClassForDataGrid2> goods_ =
                        service.GetClassByContractId2(contracts[j].id);

                    for (int k = 0; k < goods_.Count; k++)
                    {
                        this.dataGridView1.Rows.Add(new DataGridViewRow());

                        this.dataGridView1.Rows[rowsCount].Cells["Name"].Value = goods_[k].name;
                        this.dataGridView1.Rows[rowsCount].Cells["Total"].Value = goods_[k].countAll;
                        this.dataGridView1.Rows[rowsCount].Cells["left"].Value = goods_[k].countLeft;
                        this.dataGridView1.Rows[rowsCount].Cells["commentary"].Value = goods_[k].commentary;
                        this.dataGridView1.Rows[rowsCount].Cells["code"].Value = goods_[k].code;
                        this.dataGridView1.Rows[rowsCount].Cells["figure"].Value = goods_[k].figure;
                        this.dataGridView1.Rows[rowsCount].Cells["priceSold"].Value = goods_[k].priceSold;

                        rowsCount++;
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loginForm form = new loginForm();
            form.ShowDialog();
            if (form.accept == false) this.Close();
            this.login = form.login;

            var myBinding = new BasicHttpBinding();
            var Uri = new Uri(ConfigurationManager.ConnectionStrings["WcfConnectionString"].ConnectionString);
            var myEndpoint = new EndpointAddress(Uri);
            myChannelFactory = new ChannelFactory<IService>(myBinding, myEndpoint);

            service = myChannelFactory.CreateChannel();
            service.open();
            MessageBox.Show(service.getCount().ToString());
            this.UpdateAllAll();
            this.allGoods = service.getAllGoods();
            updateAfterEditPrice();
            loading = false;
            this.labelSum.Text = service.getTotalSum().ToString();
            this.labelOtgr.Text = service.getLeftSum().ToString();
        }

 
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == 0)
            {
                FillDataGrid();
                return;
            }
            ComboBox comb = sender as ComboBox;
            SelectedContr = comb.SelectedItem as Contragents;
            this.FillDataGrid(1);
        }

        private void buttoEditPrice_Click(object sender, EventArgs e)
        {
            double pr;
            bool b = Double.TryParse(this.textBox1.Text, out pr);
            if (!b)
            { MessageBox.Show("Неверно введена цена"); return; }

            service.editPriceBuy(labelName.Text, pr, oldPrice);
            updateAfterEditPrice();
        }

        private void lvGoodsPrices_SelectedValueChanged(object sender, EventArgs e)
        {
            var g = this.lvGoodsPrices.Items[lvGoodsPrices.SelectedIndex] as goodPrice;
            this.textBox1.Text = g.priceBuy.ToString();
            this.labelName.Text = g.name;
            oldPrice = g.priceBuy;
        }
    }
}
