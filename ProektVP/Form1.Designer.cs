namespace ProektVP
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.scoreTimer = new System.Windows.Forms.Timer(this.components);
            this.scoreCounterLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // scoreTimer
            // 
            this.scoreTimer.Interval = 1000;
            this.scoreTimer.Tick += new System.EventHandler(this.scoreTimer_Tick);
            // 
            // scoreCounterLbl
            // 
            this.scoreCounterLbl.BackColor = System.Drawing.SystemColors.Control;
            this.scoreCounterLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.scoreCounterLbl.Location = new System.Drawing.Point(0, 0);
            this.scoreCounterLbl.Name = "scoreCounterLbl";
            this.scoreCounterLbl.Size = new System.Drawing.Size(127, 26);
            this.scoreCounterLbl.TabIndex = 0;
            this.scoreCounterLbl.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.scoreCounterLbl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer scoreTimer;
        private System.Windows.Forms.Label scoreCounterLbl;
    }
}

