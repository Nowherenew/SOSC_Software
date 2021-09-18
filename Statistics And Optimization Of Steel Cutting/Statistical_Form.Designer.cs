
namespace Statistics_And_Optimization_Of_Steel_Cutting
{
    partial class Statistical_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TypeCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TypeComboBox = new System.Windows.Forms.ComboBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.AcceptButton = new System.Windows.Forms.Button();
            this.TabNameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TypeCheckedListBox
            // 
            this.TypeCheckedListBox.FormattingEnabled = true;
            this.TypeCheckedListBox.Location = new System.Drawing.Point(11, 12);
            this.TypeCheckedListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TypeCheckedListBox.Name = "TypeCheckedListBox";
            this.TypeCheckedListBox.Size = new System.Drawing.Size(447, 249);
            this.TypeCheckedListBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(499, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên bảng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(507, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Phân loại";
            // 
            // TypeComboBox
            // 
            this.TypeComboBox.FormattingEnabled = true;
            this.TypeComboBox.Items.AddRange(new object[] {
            "Batching",
            "Diameter",
            "ComponentName",
            "ComponentSign",
            "SteelSign"});
            this.TypeComboBox.Location = new System.Drawing.Point(707, 136);
            this.TypeComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TypeComboBox.Name = "TypeComboBox";
            this.TypeComboBox.Size = new System.Drawing.Size(209, 39);
            this.TypeComboBox.TabIndex = 4;
            this.TypeComboBox.SelectionChangeCommitted += new System.EventHandler(this.TypeComboBox_SelectionChangeCommitted);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(496, 241);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(187, 57);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Hủy";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // AcceptButton
            // 
            this.AcceptButton.Location = new System.Drawing.Point(736, 241);
            this.AcceptButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(187, 57);
            this.AcceptButton.TabIndex = 6;
            this.AcceptButton.Text = "Đồng ý";
            this.AcceptButton.UseVisualStyleBackColor = true;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // TabNameTextBox
            // 
            this.TabNameTextBox.Location = new System.Drawing.Point(707, 19);
            this.TabNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TabNameTextBox.Name = "TabNameTextBox";
            this.TabNameTextBox.Size = new System.Drawing.Size(209, 38);
            this.TabNameTextBox.TabIndex = 7;
            // 
            // Statistical_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 334);
            this.Controls.Add(this.TabNameTextBox);
            this.Controls.Add(this.AcceptButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.TypeComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TypeCheckedListBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Statistical_Form";
            this.Text = "Statistical_Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox TypeCheckedListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox TypeComboBox;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button AcceptButton;
        private System.Windows.Forms.TextBox TabNameTextBox;
    }
}