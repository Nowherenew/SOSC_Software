
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
            this.TypeCheckedListBox.Location = new System.Drawing.Point(4, 5);
            this.TypeCheckedListBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.TypeCheckedListBox.Name = "TypeCheckedListBox";
            this.TypeCheckedListBox.Size = new System.Drawing.Size(170, 109);
            this.TypeCheckedListBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(187, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên bảng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Phân loại";
            // 
            // TypeComboBox
            // 
            this.TypeComboBox.FormattingEnabled = true;
            this.TypeComboBox.Location = new System.Drawing.Point(265, 57);
            this.TypeComboBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.TypeComboBox.Name = "TypeComboBox";
            this.TypeComboBox.Size = new System.Drawing.Size(81, 21);
            this.TypeComboBox.TabIndex = 4;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(186, 101);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(70, 24);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Hủy";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // AcceptButton
            // 
            this.AcceptButton.Location = new System.Drawing.Point(276, 101);
            this.AcceptButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(70, 24);
            this.AcceptButton.TabIndex = 6;
            this.AcceptButton.Text = "Đồng ý";
            this.AcceptButton.UseVisualStyleBackColor = true;
            // 
            // TabNameTextBox
            // 
            this.TabNameTextBox.Location = new System.Drawing.Point(265, 8);
            this.TabNameTextBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.TabNameTextBox.Name = "TabNameTextBox";
            this.TabNameTextBox.Size = new System.Drawing.Size(81, 20);
            this.TabNameTextBox.TabIndex = 7;
            // 
            // Statistical_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 140);
            this.Controls.Add(this.TabNameTextBox);
            this.Controls.Add(this.AcceptButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.TypeComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TypeCheckedListBox);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
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