using Guna.UI.WinForms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Org.BouncyCastle.Asn1.Cms;
using PdfSharp.Charting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Police
{
    public partial class Form3 : Form
    {
        string fileName;
        public Form3()
        {
            InitializeComponent();
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            if (Page.Text == "2/3")
            {
                page1.Visible = true;
                p2.Visible = false;
                buttonback.Visible = false;
                Page.Text = "1/3";
            }
            else if (Page.Text == "3/3")
            {
                p2.Visible = true;
                page3.Visible = false;

                Page.Text = "2/3";
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (Page.Text == "1/3")
            {
                buttonback.Visible = true;
                page1.Visible = false;
                p2.Visible = true;
                Page.Text = "2/3";
            }
            else if (Page.Text == "2/3")
            {
                buttonback.Visible = true;
                p2.Visible = false;
                page3.Visible = true;
                Page.Text = "3/3";
            }



        }

        private void Form3_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.MultiSelect = true;

            listView1.Columns.Add("ID", 150);
            listView1.Columns.Add("Name", 150);
            listView1.Columns.Add("Relation", 150);
            string connetionString = null;
            OleDbConnection cnn;
            OleDbCommand cmd;
            string sql = null;
            OleDbDataReader reader;
            connetionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\hp\\Documents\\Police.accdb";

            sql = " Select * from Visitor ";
            cnn = new OleDbConnection(connetionString);
            try
            {
                cnn.Open();
                cmd = new OleDbCommand(sql, cnn);
                ListViewItem list;
                OleDbDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {

                    String[] produit = { rd.GetValue(0).ToString(), rd.GetValue(1).ToString(), rd.GetValue(4).ToString() };
                    ListViewItem obj = new ListViewItem(produit);
                    listView1.Items.Add(obj);
                }

                rd.Close();
                cmd.Dispose();
                cnn.Close();
            }

            catch (Exception ex)
            { MessageBox.Show("Erreur " + ex.Message); }
        }

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Choose:";
            openFileDialog1.Filter = "All file(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;



                gunaPictureBox1.Image = Image.FromFile(fileName);
                MessageBox.Show(" Image Added!!");
            }


        }

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {
            gunaTextBox19.Text = gunaTextBox1.Text;
            gunaLabel37.Text = "Prisoner No : " + gunaTextBox1.Text;
        }

        private void gunaLabel37_Click(object sender, EventArgs e)
        {

        }

        private void gunaGradientButton2_Click_1(object sender, EventArgs e)
        {

            string connetionString = null;
            OleDbConnection cnn;
            OleDbCommand cmd;
            string sql = null;
            connetionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\hp\\Documents\\Police.accdb";

            cnn = new OleDbConnection(connetionString);


            try
            {   //definir le texte de la requete
                sql = "insert into Visitor (ID,Name,relation) values ('" + gunaTextBox5.Text + "','" + gunaTextBox25.Text + "','" + gunaTextBox26.Text +"')";
                cnn.Open();

                //creation d un objet command pour lancer la requete
                cmd = new OleDbCommand(sql, cnn);
                //executer la requete avec la methode ExecuteNonQuery
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cnn.Close();
                //message d avertissement en cas d ajout avec succes
                MessageBox.Show(" Visitor Added  !!");
               
            }

            catch (Exception ex)
            {    //Afficher le message d erreur en cas de problème
                MessageBox.Show("Erreur ! " + ex.ToString());
            }
           
          
          

        }
        string gendre;
        string crime;
        string Status;
        private void gunaGradientButton3_Click(object sender, EventArgs e)
        {

           
            string connetionString = null;
            OleDbConnection cnn;
            OleDbCommand cmd;
            string sql = null;
            connetionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\hp\\Documents\\Police.accdb";
            crime=gunaComboBox1.Text;
            if (gunaRadioButton5.Checked) { gendre = "Male"; }
            else if (gunaRadioButton6.Checked)
            {
                gendre = "Female";
            }
            if (gunaRadioButton1.Checked) { Status = "Single"; }
            else if (gunaRadioButton2.Checked)
            {
                Status = "Married";
            }
            else if (gunaRadioButton3.Checked)
            {
                Status = "Widow";
            }
            else if (gunaRadioButton4.Checked)
            {
                Status = "Widows";
            }
            cnn = new OleDbConnection(connetionString);
            try
            {
                string date1 = gunaDateTimePicker2.Value.ToString("yyyy/MM/dd");
                string date2 = gunaDateTimePicker3.Value.ToString("yyyy/MM/dd");

                saveimg();
                string path= "C:\\Users\\hp\\Desktop\\projectc#\\Inmate" + "\\" + gunaTextBox1.Text+".jpg";
                //definir le texte de la requete
                sql = "INSERT INTO Rapport (ID,FirstName,LastName,Gendre,Age,Status,img,Class,Confinementdate,Caseno,CourtDate,Crime,Placebirht,Commitment,Divison,Religion,Eyecolor,height,Haircolor,course,blood,adresse,NATIONALITY) values ('" + gunaTextBox1.Text + "','" + gunaTextBox2.Text + "','" + gunaTextBox28.Text + "','" + gendre + "','" + gunaTextBox12.Text + "','" + Status + "','" + path + "','" + gunaTextBox20.Text + "','" + date1 + "','" + gunaTextBox14.Text + "','" + date2+ "','" +crime + "','"+ gunaTextBox6.Text + "','"+ gunaTextBox18.Text + "','" + gunaTextBox16.Text + "','" + gunaComboBox3.Text + "','" + gunaComboBox5.Text + "','" + gunaTextBox24.Text+ "','" + gunaComboBox6.Text+ "','" + gunaComboBox2.Text+ "','" + gunaComboBox4.Text + "','" + gunaTextBox10.Text + "','" + gunaTextBox4.Text+"') ";
                cnn.Open();
                
                //creation d un objet command pour lancer la requete
                cmd = new OleDbCommand(sql, cnn);
                //executer la requete avec la methode ExecuteNonQuery
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cnn.Close();
                //message d avertissement en cas d ajout avec succes
                MessageBox.Show(" Inmate ADDED  !!");
            }
            catch (Exception ex)
            {    //Afficher le message d erreur en cas de problème
                MessageBox.Show("Erreur ! " + ex.ToString());
            }
        }
         private void saveimg() {
            if (gunaPictureBox1.Image != null) { 
            string fname = gunaTextBox1.Text + ".jpg";
            string folder = "C:\\Users\\hp\\Desktop\\projectc#\\Inmate"+ "\\"+gunaTextBox1.Text + ".jpg";
            string folderPath=System.IO.Path.Combine(folder,fname);
                gunaPictureBox1.Image.Save(folder,ImageFormat.Png);
            }
            else { MessageBox.Show("Please add image"); }
        }
        private void button1_Click(object sender, EventArgs e)
        {
         
            
        }

        private void gunaLabel34_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string s = gunaDateTimePicker3.Value.ToString("yyyy/MM/dd");
            MessageBox.Show(s);
           
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
        
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            string connetionString = null;
            OleDbConnection cnn;
            OleDbCommand cmd;
            string sql = null;
            OleDbDataReader reader;
            connetionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\hp\\Documents\\Police.accdb";

            sql = " Select * from Visitor ";
            cnn = new OleDbConnection(connetionString);
            try
            {
                cnn.Open();
                cmd = new OleDbCommand(sql, cnn);
                ListViewItem list;
                OleDbDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {

                    String[] produit = { rd.GetValue(0).ToString(), rd.GetValue(1).ToString(), rd.GetValue(4).ToString() };
                    ListViewItem obj = new ListViewItem(produit);
                    listView1.Items.Add(obj);
                }

                rd.Close();
                cmd.Dispose();
                cnn.Close();
            }

            catch (Exception ex)
            { MessageBox.Show("Erreur " + ex.Message); }
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {

        }

        private void gunaTextBox14_TextChanged(object sender, EventArgs e)
        {
            gunaTextBox17.Text = gunaTextBox14.Text;

        }
    }
}


