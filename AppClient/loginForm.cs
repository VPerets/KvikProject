using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppClient
{
    public partial class loginForm : Form
    {
        private Service service;
        public bool accept;
        public string login = "";
        public loginForm()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.Load += LoginForm_Load;
            this.FormClosing += LoginForm_FormClosing;
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            service.close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            service = new Service();
            service.open();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            if (this.textBoxLogin.Text == "" || this.textBoxPass.Text == "") return;

            accept = service.checkLoginPass(this.textBoxLogin.Text, this.textBoxPass.Text);
            if (accept)
            {
                login = textBoxLogin.Text;
                this.Close();
            }
        }
    }
}
