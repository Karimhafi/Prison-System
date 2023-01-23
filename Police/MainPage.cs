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
using System.Data.SqlClient;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.Remoting.Lifetime;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Tables;
using Microsoft.VisualBasic.ApplicationServices;
using SortOrder = System.Windows.Forms.SortOrder;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Runtime.CompilerServices;
using ZedGraph;
using System.Drawing.Imaging;
using Microsoft.VisualBasic;

namespace Police
{
    public partial class MainPage : Form
    {
        public string ID { get; set; }
        public MainPage(string ID)
        {
            InitializeComponent();
            this.ID = ID;

        }
       


        private void gunaButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Rank()
        {
            string connetionString = null;
            OleDbConnection cnn;
            OleDbCommand cmd;
            string sql = null;
            connetionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\hp\\Documents\\Police.accdb";

            sql = "select * from police where ID = " + ID;
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
        private void Form1_Load(object sender, EventArgs e)
        {

            Rank();
            Show1();
           Basedb();
            timer1.Start();
            listView1.MultiSelect = true;
            listView1.Columns.Add("        ID", 150);
            listView1.Columns.Add("        Name", 150);
            listView1.Columns.Add("        Gender", 150);
            listView1.Columns.Add("        Age", 150);
            listView1.Columns.Add("        Status", 500);

            

        }
     

        private void Show1()
        {
            if (gunaLabel2.Text == "Chef") { }
            else if (gunaLabel2.Text == "Policee") { userAdd.Visible = false; }
            else if (gunaLabel2.Text == "Guard")
            {
                gunaAdvenceButton1.Visible = false;
                gunaAdvenceButton2.Visible = false;
                gunaAdvenceButton3.Visible = false;
                userAdd.Visible = false;
            }

        }
        /// 
        private void timer1_Tick(object sender, EventArgs e)
        {

            gunaLabel3.Text = DateTime.Now.ToString("HH:mm:");
            gunaLabel4.Text = DateTime.Now.ToString("ss");
            gunaLabel5.Text = DateTime.Now.ToString("dddd") + " ," + DateTime.Now.ToString("MMMMMM ,dd,yyyy");
            gunaLabel4.Location = new Point(gunaLabel3.Location.X + gunaLabel3.Width - 5, gunaLabel4.Location.Y);
        }



        private void pictureBox4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            Basedb();
            listView1.Sorting = SortOrder.Ascending;


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
            sql = " Select * from Rapport";
            cnn = new OleDbConnection(connetionString);
            try
            {
                cnn.Open();
                cmd = new OleDbCommand(sql, cnn);
              
                OleDbDataReader rd = cmd.ExecuteReader();

                //lire le contenu de DataReader ligne par ligne avec la méthode read
                while (rd.Read())
                {   

                    String[] produit = { rd.GetValue(0).ToString(), rd.GetValue(2).ToString(), rd.GetValue(3).ToString(), rd.GetValue(4).ToString(), rd.GetValue(5).ToString() };
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

        private void gunaAdvenceButton5_Click(object sender, EventArgs e)
        {

            int num = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            Form2 frm = new Form2(num);
            frm.Show();


        }

        /* private void gunaAdvenceButton6_Click(object sender, EventArgs e)
         {
             MessageBox.Show("hereeeeeeeeeeeeeeee");
             OpenFileDialog openFileDialog1 = new OpenFileDialog();
             openFileDialog1.Title = "Choose:";
             openFileDialog1.Filter = "All file(*.*)|*.*";
             if (openFileDialog1.ShowDialog() == DialogResult.OK)
             {
                 string fileName = openFileDialog1.FileName;



                 string connetionString = null;
                 OleDbConnection cnn;
                 OleDbCommand cmd;
                 string sql = null;
                 connetionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\hp\\Documents\\Police.accdb";

                 cnn = new OleDbConnection(connetionString);


                 try
                 {   //definir le texte de la requete
                     sql = "insert into Rapport (ID,img)values (70,'" + fileName + "')";
                     cnn.Open();

                     //creation d un objet command pour lancer la requete
                     cmd = new OleDbCommand(sql, cnn);
                     //executer la requete avec la methode ExecuteNonQuery
                     cmd.ExecuteNonQuery();
                     cmd.Dispose();
                     cnn.Close();
                     //message d avertissement en cas d ajout avec succes
                     MessageBox.Show(" Image Added!!");
                 }

                 catch (Exception ex)
                 {    //Afficher le message d erreur en cas de problème
                     MessageBox.Show("Erreur ! " + ex.ToString());
                 }
             }
         }

    */



        private void gunaAdvenceButton7_Click(object sender, EventArgs e)
        {
            if (gunaLineTextBox1.Text == "") { MessageBox.Show("You need to input in Search ' ID ' "); }
            else { searchbyID(); }



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

                sql = " Select * from Rapport where ID =" + gunaLineTextBox1.Text;
                cnn = new OleDbConnection(connetionString);
                try
                {
                    cnn.Open();
                    cmd = new OleDbCommand(sql, cnn);

                    OleDbDataReader rd = cmd.ExecuteReader();


                    while (rd.Read())
                    {

                        String[] produit = { rd.GetValue(0).ToString(), rd.GetValue(2).ToString(), rd.GetValue(3).ToString(), rd.GetValue(4).ToString(), rd.GetValue(5).ToString() };
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

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel4.Visible = false;
            panel1.Visible = false;
        }



        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
        }



        //Event handler
        private static void Table_BeginRowLayout(object sender, BeginRowLayoutEventArgs args)
        {
            //Set row height
            args.MinimalHeight = 20f;

            //Alternate row color
            if (args.RowIndex < 0)
            {
                return;
            }
            if (args.RowIndex % 2 == 1)
            {
                args.CellStyle.BackgroundBrush = PdfBrushes.LightGray;
            }
            else
            {
                args.CellStyle.BackgroundBrush = PdfBrushes.White;
            }
        }
        private void TOPSECRET(string X)
        {   //Create a PdfDocument object
            PdfDocument pdf = new PdfDocument();

            //Load a sample PDF document
            pdf.LoadFromFile(chemin);

            //Create a PdfTrueTypeFont object
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 50f), true);

            //Set the watermark text
            string text = "TOP SECRET";

            //Measure the text size
            SizeF textSize = font.MeasureString(text);

            //Calculate the values of two offset variables, 
            //which will be used to calculate the translation amount of the coordinate system
            float offset1 = (float)(textSize.Width * System.Math.Sqrt(2) / 4);
            float offset2 = (float)(textSize.Height * System.Math.Sqrt(2) / 4);

            //Traverse all the pages in the document
            foreach (PdfPageBase page in pdf.Pages)
            {
                page.Canvas.SetTransparency(0.8f);

                page.Canvas.TranslateTransform(page.Canvas.Size.Width / 2 - offset1 - offset2, page.Canvas.Size.Height / 2 + offset1 - offset2);

                page.Canvas.RotateTransform(-45);

                page.Canvas.DrawString(text, font, PdfBrushes.DarkRed, 0, 0);
            }

            //Save the changes to another file
            pdf.SaveToFile(chemin);
        }
        /* HEADER*/
        static PdfPageTemplateElement CreateHeaderTemplate(PdfDocument doc, PdfMargins margins)
        {
            //get page size
            SizeF pageSize = doc.PageSettings.Size;

            //create a PdfPageTemplateElement object as header space
            PdfPageTemplateElement headerSpace = new PdfPageTemplateElement(pageSize.Width, margins.Top);
            headerSpace.Foreground = false;

            //declare two float variables
            float x = margins.Left;
            float y = 0;

            //draw image in header space 

            PdfImage headerImage = PdfImage.FromFile("C:\\Users\\hp\\Desktop\\image\\images.png");

            float width = headerImage.Width;
            float height = headerImage.Height;
            width = 150;
            height = 100;
            headerSpace.Graphics.DrawImage(headerImage, x, margins.Top - height - 10, width, height);


            //draw line in header space
            PdfPen pen = new PdfPen(PdfBrushes.Black, 4);
            headerSpace.Graphics.DrawLine(pen, x + 50, y + margins.Top - 2, pageSize.Width - x, y + margins.Top - 2);

            //draw text in header space
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Impact", 25f, FontStyle.Bold));
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Left);
            String headerText = "INMATE INFO";
            SizeF size = font.MeasureString(headerText, format);
            headerSpace.Graphics.DrawString(headerText, font, PdfBrushes.Gray, width * 2 + 50, margins.Top - (size.Height + 5), format);

            //return headerSpace
            return headerSpace;
        }


        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel4.Visible = true;
            panel3.Visible = false;

        }

        private void gunaPictureBox2_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();

        }

        private void gunaPictureBox1_MouseEnter(object sender, EventArgs e)
        {
            gunaPictureBox1.Width += 20;
            gunaPictureBox1.Height += 20;
        }

        private void gunaPictureBox1_MouseLeave(object sender, EventArgs e)
        {
            gunaPictureBox1.Width -= 20;
            gunaPictureBox1.Height -= 20;
        }

        private void gunaPictureBox2_MouseEnter(object sender, EventArgs e)
        {
            gunaPictureBox2.Width += 20;
            gunaPictureBox2.Height += 20;
        }

        private void gunaPictureBox2_MouseLeave(object sender, EventArgs e)
        {
            gunaPictureBox2.Width -= 20;
            gunaPictureBox2.Height -= 20;
        }


        string chemin;
        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {
            //Create a PdfDocument object
            PdfDocument doc = new PdfDocument();

            //Add a page
            PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, new PdfMargins(40));

            //Create a PdfTable object
            PdfTable table = new PdfTable();
            PdfMargins margins = new PdfMargins(0, 100, 0, 60);
            doc.Template.Top = CreateHeaderTemplate(doc, margins);

            //Set font for header and the rest cells

            table.Style.DefaultStyle.Font = new PdfTrueTypeFont(new Font("Times New Roman", 12f, FontStyle.Regular), true);
            table.Style.HeaderStyle.Font = new PdfTrueTypeFont(new Font("Times New Roman", 12f, FontStyle.Bold), true);
            //

            //
            //Crate a DataTable
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Gender");
            dataTable.Columns.Add("Age");
            dataTable.Columns.Add("Status");


            for (int i = 0; i < listView1.Items.Count; i++)
            {
                dataTable.Rows.Add(new string[] { listView1.Items[i].SubItems[0].Text, listView1.Items[i].SubItems[1].Text, listView1.Items[i].SubItems[2].Text, listView1.Items[i].SubItems[3].Text, listView1.Items[i].SubItems[4].Text });

            }

            //Set the datatable as the data source of table
            table.DataSource = dataTable;

            //Show header(the header is hidden by default)
            table.Style.ShowHeader = true;

            //Set font color and backgroud color of header row
            table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.Gray;
            table.Style.HeaderStyle.TextBrush = PdfBrushes.White;

            //Set text alignment in header row
            table.Style.HeaderStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);

            //Set text alignment in other cells
            for (int i = 0; i < table.Columns.Count; i++)
            {
                table.Columns[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            }

            //Register with BeginRowLayout event
            table.BeginRowLayout += Table_BeginRowLayout;

            //Draw table on the page
            table.Draw(page, new PointF(0, 250));

            //Save the document to a PDF file 



            //
            SaveFileDialog saveFileDialog1 = new SaveFileDialog(); saveFileDialog1.Title = "Choose:";
            saveFileDialog1.Filter = "PDF(*.pdf)|*.pdf";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                chemin = saveFileDialog1.FileName;


                doc.SaveToFile(chemin);



                MessageBox.Show(" PDF FILLE AS BEEN  Added!!");
            }
            TOPSECRET(chemin);
        }





       

        private void gunaAdvenceButton2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile("C:\\Users\\hp\\Desktop\\image\\icons8-detain-48.png");

        }

        private void gunaAdvenceButton2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile("C:\\Users\\hp\\Desktop\\image\\icons8-officier-de-police-48.png");

        }

        private void gunaAdvenceButton3_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void gunaAdvenceButton3_DragLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile("C:\\Users\\hp\\Desktop\\image\\icons8-officier-de-police-48.png");

        }

        private void gunaAdvenceButton3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile("C:\\Users\\hp\\Desktop\\image\\icons8-douanier-48.png");

        }

        private void gunaAdvenceButton3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile("C:\\Users\\hp\\Desktop\\image\\icons8-officier-de-police-48.png");

        }

        private void gunaLineTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (gunaLineTextBox1.Text == "")
            {
                no.Visible = false; ok.Visible = false;
                listView1.Items.Clear();
                Basedb();
                listView1.Sorting = SortOrder.Ascending;
            }

        }

        private void gunaAdvenceButton3_MouseLeave_1(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile("C:\\Users\\hp\\Desktop\\image\\icons8-officier-de-police-48.png");

        }

        private void user_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel4.Visible = false;
            panel3.Visible = false;
        }

        private void gunaAdvenceButton4_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel5.Visible = false;
            panel6.Visible = false;

        }

        private void saveimg()
        {
            if (gunaPictureBox3.Image != null)
            {
                string fname = IDuser.Text + ".jpg";
                string folder = "C:\\Users\\hp\\Desktop\\projectc#\\Police" + "\\" + IDuser.Text+".jpg";
                string folderPath = System.IO.Path.Combine(folder, fname);
                gunaPictureBox3.Image.Save(folder, ImageFormat.Jpeg);
            }
            else { MessageBox.Show("Please add image"); }
        }

        private void gunaAdvenceButton10_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            OleDbConnection cnn;
            OleDbCommand cmd;
            string sql = null;
            connetionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\hp\\Documents\\Police.accdb";
         
          
            cnn = new OleDbConnection(connetionString);
            try
            {
                string rank = comboBox1.Text;

                saveimg();
               string path = "C:\\Users\\hp\\Desktop\\projectc#\\Police" + "\\" + IDuser.Text + ".jpg";
                sql = "insert into police values ('" + IDuser.Text + "','" + Name.Text + "','" + Pass.Text + "','" + rank + "','" + path + "')";


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
        }
        string fileName;
    

        private void gunaPictureBox3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Choose:";
            openFileDialog1.Filter = "All file(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;



                gunaPictureBox3.Image = Image.FromFile(fileName);
                MessageBox.Show(" Image Added!!");
            }
        }

        private void gunaButton1_Click_1(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.Show();
            this.Hide();
        }

        private void gunaAdvenceButton8_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            panel2.Visible = false;
            panel6.Visible = false;

        }

        private void gunaAdvenceButton9_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            OleDbConnection cnn;
            OleDbCommand cmd;
            string sql = null;
            connetionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\hp\\Documents\\Police.accdb";


            cnn = new OleDbConnection(connetionString);
            try
            {
                string rank = comboBox2.Text;

                saveimg();
                string path = "C:\\Users\\hp\\Desktop\\projectc#\\Police" + "\\" + IDuser.Text + ".jpg";
                sql = "UPDATE police SET [username] = '"+ gunaTextBox2.Text + "', [password] = '"+ gunaTextBox1.Text + "',[Rank] = '"+ rank + "', [img_P] = '"+ path + "' WHERE ID = "+ gunaTextBox3.Text;
                //sql = "UPDATE police SET username ='" + gunaTextBox2.Text + "', password ='" + gunaTextBox1.Text + "', Rank ='" + rank + "', img_P ='" + path + "' WHERE ID ='" + gunaTextBox3.Text + "';";



                cnn.Open();

                //creation d un objet command pour lancer la requete
                cmd = new OleDbCommand(sql, cnn);
                //executer la requete avec la methode ExecuteNonQuery
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cnn.Close();
                //message d avertissement en cas d ajout avec succes
                MessageBox.Show("  Update Done  !!");
            }
            catch (Exception ex1)
            {    //Afficher le message d erreur en cas de problème
                MessageBox.Show("Erreur ! " + ex1.ToString());
            }
            //////////////////
            ///
         
            }
        

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaPictureBox4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Choose:";
            openFileDialog1.Filter = "All file(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;



                gunaPictureBox3.Image = Image.FromFile(fileName);
                MessageBox.Show(" Image Added!!");
            }
        }

        private void gunaAdvenceButton6_Click(object sender, EventArgs e)
        {
            panel6.Visible = true;
            panel2.Visible = false;
            panel5.Visible = false;
      
        }

        private void gunaAdvenceButton11_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            OleDbConnection cnn;
            OleDbCommand cmd;
            string sql = null;
            connetionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\hp\\Documents\\Police.accdb";

            cnn = new OleDbConnection(connetionString);
            DialogResult res = MessageBox.Show("Are you sure you want to Delete Police ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {

                try
            {   //le texte de la requete
                sql = "delete from police where ID=" + gunaTextBox6.Text;
                cnn.Open();

                //création d une commande 
                cmd = new OleDbCommand(sql, cnn);
                //exécuter la requete à laide de la méthode ExecuteNonQuery
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cnn.Close();
                //message d avertissement en cas de suppression
                MessageBox.Show(" Police delete !!");
            }

            catch (Exception ex)
            {
                //s'il ya des erreurs détectées un message sera affiché
                MessageBox.Show("Erreur ! " + ex.ToString());
            }
            }
            DialogResult res2 = MessageBox.Show("do you wanna delete Image too ??", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res2 == DialogResult.OK)
            {
                string filePath = "C:\\Users\\hp\\Desktop\\projectc#\\Police" + "\\" + gunaTextBox6.Text + ".jpg";

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    MessageBox.Show("Image delete");
                }
                else 
                {
                  
                    MessageBox.Show("Image Not found");
                }
            }
        }

     
    }
    }




