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
using System.Drawing.Imaging;

namespace Statistics_And_Optimization_Of_Steel_Cutting
{
    public partial class Main_Interface_Form : Form
    {
        int h;
        public static class Globals
        {
            public static int IDForAll;
            public static string StactisticCommand = "";
            public static string TabName = "";
        }
        public Main_Interface_Form()
        {
            InitializeComponent();

            h = MainDataGridView.HorizontalScrollingOffset;
            using (SqlConnection sqlConnection = new SqlConnection(Properties.Resources.SQLConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("", sqlConnection))
                {
                    sqlCommand.CommandText = "SELECT COUNT(*) FROM Statistical_Table;";
                    sqlCommand.CommandType = CommandType.Text;
                    int RowCount = (int)sqlCommand.ExecuteScalar();
                    if (RowCount != 0)
                    {
                        sqlCommand.CommandText = "SELECT DISTINCT ID FROM Statistical_Table WHERE ID=(SELECT max(id) FROM Statistical_Table);";
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
            using (Steel_Editor_Form Steel_Editor_Form = new Steel_Editor_Form(int.Parse(SteelEditionTag), SelectedID))
            {
                //Steel_Editor_Form.Size = new Size(900, 408);
                Steel_Editor_Form.ShowDialog();
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
            using (SqlConnection sqlConnection = new SqlConnection(Properties.Resources.SQLConnectionString))
            {
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT ID,Batching,ComponentName,ComponentSign,SteelSign,Shape,Diameter,NumberOfComponent,BarPerComponent,TotalBar,LengthPerBar,TotalLength,TotalWeigh FROM Statistical_Table ORDER BY ID;", sqlConnection))
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
            using (SqlConnection sqlConnection = new SqlConnection(Properties.Resources.SQLConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("", sqlConnection))
                {
                    sqlCommand.CommandText = "SELECT COUNT(*) FROM Statistical_Table;";
                    sqlCommand.CommandType = CommandType.Text;
                    int RowCount = (int)sqlCommand.ExecuteScalar();
                    if (RowCount != 0)
                    {
                        sqlCommand.CommandText = "SELECT DISTINCT ID FROM Statistical_Table WHERE ID=(SELECT max(id) FROM Statistical_Table);";
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
            if (MainDataGridView.Rows.Count > 0)
            {
                MainDataGridView.FirstDisplayedScrollingRowIndex = h;
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        private void AnotherScroll(object sender, ScrollEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        private void MainDataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            h = MainDataGridView.FirstDisplayedScrollingRowIndex;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void SyntheticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.TabName = "";
            using (Statistical_Form statistical_Form = new Statistical_Form())
            {
                statistical_Form.ShowDialog();
                if (statistical_Form.DialogResult == DialogResult.OK)
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
            if (MainDataGridView.Rows.Count == 0)
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
            using (SqlConnection sqlConnection = new SqlConnection(Properties.Resources.SQLConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = "DELETE FROM Statistical_Table WHERE ID = " + RowIndex;
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText = "UPDATE Statistical_Table SET ID = ID - 1 WHERE ID > " + RowIndex;
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

            using (SqlConnection sqlConnection = new SqlConnection(Properties.Resources.SQLConnectionString))
            {
                sqlConnection.Open();
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT Batching,ComponentName,ComponentSign,SteelSign,Shape,Diameter,NumberOfComponent,BarPerComponent,TotalBar,LengthPerBar,TotalLength,TotalWeigh FROM Statistical_Table WHERE " + Globals.StactisticCommand + " ORDER BY ID;", sqlConnection))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sqlDataAdapter.Fill(dt);
                        dataGridView.DataSource = dt;
                    }
                }
                sqlConnection.Close();
            }

            if (Globals.TabName == "")
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
        private void SheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ExcelPath = "";
            string ExcelFileName = "";
            ExcelSaveFileDialog.Filter = "Excel files | *.xlsx";
            if (ExcelSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExcelFileName = ExcelSaveFileDialog.FileName;
                ExcelPath = Path.GetFullPath(ExcelSaveFileDialog.FileName);
            }

            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            excel.Visible = true;
            worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.Sheets["Sheet1"];
            worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.ActiveSheet;
            worksheet.Name = MainTabControl.SelectedTab.Text;

            worksheet.Cells[1, 1] = MainTabControl.SelectedTab.Text;

            worksheet.Cells[2, 1] = "STT";
            worksheet.Cells[2, 2] = "Phân đợt";
            worksheet.Cells[2, 3] = "Tên cấu kiện";
            worksheet.Cells[2, 4] = "Kí hiệu cấu kiện";
            worksheet.Cells[2, 5] = "Số hiệu thép";
            worksheet.Cells[2, 6] = "Kích thước";
            worksheet.Cells[2, 7] = "Đường kính";
            worksheet.Cells[2, 8] = "Số lượng cấu kiện";
            worksheet.Cells[2, 9] = "Số thanh / Cấu kiện";
            worksheet.Cells[2, 10] = "Tổng số thanh";
            worksheet.Cells[2, 11] = "Chiều dài một thanh";
            worksheet.Cells[2, 12] = "Tổng chiều dài";
            worksheet.Cells[2, 13] = "Tổng khối lượng";
            worksheet.Columns[1].ColumnWidth = 5;
            worksheet.Columns[2].ColumnWidth = 10;
            worksheet.Columns[3].ColumnWidth = 10;
            worksheet.Columns[4].ColumnWidth = 10;
            worksheet.Columns[5].ColumnWidth = 10;
            worksheet.Columns[6].ColumnWidth = 35;
            worksheet.Columns[7].ColumnWidth = 15;
            worksheet.Columns[8].ColumnWidth = 15;
            worksheet.Columns[9].ColumnWidth = 15;
            worksheet.Columns[10].ColumnWidth = 15;
            worksheet.Columns[11].ColumnWidth = 15;
            worksheet.Columns[12].ColumnWidth = 15;
            worksheet.Columns[13].ColumnWidth = 15;

            foreach (DataGridView dataGridView in MainTabControl.SelectedTab.Controls)
            {

                for (int i = 2; i < (dataGridView.Rows.Count + 2); i++)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        if (dataGridView.Rows[i - 2].Cells[j].Value.GetType() == typeof(byte[]))
                        {
                            Image image1 = byteArrayToImage((byte[])dataGridView.Rows[i - 2].Cells[j].Value);
                            image1.Save(@"B:\test.PNG");
                            Microsoft.Office.Interop.Excel.Range oRange = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[i + 1, j + 1];
                            float Left = (float)((double)oRange.Left);
                            float Top = (float)((double)oRange.Top);
                            worksheet.Shapes.AddPicture(@"B:\test.PNG", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, 170, 95);
                            oRange.RowHeight = 95;
                            File.Delete(@"B:\test.PNG");

                        }
                        else
                        {
                            worksheet.Cells[i + 1, j + 1] = dataGridView.Rows[i - 2].Cells[j].Value.ToString();
                        }
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                    }
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }

            workbook.SaveAs(ExcelPath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            GC.Collect();
            GC.WaitForPendingFinalizers();

        }
    }
}
