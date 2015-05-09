namespace ProektVP
{
    partial class HallOfFame
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
            this.highScoresLb = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // highScoresLb
            // 
            this.highScoresLb.FormattingEnabled = true;
            this.highScoresLb.Location = new System.Drawing.Point(0, 0);
            this.highScoresLb.Name = "highScoresLb";
            this.highScoresLb.Size = new System.Drawing.Size(202, 264);
            this.highScoresLb.TabIndex = 0;
            this.highScoresLb.Enter += new System.EventHandler(this.listBox1_Enter_1);
            // 
            // HallOfFame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(202, 262);
            this.Controls.Add(this.highScoresLb);
            this.Name = "HallOfFame";
            this.Text = "Hall Of Fame";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox highScoresLb;
    }
}