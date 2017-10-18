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
    public partial class editContract : Form
    {
        public string num = "";
        public DateTime dt;

        public editContract(DateTime dt, string tx)
        {
            InitializeComponent();
            this.dateTimePicker1.Value = dt;
            this.textBox1.Text = tx;
            this.FormClosing += EditContract_FormClosing;
        }

        private void EditContract_FormClosing(object sender, FormClosingEventArgs e)
        {
            dt = this.dateTimePicker1.Value.Date;
            num = this.textBox1.Text;
        }
    }
}
