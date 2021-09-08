using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Statistics_And_Optimization_Of_Steel_Cutting
{
    public partial class Work_With_Steel : Form
    {
        List<TextBox> LengthTextBoxes;
        public Work_With_Steel()
        {
            InitializeComponent();
            LengthTextBoxes = new List<TextBox> { Length1TextBox, Length2TextBox, Length3TextBox, Length4TextBox, Length5TextBox, Length6TextBox, Length7TextBox};
            
        }
        private void PictureBox_Click_Event(object sender, EventArgs e)
        {
            for (int i = 0; i < LengthTextBoxes.Count; i++)
            {
                LengthTextBoxes[i].Tag = "";
                LengthTextBoxes[i].Text = "";
            }
            if (ShapePictureBox.Image != null)
                ShapePictureBox.Image.Dispose();
            string PictureTag = (string)(sender as PictureBox).Tag;
            ShapePictureBox.Image = Image.FromFile("B:/Software Data/VisualStudio/SOSC_Software/Statistics And Optimization Of Steel Cutting/Resources/" + PictureTag + "_NCM.jpg");
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void Work_With_Steel_SizeChanged(object sender, EventArgs e)
        {
            TestLabel.Text = "" + this.Size;
        }

        private void Work_With_Steel_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 0; i < ShapeTabControl.TabCount; i++)
            {
                foreach (PictureBox pictureBox in ShapeTabControl.TabPages[i].Controls)
                {
                    pictureBox.Image.Dispose();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }
        }

        private void ShapeTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
