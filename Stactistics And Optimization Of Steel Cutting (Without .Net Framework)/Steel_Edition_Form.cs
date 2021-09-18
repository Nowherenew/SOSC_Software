using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Imaging;

namespace Stactistics_And_Optimization_Of_Steel_Cutting__Without_.Net_Framework_
{
    public partial class Steel_Edition_Form : Form
    {
        List<TextBox> LengthTextBoxes;
        double BarLength = 0;
        byte[] ImageBytes;
        int MODE;
        int ROW;
        int id;
        public Steel_Edition_Form(int Mode, int RowIndex)
        {
            InitializeComponent();
            LengthTextBoxes = new List<TextBox> {Length1TextBox, Length2TextBox, Length3TextBox, Length4TextBox, Length5TextBox, Length6TextBox, Length7TextBox };
            MODE = Mode;
            ROW = RowIndex;

            id = ROW;
            if (MODE==4)
            {
                using (SqlConnection sqlConnection = new SqlConnection(Main_Interface_Form.Globals.connectionString))
                {
                    sqlConnection.Open();
                    ROW++;
                    using (SqlCommand sqlCommand = new SqlCommand("", sqlConnection))
                    {
                        sqlCommand.CommandText = "SELECT Batching, ComponentName, ComponentSign, SteelSign, ShapeTag, Diameter, NumberOfComponent, BarPerComponent,Curling45, Curling90, Curling135 FROM Statictiscal_Table WHERE ID=" + ROW;
                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            while (sqlDataReader.Read())
                            {
                                BatchingTextBox.Text = sqlDataReader["Batching"].ToString();
                                ComponentNameTextBox.Text = sqlDataReader["ComponentName"].ToString();
                                ComponentSignTextBox.Text = sqlDataReader["ComponentSign"].ToString();
                                SteelSignTextBox.Text = sqlDataReader["SteelSign"].ToString();
                                ShapePictureBox.Tag = sqlDataReader["ShapeTag"].ToString().Trim();
                                DiameterComboBox.Text = sqlDataReader["Diameter"].ToString();
                                NumberOfComponentTextBox.Text = sqlDataReader["NumberOfComponent"].ToString();
                                BarPerComponentTextBox.Text = sqlDataReader["BarPerComponent"].ToString();
                                Curling45TextBox.Text = sqlDataReader["Curling45"].ToString();
                                Curling90TextBox.Text = sqlDataReader["Curling90"].ToString();
                                Curling135TextBox.Text = sqlDataReader["Curling135"].ToString();
                            }
                        }
                    }
                    sqlConnection.Close();
                }
                PictureShow((string)ShapePictureBox.Tag);
            }
        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
            string PictureBoxTag = (string)(sender as PictureBox).Tag;
            ShapePictureBox.Tag = PictureBoxTag;
            PictureShow(PictureBoxTag);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        private void PictureShow(string PictureBoxTag)
        {
            for (int i = 0; i < LengthTextBoxes.Count; i++)
            {
                LengthTextBoxes[i].Tag = "";
                LengthTextBoxes[i].Text = "";
                LengthTextBoxes[i].Visible = false;
            }
            string PicturePath = "B:/Software Data/VisualStudio/SOSC_Software/Stactistics And Optimization Of Steel Cutting (Without .Net Framework)/Resources/" + PictureBoxTag + "_NCM.jpg";
            if (ShapePictureBox.BackgroundImage != null)
            {
                ShapePictureBox.BackgroundImage.Dispose();
                ShapePictureBox.BackgroundImage = Image.FromFile(PicturePath);
            }
            else
            {
                ShapePictureBox.BackgroundImage = Image.FromFile(PicturePath);
            }

            int PointX = 0, PointY = 0;
            if (PictureBoxTag == "1")
            {
                //ShapePictureBox.BackgroundImage = Properties.Resources._1_NCM;
                PointX = ShapePictureBox.Location.X + 378;
                PointY = ShapePictureBox.Location.Y + 173;
                LengthTextBoxes[0].Location = new Point(PointX, PointY);
                LengthTextBoxes[0].Tag = "lx1";
                LengthTextBoxes[0].Visible = true;
            }
            else if (PictureBoxTag == "2")
            {
                //ShapePictureBox.BackgroundImage = Properties.Resources._2_NCM;
                PointX = ShapePictureBox.Location.X + 378;
                PointY = ShapePictureBox.Location.Y + 173;
                LengthTextBoxes[0].Location = new Point(PointX, PointY);
                LengthTextBoxes[0].Tag = "lx1";
                LengthTextBoxes[0].Visible = true;
                PointX = ShapePictureBox.Location.X + 733;
                PointY = ShapePictureBox.Location.Y + 173;
                LengthTextBoxes[1].Location = new Point(PointX, PointY);
                LengthTextBoxes[1].Tag = "hook";
                LengthTextBoxes[1].Visible = true;
            }
            else if (PictureBoxTag == "3")
            {
                //ShapePictureBox.BackgroundImage = Properties.Resources._3_NCM;
                PointX = ShapePictureBox.Location.X + 378;
                PointY = ShapePictureBox.Location.Y + 83;
                LengthTextBoxes[0].Location = new Point(PointX, PointY);
                LengthTextBoxes[0].Tag = "lx1";
                LengthTextBoxes[0].Visible = true;
                PointX = ShapePictureBox.Location.X + 23;
                PointY = ShapePictureBox.Location.Y + 243;
                LengthTextBoxes[1].Location = new Point(PointX, PointY);
                LengthTextBoxes[1].Tag = "ly1";
                LengthTextBoxes[1].Visible = true;
            }
            else if (PictureBoxTag == "4")
            {
                //ShapePictureBox.BackgroundImage = Properties.Resources._4_NCM;
                PointX = ShapePictureBox.Location.X + 23;
                PointY = ShapePictureBox.Location.Y + 243;
                LengthTextBoxes[0].Location = new Point(PointX, PointY);
                LengthTextBoxes[0].Tag = "ly1";
                LengthTextBoxes[0].Visible = true;
                PointX = ShapePictureBox.Location.X + 183;
                PointY = ShapePictureBox.Location.Y + 83;
                LengthTextBoxes[1].Location = new Point(PointX, PointY);
                LengthTextBoxes[1].Tag = "lx1";
                LengthTextBoxes[1].Visible = true;
                PointX = ShapePictureBox.Location.X + 378;
                PointY = ShapePictureBox.Location.Y + 83;
                LengthTextBoxes[2].Location = new Point(PointX, PointY);
                LengthTextBoxes[2].Tag = "lnx1";
                LengthTextBoxes[2].Visible = true;
                PointX = ShapePictureBox.Location.X + 543;
                PointY = ShapePictureBox.Location.Y + 173;
                LengthTextBoxes[3].Location = new Point(PointX, PointY);
                LengthTextBoxes[3].Tag = "lny1";
                LengthTextBoxes[3].Visible = true;
                PointX = ShapePictureBox.Location.X + 543;
                PointY = ShapePictureBox.Location.Y + 353;
                LengthTextBoxes[4].Location = new Point(PointX, PointY);
                LengthTextBoxes[4].Tag = "lx2";
                LengthTextBoxes[4].Visible = true;
                PointX = ShapePictureBox.Location.X + 733;
                PointY = ShapePictureBox.Location.Y + 243;
                LengthTextBoxes[5].Location = new Point(PointX, PointY);
                LengthTextBoxes[5].Tag = "hook";
                LengthTextBoxes[5].Visible = true;
            }
            else if (PictureBoxTag == "5")
            {
                //ShapePictureBox.BackgroundImage = Properties.Resources._5_NCM;
                PointX = ShapePictureBox.Location.X + 23;
                PointY = ShapePictureBox.Location.Y + 243;
                LengthTextBoxes[0].Location = new Point(PointX, PointY);
                LengthTextBoxes[0].Tag = "ly1";
                LengthTextBoxes[0].Visible = true;
                PointX = ShapePictureBox.Location.X + 183;
                PointY = ShapePictureBox.Location.Y + 83;
                LengthTextBoxes[1].Location = new Point(PointX, PointY);
                LengthTextBoxes[1].Tag = "lx1";
                LengthTextBoxes[1].Visible = true;
                PointX = ShapePictureBox.Location.X + 378;
                PointY = ShapePictureBox.Location.Y + 83;
                LengthTextBoxes[2].Location = new Point(PointX, PointY);
                LengthTextBoxes[2].Tag = "lnx1";
                LengthTextBoxes[2].Visible = true;
                PointX = ShapePictureBox.Location.X + 543;
                PointY = ShapePictureBox.Location.Y + 173;
                LengthTextBoxes[3].Location = new Point(PointX, PointY);
                LengthTextBoxes[3].Tag = "lny1";
                LengthTextBoxes[3].Visible = true;
                PointX = ShapePictureBox.Location.X + 543;
                PointY = ShapePictureBox.Location.Y + 353;
                LengthTextBoxes[4].Location = new Point(PointX, PointY);
                LengthTextBoxes[4].Tag = "lx2";
                LengthTextBoxes[4].Visible = true;
            }
            else if (PictureBoxTag == "6")
            {
                //ShapePictureBox.BackgroundImage = Properties.Resources._6_NCM;
                PointX = ShapePictureBox.Location.X + 23;
                PointY = ShapePictureBox.Location.Y + 243;
                LengthTextBoxes[0].Location = new Point(PointX, PointY);
                LengthTextBoxes[0].Tag = "ly1";
                LengthTextBoxes[0].Visible = true;
                PointX = ShapePictureBox.Location.X + 183;
                PointY = ShapePictureBox.Location.Y + 83;
                LengthTextBoxes[1].Location = new Point(PointX, PointY);
                LengthTextBoxes[1].Tag = "lx1";
                LengthTextBoxes[1].Visible = true;
                PointX = ShapePictureBox.Location.X + 378;
                PointY = ShapePictureBox.Location.Y + 83;
                LengthTextBoxes[2].Location = new Point(PointX, PointY);
                LengthTextBoxes[2].Tag = "lnx1";
                LengthTextBoxes[2].Visible = true;
                PointX = ShapePictureBox.Location.X + 543;
                PointY = ShapePictureBox.Location.Y + 173;
                LengthTextBoxes[3].Location = new Point(PointX, PointY);
                LengthTextBoxes[3].Tag = "lny1";
                LengthTextBoxes[3].Visible = true;
                PointX = ShapePictureBox.Location.X + 543;
                PointY = ShapePictureBox.Location.Y + 353;
                LengthTextBoxes[4].Location = new Point(PointX, PointY);
                LengthTextBoxes[4].Tag = "lx2";
                LengthTextBoxes[4].Visible = true;
            }
            else if (PictureBoxTag == "7")
            {
                //ShapePictureBox.BackgroundImage = Properties.Resources._7_NCM;
                PointX = ShapePictureBox.Location.X + 23;
                PointY = ShapePictureBox.Location.Y + 243;
                LengthTextBoxes[0].Location = new Point(PointX, PointY);
                LengthTextBoxes[0].Tag = "ly1";
                LengthTextBoxes[0].Visible = true;
                PointX = ShapePictureBox.Location.X + 183;
                PointY = ShapePictureBox.Location.Y + 243;
                LengthTextBoxes[1].Location = new Point(PointX, PointY);
                LengthTextBoxes[1].Tag = "lnx1";
                LengthTextBoxes[1].Visible = true;
                PointX = ShapePictureBox.Location.X + 418;
                PointY = ShapePictureBox.Location.Y + 173;
                LengthTextBoxes[2].Location = new Point(PointX, PointY);
                LengthTextBoxes[2].Tag = "lny1";
                LengthTextBoxes[2].Visible = true;
                PointX = ShapePictureBox.Location.X + 543;
                PointY = ShapePictureBox.Location.Y + 83;
                LengthTextBoxes[3].Location = new Point(PointX, PointY);
                LengthTextBoxes[3].Tag = "lny1";
                LengthTextBoxes[3].Visible = true;
                PointX = ShapePictureBox.Location.X + 733;
                PointY = ShapePictureBox.Location.Y + 243;
                LengthTextBoxes[4].Location = new Point(PointX, PointY);
                LengthTextBoxes[4].Tag = "lx2";
                LengthTextBoxes[4].Visible = true;
            }
            else if (PictureBoxTag == "8")
            {
                //ShapePictureBox.BackgroundImage = Properties.Resources._8_NCM;
                PointX = ShapePictureBox.Location.X + 378;
                PointY = ShapePictureBox.Location.Y + 83;
                LengthTextBoxes[0].Location = new Point(PointX, PointY);
                LengthTextBoxes[0].Tag = "lx1";
                LengthTextBoxes[0].Visible = true;
                PointX = ShapePictureBox.Location.X + 23;
                PointY = ShapePictureBox.Location.Y + 243;
                LengthTextBoxes[1].Location = new Point(PointX, PointY);
                LengthTextBoxes[1].Tag = "ly11";
                LengthTextBoxes[1].Visible = true;
            }
            else if (PictureBoxTag == "9")
            {
                //ShapePictureBox.BackgroundImage = Properties.Resources._9_NCM;
                PointX = ShapePictureBox.Location.X + 123;
                PointY = ShapePictureBox.Location.Y + 153;
                LengthTextBoxes[0].Location = new Point(PointX, PointY);
                LengthTextBoxes[0].Tag = "lx1";
                LengthTextBoxes[0].Visible = true;
                PointX = ShapePictureBox.Location.X + 233;
                PointY = ShapePictureBox.Location.Y + 83;
                LengthTextBoxes[1].Location = new Point(PointX, PointY);
                LengthTextBoxes[1].Tag = "lnx1";
                LengthTextBoxes[1].Visible = true;
                PointX = ShapePictureBox.Location.X + 338;
                PointY = ShapePictureBox.Location.Y + 153;
                LengthTextBoxes[2].Location = new Point(PointX, PointY);
                LengthTextBoxes[2].Tag = "lny1";
                LengthTextBoxes[2].Visible = true;
                PointX = ShapePictureBox.Location.X + 378;
                PointY = ShapePictureBox.Location.Y + 353;
                LengthTextBoxes[3].Location = new Point(PointX, PointY);
                LengthTextBoxes[3].Tag = "lx2";
                LengthTextBoxes[3].Visible = true;
                PointX = ShapePictureBox.Location.X + 433;
                PointY = ShapePictureBox.Location.Y + 243;
                LengthTextBoxes[4].Location = new Point(PointX, PointY);
                LengthTextBoxes[4].Tag = "lny2";
                LengthTextBoxes[4].Visible = true;
                PointX = ShapePictureBox.Location.X + 543;
                PointY = ShapePictureBox.Location.Y + 83;
                LengthTextBoxes[5].Location = new Point(PointX, PointY);
                LengthTextBoxes[5].Tag = "lnx2";
                LengthTextBoxes[5].Visible = true;
                PointX = ShapePictureBox.Location.X + 643;
                PointY = ShapePictureBox.Location.Y + 153;
                LengthTextBoxes[6].Location = new Point(PointX, PointY);
                LengthTextBoxes[6].Tag = "lx3";
                LengthTextBoxes[6].Visible = true;
            }
            else if (PictureBoxTag == "10")
            {
                //ShapePictureBox.BackgroundImage = Properties.Resources._10_NCM;
                PointX = ShapePictureBox.Location.X + 233;
                PointY = ShapePictureBox.Location.Y + 353;
                LengthTextBoxes[0].Location = new Point(PointX, PointY);
                LengthTextBoxes[0].Tag = "lnx1";
                LengthTextBoxes[0].Visible = true;
                PointX = ShapePictureBox.Location.X + 543;
                PointY = ShapePictureBox.Location.Y + 353;
                LengthTextBoxes[1].Location = new Point(PointX, PointY);
                LengthTextBoxes[1].Tag = "lnx2";
                LengthTextBoxes[1].Visible = true;
                PointX = ShapePictureBox.Location.X + 433;
                PointY = ShapePictureBox.Location.Y + 243;
                LengthTextBoxes[2].Location = new Point(PointX, PointY);
                LengthTextBoxes[2].Tag = "lny1";
                LengthTextBoxes[2].Visible = true;
            }
            else if (PictureBoxTag == "11")
            {
                //ShapePictureBox.BackgroundImage = Properties.Resources._11_NCM;
                PointX = ShapePictureBox.Location.X + 23;
                PointY = ShapePictureBox.Location.Y + 173;
                LengthTextBoxes[0].Location = new Point(PointX, PointY);
                LengthTextBoxes[0].Tag = "ly1";
                LengthTextBoxes[0].Visible = true;
                PointX = ShapePictureBox.Location.X + 378;
                PointY = ShapePictureBox.Location.Y + 353;
                LengthTextBoxes[1].Location = new Point(PointX, PointY);
                LengthTextBoxes[1].Tag = "lx1";
                LengthTextBoxes[1].Visible = true;
                PointX = ShapePictureBox.Location.X + 733;
                PointY = ShapePictureBox.Location.Y + 173;
                LengthTextBoxes[2].Location = new Point(PointX, PointY);
                LengthTextBoxes[2].Tag = "ly2";
                LengthTextBoxes[2].Visible = true;

            }
            else if (PictureBoxTag == "12")
            {
                //ShapePictureBox.BackgroundImage = Properties.Resources._12_NCM;
                PointX = ShapePictureBox.Location.X + 23;
                PointY = ShapePictureBox.Location.Y + 173;
                LengthTextBoxes[0].Location = new Point(PointX, PointY);
                LengthTextBoxes[0].Tag = "ly1";
                LengthTextBoxes[0].Visible = true;
                PointX = ShapePictureBox.Location.X + 378;
                PointY = ShapePictureBox.Location.Y + 353;
                LengthTextBoxes[1].Location = new Point(PointX, PointY);
                LengthTextBoxes[1].Tag = "lx1";
                LengthTextBoxes[1].Visible = true;
            }
            else if (PictureBoxTag == "13")
            {
                //ShapePictureBox.BackgroundImage = Properties.Resources._13_NCM;
                PointX = ShapePictureBox.Location.X + 23;
                PointY = ShapePictureBox.Location.Y + 173;
                LengthTextBoxes[0].Location = new Point(PointX, PointY);
                LengthTextBoxes[0].Tag = "ly1";
                LengthTextBoxes[0].Visible = true;
                PointX = ShapePictureBox.Location.X + 378;
                PointY = ShapePictureBox.Location.Y + 353;
                LengthTextBoxes[1].Location = new Point(PointX, PointY);
                LengthTextBoxes[1].Tag = "lx1";
                LengthTextBoxes[1].Visible = true;
                PointX = ShapePictureBox.Location.X + 643;
                PointY = ShapePictureBox.Location.Y + 153;
                LengthTextBoxes[2].Location = new Point(PointX, PointY);
                LengthTextBoxes[2].Tag = "lx2";
                LengthTextBoxes[2].Visible = true;
            }
            else if (PictureBoxTag == "14")
            {
                //ShapePictureBox.BackgroundImage = Properties.Resources._14_NCM;
                PointX = ShapePictureBox.Location.X + 183;
                PointY = ShapePictureBox.Location.Y + 83;
                LengthTextBoxes[0].Location = new Point(PointX, PointY);
                LengthTextBoxes[0].Tag = "lx1";
                LengthTextBoxes[0].Visible = true;
                PointX = ShapePictureBox.Location.X + 378;
                PointY = ShapePictureBox.Location.Y + 83;
                LengthTextBoxes[1].Location = new Point(PointX, PointY);
                LengthTextBoxes[1].Tag = "lnx1";
                LengthTextBoxes[1].Visible = true;
                PointX = ShapePictureBox.Location.X + 543;
                PointY = ShapePictureBox.Location.Y + 173;
                LengthTextBoxes[2].Location = new Point(PointX, PointY);
                LengthTextBoxes[2].Tag = "lny1";
                LengthTextBoxes[2].Visible = true;
                PointX = ShapePictureBox.Location.X + 543;
                PointY = ShapePictureBox.Location.Y + 353;
                LengthTextBoxes[3].Location = new Point(PointX, PointY);
                LengthTextBoxes[3].Tag = "lx2";
                LengthTextBoxes[3].Visible = true;
            }
            else if (PictureBoxTag == "15")
            {
                //ShapePictureBox.BackgroundImage = Properties.Resources._15_NCM;
                PointX = ShapePictureBox.Location.X + 233;
                PointY = ShapePictureBox.Location.Y + 83;
                LengthTextBoxes[0].Location = new Point(PointX, PointY);
                LengthTextBoxes[0].Tag = "lx1";
                LengthTextBoxes[0].Visible = true;
                PointX = ShapePictureBox.Location.X + 543;
                PointY = ShapePictureBox.Location.Y + 83;
                LengthTextBoxes[1].Location = new Point(PointX, PointY);
                LengthTextBoxes[1].Tag = "lnx1";
                LengthTextBoxes[1].Visible = true;
                PointX = ShapePictureBox.Location.X + 733;
                PointY = ShapePictureBox.Location.Y + 243;
                LengthTextBoxes[2].Location = new Point(PointX, PointY);
                LengthTextBoxes[2].Tag = "lny1";
                LengthTextBoxes[2].Visible = true;
            }
            else if (PictureBoxTag == "16")
            {
                //ShapePictureBox.BackgroundImage = Properties.Resources._16_NCM;
                PointX = ShapePictureBox.Location.X + 378;
                PointY = ShapePictureBox.Location.Y + 173;
                LengthTextBoxes[0].Location = new Point(PointX, PointY);
                LengthTextBoxes[0].Tag = "dlx1";
                LengthTextBoxes[0].Visible = true;
                PointX = ShapePictureBox.Location.X + 123;
                PointY = ShapePictureBox.Location.Y + 153;
                LengthTextBoxes[1].Location = new Point(PointX, PointY);
                LengthTextBoxes[1].Tag = "lx2";
                LengthTextBoxes[1].Visible = true;
            }
            else if (PictureBoxTag == "17")
            {
                //ShapePictureBox.BackgroundImage = Properties.Resources._17_NCM;
                PointX = ShapePictureBox.Location.X + 143;
                PointY = ShapePictureBox.Location.Y + 173;
                LengthTextBoxes[0].Location = new Point(PointX, PointY);
                LengthTextBoxes[0].Tag = "ly1";
                LengthTextBoxes[0].Visible = true;
                PointX = ShapePictureBox.Location.X + 378;
                PointY = ShapePictureBox.Location.Y + 413;
                LengthTextBoxes[1].Location = new Point(PointX, PointY);
                LengthTextBoxes[1].Tag = "lx1";
                LengthTextBoxes[1].Visible = true;
                PointX = ShapePictureBox.Location.X + 603;
                PointY = ShapePictureBox.Location.Y + 83;
                LengthTextBoxes[2].Location = new Point(PointX, PointY);
                LengthTextBoxes[2].Tag = "lx2";
                LengthTextBoxes[2].Visible = true;
            }
            else if (PictureBoxTag == "18")
            {
                //ShapePictureBox.BackgroundImage = Properties.Resources._18_NCM;
                PointX = ShapePictureBox.Location.X + 378;
                PointY = ShapePictureBox.Location.Y + 83;
                LengthTextBoxes[0].Location = new Point(PointX, PointY);
                LengthTextBoxes[0].Tag = "alx1";
                LengthTextBoxes[0].Visible = true;
                PointX = ShapePictureBox.Location.X + 233;
                PointY = ShapePictureBox.Location.Y + 153;
                LengthTextBoxes[1].Location = new Point(PointX, PointY);
                LengthTextBoxes[1].Tag = "bly1";
                LengthTextBoxes[1].Visible = true;
                PointX = ShapePictureBox.Location.X + 543;
                PointY = ShapePictureBox.Location.Y + 153;
                LengthTextBoxes[2].Location = new Point(PointX, PointY);
                LengthTextBoxes[2].Tag = "lx2";
                LengthTextBoxes[2].Visible = true;
            }
            else if (PictureBoxTag == "19")
            {
                //ShapePictureBox.BackgroundImage = Properties.Resources._19_NCM;
                PointX = ShapePictureBox.Location.X + 23;
                PointY = ShapePictureBox.Location.Y + 173;
                LengthTextBoxes[0].Location = new Point(PointX, PointY);
                LengthTextBoxes[0].Tag = "lny1";
                LengthTextBoxes[0].Visible = true;
                PointX = ShapePictureBox.Location.X + 233;
                PointY = ShapePictureBox.Location.Y + 83;
                LengthTextBoxes[1].Location = new Point(PointX, PointY);
                LengthTextBoxes[1].Tag = "lnx1";
                LengthTextBoxes[1].Visible = true;
                PointX = ShapePictureBox.Location.X + 543;
                PointY = ShapePictureBox.Location.Y + 83;
                LengthTextBoxes[2].Location = new Point(PointX, PointY);
                LengthTextBoxes[2].Tag = "lx1";
                LengthTextBoxes[2].Visible = true;
                PointX = ShapePictureBox.Location.X + 733;
                PointY = ShapePictureBox.Location.Y + 243;
                LengthTextBoxes[3].Location = new Point(PointX, PointY);
                LengthTextBoxes[3].Tag = "ly1";
                LengthTextBoxes[3].Visible = true;
            }
            else if (PictureBoxTag == "20")
            {
                //ShapePictureBox.BackgroundImage = Properties.Resources._20_NCM;
                PointX = ShapePictureBox.Location.X + 233;
                PointY = ShapePictureBox.Location.Y + 353;
                LengthTextBoxes[0].Location = new Point(PointX, PointY);
                LengthTextBoxes[0].Tag = "lx1";
                LengthTextBoxes[0].Visible = true;
                PointX = ShapePictureBox.Location.X + (340);
                PointY = ShapePictureBox.Location.Y + 243;
                LengthTextBoxes[1].Location = new Point(PointX, PointY);
                LengthTextBoxes[1].Tag = "lny1";
                LengthTextBoxes[1].Visible = true;
                PointX = ShapePictureBox.Location.X + 543;
                PointY = ShapePictureBox.Location.Y + 173;
                LengthTextBoxes[2].Location = new Point(PointX, PointY);
                LengthTextBoxes[2].Tag = "lnx1";
                LengthTextBoxes[2].Visible = true;
                PointX = ShapePictureBox.Location.X + 733;
                PointY = ShapePictureBox.Location.Y + 173;
                LengthTextBoxes[3].Location = new Point(PointX, PointY);
                LengthTextBoxes[3].Tag = "ly1";
                LengthTextBoxes[3].Visible = true;
            }
            else if (PictureBoxTag == "21")
            {
                //ShapePictureBox.BackgroundImage = Properties.Resources._21_NCM;
                PointX = ShapePictureBox.Location.X + 23;
                PointY = ShapePictureBox.Location.Y + 243;
                LengthTextBoxes[0].Location = new Point(PointX, PointY);
                LengthTextBoxes[0].Tag = "ly1";
                LengthTextBoxes[0].Visible = true;
                PointX = ShapePictureBox.Location.X + 378;
                PointY = ShapePictureBox.Location.Y + 83;
                LengthTextBoxes[1].Location = new Point(PointX, PointY);
                LengthTextBoxes[1].Tag = "lx1";
                LengthTextBoxes[1].Visible = true;
                PointX = ShapePictureBox.Location.X + 733;
                PointY = ShapePictureBox.Location.Y + 243;
                LengthTextBoxes[2].Location = new Point(PointX, PointY);
                LengthTextBoxes[2].Tag = "ly2";
                LengthTextBoxes[2].Visible = true;
            }
            else if (PictureBoxTag == "22")
            {
                //ShapePictureBox.BackgroundImage = Properties.Resources._22_NCM;
                PointX = ShapePictureBox.Location.X + 233;
                PointY = ShapePictureBox.Location.Y + 83;
                LengthTextBoxes[0].Location = new Point(PointX, PointY);
                LengthTextBoxes[0].Tag = "lx1";
                LengthTextBoxes[0].Visible = true;
                PointX = ShapePictureBox.Location.X + 338;
                PointY = ShapePictureBox.Location.Y + 153;
                LengthTextBoxes[1].Location = new Point(PointX, PointY);
                LengthTextBoxes[1].Tag = "ly1";
                LengthTextBoxes[1].Visible = true;
                PointX = ShapePictureBox.Location.X + 543;
                PointY = ShapePictureBox.Location.Y + 173;
                LengthTextBoxes[2].Location = new Point(PointX, PointY);
                LengthTextBoxes[2].Tag = "lx2";
                LengthTextBoxes[2].Visible = true;
                PointX = ShapePictureBox.Location.X + 733;
                PointY = ShapePictureBox.Location.Y + 243;
                LengthTextBoxes[3].Location = new Point(PointX, PointY);
                LengthTextBoxes[3].Tag = "ly2";
                LengthTextBoxes[3].Visible = true;
            }
        }
        private void InputNumber_Only(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void LentghTextBox_InputNumber_Only(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void LengthTextBox_Change(object sender, EventArgs e)
        {
            double CalTheHypotenuse(int FirstEdge, int SecondEdge)
            {
                double HypotenuseLength;
                HypotenuseLength = Math.Sqrt((FirstEdge * FirstEdge) + (SecondEdge * SecondEdge));
                return HypotenuseLength;
            }
            string ShapePictureBoxTag = (string)ShapePictureBox.Tag;
            int diameter;
            diameter = 0;
            double c45, c90, c135;
            c45 = 0;
            c90 = 0;
            c135 = 0;
            if(DiameterComboBox.Text!="" && int.TryParse(DiameterComboBox.Text, out diameter) == true)
            {
                diameter = int.Parse(DiameterComboBox.Text);
            }
            if (Curling45TextBox.Text != "" && double.TryParse(Curling45TextBox.Text, out c45) == true)
            {
                c45 = double.Parse(Curling45TextBox.Text);
                c45 = c45 * diameter;
            }
            if (Curling90TextBox.Text != "" && double.TryParse(Curling90TextBox.Text, out c90) == true)
            {
                c90 = double.Parse(Curling90TextBox.Text);
                c90 = c90 * diameter;
            }
            if (Curling135TextBox.Text != "" && double.TryParse(Curling135TextBox.Text, out c135) == true)
            {
                c135 = double.Parse(Curling135TextBox.Text);
                c135 = c135 * diameter;
            }

            int lx1, lx2, lx3, ly1, ly2, lnx1, lnx2, lny1, lny2, dlx1, alx1, bly1, hook;
            lx1 = 0;
            lx2 = 0;
            lx3 = 0;
            ly1 = 0;
            ly2 = 0;
            lnx1 = 0;
            lnx2 = 0;
            lny1 = 0;
            lny2 = 0;
            dlx1 = 0;
            alx1 = 0;
            bly1 = 0;
            hook = 0;

            for (int i = 0; i < LengthTextBoxes.Count; i++)
            {
                if ((string)LengthTextBoxes[i].Tag == "lx1" && LengthTextBoxes[i].Text != "")
                {
                    lx1 = int.Parse(LengthTextBoxes[i].Text);
                }
                else if((string)LengthTextBoxes[i].Tag == "lx2" && LengthTextBoxes[i].Text != "")
                {
                    lx2 = int.Parse(LengthTextBoxes[i].Text);
                }
                else if ((string)LengthTextBoxes[i].Tag == "lx3" && LengthTextBoxes[i].Text != "")
                {
                    lx3 = int.Parse(LengthTextBoxes[i].Text);
                }
                else if ((string)LengthTextBoxes[i].Tag == "ly1" && LengthTextBoxes[i].Text != "")
                {
                    ly1 = int.Parse(LengthTextBoxes[i].Text);
                }
                else if ((string)LengthTextBoxes[i].Tag == "ly2" && LengthTextBoxes[i].Text != "")
                {
                    ly2 = int.Parse(LengthTextBoxes[i].Text);
                }
                else if ((string)LengthTextBoxes[i].Tag == "lnx1" && LengthTextBoxes[i].Text != "")
                {
                    lnx1 = int.Parse(LengthTextBoxes[i].Text);
                }
                else if ((string)LengthTextBoxes[i].Tag == "lnx2" && LengthTextBoxes[i].Text != "")
                {
                    lnx2 = int.Parse(LengthTextBoxes[i].Text);
                }
                else if ((string)LengthTextBoxes[i].Tag == "lny1" && LengthTextBoxes[i].Text != "")
                {
                    lny1 = int.Parse(LengthTextBoxes[i].Text);
                }
                else if ((string)LengthTextBoxes[i].Tag == "lny2" && LengthTextBoxes[i].Text != "")
                {
                    lny2 = int.Parse(LengthTextBoxes[i].Text);
                }
                else if ((string)LengthTextBoxes[i].Tag == "dlx1" && LengthTextBoxes[i].Text != "")
                {
                    dlx1 = int.Parse(LengthTextBoxes[i].Text);
                }
                else if ((string)LengthTextBoxes[i].Tag == "alx1" && LengthTextBoxes[i].Text != "")
                {
                    alx1 = int.Parse(LengthTextBoxes[i].Text);
                }
                else if ((string)LengthTextBoxes[i].Tag == "bly1" && LengthTextBoxes[i].Text != "")
                {
                    bly1 = int.Parse(LengthTextBoxes[i].Text);
                }
                else if ((string)LengthTextBoxes[i].Tag == "hook" && LengthTextBoxes[i].Text != "")
                {
                    hook = int.Parse(LengthTextBoxes[i].Text);
                }
            }

            if (ShapePictureBoxTag == "1")
            {
                BarLength = lx1;
            }
            else if (ShapePictureBoxTag == "2")
            {
                BarLength = lx1 + (2 * hook) - (2 * c135);
            }
            else if (ShapePictureBoxTag == "3")
            {
                BarLength = lx1 + (2 * ly1) - (2 * c90);
            }
            else if (ShapePictureBoxTag == "4")
            {
                BarLength = lx1 + lx2 + ly1 + CalTheHypotenuse(lnx1, lny1) + hook - ((2 * c45) + c90 + c135);
            }
            else if (ShapePictureBoxTag == "5")
            {
                BarLength = lx1 + lx2 + ly1 + CalTheHypotenuse(lnx1, lny1) + hook - ((2 * c45) + c90);
            }
            else if (ShapePictureBoxTag == "6")
            {
                BarLength = lx1 + lx2 + ly1 + CalTheHypotenuse(lnx1, lny1) + hook - ((2 * c45) + c90);
            }
            else if (ShapePictureBoxTag == "7")
            {
                BarLength = lx1 + ly1 + ly2 + CalTheHypotenuse(lnx1, lny1) - ((2 * c45) + (2 * c90));
            }
            else if (ShapePictureBoxTag == "8")
            {
                BarLength = lx1 + ly1 - c90;
            }
            else if (ShapePictureBoxTag == "9")
            {
                BarLength = lx1 + lx2 + lx3 + CalTheHypotenuse(lnx1, lny1) + CalTheHypotenuse(lnx2, lny2) - (4 * c45);
            }
            else if (ShapePictureBoxTag == "10")
            {
                BarLength = CalTheHypotenuse(lnx1, lny1) + CalTheHypotenuse(lnx2, lny1) - c45;
            }
            else if (ShapePictureBoxTag == "11")
            {
                BarLength = lx1 + ly1 + ly2 - (2 * c90);
            }
            else if (ShapePictureBoxTag == "12")
            {
                BarLength = lx1 + ly1 - c90;
            }
            else if (ShapePictureBoxTag == "13")
            {
                BarLength = (2 * lx1) + (2 * ly1) + (2 * lx2) - (5 * c90);
            }
            else if (ShapePictureBoxTag == "14")
            {
                BarLength = lx1 + lx2 + CalTheHypotenuse(lnx1, lny1) - (2 * c45);
            }
            else if (ShapePictureBoxTag == "15")
            {
                BarLength = lx1 + CalTheHypotenuse(lnx1, lny1) - c45;
            }
            else if (ShapePictureBoxTag == "16")
            {
                BarLength = (Math.PI * dlx1) + (2 * lx2);
            }
            else if (ShapePictureBoxTag == "17")
            {
                BarLength = (4 * lx1) + (4 * ly1) + (2 * lx2) - (9 * c90);
            }
            else if (ShapePictureBoxTag == "18")
            {
                BarLength = (2 * alx1) + (4 * bly1) + (2 * lx2) - (7 * c90);
            }
            else if (ShapePictureBoxTag == "19")
            {
                BarLength = lx1 + ly1 + CalTheHypotenuse(lnx1, lny1) - (c45 + c90);
            }
            else if (ShapePictureBoxTag == "20")
            {
                BarLength = lx1 + ly1 + CalTheHypotenuse(lnx1, lny1) - (2 * c45);
            }
            else if (ShapePictureBoxTag == "21")
            {
                BarLength = lx1 + ly1 + ly2 - (2 * c90);
            }
            else if (ShapePictureBoxTag == "22")
            {
                BarLength = lx1 + lx2 + ly1 + ly2 - (3 * c90);
            }
            BarLengthLabel.Text = "Kích thước (mm): " + BarLength;
        }
        private void InsertTextPictureBox()
        {
            string PicturePath = "B:/Software Data/VisualStudio/SOSC_Software/Stactistics And Optimization Of Steel Cutting (Without .Net Framework)/Resources/" + ShapePictureBox.Tag + "_NCM.jpg";
            using (Image DrawedImage = Image.FromFile(PicturePath))
            {
                using (Graphics graphics = Graphics.FromImage(DrawedImage))
                {
                    using (Font arialFont = new Font("Time New Roman", 40))
                    {
                        for (int i = 0; i < LengthTextBoxes.Count; i++)
                        {
                            if (LengthTextBoxes[i].Visible == true)
                            {
                                float PX, PY;
                                int px, py;
                                PX = LengthTextBoxes[i].Location.X - ShapePictureBox.Location.X;
                                PY = LengthTextBoxes[i].Location.Y - ShapePictureBox.Location.Y;

                                PX = (PX * 100) / ShapePictureBox.Size.Width;
                                PY = (PY * 100) / ShapePictureBox.Size.Height;

                                PX = PX * (DrawedImage.Size.Width / 100);
                                PY = PY * (DrawedImage.Size.Height / 100);

                                px = (int)PX;
                                py = (int)PY;
                                Point TextBoxPoint = new Point(px, py);
                                graphics.DrawString(LengthTextBoxes[i].Text, arialFont, Brushes.Blue, TextBoxPoint);
                            }
                        }
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            DrawedImage.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                            ImageBytes = memoryStream.ToArray();
                        }
                    }
                }
            }
        }
        private void AcceptButton_Click(object sender, EventArgs e)
        {
            bool LengthTextBoxesFilled = true;
            for (int i = 0; i < LengthTextBoxes.Count; i++)
            {
                if(LengthTextBoxes[i].Visible==true)
                {
                    if(LengthTextBoxes[i].Text=="")
                    {
                        LengthTextBoxesFilled = false;
                    }
                    else
                    {
                        if(int.Parse(LengthTextBoxes[i].Text)==0)
                        {
                            LengthTextBoxesFilled = false;
                        }
                    }
                }
            }
            if (BatchingTextBox.Text == "")
            {
                MessageBox.Show("Hãy nhập phân đợt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (ComponentNameTextBox.Text == "")
            {
                MessageBox.Show("Hãy nhập tên cấu kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (ComponentNameTextBox.Text == "")
            {
                MessageBox.Show("Hãy nhập tên cấu kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (ComponentSignTextBox.Text == "")
            {
                MessageBox.Show("Hãy nhập kí hiệu cấu kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (NumberOfComponentTextBox.Text == "")
            {
                MessageBox.Show("Hãy nhập số lượng cấu kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Curling45TextBox.Text == "")
            {
                MessageBox.Show("Hãy nhập độ giãn uốn 45°", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Curling90TextBox.Text == "")
            {
                MessageBox.Show("Hãy nhập độ giãn uốn 45°", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Curling135TextBox.Text == "")
            {
                MessageBox.Show("Hãy nhập độ giãn uốn 135° - 180°", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (BarPerComponentTextBox.Text == "")
            {
                MessageBox.Show("Hãy nhập số thanh / cấu kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (DiameterComboBox.Text == "")
            {
                MessageBox.Show("Hãy chọn đường kính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (LengthTextBoxesFilled == false)
            {
                MessageBox.Show("Hãy nhập đầy đủ kích thước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(BarLength>11700)
            {
                MessageBox.Show("Chiều dài quá 11.7m", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
            else
            {
                if (MODE == 1)
                {
                    SQLNew();
                }
                else if(MODE==2||MODE==3)
                {
                    SQLInsert();
                }
                else if(MODE==4)
                {
                    SQLEdit();
                }
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        private void SQLNew()
        {
            InsertTextPictureBox();
            using (SqlConnection sqlConnection = new SqlConnection(Main_Interface_Form.Globals.connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("", sqlConnection))
                {

                    int TotalBar = int.Parse(NumberOfComponentTextBox.Text) * int.Parse(BarPerComponentTextBox.Text);
                    double Diameter = double.Parse(DiameterComboBox.Text) / 1000;
                    double TotalLength = (BarLength * TotalBar)/1000;
                    double TotalWeigh = 7850 * TotalLength * Math.PI * Diameter * Diameter;
                    TotalWeigh = TotalWeigh / 4;
                    Main_Interface_Form.Globals.IDForAll++;
                    sqlCommand.CommandText = "INSERT INTO Statictiscal_Table (ID, Batching, ComponentName, ComponentSign, SteelSign, Shape, Diameter, NumberOfComponent, BarPerComponent, TotalBar, LengthPerBar, TotalLength, TotalWeigh, Curling45, Curling90, Curling135, ShapeTag)" +
                                                                    "VALUES (@iD,@batching,@componentName,@componentSign,@steelSign,@shape,@diameter,@numberOfComponent,@barPerComponent,@totalBar,@lengthPerBar,@totalLength,@totalWeigh,@curling45,@curling90,@curling135,@shapeTag);";
                    sqlCommand.Parameters.AddWithValue("@iD", Main_Interface_Form.Globals.IDForAll);
                    sqlCommand.Parameters.AddWithValue("@batching", BatchingTextBox.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@componentName", ComponentNameTextBox.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@componentSign", ComponentSignTextBox.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@steelSign", SteelSignTextBox.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@shape", ImageBytes);
                    sqlCommand.Parameters.AddWithValue("@diameter", DiameterComboBox.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@numberOfComponent", NumberOfComponentTextBox.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@barPerComponent", BarPerComponentTextBox.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@totalBar", TotalBar);
                    sqlCommand.Parameters.AddWithValue("@lengthPerBar", BarLength);
                    sqlCommand.Parameters.AddWithValue("@totalLength", TotalLength);
                    sqlCommand.Parameters.AddWithValue("@totalWeigh", TotalWeigh);
                    sqlCommand.Parameters.AddWithValue("@curling45", Curling45TextBox.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@curling90", Curling90TextBox.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@curling135", Curling135TextBox.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@shapeTag", (string)ShapePictureBox.Tag);
                    sqlCommand.CommandType = CommandType.Text;
                    int SQLExecuteNonQuertyDone=sqlCommand.ExecuteNonQuery();
                    if(SQLExecuteNonQuertyDone==0)
                    {
                        MessageBox.Show("Lỗi khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Đã lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                sqlConnection.Close();
            }
        }
        private void SQLInsert()
        {
            InsertTextPictureBox();
            using (SqlConnection sqlConnection = new SqlConnection(Main_Interface_Form.Globals.connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("", sqlConnection))
                {
                    string Condition = "";
                    if (MODE == 2)
                    {
                        Condition = ">=" + ROW;
                        id = ROW;
                        ROW++;
                    }
                    else if (MODE == 3)
                    {
                        ROW++;
                        Condition = ">" + ROW;
                        id=ROW+1;
                    }
                    sqlCommand.CommandText = "UPDATE Statictiscal_Table SET ID = ID + 1 WHERE ID " + Condition;
                    sqlCommand.ExecuteNonQuery();


                    int TotalBar = int.Parse(NumberOfComponentTextBox.Text) * int.Parse(BarPerComponentTextBox.Text);
                    double Diameter = double.Parse(DiameterComboBox.Text) / 1000;
                    double TotalLength = (BarLength * TotalBar) / 1000;
                    double TotalWeigh = 7850 * TotalLength * Math.PI * Diameter * Diameter;
                    TotalWeigh = TotalWeigh / 4;
                    sqlCommand.CommandText = "INSERT INTO Statictiscal_Table (ID, Batching, ComponentName, ComponentSign, SteelSign, Shape, Diameter, NumberOfComponent, BarPerComponent, TotalBar, LengthPerBar, TotalLength, TotalWeigh, Curling45, Curling90, Curling135, ShapeTag)" +
                                                                    "VALUES (@iD,@batching,@componentName,@componentSign,@steelSign,@shape,@diameter,@numberOfComponent,@barPerComponent,@totalBar,@lengthPerBar,@totalLength,@totalWeigh,@curling45,@curling90,@curling135,@shapeTag);";
                    sqlCommand.Parameters.AddWithValue("@iD", id);
                    sqlCommand.Parameters.AddWithValue("@batching", BatchingTextBox.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@componentName", ComponentNameTextBox.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@componentSign", ComponentSignTextBox.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@steelSign", SteelSignTextBox.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@shape", ImageBytes);
                    sqlCommand.Parameters.AddWithValue("@diameter", DiameterComboBox.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@numberOfComponent", NumberOfComponentTextBox.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@barPerComponent", BarPerComponentTextBox.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@totalBar", TotalBar);
                    sqlCommand.Parameters.AddWithValue("@lengthPerBar", BarLength);
                    sqlCommand.Parameters.AddWithValue("@totalLength", TotalLength);
                    sqlCommand.Parameters.AddWithValue("@totalWeigh", TotalWeigh);
                    sqlCommand.Parameters.AddWithValue("@curling45", Curling45TextBox.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@curling90", Curling90TextBox.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@curling135", Curling135TextBox.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@shapeTag", (string)ShapePictureBox.Tag);
                    sqlCommand.CommandType = CommandType.Text;
                    int SQLExecuteNonQuertyDone = sqlCommand.ExecuteNonQuery();
                    if (SQLExecuteNonQuertyDone == 0)
                    {
                        MessageBox.Show("Lỗi khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Đã lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                sqlConnection.Close();
            }
        }
        private void SQLEdit()
        {
            InsertTextPictureBox();
            using (SqlConnection sqlConnection = new SqlConnection(Main_Interface_Form.Globals.connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("", sqlConnection))
                {

                    int TotalBar = int.Parse(NumberOfComponentTextBox.Text) * int.Parse(BarPerComponentTextBox.Text);
                    double Diameter = double.Parse(DiameterComboBox.Text) / 1000;
                    double TotalLength = (BarLength * TotalBar) / 1000;
                    double TotalWeigh = 7850 * TotalLength * Math.PI * Diameter * Diameter;
                    TotalWeigh = TotalWeigh / 4;
                    sqlCommand.CommandText = "UPDATE Statictiscal_Table SET Batching=@batching, ComponentName=@componentName, ComponentSign=@componentSign, SteelSign=@steelSign, Shape=@shape, Diameter=@diameter, NumberOfComponent=@numberOfComponent, BarPerComponent=@barPerComponent, TotalBar=@totalBar, LengthPerBar=@lengthPerBar, TotalLength=@totalLength, TotalWeigh=@totalWeigh, Curling45=@curling45, Curling90=@curling90, Curling135=@curling135, ShapeTag=@shapeTag WHERE ID=@id";
                    sqlCommand.Parameters.AddWithValue("@batching", BatchingTextBox.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@componentName", ComponentNameTextBox.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@componentSign", ComponentSignTextBox.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@steelSign", SteelSignTextBox.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@shape", ImageBytes);
                    sqlCommand.Parameters.AddWithValue("@diameter", DiameterComboBox.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@numberOfComponent", NumberOfComponentTextBox.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@barPerComponent", BarPerComponentTextBox.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@totalBar", TotalBar);
                    sqlCommand.Parameters.AddWithValue("@lengthPerBar", BarLength);
                    sqlCommand.Parameters.AddWithValue("@totalLength", TotalLength);
                    sqlCommand.Parameters.AddWithValue("@totalWeigh", TotalWeigh);
                    sqlCommand.Parameters.AddWithValue("@curling45", Curling45TextBox.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@curling90", Curling90TextBox.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@curling135", Curling135TextBox.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@shapeTag", (string)ShapePictureBox.Tag);
                    sqlCommand.Parameters.AddWithValue("@id", ROW);
                    sqlCommand.CommandType = CommandType.Text;
                    int SQLExecuteNonQuertyDone = sqlCommand.ExecuteNonQuery();
                    if (SQLExecuteNonQuertyDone == 0)
                    {
                        MessageBox.Show("Lỗi khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Đã lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                }
                sqlConnection.Close();
            }
        }
        private void Steel_Edition_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
