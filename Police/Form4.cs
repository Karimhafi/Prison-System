using Guna.UI.WinForms;
using PdfSharp.Charting;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ZedGraph;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Police
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

     



        void Age()
        {
            chart1.Update();
             // Setup the graph
            // Size the control to fill the form with a margin
            string connetionString = null;
        OleDbConnection cnn;
        OleDbCommand cmd;
        string sql = null;
        //Déclarer un objet OleDbDataReader pour stocker les lignes arrivant de la BD
        // c'est une zone mémoire (buffer) qui prend la même structure de la table reçu
        OleDbDataReader reader;
        connetionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\hp\\Documents\\Police.accdb";
            chart1.Series.Add("Age");
            chart1.Series["Age"].XValueMember = "Age";
            //déclarer la chaine de la requete
            sql = " Select * from Rapport " ;
            cnn = new OleDbConnection(connetionString);
        int i = 0;
          
           
            try
            {
                cnn.Open();
                cmd = new OleDbCommand(sql, cnn);
        //déclarer une listViewItem

        //Exécuter la requete avec la méthode ExecuteReader et ranger le resultat dans un DataReader
        OleDbDataReader rd = cmd.ExecuteReader();
            
                //lire le contenu de DataReader ligne par ligne avec la méthode read
                while (rd.Read())
                {    //extraire les cellules de chaque ligne 
                     //rd.GetValue(0) : la première valeur  de la ligne: reference
                     //rd.GetValue(1)  : la deuxime valeur de la ligne :
                     //....

                   
                    this.chart1.Series["Age"].Points.AddXY(rd["LastName"].ToString(), rd["Age"].ToString());



                }



    rd.Close();
                cmd.Dispose();
                cnn.Close();
       
              
            }
            catch (Exception ex)
{ MessageBox.Show("Erreur " + ex.Message); }}

        void sexe()

        {

            chart2.Update();

            // Setup the graph
            //    CreateGraph(zz);
            // Size the control to fill the form with a margin
            string connetionString = null;
            OleDbConnection cnn;
            OleDbCommand cmd;
             
            string sql = null;
            string sql2 = null;
           
          //Déclarer un objet OleDbDataReader pour stocker les lignes arrivant de la BD
          // c'est une zone mémoire (buffer) qui prend la même structure de la table reçu
          OleDbDataReader reader;
            connetionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\hp\\Documents\\Police.accdb";

            //déclarer la chaine de la requete
            sql = " Select COUNT (ID) from Rapport where Gendre LIKE 'm%' ";
            sql2 = " Select COUNT (ID) from Rapport where Gendre LIKE 'f%' ";
            cnn = new OleDbConnection(connetionString);
            chart2.Titles.Add("Gendre Pie");
           
            chart2.Series.Add("gendre");
            chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

            if (comboBox1.Text == "Numbers") { chart2.Series["gendre"].Label = ""; }
            if (comboBox1.Text == "Percentage") { chart2.Series["gendre"].Label = "#PERCENT"; }
   
            chart2.Series["gendre"].IsValueShownAsLabel = true;
            chart2.Series["gendre"].XValueMember = "gendre";

            string m = "z";
            string f = "z";

            try
            {
                cnn.Open();
                cmd = new OleDbCommand(sql, cnn);
            
                //déclarer une listViewItem

                //Exécuter la requete avec la méthode ExecuteReader et ranger le resultat dans un DataReader
                OleDbDataReader rd = cmd.ExecuteReader();
              

                //lire le contenu de DataReader ligne par ligne avec la méthode read
                while (rd.Read())
                {   

                    String[] produit = { rd.GetValue(0).ToString() };


                    m = produit[0];
                }

            

         
            }
            catch (Exception ex)
            { MessageBox.Show("Erreur  " + ex.Message); }
            try
            {
                cmd = new OleDbCommand(sql2, cnn);
                OleDbDataReader rd = cmd.ExecuteReader();

              

                while (rd.Read())
                {   

                    String[] produit = { rd.GetValue(0).ToString() };


                   f = produit[0];
         

                }

                chart2.Series["gendre"].Points.AddXY("Male", m);
                chart2.Series["gendre"].Points.AddXY("Female", f);

                rd.Close();
                cmd.Dispose();
                cnn.Close();
            }
            catch (Exception ex)
            { MessageBox.Show("Erreur  " + ex.Message); }
        }
     

        private void Form4_MouseClick(object sender, MouseEventArgs e)
        {
         
        }

      

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
          

        }

        private void button2_Click(object sender, EventArgs e)
        {
              
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
           
            chart1.Visible = true;

            chart1.Series.Clear();
            chart1.Visible = true;
            chart2.Visible = false;
            Age();
        }

        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            chart2.Titles.Clear();
            chart2.Series.Clear();
            sexe();

            chart2.Visible = true;
            chart1.Visible = false;
        }

        private void gunaGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
