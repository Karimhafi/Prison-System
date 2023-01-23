using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Police
{
    public partial class Form6 : Form
    {
        public Form6(int num)
        {
            InitializeComponent();
            this.num = num;

        }
        public int num { get; set; }
        private void Form6_Load(object sender, EventArgs e)
        {
            Basedb(num);


        }

        private void Basedb(int y)
        {
            int x = num;
            string connetionString = null;
            OleDbConnection cnn;
            OleDbCommand cmd;
            string sql = null;
            OleDbDataReader reader;
            connetionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\hp\\Documents\\Police.accdb";
            sql = " Select * from Visitor where ID =" + x.ToString();

            cnn = new OleDbConnection(connetionString);
            try
            {

                cnn.Open();
                cmd = new OleDbCommand(sql, cnn);
                OleDbDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {



                    gunaLabel6.Text = rd.GetValue(0).ToString();
                   string sortie= rd.GetValue(3).ToString();
                    if (sortie == "") {
                        //
                        gunaLabel5.Text = rd.GetValue(2).ToString();

                        string o = DateTime.Now.ToString("HH:mm:ss");
                    DateTime timed = DateTime.Parse(gunaLabel5.Text);
                    DateTime now = Convert.ToDateTime(o);


                    string lstrADate = timed.ToString("HH:mm:ss");
                    TimeSpan diff = (timed - now).Duration();
                    gunaLabel5.Text = diff.ToString();
                    }
                    else if (sortie !="")
                    {

                        DateTime timed = DateTime.Parse(rd.GetValue(2).ToString());
                        DateTime now = DateTime.Parse(sortie);


                        TimeSpan diff = (timed - now).Duration();
                        gunaLabel2.Text = "TIME SPEND " ;
                            gunaLabel5.Text = diff.ToString();


                    }

                }

                rd.Close();
                cmd.Dispose();
                cnn.Close();
            }

            catch (Exception ex)
            { MessageBox.Show("Erreur " + ex.Message); }


        }

        private void gunaLabel5_Click(object sender, EventArgs e)
        {
        
         
        }

        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            num++;
            int res = num;
            Basedb(res);
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            num--;
            int res = num;
            Basedb(res);
        }
    }
}
