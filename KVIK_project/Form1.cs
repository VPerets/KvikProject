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
        private List<Contracts> contracts = new List<Contracts>();
        private List<Contragents> contragentsTemp = new List<Contragents>();
        public List<Contragents> AllContragents = new List<Contragents>();
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

        private void FillComboContragents()
        {         
            if (this.comboBox1.Items.Count != 0) this.comboBox1.Items.Clear();
            this.comboBox1.Items.Add("Все");
            this.comboBox1.Items.AddRange(this.contragents.ToArray());
            this.comboBox1.SelectedIndex = 0;
        }

        private void UpdateForFill()
        {          
            if (dataGridView1.Rows.Count != 0) this.dataGridView1.Rows.Clear();
            if (this.contragentsTemp.Count != 0) this.contragentsTemp.Clear();
        }

        private void UpdateAllAll()
        {
            if (dataGridView1.Rows.Count!=0) this.dataGridView1.Rows.Clear();
            this.contragents = service.GetContragents();
            this.AllContragents = service.GetAllContragents();
            FillComboContragents();
            if (this.comboBoxContragents.Items.Count != 0) this.comboBoxContragents.Items.Clear();
            this.comboBoxContragents.Items.AddRange(this.AllContragents.ToArray());
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
                    this.dataGridView1.Rows[rowsCount].Cells[c].Style.BackColor = Color.Blue;
                }
                rowsCount++;
                contracts = service.GetContractsByContragent(contragentsTemp[i].ID);
                for (int j = 0; j < contracts.Count; j++)
                {
                    this.dataGridView1.Rows.Add(new DataGridViewRow());
                    this.dataGridView1.Rows[rowsCount].Cells[0].Value = "Договор №";
                    this.dataGridView1.Rows[rowsCount].Cells[1].Value = contracts[j].Number;
                    for (int c1 = 0; c1 < this.dataGridView1.Rows[0].Cells.Count; c1++)
                    {
                        this.dataGridView1.Rows[rowsCount].Cells[c1].Style.BackColor = Color.Yellow;
                    }
                    
                    rowsCount++;

                    List<NewClassForDataGrid> goods_ = 
                        service.GetClassByContractNumber(contracts[j].Number);
                   
                    for (int k = 0; k < goods_.Count; k++)
                    {
                        this.dataGridView1.Rows.Add(new DataGridViewRow());
                        this.dataGridView1.Rows[rowsCount].Tag = contracts[j].Number;
                        this.dataGridView1.Rows[rowsCount].Cells[2].Value = goods_[k].name;
                        this.dataGridView1.Rows[rowsCount].Cells[2].Tag = goods_[k].idGood;
                        this.dataGridView1.Rows[rowsCount].Cells[3].Value = goods_[k].countAll;
                        this.dataGridView1.Rows[rowsCount].Cells[4].Value = goods_[k].CountLeft;
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
        }

        private void btnAddGood_Click(object sender, EventArgs e)
        {
            AddGood addGoodForm = new AddGood(this.service);
             addGoodForm.Show();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            if (e.ColumnIndex != 6 || row.Tag == null || row.Cells[5].Value == null) return;
            int quant;
            bool b =
                Int32.TryParse(row.Cells[5].Value.ToString(), out quant);
            if (!b || quant > Int32.Parse(row.Cells[4].Value.ToString())) return;          
                string idContract = row.Tag as string;
            service.addQuantityLeftInGoods(quant, idContract,
                    Int32.Parse(row.Cells[2].Tag.ToString()));
           
            row.Cells[4].Value = Int32.Parse(row.Cells[4].Value.ToString()) - quant;
            row.Cells[5].Value = null;
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
    }
}
