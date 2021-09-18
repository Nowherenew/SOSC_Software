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
    public partial class Statistical_Form : Form
    {
        string Type = "";
        public Statistical_Form()
        {
            InitializeComponent();
            
        }

        private void TypeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
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
            string Condition = "";
            int max = TypeCheckedListBox.CheckedItems.Count - 1;
            for (int i = 0; i < TypeCheckedListBox.CheckedItems.Count; i++)
            {
                
                if (i==max)
                {
                    Condition = Condition + Type + " = " + "'" + TypeCheckedListBox.CheckedItems[i].ToString() + "'";
                }
                else if(i!=max)
                {
                    Condition = Condition + Type + " = " + "'" + TypeCheckedListBox.CheckedItems[i].ToString() + "'" + " OR ";
                }
            }
            Main_Interface_Form.Globals.StactisticCommand = Condition;
            Main_Interface_Form.Globals.TabName = TabNameTextBox.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
