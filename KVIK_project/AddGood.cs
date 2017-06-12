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

namespace KVIK_project
{
    public partial class AddGood : Form
    {
        public string name;
        public string code;
        public string figure;
        public double buy;
        public double sold;
        private IService service;

        public AddGood(IService service)
        {
            InitializeComponent();
            this.FormClosing += AddGood_FormClosing;
            this.service = service;
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
            if (Double.TryParse(this.tbSold.Text, out b))
                buy = b;
            else
            {
                MessageBox.Show("Ввести корректное значение цены продажи");
                return;
            }

            bool bool_ = service.addGoodsToDB(name, code, figure, buy);


            if (bool_ == false)
            {
                MessageBox.Show("Продукт с таким чертежем уже существует");
                return;
            }          

            this.tbName.Text = "";
            this.tbPriceBuy.Text = "";
            this.tbSold.Text = "";
            this.tbCode.Text = "";
            this.tbFigure.Text = "";
        }
    }
}
