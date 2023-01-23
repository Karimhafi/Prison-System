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
    public partial class Form1 : Form
    {
        public string g{ get; set; }

        public Form1(string g)
        {
            InitializeComponent();
            this.g = g;

        }

    

        private void Form1_Load(object sender, EventArgs e)
        {

            Rank();
            Basedb();
            timer1.Start();
            listView1.MultiSelect = true;
            listView1.Columns.Add("        ID", 150);
            listView1.Columns.Add("        Name", 150);
            listView1.Columns.Add("        Date Entre", 150);
            listView1.Columns.Add("        Datte Sortie", 150);
            listView1.Columns.Add("        Relation", 500);
            listView2.MultiSelect = true;
            listView2.Columns.Add(" ID", 150);
            listView2.Columns.Add("Name", 150);
            listView1.Sorting = SortOrder.Ascending;


        }
        private void Rank()
        {
            string connetionString = null;
            OleDbConnection cnn;
            OleDbCommand cmd;
            string sql = null;
            connetionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\hp\\Documents\\Police.accdb";

            sql = "select * from police where ID = " + g;
            cnn = new OleDbConnection(connetionString);
            try
            {

                cnn.Open();
                cmd = new OleDbCommand(sql, cnn);
                OleDbDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {


                    pictureBox1.Image = Image.FromFile("C:\\Users\\hp\\Desktop\\projectc#\\Police\\" + rd.GetValue(0).ToString() + ".jpg");
                    gunaLabel1.Text = "Welcome , " + rd.GetValue(1).ToString();
                    gunaLabel2.Text = rd.GetValue(3).ToString();




                }

                rd.Close();
                cmd.Dispose();
                cnn.Close();
            }

            catch (Exception ex)
            { MessageBox.Show("Erreur " + ex.Message); }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            gunaLabel3.Text = DateTime.Now.ToString("HH:mm:");
            gunaLabel4.Text = DateTime.Now.ToString("ss");
            gunaLabel5.Text = DateTime.Now.ToString("dddd") + " ," + DateTime.Now.ToString("MMMMMM ,dd,yyyy");
            gunaLabel4.Location = new Point(gunaLabel3.Location.X + gunaLabel3.Width - 5, gunaLabel4.Location.Y);

        }
        private void Basedb()
        {

            string connetionString = null;
            OleDbConnection cnn;
            OleDbCommand cmd;
            string sql = null;
            //Déclarer un objet OleDbDataReader pour stocker les lignes arrivant de la BD
            // c'est une zone mémoire (buffer) qui prend la même structure de la table reçu
            OleDbDataReader reader;
            connetionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\hp\\Documents\\Police.accdb";

            //déclarer la chaine de la requete
            sql = " Select * from Visitor";
            cnn = new OleDbConnection(connetionString);
            try
            {
                cnn.Open();
                cmd = new OleDbCommand(sql, cnn);

                OleDbDataReader rd = cmd.ExecuteReader();

                //lire le contenu de DataReader ligne par ligne avec la méthode read
                while (rd.Read())
                {

                    String[] produit = { rd.GetValue(0).ToString(), rd.GetValue(1).ToString(), rd.GetValue(2).ToString(), rd.GetValue(3).ToString(), rd.GetValue(4).ToString() };
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
        private void Basedb2()
        {

            string connetionString = null;
            OleDbConnection cnn;
            OleDbCommand cmd;
            string sql = null;
            OleDbDataReader reader;
            connetionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\hp\\Documents\\Police.accdb";

            //déclarer la chaine de la requete
            sql = " Select * from Visitor";
            cnn = new OleDbConnection(connetionString);
            try
            {
                cnn.Open();
                cmd = new OleDbCommand(sql, cnn);

                OleDbDataReader rd = cmd.ExecuteReader();

                //lire le contenu de DataReader ligne par ligne avec la méthode read
                while (rd.Read())
                {

                    String[] produit = { rd.GetValue(0).ToString(), rd.GetValue(1).ToString() };
                    ListViewItem obj = new ListViewItem(produit);
                    listView2.Items.Add(obj);
                }

                rd.Close();
                cmd.Dispose();
                cnn.Close();
            }
            catch (Exception ex)
            { MessageBox.Show("Erreur " + ex.Message); }


        }
        private void searchbyID()
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (gunaLineTextBox1.Text == listView1.Items[i].SubItems[0].Text)
                {
                    listView1.Items.Clear();
                }
                string connetionString = null;
                OleDbConnection cnn;
                OleDbCommand cmd;
                string sql = null;
                OleDbDataReader reader;
                connetionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\hp\\Documents\\Police.accdb";
                int numberOrResults = 0;

                sql = " Select * from Visitor where ID =" + gunaLineTextBox1.Text;
                cnn = new OleDbConnection(connetionString);
                try
                {
                    cnn.Open();
                    cmd = new OleDbCommand(sql, cnn);

                    OleDbDataReader rd = cmd.ExecuteReader();


                    while (rd.Read())
                    {

                        String[] produit = { rd.GetValue(0).ToString(), rd.GetValue(1).ToString(), rd.GetValue(2).ToString(), rd.GetValue(3).ToString(), rd.GetValue(4).ToString() };
                        ListViewItem obj = new ListViewItem(produit);
                        listView1.Items.Add(obj);
                        numberOrResults++;

                    }

                    rd.Close();
                    cmd.Dispose();
                    cnn.Close();
                }
                catch (Exception ex)
                { MessageBox.Show("Erreur " + ex.Message); }
                if (numberOrResults == 0) { ok.Visible = false; no.Visible = true; listView1.Items.Clear(); Basedb(); }

                else if (numberOrResults > 0)
                {
                    ok.Visible = true; no.Visible = false;

                }
            }
        }

        private void gunaAdvenceButton7_Click(object sender, EventArgs e)
        {
            if (gunaLineTextBox1.Text == "") { MessageBox.Show("You need to input in Search ' ID ' "); }
            else { searchbyID(); }
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            listView1.Items.Clear();
            Basedb();
            listView1.Sorting = SortOrder.Ascending;
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            gunaShadowPanel1.Visible = true;
            gunaShadowPanel2.Visible = false;
            gunaShadowPanel3.Visible = false;
            gunaShadowPanel4.Visible = false;



        }

      
        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            OleDbConnection cnn;
            OleDbCommand cmd;
            string sql = null;
            connetionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\hp\\Documents\\Police.accdb";

            cnn = new OleDbConnection(connetionString);
            DialogResult res = MessageBox.Show("Are you sure you want to Delete Visitor ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {

                try
                {   //le texte de la requete
                    sql = "delete from Visitor where ID=" + gunaLineTextBox2.Text;
                    cnn.Open();

                    //création d une commande 
                    cmd = new OleDbCommand(sql, cnn);
                    //exécuter la requete à laide de la méthode ExecuteNonQuery
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    cnn.Close();
                    //message d avertissement en cas de suppression
                    MessageBox.Show(" Visitor delete !!");
                }

                catch (Exception ex)
                {
                    //s'il ya des erreurs détectées un message sera affiché
                    MessageBox.Show("Erreur ! " + ex.ToString());
                }
            }

            listView1.Items.Clear();
            Basedb();
            listView1.Sorting = SortOrder.Ascending;
        }

        private void gunaAdvenceButton5_Click(object sender, EventArgs e)
        {
            gunaShadowPanel2.Visible = true;
            gunaShadowPanel1.Visible = false;
            gunaShadowPanel3.Visible = false;
            gunaShadowPanel4.Visible = false;
      


        }
        public static DateTime Now { get; }

        private void gunaAdvenceButton4_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            OleDbConnection cnn;
            OleDbCommand cmd;
            string sql = null;
            connetionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\hp\\Documents\\Police.accdb";

            string x= DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
      

            cnn = new OleDbConnection(connetionString);
            try
            {

                string s = "";
                sql = "insert into Visitor values ('" + gunaLineTextBox3.Text + "','" + gunaLineTextBox4.Text + "','" + x + "','" + s+ "','" + gunaLineTextBox7.Text + "')";


                cnn.Open();

                //creation d un objet command pour lancer la requete
                cmd = new OleDbCommand(sql, cnn);
                //executer la requete avec la methode ExecuteNonQuery
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cnn.Close();
                //message d avertissement en cas d ajout avec succes
                MessageBox.Show("  ADDED  !!");
            }
            catch (Exception ex1)
            {    //Afficher le message d erreur en cas de problème
                MessageBox.Show("Erreur ! " + ex1.ToString());
            }
            gunaLineTextBox3.Text = " ";
            gunaLineTextBox4.Text = " ";
            gunaLineTextBox7.Text =  "" ;
            listView1.Items.Clear();
            Basedb();
            listView1.Sorting = SortOrder.Ascending;
        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            gunaShadowPanel2.Visible = false;
            gunaShadowPanel1.Visible = false;
            gunaShadowPanel3.Visible = true;
            gunaShadowPanel4.Visible = false;
        

        }

        private void gunaAdvenceButton6_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            OleDbConnection cnn;
            OleDbCommand cmd;
            string sql = null;
            connetionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\hp\\Documents\\Police.accdb";


            cnn = new OleDbConnection(connetionString);
            try
            {
 
                sql = "UPDATE Visitor SET [ID] = '" + gunaLineTextBox8.Text + "', [Name] = '" + gunaLineTextBox6.Text + "', [relation] = '" + gunaLineTextBox5.Text + "' WHERE ID = " + gunaLineTextBox8.Text;
                
                 cnn.Open();
                cmd = new OleDbCommand(sql, cnn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cnn.Close();
                MessageBox.Show("  Update Done  !!");
            }
            catch (Exception ex1) { 
                MessageBox.Show("Erreur ! " + ex1.ToString());
            }
            listView1.Items.Clear();
            Basedb();
            listView1.Sorting = SortOrder.Ascending;
            gunaLineTextBox8.Text = " ";
            gunaLineTextBox6.Text = " ";
            gunaLineTextBox5.Text = " ";
        }

        private void gunaAdvenceButton9_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            OleDbConnection cnn;
            OleDbCommand cmd;
            string sql = null;
            connetionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\hp\\Documents\\Police.accdb";

            string x = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

            cnn = new OleDbConnection(connetionString);
            try
            {

                sql = "UPDATE Visitor SET  [Date_sortie] = '" + x +  "' WHERE ID = " + gunaLineTextBox11.Text;


                cnn.Open();

                //creation d un objet command pour lancer la requete
                cmd = new OleDbCommand(sql, cnn);
                //executer la requete avec la methode ExecuteNonQuery
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cnn.Close();
                //message d avertissement en cas d ajout avec succes
                MessageBox.Show("  ADDED  !!");
            }
            catch (Exception ex1)
            {    //Afficher le message d erreur en cas de problème
                MessageBox.Show("Erreur ! " + ex1.ToString());
            }
            gunaLineTextBox11.Text = "";
            listView1.Items.Clear();
            Basedb();
            listView1.Sorting = SortOrder.Ascending;
        }

        private void gunaAdvenceButton8_Click(object sender, EventArgs e)
        {
            gunaShadowPanel1.Visible = false;
            gunaShadowPanel2.Visible = false;
            gunaShadowPanel3.Visible = false;
            gunaShadowPanel4.Visible = true;
       


        }

        private void gunaAdvenceButton10_Click(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton11_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
          

        }

        private void gunaAdvenceButton10_Click_1(object sender, EventArgs e)
        {
            Basedb2();
            panel1.Visible = true;
            panel3.Visible = false;
        }

        private void gunaAdvenceButton11_Click_1(object sender, EventArgs e)
        {
            try
            {
                int num = int.Parse(listView2.SelectedItems[0].SubItems[0].Text);
                Form6 frm = new Form6(num);
                frm.Show();
            } catch { MessageBox.Show("please select a Visitor"); }
        
        }

        private void gunaAdvenceButton12_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel3.Visible = true;
        }
    }
}
