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
        public IService service = null;
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var myBinding = new BasicHttpBinding();
            var Uri = new Uri(ConfigurationManager.ConnectionStrings["WcfConnectionString"].ConnectionString);
            var myEndpoint = new EndpointAddress(Uri);
            var myChannelFactory = new ChannelFactory<IService>(myBinding, myEndpoint);

            service = myChannelFactory.CreateChannel();

            service.addGoodsToDB("a", "s", "s", 456);
        }

        private void btnAddGood_Click(object sender, EventArgs e)
        {
            AddGood addGoodForm = new AddGood();
            DialogResult dr = addGoodForm.ShowDialog();
            if (dr == DialogResult.OK)
            {

            }
        }
    }
}
