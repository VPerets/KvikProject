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
        private List<Contracts> contracts = new List<Contracts>();


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

        private void FillDataGrid()
        {
            this.contragents = service.GetContragents();
            int rowsCount = 0;
            for (int i = 0; i < contragents.Count; i++)
            {
                this.dataGridView1.Rows.Add(new DataGridViewRow());
                this.dataGridView1.Rows[rowsCount].Cells[0].Value = contragents[i].Name;
                for (int c = 0; c < this.dataGridView1.Rows[0].Cells.Count; c++)
                {
                    this.dataGridView1.Rows[rowsCount].Cells[c].Style.BackColor = Color.Blue;
                }
                rowsCount++;
                contracts = service.GetContractsByContragent(contragents[i].ID);
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
            FillDataGrid();
        }

        private void btnAddGood_Click(object sender, EventArgs e)
        {
            AddGood addGoodForm = new AddGood();
            DialogResult dr = addGoodForm.ShowDialog();
            if (dr == DialogResult.OK)
            {

            }
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
    }
}
