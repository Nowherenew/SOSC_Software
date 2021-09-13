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

namespace Stactistics_And_Optimization_Of_Steel_Cutting__Without_.Net_Framework_
{
    public partial class Main_Interface_Form : Form
    {
        int h;
        public static class Globals
        {
            public static int IDForAll;
            public static string connectionString = "Data Source=DESKTOP-4P0S6LP;Initial Catalog=SOSC_Database;Integrated Security=True";
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
            int SelectedID = MainDataGridView.CurrentCell.RowIndex;
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

        private void MainDataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            h = MainDataGridView.FirstDisplayedScrollingRowIndex;
            TestLabel.Text = "" + h;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void SyntheticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(Statistical_From statistical_From=new Statistical_From())
            {
                statistical_From.ShowDialog();
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
    }
}
