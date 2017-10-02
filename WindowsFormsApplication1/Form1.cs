using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.Linq;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
       

        public Form1()
        {
            InitializeComponent();

            string connStr = "server=mysql.zzz.com.ua" +
               ";user=kvik" +
               ";database=kvik2006" +
                ";port=3306"+
               ";password=Western2233";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
          
            //Console.WriteLine(conn.State);


        }
    }
}
