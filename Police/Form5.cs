using Guna.UI.WinForms;
using Microsoft.VisualBasic.ApplicationServices;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Police
{
    public partial class Form5 : Form
    {
     
        string username;
        string password;
        string ID;
        string RANK;
        string g;

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
           
        }
     
        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            username = User.Text;
            password = pwd.Text;
            CheckLogin(username,password);
      

        }

        ///////////////
        ///

        private int _failedLoginCounter = 0;


        private void CheckLogin(string username, string password)
        {
            try
            {
                string constring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\hp\\Documents\\Police.accdb";

                using (OleDbConnection conDataBase = new OleDbConnection(constring))
                {
                    using (OleDbCommand cmdDataBase = conDataBase.CreateCommand())
                    {
                        cmdDataBase.CommandText = "SELECT * FROM police WHERE username = @" + username + " AND password = @" + password + ";";

                        cmdDataBase.Parameters.AddRange(new OleDbParameter[]
                        {
                    new OleDbParameter("@username",username),
                    new OleDbParameter("@password",password)
                        });
                        if (conDataBase.State != ConnectionState.Open)
                            conDataBase.Open();

                        var numberOrResults = 0;
                     
                        using (OleDbDataReader myReader = cmdDataBase.ExecuteReader())
                        {
                            while (myReader != null && myReader.Read())
                            {
                             ID = myReader.GetValue(0).ToString();

                                numberOrResults++;
                            }
                        }

                        if (numberOrResults == 1)
                        {
                          
                            MessageBox.Show("Login Successful");
                            using (OleDbDataReader myReader = cmdDataBase.ExecuteReader())
                            {
                                while (myReader != null && myReader.Read())
                                {
                                    ID = myReader.GetValue(0).ToString();
                                    g = myReader.GetValue(0).ToString();
                                    RANK = myReader.GetValue(3).ToString();
                                    if (RANK == "Guard")
                                    {
                                        Form1 frm = new Form1(g);
                                        frm.Show();
                                        this.Hide();
                                    }
                                    else
                                    {
                                        MainPage frm = new MainPage(ID);
                                        frm.Show();
                                        this.Hide();
                                    }
                                  
                                }
                            }
                          
                        }


                        else if (numberOrResults > 1)
                        {
                            MessageBox.Show("Duplicate Username or Password");
               _failedLoginCounter++;
                        }
                        else if (numberOrResults == 0)
                        {
                            MessageBox.Show("Username or Password do not match");
                            // increment the failed login counter
                            _failedLoginCounter++;
                        }
                    }

                }

                if (_failedLoginCounter >= 3)
                    this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gunaShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
