using Guna.UI.WinForms;
using System;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Tables;
using System.Data;
using System.IO;








namespace Police
{
    public partial class Form2 : Form
    {
        public Form2(int num)
        {
            InitializeComponent();

            this.num = num;
        }

        public int num { get; set; }
      

        private void gunaLabel53_Click(object sender, EventArgs e)
        {

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("Name", 70);
            listView1.Columns.Add("Realtionship", 70);
            listView1.Columns.Add("Adress", 70);
            listView1.Columns.Add("Father Name", 70);
            listView1.Columns.Add("Mother Name", 70);
            listView1.Columns.Add("Lawyer ID", 70);
            Basedb(num);
            db2(num);
        }

        private void Basedb(int y)
        {
            listView1.Refresh();
            int x = num;
            string connetionString = null;
            OleDbConnection cnn;
            OleDbCommand cmd;
            string sql = null;
            OleDbDataReader reader;
            connetionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\hp\\Documents\\Police.accdb";

            sql = " Select * from Family F,Rapport R where  F.ID_f=R.ID and R.ID=" + x.ToString();
            cnn = new OleDbConnection(connetionString);
            try
            {

                cnn.Open();
                cmd = new OleDbCommand(sql, cnn);
                ListViewItem list;
                OleDbDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {



                    lname.Text = rd.GetValue(0).ToString();
                    gunaLabel54.Text = rd.GetValue(4).ToString();
                    gunaLabel57.Text = rd.GetValue(5).ToString();
                    gunaLabel60.Text = rd.GetValue(1).ToString();
                    ladresse.Text = rd.GetValue(2).ToString();
                    String[] produit = { rd.GetValue(0).ToString(), rd.GetValue(1).ToString(), rd.GetValue(2).ToString(), rd.GetValue(4).ToString(), rd.GetValue(5).ToString(), rd.GetValue(6).ToString() };
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
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void gunaButton1_Click(object sender, EventArgs e)
        {


        }


        private void NextB_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();


            num++;
            int res = num;
            Basedb(res);
            db2(res);


        }

        private void previousB_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            num--;
            int ges = num;
            db2(ges);
            Basedb(ges);

        }

        private void db2(int y)
        {

            listView1.Refresh();
            string connetionString = null;
            OleDbConnection cnn;
            OleDbCommand cmd;
            string sql = null;
            OleDbDataReader reader;
            connetionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\hp\\Documents\\Police.accdb";
            sql = " Select * from Rapport WHERE  ID =" + y.ToString();
            cnn = new OleDbConnection(connetionString);
            try
            {
                cnn.Open();

                cmd = new OleDbCommand(sql, cnn);
                OleDbDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    gunaPictureBox1.Image = Image.FromFile("C:\\Users\\hp\\Desktop\\projectc#\\Inmate\\" + rd.GetValue(0).ToString());

                    l1.Text = rd.GetValue(0).ToString();


                    l2.Text = rd.GetValue(7).ToString();

                    string x2 = rd.GetValue(8).ToString();
                    string[] s2 = x2.Split(' ');
                    l4.Text = s2[0];
                    l5.Text = rd.GetValue(5).ToString();
                    l6.Text = rd.GetValue(9).ToString();

                    string x = rd.GetValue(10).ToString();
                    string[] s1 = x.Split(' ');
                    l7.Text = s1[0];
                    l8.Text = rd.GetValue(11).ToString();
                    gunaLabel49.Text = rd.GetValue(21).ToString();
                    lblood.Text = rd.GetValue(20).ToString();
                    gunaLabel33.Text = rd.GetValue(1).ToString();
                    gunaLabel34.Text = rd.GetValue(22).ToString();
                    gunaLabel35.Text = rd.GetValue(3).ToString();
                    gunaLabel42.Text = rd.GetValue(4).ToString();
                    lbrith.Text = rd.GetValue(12).ToString();
                    gunaLabel50.Text = rd.GetValue(5).ToString();
                    gunaLabel51.Text = rd.GetValue(14).ToString();
                    //
                    lreligion.Text = rd.GetValue(15).ToString();
                    leye.Text = rd.GetValue(16).ToString();
                    lhair.Text = rd.GetValue(18).ToString();
                    lheight.Text = rd.GetValue(17).ToString();
                    lcourse.Text = rd.GetValue(19).ToString();
                }

                rd.Close();
                cmd.Dispose();
                cnn.Close();

            }
            catch (Exception ex)
            { MessageBox.Show("Erreur " + ex.Message); }
        }

        private void Form2_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {

        }
        string chemin;
        private void gunaButton1_Click_1(object sender, EventArgs e)
        {
            //Create a PdfDocument object
            PdfDocument doc = new PdfDocument();

            //Add a page
            PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, new PdfMargins(20));

            //Create a PdfTable object
            PdfTable table = new PdfTable();
            PdfMargins margins = new PdfMargins(0, 100, 0, 60);
            doc.Template.Top = CreateHeaderTemplate(doc, margins);

            //Set font for header and the rest cells

            table.Style.DefaultStyle.Font = new PdfTrueTypeFont(new Font("Times New Roman", 12f, FontStyle.Regular), true);
            table.Style.HeaderStyle.Font = new PdfTrueTypeFont(new Font("Times New Roman", 12f, FontStyle.Bold), true);
            //

            //
            //Crate a DataTable 1
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Nationality");
            dataTable.Columns.Add("Gender");
            dataTable.Columns.Add("Born in");
            dataTable.Columns.Add("place of birth");
            dataTable.Columns.Add("Age");
            dataTable.Columns.Add("Adress");
            dataTable.Columns.Add("Status");
            //table 2
            PdfTable table2 = new PdfTable();
            table2.Style.DefaultStyle.Font = new PdfTrueTypeFont(new Font("Times New Roman", 12f, FontStyle.Regular), true);
            table2.Style.HeaderStyle.Font = new PdfTrueTypeFont(new Font("Times New Roman", 12f, FontStyle.Bold), true);
           
            DataTable dataTable2 = new DataTable();
            dataTable2.Columns.Add("Prisoner No");
            dataTable2.Columns.Add("Detension Class");
            dataTable2.Columns.Add("Confinement Date");
            dataTable2.Columns.Add("Crime");
            dataTable2.Columns.Add("Conviction Status");
            dataTable2.Columns.Add("Case No");
            dataTable2.Columns.Add("Court Date");
            dataTable2.Rows.Add(new string[] { l1.Text, l2.Text, l4.Text, l8.Text, l5.Text, l6.Text, l7.Text });
           
            //Set the datatable as the data source of table
            table2.DataSource = dataTable2;

            //Show header(the header is hidden by default)
            table2.Style.ShowHeader = true;

            //Set font color and backgroud color of header row
            table2.Style.HeaderStyle.BackgroundBrush = PdfBrushes.Gray;
            table2.Style.HeaderStyle.TextBrush = PdfBrushes.White;

            //Set text alignment in header row
            table2.Style.HeaderStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);

            //Set text alignment in other cells
            for (int i = 0; i < table2.Columns.Count; i++)
            {
                table2.Columns[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            }

            //Register with BeginRowLayout event
            table2.BeginRowLayout += Table_BeginRowLayout;

            //Draw table on the page
            table2.Draw(page, new PointF(0, 300));
            ///

            PdfImage image = PdfImage.FromFile("C:\\Users\\hp\\Desktop\\projectc#\\Inmate\\"+ l1.Text);
          
            

            PdfSolidBrush brush1 = new PdfSolidBrush(Color.Gray);
            PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 18f);
            page.Canvas.DrawString("Family  : ", font, brush1, 0, 450f);
            // table family 
            PdfTable table3 = new PdfTable();
            table3.Style.DefaultStyle.Font = new PdfTrueTypeFont(new Font("Times New Roman", 12f, FontStyle.Regular), true);
            table3.Style.HeaderStyle.Font = new PdfTrueTypeFont(new Font("Times New Roman", 12f, FontStyle.Bold), true);

            DataTable dataTable3 = new DataTable();
            dataTable3.Columns.Add("Name");
            dataTable3.Columns.Add("Relation");
            dataTable3.Columns.Add("Adress");
            dataTable3.Columns.Add("Mother Name");
            dataTable3.Columns.Add("Father Name");
            for (int i =0; i<listView1.Items.Count; i++)
            {
                dataTable3.Rows.Add(new string[] { listView1.Items[i].SubItems[0].Text, listView1.Items[i].SubItems[1].Text, listView1.Items[i].SubItems[2].Text, listView1.Items[i].SubItems[4].Text, listView1.Items[i].SubItems[5].Text });
            }
            table3.DataSource = dataTable3;

            //Show header(the header is hidden by default)
            table3.Style.ShowHeader = true;

            //Set font color and backgroud color of header row
            table3.Style.HeaderStyle.BackgroundBrush = PdfBrushes.Gray;
            table3.Style.HeaderStyle.TextBrush = PdfBrushes.White;

            //Set text alignment in header row
            table3.Style.HeaderStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);

            //Set text alignment in other cells
            for (int i = 0; i < table3.Columns.Count; i++)
            {
                table3.Columns[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            }

            //Register with BeginRowLayout event
            table3.BeginRowLayout += Table_BeginRowLayout;

            //Draw table on the page
            table3.Draw(page, new PointF(0, 480f));
            ////////
            
            page.Canvas.DrawString("Other Personal Info : ", font, brush1, 0, 540f);

            /////table 4
            ///
            PdfTable table4 = new PdfTable();
            table4.Style.DefaultStyle.Font = new PdfTrueTypeFont(new Font("Times New Roman", 12f, FontStyle.Regular), true);
            table4.Style.HeaderStyle.Font = new PdfTrueTypeFont(new Font("Times New Roman", 12f, FontStyle.Bold), true);

            DataTable dataTable4 = new DataTable();
            dataTable4.Columns.Add("Religion");
            dataTable4.Columns.Add("Eye Color");
            dataTable4.Columns.Add("built");
            dataTable4.Columns.Add("Course");
            dataTable4.Columns.Add("hair Color");
            dataTable4.Columns.Add("Blood Type");
            dataTable4.Columns.Add("Height");



            dataTable4.Rows.Add(new string[] { lreligion.Text, leye.Text, gunaLabel90.Text, lcourse.Text, lhair.Text, lblood.Text, lheight.Text });
            
            table4.DataSource = dataTable4;

            //Show header(the header is hidden by default)
            table4.Style.ShowHeader = true;

            //Set font color and backgroud color of header row
            table4.Style.HeaderStyle.BackgroundBrush = PdfBrushes.Gray;
            table4.Style.HeaderStyle.TextBrush = PdfBrushes.White;

            //Set text alignment in header row
            table4.Style.HeaderStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);

            //Set text alignment in other cells
            for (int i = 0; i < table4.Columns.Count; i++)
            {
                table4.Columns[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            }

            //Register with BeginRowLayout event
            table4.BeginRowLayout += Table_BeginRowLayout;

            //Draw table on the page
            table4.Draw(page, new PointF(0, 570));
            ////////
            page.Canvas.DrawString("Image Inamte! : ", font, brush1, 0, 160f);

            float x =120f;
            
            float y = 120f;
            float width = 100;
            
            float height = 100;

            page.Canvas.DrawImage(image, x, y, width, height);

            page.Canvas.DrawString("Inmate Information  : ", font, brush1, 0, 250f);
            dataTable.Rows.Add(new string[] { gunaLabel33.Text, gunaLabel34.Text, gunaLabel35.Text, gunaLabel40.Text, lbrith.Text, gunaLabel42.Text, gunaLabel49.Text, gunaLabel50.Text });

            

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
            table.Draw(page, new PointF(0, 380));

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
            try
            {
                doc.SaveToFile(chemin, FileFormat.PDF);
            }catch(Exception ex) { MessageBox.Show("You need to pick place to save"); }
        }
        static PdfPageTemplateElement CreateHeaderTemplate(PdfDocument doc, PdfMargins margins)
        {
            //get page size
            SizeF pageSize = doc.PageSettings.Size;

            //create a PdfPageTemplateElement object as header space
            PdfPageTemplateElement headerSpace = new PdfPageTemplateElement(pageSize.Width, margins.Top+50);
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
            headerSpace.Graphics.DrawImage(headerImage, x, margins.Top -110, width, height);


            //draw line in header space
            PdfPen pen = new PdfPen(PdfBrushes.Black, 4);
            headerSpace.Graphics.DrawLine(pen, 0 ,  margins.Top , pageSize.Width , margins.Top );

            //draw text in header space
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Impact", 25f, FontStyle.Bold));
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Left);
            String headerText = "Inamte Rapport";
            SizeF size = font.MeasureString(headerText, format);
            headerSpace.Graphics.DrawString(headerText, font, PdfBrushes.Gray, pageSize.Width-160, margins.Top - 80, format);

            //return headerSpace
            return headerSpace;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
    }
    
