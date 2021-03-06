﻿using System;
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
    public partial class Form1 : Form
    {
        private IService service = null;
        private ChannelFactory<IService> myChannelFactory = null;
        private List<Contragents> contragents = new List<Contragents>();
        private Contragents SelectedContr;
        private List<Contragents> contragentsTemp = new List<Contragents>();
        private List<Contragents> AllContragents = new List<Contragents>();
        private List<owners> allOwners = new List<owners>();
        private List<Goods> allGoods = new List<Goods>();
        private string textCommTemp = "";
        private bool loading = true;
        private string login = "";

        public Form1()
        {
            InitializeComponent();
            this.Icon = new Icon("./_bmp.ico");
            this.Load += Form1_Load;
            this.FormClosing += Form1_FormClosing;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (service!=null)
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
            this.AllContragents = service.GetAllContragents();
            if (this.comboBoxContragents.Items.Count != 0) this.comboBoxContragents.Items.Clear();
            this.comboBoxContragents.Items.AddRange(this.AllContragents.ToArray());
        }

      
        private void updateComboTabOwner()
        {
            this.allOwners = service.getAllOwners();
            if (this.comboBoxOwners.Items.Count != 0) this.comboBoxOwners.Items.Clear();
            this.comboBoxOwners.Items.AddRange(this.allOwners.ToArray());
        }
        private void UpdateForFill()
        {
            if (dataGridView1.Rows.Count != 0) this.dataGridView1.Rows.Clear();
            if (this.contragentsTemp.Count != 0) this.contragentsTemp.Clear();
        }

        private void UpdateAllAll()
        {
            UpdateComboContragents();
            updateComboTabOwner();
            FillDataGrid();
            fillDataGrid1();
        }

        private void fillDataGrid1()
        {
            if (this.dataGridView2.Rows.Count != 0) this.dataGridView2.Rows.Clear();
            List<DateSum> coll = service.getForDataGrid1();
            int rows = 0;
            foreach (var item in coll)
            {
                this.dataGridView2.Rows.Add(new DataGridViewRow());
                this.dataGridView2.Rows[rows].Cells["contract"].Value = item.contract;
                this.dataGridView2.Rows[rows].Cells["date"].Value = item.Data;
                this.dataGridView2.Rows[rows].Cells["good"].Value = item.good;
                this.dataGridView2.Rows[rows].Cells["quant"].Value = item.quant;
                this.dataGridView2.Rows[rows].Cells["sum"].Value = item.summSold;
                rows++;
            }
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
                    this.dataGridView1.Rows[rowsCount].Tag = contracts[j].id;
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
                        this.dataGridView1.Rows[rowsCount].Cells["deadLine"].Value = goods_[k].deadLine;
                        this.dataGridView1.Rows[rowsCount].Cells["code"].Value = goods_[k].code;
                        this.dataGridView1.Rows[rowsCount].Cells["priceSold"].Value = goods_[k].priceSold;
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

            var myBinding = new BasicHttpBinding();
            var Uri = new Uri(ConfigurationManager.ConnectionStrings["WcfConnectionString"].ConnectionString);
            var myEndpoint = new EndpointAddress(Uri);
            myChannelFactory = new ChannelFactory<IService>(myBinding, myEndpoint);

            service = myChannelFactory.CreateChannel();
            service.open();
            this.UpdateAllAll();
            this.allGoods = service.getAllGoods();
            loading = false;
            this.labelSum.Text = service.getTotalSum().ToString();
            this.labelOtgr.Text = service.getLeftSum().ToString();
            this.dtDeadLine.Value = new DateTime(2017, 12, 31).Date;
        }

        private void btnAddGood_Click(object sender, EventArgs e)
        {
            AddGood addGoodForm = new AddGood();
            addGoodForm.Show();
            if (addGoodForm.added)
            {
                this.allGoods = service.getAllGoods();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
             DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            if (e.ColumnIndex != 6 || row.Tag == null || row.Cells["send"].Value == null) return;
            int quant;
            bool b =
                Int32.TryParse(row.Cells["send"].Value.ToString(), out quant);
            if (!b || quant > Int32.Parse(row.Cells["left"].Value.ToString()) ||
               Int32.Parse(row.Cells["total"].Value.ToString()) < (quant - Int32.Parse(row.Cells["left"].Value.ToString())))
               return;

            int id = (int)row.Tag;

            boolInt left = service.addQuantityLeftInGoods(quant, id, this.login);

            if (left.b == false)
            {
                MessageBox.Show("Информация о оставшемся количестве товара обновлена!Введите количество заново");
                row.Cells["left"].Value = left.q;
                row.Cells["send"].Value = null;
                this.labelOtgr.Text = service.getLeftSum().ToString();
                return;
            }

            row.Cells["left"].Value = left.q;
            row.Cells["send"].Value = null;
            this.labelOtgr.Text = service.getLeftSum().ToString();
            fillDataGrid1();
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

        private void buttonAddContract_Click(object sender, EventArgs e)
        {
            if (this.textBoxТNumberContract.Text == "" || this.comboBoxContragents.SelectedIndex == -1
                || this.comboBoxOwners.SelectedIndex == -1)
                return;
            int idContr = (this.comboBoxContragents.SelectedItem as Contragents).ID;
            int idOwner = (this.comboBoxOwners.SelectedItem as owners).ID;
            bool b = service.AddContract(textBoxТNumberContract.Text, idContr, dtFromContr.Value.Date,
              dtDeadLine.Value.Date, idOwner, tbCommContract.Text);
            if (b == true)
            {
                MessageBox.Show("Договор добавлен");
                this.textBoxТNumberContract.Text = "";
                this.tbCommContract.Text = "";
                this.comboBoxContragents.SelectedIndex = -1;
                this.comboBoxOwners.SelectedIndex = -1;
            }
            else
                MessageBox.Show("Возможно такой номер дрговора уже существуетЭ.Попробуйте еще");
        }

        private void buttonAddContragent_Click(object sender, EventArgs e)
        {
            if (this.textBoxContrags.Text == "") return;
            bool b = service.AddContragent(this.textBoxContrags.Text);
            if
                (!b)
                MessageBox.Show("С таким именем уже существует");
            else
            {
                this.textBoxContrags.Text = "";
                UpdateComboContragents();
                FillDataGrid();
            }
        }

        private void buttonAddGoodsInContract_Click(object sender, EventArgs e)
        {
            AddGoodsInContract form = new AddGoodsInContract();
            form.ShowDialog();
            if (form.added == true)
            {
                UpdateComboContragents();
                this.FillDataGrid();
                this.labelSum.Text = service.getTotalSum().ToString();
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (loading == true || e.ColumnIndex != 7) return;
            if (dataGridView1.Rows[e.RowIndex].Cells["commentary"].Value == null)
                textCommTemp = "";
            else
                textCommTemp = dataGridView1.Rows[e.RowIndex].Cells["commentary"].Value.ToString();
            int id = (int)dataGridView1.Rows[e.RowIndex].Tag;
            service.addCommentary(id, textCommTemp);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (tbOwner.Text == "") return;
            bool b = service.addOwner(tbOwner.Text);
            if (b == false) { MessageBox.Show("Фирма с таким именем уже существует");}
            tbOwner.Text = "";
            updateComboTabOwner();        
        }
    }
}
