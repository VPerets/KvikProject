using KvikLibrary;
using System.Collections.Generic;
using System.Configuration;
using System.ServiceModel;
using System.Windows;
using WcfService;
using System;
using System.ServiceModel.Channels;
using System.Windows.Controls;

namespace WpfUser
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int rowNeed = 0;
        private IService service = null;
        private List<Contragents> contragents = new List<Contragents>();
        private Contragents SelectedContr;
        private List<Contracts> contracts = new List<Contracts>();
        private List<Contragents> contragentsTemp = new List<Contragents>();
        public List<Contragents> AllContragents = new List<Contragents>();
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
          //  this.dataGridView1.Loaded += DataGridView1_Loaded;
        }

        private void DataGridView1_Loaded(object sender, RoutedEventArgs e)
        {
            forDataGrid();
        }

        public void forDataGrid()
        {
            for (int i = 0; i < this.contragents.Count; i++)
            {
                Label l = new Label();
                l.Content = contragents[i].Name;
                StackTab1.Children.Add(l);
                var AllContractsContragent = service.GetContractsByContragent(contragents[i].ID);

             
                    for (int j = 0; j < AllContractsContragent.Count; j++)
                    {
                        Label l2 = new Label();
                        l2.Content = AllContractsContragent[j];
                        StackTab1.Children.Add(l2);
                        DataGrid dg = new DataGrid();
                        dg.SelectedCellsChanged += Dg_SelectedCellsChanged;
                        var c = service.GetClassByContractNumber(AllContractsContragent[j].number);
                        dg.ItemsSource = c;
                        
                        //  System.Windows.Forms.MessageBox.Show(c.Count.ToString());

                        StackTab1.Children.Add(dg);
                    }
            }
        }

        private void Dg_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
           
        }

        public void AddToComboBox()
        {
            this.ComboContragents.Items.Add("Все");
            for (int i=0; i<this.contragents.Count; i++)
            this.ComboContragents.Items.Add(this.contragents[i]);
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {   
            var myBinding = new BasicHttpBinding();
            var Uri = new Uri(ConfigurationManager.ConnectionStrings["WcfConnectionString"].ConnectionString);
            var myEndpoint = new EndpointAddress(Uri);
            var myChannelFactory = new ChannelFactory<IService>(myBinding, myEndpoint);

            service = myChannelFactory.CreateChannel();
            this.contragents = service.GetContragents();
            System.Windows.Forms.MessageBox.Show(contragents.Count.ToString());
            forDataGrid();
            AddToComboBox();

            // this.UpdateAllAll();
            //FillDataGrid();
        }

        //private void FillDataGrid(int temp = 0)
        //{
        //    if (temp != 1)
        //    {
        //       // UpdateForFill();
        //        this.contragentsTemp.AddRange(this.contragents.ToArray());
        //    }
        //    else
        //    {
        //        //UpdateForFill();
        //        this.contragentsTemp.Add(SelectedContr);
        //    }

        //    int rowsCount = 0;
        //    for (int i = 0; i < contragentsTemp.Count; i++)
        //    {
             
        //        this.dataGridView1.Items.
        //        this.dataGridView1.Rows[rowsCount].Cells[0].Value = contragentsTemp[i].Name;
        //        for (int c = 0; c < this.dataGridView1.Rows[0].Cells.Count; c++)
        //        {
        //            this.dataGridView1.Rows[rowsCount].Cells[c].Style.BackColor = Color.Blue;
        //        }
        //        rowsCount++;
        //        contracts = service.GetContractsByContragent(contragentsTemp[i].ID);
        //        for (int j = 0; j < contracts.Count; j++)
        //        {
        //            this.dataGridView1.Rows.Add(new DataGridViewRow());
        //            this.dataGridView1.Rows[rowsCount].Cells[0].Value = "Договор №";
        //            this.dataGridView1.Rows[rowsCount].Cells[1].Value = contracts[j].Number;
        //            for (int c1 = 0; c1 < this.dataGridView1.Rows[0].Cells.Count; c1++)
        //            {
        //                this.dataGridView1.Rows[rowsCount].Cells[c1].Style.BackColor = Color.Yellow;
        //            }

        //            rowsCount++;

        //            List<NewClassForDataGrid> goods_ =
        //                service.GetClassByContractNumber(contracts[j].Number);

        //            for (int k = 0; k < goods_.Count; k++)
        //            {
        //                this.dataGridView1.Rows.Add(new DataGridViewRow());
        //                this.dataGridView1.Rows[rowsCount].Tag = contracts[j].Number;
        //                this.dataGridView1.Rows[rowsCount].Cells[2].Value = goods_[k].name;
        //                this.dataGridView1.Rows[rowsCount].Cells[2].Tag = goods_[k].idGood;
        //                this.dataGridView1.Rows[rowsCount].Cells[3].Value = goods_[k].countAll;
        //                this.dataGridView1.Rows[rowsCount].Cells[4].Value = goods_[k].CountLeft;
        //                rowsCount++;
        //            }
        //        }
        //    }
      //  }

    }

    //ListView lv = new ListView();
    //        for (int i = 0; i<contragents.Count; i++)
    //        {
    //            lv.Items.Add(this.contragents[i].Name);

    //var contrByContrag = service.GetContractsByContragent(contragents[i].ID);
    //            for (int j = 0; j < contrByContrag.Count; j++)
    //            {
    //    lv.Items.Add(contrByContrag[j].Number);
    //    var coll = service.GetClassByContractNumber(contrByContrag[j].Number);
    //    for (int ii = 0; ii < coll.Count; ii++)
    //    {
    //        lv.Items.Add(coll[ii].ToString());
    //    }
    //}
    //}
    //StackTab1.Children.Add(lv);
           
    class MyTable
    {
        public MyTable(int Id, string Vocalist, string Album, int Year)
        {
            this.Id = Id;
            this.Vocalist = Vocalist;
            this.Album = Album;
            this.Year = Year;
        }
        public int Id { get; set; }
        public string Vocalist { get; set; }
        public string Album { get; set; }
        public int Year { get; set; }
    }
}
