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

namespace Statistics_And_Optimization_Of_Steel_Cutting
{
    public partial class Main_Interface : Form
    {
        public Main_Interface()
        {
            InitializeComponent();
            GobalVariables.ConnectionString = "Data Source=DESKTOP-4P0S6LP;Initial Catalog=SOSC_Database;Integrated Security=True";
            label2.Text = "" + this.Size;
            //this.Size = new Size(2660, 1440);
        }

        private void AddSteelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(Work_With_Steel work_With_Steel=new Work_With_Steel())
            {
                work_With_Steel.Size = new Size(860, 400);
                work_With_Steel.ShowDialog();
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void Main_Interface_SizeChanged(object sender, EventArgs e)
        {
            label2.Text = "" + this.Size;

        }
    }
}
public static class GobalVariables
{
    public static string ConnectionString { get; set; }
}
