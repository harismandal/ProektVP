namespace ProektVP
{
    partial class Difficulty
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
            this.easyDifficultyBtn = new System.Windows.Forms.Button();
            this.mediumDifficultyBtn = new System.Windows.Forms.Button();
            this.hardDifficultyBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // easyDifficultyBtn
            // 
            this.easyDifficultyBtn.Location = new System.Drawing.Point(12, 12);
            this.easyDifficultyBtn.Name = "easyDifficultyBtn";
            this.easyDifficultyBtn.Size = new System.Drawing.Size(75, 23);
            this.easyDifficultyBtn.TabIndex = 0;
            this.easyDifficultyBtn.Text = "Easy";
            this.easyDifficultyBtn.UseVisualStyleBackColor = true;
            this.easyDifficultyBtn.Click += new System.EventHandler(this.easyDifficultyBtn_Click);
            // 
            // mediumDifficultyBtn
            // 
            this.mediumDifficultyBtn.Location = new System.Drawing.Point(103, 12);
            this.mediumDifficultyBtn.Name = "mediumDifficultyBtn";
            this.mediumDifficultyBtn.Size = new System.Drawing.Size(75, 23);
            this.mediumDifficultyBtn.TabIndex = 1;
            this.mediumDifficultyBtn.Text = "Medium";
            this.mediumDifficultyBtn.UseVisualStyleBackColor = true;
            this.mediumDifficultyBtn.Click += new System.EventHandler(this.mediumDifficultyBtn_Click);
            // 
            // hardDifficultyBtn
            // 
            this.hardDifficultyBtn.Location = new System.Drawing.Point(197, 12);
            this.hardDifficultyBtn.Name = "hardDifficultyBtn";
            this.hardDifficultyBtn.Size = new System.Drawing.Size(75, 23);
            this.hardDifficultyBtn.TabIndex = 2;
            this.hardDifficultyBtn.Text = "Hard";
            this.hardDifficultyBtn.UseVisualStyleBackColor = true;
            this.hardDifficultyBtn.Click += new System.EventHandler(this.hardDifficultyBtn_Click);
            // 
            // Difficulty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 42);
            this.Controls.Add(this.hardDifficultyBtn);
            this.Controls.Add(this.mediumDifficultyBtn);
            this.Controls.Add(this.easyDifficultyBtn);
            this.Name = "Difficulty";
            this.Text = "Difficulty";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button easyDifficultyBtn;
        private System.Windows.Forms.Button mediumDifficultyBtn;
        private System.Windows.Forms.Button hardDifficultyBtn;
    }
}