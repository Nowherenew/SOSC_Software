
namespace Stactistics_And_Optimization_Of_Steel_Cutting__Without_.Net_Framework_
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
            this.CancelButton = new System.Windows.Forms.Button();
            this.AcceptButton = new System.Windows.Forms.Button();
            this.TypeComboBox = new System.Windows.Forms.ComboBox();
            this.TypeCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.TabNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(566, 344);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(188, 58);
            this.CancelButton.TabIndex = 0;
            this.CancelButton.Text = "Hủy";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // AcceptButton
            // 
            this.AcceptButton.Location = new System.Drawing.Point(893, 344);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(188, 58);
            this.AcceptButton.TabIndex = 1;
            this.AcceptButton.Text = "Đồng ý";
            this.AcceptButton.UseVisualStyleBackColor = true;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // TypeComboBox
            // 
            this.TypeComboBox.FormattingEnabled = true;
            this.TypeComboBox.Items.AddRange(new object[] {
            "Phân đợt",
            "Đường kính",
            "Tên cấu kiện",
            "Kí hiệu cấu kiện",
            "Số hiệu thép"});
            this.TypeComboBox.Location = new System.Drawing.Point(762, 188);
            this.TypeComboBox.Name = "TypeComboBox";
            this.TypeComboBox.Size = new System.Drawing.Size(209, 49);
            this.TypeComboBox.TabIndex = 3;
            this.TypeComboBox.SelectionChangeCommitted += new System.EventHandler(this.TypeComboBox_SelectionChangeCommitted);
            // 
            // TypeCheckedListBox
            // 
            this.TypeCheckedListBox.FormattingEnabled = true;
            this.TypeCheckedListBox.Location = new System.Drawing.Point(12, 12);
            this.TypeCheckedListBox.Name = "TypeCheckedListBox";
            this.TypeCheckedListBox.Size = new System.Drawing.Size(516, 400);
            this.TypeCheckedListBox.TabIndex = 4;
            // 
            // TabNameTextBox
            // 
            this.TabNameTextBox.Location = new System.Drawing.Point(762, 9);
            this.TabNameTextBox.Name = "TabNameTextBox";
            this.TabNameTextBox.Size = new System.Drawing.Size(209, 47);
            this.TabNameTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(566, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 41);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tên bảng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(566, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 41);
            this.label2.TabIndex = 7;
            this.label2.Text = "Phân loại";
            // 
            // Statistical_From
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TabNameTextBox);
            this.Controls.Add(this.TypeCheckedListBox);
            this.Controls.Add(this.TypeComboBox);
            this.Controls.Add(this.AcceptButton);
            this.Controls.Add(this.CancelButton);
            this.Name = "Statistical_From";
            this.Text = "Statistical_From";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button AcceptButton;
        private System.Windows.Forms.ComboBox TypeComboBox;
        private System.Windows.Forms.CheckedListBox TypeCheckedListBox;
        private System.Windows.Forms.TextBox TabNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}