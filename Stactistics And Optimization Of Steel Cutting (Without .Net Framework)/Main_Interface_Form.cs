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
        string connectionString = "Data Source=DESKTOP-4P0S6LP;Initial Catalog=SOSC_Database;Integrated Security=True";
        public static class Globals
        {
            public static int IDForAll;
        }
        public Main_Interface_Form()
        {
            InitializeComponent();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
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
            TestLabel.Text = "" + Globals.IDForAll;
        }
        private void SteelEdition_click(object sender, EventArgs e)
        {
            string SteelEditionTag = (string)(sender as ToolStripItem).Tag;
            if (SteelEditionTag == "1")
            {
                using (Steel_Edition_Form steel_Edition_Form = new Steel_Edition_Form())
                {
                    steel_Edition_Form.ShowDialog();
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private void Test1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void Test2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Statictiscal_Table ORDER BY ID", sqlConnection))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sqlDataAdapter.Fill(dt);
                        MainDataGridView.DataSource = dt;
                    }
                }
            }
        }
    }
}
