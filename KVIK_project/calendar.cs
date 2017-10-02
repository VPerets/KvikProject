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
    public partial class calendar : Form
    {
        public DateTime dateVal = DateTime.Now;

        public calendar()
        {
            InitializeComponent();
            this.Text = "Дата отгрузки";
            this.MaximumSize = new Size(250,200);
            this.MinimumSize = new Size(250, 200);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dateVal = this.dateTimePicker1.Value.Date;
            this.Close();
        }
    }
}
