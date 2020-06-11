using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Data.SqlClient; 

namespace ODBCConnectTEST
{
   
    public partial class Form1 : Form
    {
        String SERVER_IPADDRESS= "172.17.247.68";

        public Form1()
        {
            InitializeComponent();

           
        
        }

        

        private void button1_Click(object sender, EventArgs e)
        {

            //string constr = @"Server = 172.17.156.238\SQLEXPRESS; database = TEST; UID=sa1;PWD=password01!!";

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = SERVER_IPADDRESS + @"\SQLEXPRESS";
            builder.InitialCatalog = "TEST";
            builder.UserID = "sa1";
            builder.Password = "password01!!";

            //using (OdbcConnection connection = new OdbcConnection(constr))

            this.textBox1.Text = builder.ConnectionString;  

            using (SqlConnection connection=new SqlConnection())
            {

                connection.ConnectionString = builder.ConnectionString;  
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Tbl1";
                cmd.Connection = connection;

                
                SqlDataReader r;
                r = cmd.ExecuteReader();

                string str1 = string.Empty; 
                
                while (r.Read())
                {
                    str1 += r[1] + " " + r[2] + "\r\n";
                }


                MessageBox.Show(str1);  
                
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            OdbcConnectionStringBuilder builder = new OdbcConnectionStringBuilder();


           

            builder.ConnectionString = @"Driver={SQL Server};Server=" + SERVER_IPADDRESS + @"\SQLEXPRESS;Database=TEST;Uid=sa1;Pwd=password01!!";

            //MessageBox.Show(builder.ConnectionString);
            this.textBox2.Text = builder.ConnectionString;   

            using (OdbcConnection connection = new OdbcConnection(builder.ConnectionString))
            {

                OdbcCommand cmd = new OdbcCommand();
                cmd.CommandText = "SELECT * FROM Tbl1";

                connection.Open();  
                
                cmd.Connection = connection;

                OdbcDataReader r;
                r = cmd.ExecuteReader();

                string str1 = string.Empty;

                while (r.Read())
                {
                    str1 += r[1] + " " + r[2] + "\r\n";
                }


                MessageBox.Show(str1);

            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            OdbcConnectionStringBuilder builder = new OdbcConnectionStringBuilder();

            builder.ConnectionString = @"Provider=MSDASQL;DSN=SQLServer172.17.156.238;Uid=sa1;Pwd=password01!!";

            //MessageBox.Show(builder.ConnectionString);
            this.textBox3.Text = builder.ConnectionString;

            using (OdbcConnection connection = new OdbcConnection(builder.ConnectionString))
            {

                OdbcCommand cmd = new OdbcCommand();
                cmd.CommandText = "SELECT * FROM Tbl1";

                connection.Open();

                cmd.Connection = connection;

                OdbcDataReader r;
                r = cmd.ExecuteReader();

                string str1 = string.Empty;

                while (r.Read())
                {
                    str1 += r[1] + " " + r[2] + "\r\n";
                }


                MessageBox.Show(str1);

            }
        }
    }
}
