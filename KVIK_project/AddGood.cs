using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KVIK_project
{
    public partial class AddGood : Form
    {
        public string name;
        public string code;
        public string figure;
        public double buy;
        public double sold;

        public AddGood()
        {
            InitializeComponent();
            this.FormClosing += AddGood_FormClosing;
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
            this.Close();
        }
    }
}
