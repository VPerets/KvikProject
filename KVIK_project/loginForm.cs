using System;
using System.Windows.Forms;
//using WcfService;

namespace KVIK_project
{
    public partial class loginForm : Form
    {
        private Service service;
      
        public bool accept;
        public string login = "";
      //  private ChannelFactory<IService> myChannelFactory = null;
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
            //this.myChannelFactory.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            //var myBinding = new BasicHttpBinding();
            //var Uri = new Uri(ConfigurationManager.ConnectionStrings["WcfConnectionString"].ConnectionString);
            //var myEndpoint = new EndpointAddress(Uri);
            //myChannelFactory = new ChannelFactory<IService>(myBinding, myEndpoint);

            //service = myChannelFactory.CreateChannel();
            //service.open();
            service = new Service();
            service.open();
            //MessageBox.Show(service.getCount().ToString());
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
