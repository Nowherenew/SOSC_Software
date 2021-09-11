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
        int ID;
        public Main_Interface_Form()
        {
            InitializeComponent();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using(SqlCommand sqlCommand=new SqlCommand("",sqlConnection))
                {
                    sqlCommand.CommandText = "SELECT MAX(ID) FROM Statictiscal_Table;";
                    //sqlCommand.CommandType = CommandType.Text;
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {

                        if (sqlDataReader.HasRows)
                        {
                            while (sqlDataReader.Read())
                            {
                                ID = int.Parse(sqlDataReader["ID"].ToString());
                            }
                        }
                        else
                        {
                            ID = 1;
                        }
                    }
                }
                sqlConnection.Close();
            }
        }
        private void SteelEdition_click(object sender, EventArgs e)
        {
            string SteelEditionTag = (string)(sender as ToolStripItem).Tag;
            if (SteelEditionTag == "1")
            {
                using (Steel_Edition_Form steel_Edition_Form = new Steel_Edition_Form())
                {
                    steel_Edition_Form.ShowDialog();
                    steel_Edition_Form.Dispose();
                }
                GC.Collect();
            }
        }

        private void Test1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
