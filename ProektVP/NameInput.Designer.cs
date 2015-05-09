namespace ProektVP
{
    partial class NameInput
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
            this.nameInputTb = new System.Windows.Forms.TextBox();
            this.okayBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nameInputTb
            // 
            this.nameInputTb.Location = new System.Drawing.Point(12, 37);
            this.nameInputTb.Name = "nameInputTb";
            this.nameInputTb.Size = new System.Drawing.Size(132, 20);
            this.nameInputTb.TabIndex = 0;
            this.nameInputTb.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // okayBtn
            // 
            this.okayBtn.Location = new System.Drawing.Point(182, 34);
            this.okayBtn.Name = "okayBtn";
            this.okayBtn.Size = new System.Drawing.Size(75, 23);
            this.okayBtn.TabIndex = 1;
            this.okayBtn.Text = "Okay";
            this.okayBtn.UseVisualStyleBackColor = true;
            this.okayBtn.Click += new System.EventHandler(this.okayBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "How would you like to be called in the Hall of Fame?";
            // 
            // NameInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 69);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.okayBtn);
            this.Controls.Add(this.nameInputTb);
            this.Name = "NameInput";
            this.Text = "Name";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameInputTb;
        private System.Windows.Forms.Button okayBtn;
        private System.Windows.Forms.Label label1;
    }
}