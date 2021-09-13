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

namespace Stactistics_And_Optimization_Of_Steel_Cutting__Without_.Net_Framework_
{
    public partial class Statistical_From : Form
    {
        public Statistical_From()
        {
            InitializeComponent();
            
        }

        private void TypeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string Type = "";
            if (TypeComboBox.SelectedIndex==0)
            {
                Type = "Batching";
            }
            else if (TypeComboBox.SelectedIndex == 1)
            {
                Type = "Diameter";
            }
            else if (TypeComboBox.SelectedIndex == 2)
            {
                Type = "ComponentName";
            }
            else if (TypeComboBox.SelectedIndex == 3)
            {
                Type = "ComponentSign";
            }
            else if (TypeComboBox.SelectedIndex == 4)
            {
                Type = "SteelSign";
            }

            using (SqlConnection sqlConnection = new SqlConnection(Main_Interface_Form.Globals.connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = "SELECT DISTINCT " + Type + " FROM Statictiscal_Table";
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        TypeCheckedListBox.Items.Clear();
                        while (sqlDataReader.Read())
                        {
                            TypeCheckedListBox.Items.Add(sqlDataReader[Type]);
                        }
                    }
                }
                sqlConnection.Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            string TestString = "";
            for (int i = 0; i < TypeCheckedListBox.SelectedItems.Count; i++)
            {
                
                if (i==(TypeCheckedListBox.SelectedItems.Count-1))
                {
                    TestString = TestString + TypeCheckedListBox.SelectedItems[i].ToString();
                }
                else
                {
                    TestString = TestString + TypeCheckedListBox.SelectedItems[i].ToString();
                    TestString = TestString + " OR ";
                }
            }
        }
    }
}
