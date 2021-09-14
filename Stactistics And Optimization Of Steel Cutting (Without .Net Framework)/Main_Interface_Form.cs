using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing.Imaging;

namespace Stactistics_And_Optimization_Of_Steel_Cutting__Without_.Net_Framework_
{
    public partial class Main_Interface_Form : Form
    {
        int h;
        public static class Globals
        {
            public static int IDForAll;
            public const string connectionString = "Data Source=DESKTOP-4P0S6LP;Initial Catalog=SOSC_Database;Integrated Security=True";
            public static string StactisticCommand = "";
            public static string TabName = "";
        }
        public Main_Interface_Form()
        {
            InitializeComponent();

            h= MainDataGridView.HorizontalScrollingOffset;
            using (SqlConnection sqlConnection = new SqlConnection(Globals.connectionString))
            {
                sqlConnection.Open();
                using(SqlCommand sqlCommand=new SqlCommand("",sqlConnection))
                {
                    sqlCommand.CommandText = "SELECT COUNT(*) FROM Statictiscal_Table;";
                    sqlCommand.CommandType = CommandType.Text;
                    int RowCount = (int)sqlCommand.ExecuteScalar();
                    if (RowCount != 0)
                    {
                        sqlCommand.CommandText = "SELECT DISTINCT ID FROM Statictiscal_Table WHERE ID=(SELECT max(id) FROM Statictiscal_Table);";
                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {

                            while (sqlDataReader.Read())
                            {
                                Globals.IDForAll = int.Parse(sqlDataReader["ID"].ToString());
                            }
                        }
                    }
                    else
                    {
                        Globals.IDForAll = 1;
                    }
                }
                sqlConnection.Close();
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        private void SteelEdition_click(object sender, EventArgs e)
        {
            int SelectedID;
            if (MainDataGridView.Rows.Count > 0)
            {
                SelectedID = MainDataGridView.CurrentCell.RowIndex;
            }
            else
            {
                SelectedID = 0;
            }
            string SteelEditionTag = (string)(sender as ToolStripItem).Tag;
            using (Steel_Edition_Form steel_Edition_Form = new Steel_Edition_Form(int.Parse(SteelEditionTag), SelectedID))
            {
                steel_Edition_Form.ShowDialog();
            }
            Main_DataGridViewUpdate();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }


        private void Test1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void Test2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main_DataGridViewUpdate();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        private void Main_DataGridViewUpdate()
        {
            using (SqlConnection sqlConnection = new SqlConnection(Globals.connectionString))
            {
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT ID,Batching,ComponentName,ComponentSign,SteelSign,Shape,Diameter,NumberOfComponent,BarPerComponent,TotalBar,LengthPerBar,TotalLength,TotalWeigh FROM Statictiscal_Table ORDER BY ID;", sqlConnection))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sqlDataAdapter.Fill(dt);
                        MainDataGridView.DataSource = dt;
                    }
                }
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            using (SqlConnection sqlConnection = new SqlConnection(Globals.connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("", sqlConnection))
                {
                    sqlCommand.CommandText = "SELECT COUNT(*) FROM Statictiscal_Table;";
                    sqlCommand.CommandType = CommandType.Text;
                    int RowCount = (int)sqlCommand.ExecuteScalar();
                    if (RowCount != 0)
                    {
                        sqlCommand.CommandText = "SELECT DISTINCT ID FROM Statictiscal_Table WHERE ID=(SELECT max(id) FROM Statictiscal_Table);";
                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {

                            while (sqlDataReader.Read())
                            {
                                Globals.IDForAll = int.Parse(sqlDataReader["ID"].ToString());
                            }
                        }
                    }
                    else
                    {
                        Globals.IDForAll = 1;
                    }
                }
                sqlConnection.Close();
            }
            MainDataGridView.FirstDisplayedScrollingRowIndex = h;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        private void AnotherScroll(object sender,ScrollEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        private void MainDataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            h = MainDataGridView.FirstDisplayedScrollingRowIndex;
            TestLabel.Text = "" + h;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void SyntheticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.TabName = "";
            using (Statistical_From statistical_From=new Statistical_From())
            {
                statistical_From.ShowDialog();
                if(statistical_From.DialogResult==DialogResult.OK)
                {
                    CreateTab();
                }    
            }
            Main_DataGridViewUpdate();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void Main_Interface_Form_Resize(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void EditToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            if(MainDataGridView.Rows.Count==0)
            {
                EditToolStripMenuItem.DropDownItems[1].Enabled = false;
                EditToolStripMenuItem.DropDownItems[2].Enabled = false;
                EditToolStripMenuItem.DropDownItems[3].Enabled = false;

                DataGridViewRigthClick.Items[1].Enabled = false;
                DataGridViewRigthClick.Items[2].Enabled = false;
                DataGridViewRigthClick.Items[3].Enabled = false;
            }
            else
            {
                EditToolStripMenuItem.DropDownItems[1].Enabled = true;
                EditToolStripMenuItem.DropDownItems[2].Enabled = true;
                EditToolStripMenuItem.DropDownItems[3].Enabled = true;

                DataGridViewRigthClick.Items[1].Enabled = true;
                DataGridViewRigthClick.Items[2].Enabled = true;
                DataGridViewRigthClick.Items[3].Enabled = true;
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void RemoveSteelToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int RowIndex = MainDataGridView.CurrentCell.RowIndex;
            RowIndex++;
            using (SqlConnection sqlConnection=new SqlConnection(Globals.connectionString))
            {
                sqlConnection.Open();
                using(SqlCommand sqlCommand =new SqlCommand("",sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = "DELETE FROM Statictiscal_Table WHERE ID = " + RowIndex;
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText = "UPDATE Statictiscal_Table SET ID = ID - 1 WHERE ID > " + RowIndex;
                    sqlCommand.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
            Main_DataGridViewUpdate();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void MainDataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int rowIndex = MainDataGridView.HitTest(e.X, e.Y).RowIndex;

                // If there was no DataGridViewRow under the cursor, return
                if (rowIndex == -1) { return; }
                MainDataGridView.ClearSelection();
                MainDataGridView.Rows[rowIndex].Selected = true;
                DataGridViewRigthClick.Show(MainDataGridView, new Point(e.X, e.Y));
            }
        }
        private void CreateTab()
        {
            DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn column5 = new DataGridViewTextBoxColumn();
            DataGridViewImageColumn column6 = new DataGridViewImageColumn();
            DataGridViewTextBoxColumn column7 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn column8 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn column9 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn column10 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn column11 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn column12 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn column13 = new DataGridViewTextBoxColumn();

            column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            column1.Name = "ID";
            column1.HeaderText = "STT";
            column1.MinimumWidth = 100;
            column1.ReadOnly = true;
            column1.Width = 121;
            // 
            // Column2
            // 
            column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            column2.DataPropertyName = "Batching";
            column2.HeaderText = "Phân đợt";
            column2.MinimumWidth = 150;
            column2.ReadOnly = true;
            column2.Width = 178;
            // 
            // Column3
            // 
            column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            column3.DataPropertyName = "ComponentName";
            column3.HeaderText = "Tên cấu kiện";
            column3.MinimumWidth = 12;
            column3.ReadOnly = true;
            column3.Width = 216;
            // 
            // Column4
            // 
            column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            column4.DataPropertyName = "ComponentSign";
            column4.HeaderText = "Kí hiệu cấu kiện";
            column4.MinimumWidth = 150;
            column4.ReadOnly = true;
            column4.Width = 206;
            // 
            // Column5
            // 
            column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            column5.DataPropertyName = "SteelSign";
            column5.HeaderText = "Số hiệu thép";
            column5.MinimumWidth = 150;
            column5.ReadOnly = true;
            column5.Width = 221;
            // 
            // Column6
            // 
            column6.DataPropertyName = "Shape";
            column6.HeaderText = "Kích thước";
            column6.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            column6.MinimumWidth = 670;
            column6.ReadOnly = true;
            column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            column6.Width = 670;
            // 
            // Column7
            // 
            column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            column7.DataPropertyName = "Diameter";
            column7.HeaderText = "Đường kính";
            column7.MinimumWidth = 150;
            column7.ReadOnly = true;
            column7.Width = 210;
            // 
            // Column8
            // 
            column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            column8.DataPropertyName = "NumberOfComponent";
            column8.HeaderText = "Số lượng cấu kiện";
            column8.MinimumWidth = 200;
            column8.ReadOnly = true;
            column8.Width = 234;
            // 
            // Column9
            // 
            column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            column9.DataPropertyName = "BarPerComponent";
            column9.HeaderText = "Số thanh / Cấu kiện";
            column9.MinimumWidth = 200;
            column9.ReadOnly = true;
            column9.Width = 254;
            // 
            // Column10
            // 
            column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            column10.DataPropertyName = "TotalBar";
            column10.HeaderText = "Tổng số thanh";
            column10.MinimumWidth = 200;
            column10.ReadOnly = true;
            column10.Width = 243;
            // 
            // Column11
            // 
            column11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            column11.DataPropertyName = "LengthPerBar";
            column11.HeaderText = "Chiều dài / Thanh";
            column11.MinimumWidth = 200;
            column11.ReadOnly = true;
            column11.Width = 207;
            // 
            // Column12
            // 
            column12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            column12.DataPropertyName = "TotalLength";
            column12.HeaderText = "Tổng chiều dài";
            column12.MinimumWidth = 200;
            column12.ReadOnly = true;
            // 
            // TotalWeigh
            // 
            column13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            column13.DataPropertyName = "TotalWeigh";
            column13.HeaderText = "Tổng khối lượng";
            column13.MinimumWidth = 200;
            column13.ReadOnly = true;
            column13.Width = 268;

            DataGridView dataGridView = new DataGridView();

            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridView.ColumnHeadersHeight = 100;
            dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            column1,
            column2,
            column3,
            column4,
            column5,
            column6,
            column7,
            column8,
            column9,
            column10,
            column11,
            column12,
            column13});
            dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.Location = new System.Drawing.Point(3, 3);
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 200;
            dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView.RowTemplate.Height = 400;
            dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new System.Drawing.Size(2220, 1152);
            dataGridView.Scroll += new System.Windows.Forms.ScrollEventHandler(AnotherScroll);
            dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(MainDataGridView_CellClick);
            dataGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(DataGridViewRowPostPaintEvent);

            using (SqlConnection sqlConnection = new SqlConnection(Globals.connectionString))
            {
                sqlConnection.Open();
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT Batching,ComponentName,ComponentSign,SteelSign,Shape,Diameter,NumberOfComponent,BarPerComponent,TotalBar,LengthPerBar,TotalLength,TotalWeigh FROM Statictiscal_Table WHERE "+ Globals.StactisticCommand +" ORDER BY ID;", sqlConnection))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sqlDataAdapter.Fill(dt);
                        dataGridView.DataSource = dt;
                    }
                }
                sqlConnection.Close();
            }

            if(Globals.TabName=="")
            {
                Globals.TabName = "Bảng";
            }

            TabPage tabPage = new TabPage(Globals.TabName);
            tabPage.Controls.Add(dataGridView);

            MainTabControl.Controls.Add(tabPage);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void MainTabControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TabControlRightClick.Show(MainTabControl, new Point(e.X, e.Y));
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        private void DeleteTabPage(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex != 0)
            {
                foreach (Control item in MainTabControl.SelectedTab.Controls)
                {
                    item.Dispose();
                }
                MainTabControl.SelectedTab.Dispose();
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void MainDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        private void DataGridViewRowPostPaintEvent(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            (sender as DataGridView).Rows[e.RowIndex].Cells["ID"].Value = (e.RowIndex + 1).ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.Sheets["Sheet1"];
            worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = "Exported from gridview";
            // storing header part in Excel  
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < MainDataGridView.Rows.Count - 1; i++)
            {
                for (int j = 0; j < MainDataGridView.Columns.Count; j++)
                {
                    if (MainDataGridView.Rows[i].Cells[j].Value.GetType() == typeof(byte[]))
                    {
                        Image image1 = byteArrayToImage((byte[])MainDataGridView.Rows[i].Cells[j].Value);
                        image1.Save(@"B:\test.PNG");
                        Microsoft.Office.Interop.Excel.Range oRange = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[i + 1, j + 1];
                        float Left = (float)((double)oRange.Left);
                        float Top = (float)((double)oRange.Top);
                        worksheet.Shapes.AddPicture(@"B:\test.PNG", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, 170,95);
                        oRange.RowHeight = 95;
                        File.Delete(@"B:\test.PNG");
                    }
                    else
                    {
                        worksheet.Cells[i + 1, j + 1] = MainDataGridView.Rows[i].Cells[j].Value.ToString();
                    }

                }
            }
            workbook.SaveAs("B:\\output.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

        }


        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }



    }
}
