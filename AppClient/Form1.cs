using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WcfService;
using KvikLibrary;
using System.ServiceModel;
using System.Configuration;

namespace AppClient
{
    public partial class Form1 : Form
    {
        private Service service = null;
        private List<Contragents> contragents = new List<Contragents>();
        private List<Contragents> SelectedContr = new List<Contragents>();
        private List<Contragents> AllContragents = new List<Contragents>();
        private string textCommTemp = "";
        private bool loading = true;
        private double oldPrice = 0;
        private string login = "";
        private int selectedContrIndex = 0;
        //       private ChannelFactory<IService> myChannelFactory = null;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            this.FormClosing += Form1_FormClosing;
            this.Resize += Form1_Resize;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.lvGoodsPrices.Height = this.Height - 10;
            this.lvGoodsPrices.Width = this.Width - 100;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            service.close();
        }

        private void UpdateComboContragents()
        {
            this.contragents = service.GetContragents();
            if (this.SelectedContr.Count>0) this.SelectedContr.Clear();
            this.SelectedContr.AddRange(this.contragents.ToArray());
            if (this.comboBox1.Items.Count != 0) this.comboBox1.Items.Clear();
            this.comboBox1.Items.Add("Все");
            this.comboBox1.Items.AddRange(this.contragents.ToArray());
            this.comboBox1.SelectedIndex = -1;
            selectedContrIndex = -1;

        }

        private void updateAfterEditPrice()
        {
            List<goodPrice> goodPrice = service.getAllGoodPrice();
            SortClass<goodPrice> sorting = new SortClass<goodPrice>();
            goodPrice.Sort(sorting);
            if (lvGoodsPrices.Items.Count != 0) this.lvGoodsPrices.Items.Clear();
            for (int i = 0; i < goodPrice.Count; i++)
            {
                this.lvGoodsPrices.Items.Add(goodPrice[i]);
            }
        }
     
        private void UpdateForFill()
        {
            if (dataGridView1.Rows.Count != 0) this.dataGridView1.Rows.Clear();
        }

        private void UpdateAllAll()
        {
            UpdateComboContragents();
            FillDataGrid();
        }

        private void FillDataGrid()
        {

            UpdateForFill();

            int rowsCount = 0;

            for (int i = 0; i < SelectedContr.Count; i++)
            {
                this.dataGridView1.Rows.Add(new DataGridViewRow());
                this.dataGridView1.Rows[rowsCount].Cells["total"].Value = SelectedContr[i].Name;
                this.dataGridView1.Rows[rowsCount].Cells["total"].Style.Font
                    = new Font("Arial", 14);
                for (int c = 0; c < this.dataGridView1.Rows[0].Cells.Count; c++)
                {
                    this.dataGridView1.Rows[rowsCount].Cells[c].Style.BackColor = Color.FromArgb(240, 188, 99);
                    this.dataGridView1.Rows[rowsCount].Cells[c].ReadOnly = true;
                }
                rowsCount++;
                var contracts = service.GetContractsByContragent(SelectedContr[i].ID);
                for (int j = 0; j < contracts.Count; j++)
                {
                    this.dataGridView1.Rows.Add(new DataGridViewRow());

                    this.dataGridView1.Rows[rowsCount].Cells["code"].Value =
                        "Договор № " + contracts[j].number;
                    this.dataGridView1.Rows[rowsCount].Cells["name"].Value = contracts[j].name;
                    this.dataGridView1.Rows[rowsCount].Cells["code"].Style.Font
                    = new Font("Arial", 12);
                    this.dataGridView1.Rows[rowsCount].Cells["name"].Style.Font
                  = new Font("Arial", 12);
                    for (int c1 = 0; c1 < this.dataGridView1.Rows[0].Cells.Count; c1++)
                    {
                        this.dataGridView1.Rows[rowsCount].Cells[c1].Style.BackColor = Color.FromArgb(83, 242, 51);
                        this.dataGridView1.Rows[rowsCount].Cells[c1].ReadOnly = true;
                    }

                    rowsCount++;

                    List<NewClassForDataGrid> goods_ =
                        service.GetClassByContractId(contracts[j].id);

                    for (int k = 0; k < goods_.Count; k++)
                    {
                        this.dataGridView1.Rows.Add(new DataGridViewRow());

                        this.dataGridView1.Rows[rowsCount].Tag = goods_[k].idGinC;
                        this.dataGridView1.Rows[rowsCount].Cells["Name"].Value = goods_[k].name;
                        this.dataGridView1.Rows[rowsCount].Cells["Total"].Value = goods_[k].countAll;
                        this.dataGridView1.Rows[rowsCount].Cells["left"].Value = goods_[k].countLeft;
                        this.dataGridView1.Rows[rowsCount].Cells["commentary"].Value = goods_[k].commentary;
                        this.dataGridView1.Rows[rowsCount].Cells["code"].Value = goods_[k].code;
                        this.dataGridView1.Rows[rowsCount].Cells["figure"].Value = goods_[k].figure;
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
            service = new Service();
            service.open();
            this.UpdateAllAll();
            updateAfterEditPrice();
            loading = false;
            this.lvGoodsPrices.Height = this.Height;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comb = sender as ComboBox;
            if (selectedContrIndex == comb.SelectedIndex) return;
            selectedContrIndex = comb.SelectedIndex;

            this.SelectedContr.Clear();

            if (this.comboBox1.SelectedIndex == 0)
            {
                this.SelectedContr.AddRange(this.contragents.ToArray());
                FillDataGrid();
                return;
            }

            this.SelectedContr.Add(this.contragents[comb.SelectedIndex - 1]);
            this.FillDataGrid();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (loading == true || e.ColumnIndex != 5) return;
            if (dataGridView1.Rows[e.RowIndex].Cells["commentary"].Value == null)
                textCommTemp = "";
            else
                textCommTemp = dataGridView1.Rows[e.RowIndex].Cells["commentary"].Value.ToString();
            int id = (int)dataGridView1.Rows[e.RowIndex].Tag;
            service.addCommentary(id, textCommTemp);
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

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            UpdateAllAll();
        }

        private void setByRadio(int case_)
        {
            if (case_ == 1)
            {
                FillDataGrid();
                return;
            }

            FillDataGrid();
            int count = dataGridView1.Rows.Count;
            bool bool_;

            if (case_ == 0)
                bool_ = true;
            else
                bool_ = false;

            for (int i = 0; i < count; i++)
            {
                if (dataGridView1.Rows[i].Cells["left"].Value == null) continue;
                if ((Int32.Parse(dataGridView1.Rows[i].Cells["left"].Value.ToString()) <= 0) == bool_)
                {
                    dataGridView1.Rows.RemoveAt(i);
                    i--;
                    count--;
                }
            }
        }

        private void radioAll_Click(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
        
            switch (rb.Name)
            {
                case "radioLeft":
                    setByRadio(0);
                    break;
                case "radioAll":
                    setByRadio(1);
                    break;
                case "radioNoLeft":
                    setByRadio(2);
                    break;
            }
        }
    }
}
