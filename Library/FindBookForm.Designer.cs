
namespace Library
{
    partial class FindBookForm
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.keywords = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.findBookButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(36, 47);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(205, 24);
            this.comboBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(33, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select a criteria for searching:";
            // 
            // keywords
            // 
            this.keywords.Location = new System.Drawing.Point(36, 115);
            this.keywords.Name = "keywords";
            this.keywords.Size = new System.Drawing.Size(322, 22);
            this.keywords.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(33, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fill in keywords for searchng:";
            // 
            // findBookButton
            // 
            this.findBookButton.Location = new System.Drawing.Point(257, 152);
            this.findBookButton.Name = "findBookButton";
            this.findBookButton.Size = new System.Drawing.Size(101, 27);
            this.findBookButton.TabIndex = 4;
            this.findBookButton.Text = "Find book";
            this.findBookButton.UseVisualStyleBackColor = true;
            this.findBookButton.Click += new System.EventHandler(this.findBookButton_Click);
            // 
            // FindBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 191);
            this.Controls.Add(this.findBookButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.keywords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "FindBookForm";
            this.Text = "FindBookForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox keywords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button findBookButton;
    }
}