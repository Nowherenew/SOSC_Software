using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stactistics_And_Optimization_Of_Steel_Cutting__Without_.Net_Framework_
{
    public partial class Main_Interface_Form : Form
    {
        public Main_Interface_Form()
        {
            InitializeComponent();
        }
        private void SteelEdition_click(object sender, EventArgs e)
        {
            string SteelEditionTag = (string)(sender as ToolStripItem).Tag;
            TestLabel.Text = "" + SteelEditionTag;
            if (SteelEditionTag == "1")
            {
                using (Steel_Edition_Form steel_Edition_Form = new Steel_Edition_Form())
                {
                    steel_Edition_Form.ShowDialog();
                    steel_Edition_Form.Dispose();
                }
                GC.Collect();
            }
            else if (SteelEditionTag == "2")
            {
                using(Steel_Edition_Form steel_Edition_Form = new Steel_Edition_Form())
                {
                    steel_Edition_Form.ShowDialog();
                }    
            }
            else if (SteelEditionTag == "3")
            {

            }
            else if (SteelEditionTag == "4")
            {

            }
        }

        private void Test1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
