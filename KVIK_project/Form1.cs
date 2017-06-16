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
    public partial class Form1 : Form
    {
        private int rowNeed = 0;
        private IService service = null;
        private List<Contragents> contragents = new List<Contragents>();
        private Contragents SelectedContr;
        private List<Contragents> contragentsTemp = new List<Contragents>();
        private List<Contragents> AllContragents = new List<Contragents>();
        private List<owners> allOwners = new List<owners>();
        private bool textChanged = false;
        private string textCommTemp = "";
        private bool loading = true;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
           
        }



       async  private void DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == 0)
            {
                e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;

            }
        }

        private void UpdateComboContragents()
        {
            this.contragents = service.GetContragents();
            if (this.comboBox1.Items.Count != 0) this.comboBox1.Items.Clear();
            this.comboBox1.Items.Add("Все");
            this.comboBox1.Items.AddRange(this.contragents.ToArray());
            this.comboBox1.SelectedIndex = 0;
        }

        private void updateComboTab2()
        {
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
            updateComboTab2();
            UpdateComboContragents();
            updateComboTabOwner();

            if (dataGridView1.Rows.Count != 0) this.dataGridView1.Rows.Clear();
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
                this.dataGridView1.Rows[rowsCount].Cells[0].Value = contragentsTemp[i].Name;
                for (int c = 0; c < this.dataGridView1.Rows[0].Cells.Count; c++)
                {
                    this.dataGridView1.Rows[rowsCount].Cells[c].Style.BackColor = Color.FromArgb(240, 188, 99);
                }
                rowsCount++;
                var contracts = service.GetContractsByContragent(contragentsTemp[i].ID);
                for (int j = 0; j < contracts.Count; j++)
                {
                    this.dataGridView1.Rows.Add(new DataGridViewRow());
                    this.dataGridView1.Rows[rowsCount].Cells["name"].Value = "Договор № " + contracts[j];
                    for (int c1 = 0; c1 < this.dataGridView1.Rows[0].Cells.Count; c1++)
                    {
                        this.dataGridView1.Rows[rowsCount].Cells[c1].Style.BackColor = Color.FromArgb(83, 242, 51);
                    }

                    rowsCount++;

                    List<NewClassForDataGrid> goods_ =
                        service.GetClassByContractNumber(contracts[j]);

                    for (int k = 0; k < goods_.Count; k++)
                    {
                        this.dataGridView1.Rows.Add(new DataGridViewRow());

                        this.dataGridView1.Rows[rowsCount].Tag = goods_[k].idGinC;
                        this.dataGridView1.Rows[rowsCount].Cells["Name"].Value = goods_[k].name;
                        this.dataGridView1.Rows[rowsCount].Cells["Total"].Value = goods_[k].countAll;
                        this.dataGridView1.Rows[rowsCount].Cells["left"].Value = goods_[k].countLeft;
                        this.dataGridView1.Rows[rowsCount].Cells["commentary"].Value = goods_[k].commentary;
                        this.dataGridView1.Rows[rowsCount].Cells["deadLine"].Value = goods_[k].deadLine;
                        rowsCount++;
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var myBinding = new BasicHttpBinding();
            var Uri = new Uri(ConfigurationManager.ConnectionStrings["WcfConnectionString"].ConnectionString);
            var myEndpoint = new EndpointAddress(Uri);
            var myChannelFactory = new ChannelFactory<IService>(myBinding, myEndpoint);

            service = myChannelFactory.CreateChannel();
            this.UpdateAllAll();
            FillDataGrid();

            loading = false;
        }

        private void btnAddGood_Click(object sender, EventArgs e)
        {
            AddGood addGoodForm = new AddGood(this.service);
             addGoodForm.Show();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            if (e.ColumnIndex != 5 || row.Tag == null || row.Cells["send"].Value == null) return;
            int quant;
            bool b =
                Int32.TryParse(row.Cells["send"].Value.ToString(), out quant);
            if (!b || quant > Int32.Parse(row.Cells["left"].Value.ToString())) return;
            int id = (int)row.Tag;

            service.addQuantityLeftInGoods(quant, id);

            row.Cells["left"].Value = Int32.Parse(row.Cells["left"].Value.ToString()) - quant;
            row.Cells["send"].Value = null;
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
              dtDeadLine.Value.Date, idOwner);
            if (b == true)
            {
                MessageBox.Show("Договор добавлен");
                this.textBoxТNumberContract.Text = "";
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
                this.AllContragents = service.GetAllContragents();
                if (comboBoxContragents.Items.Count!=0) this.comboBoxContragents.Items.Clear();
                this.comboBoxContragents.Items.AddRange(this.AllContragents.ToArray());
            }
        }

        private void buttonAddGoodsInContract_Click(object sender, EventArgs e)
        {
            AddGoodsInContract form = new AddGoodsInContract();
            form.Show();

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
         //   UpdateAllAll();
        }

        private void tabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            UpdateAllAll();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (loading == true || e.ColumnIndex != 6) return;
            textCommTemp = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            int id = (int)dataGridView1.Rows[e.RowIndex].Tag;
            service.addCommentary(id, textCommTemp);
        }
    }
}
