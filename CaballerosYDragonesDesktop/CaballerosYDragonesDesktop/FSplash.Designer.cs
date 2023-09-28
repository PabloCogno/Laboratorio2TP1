namespace CaballerosYDragonesDesktop
{
    partial class FSplash
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
            this.pbSplash = new System.Windows.Forms.PictureBox();
            this.timerSplash = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbSplash)).BeginInit();
            this.SuspendLayout();
            // 
            // pbSplash
            // 
            this.pbSplash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSplash.Image = global::CaballerosYDragonesDesktop.Properties.Resources.home1;
            this.pbSplash.Location = new System.Drawing.Point(0, 0);
            this.pbSplash.Name = "pbSplash";
            this.pbSplash.Size = new System.Drawing.Size(751, 698);
            this.pbSplash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSplash.TabIndex = 0;
            this.pbSplash.TabStop = false;
            // 
            // timerSplash
            // 
            this.timerSplash.Tick += new System.EventHandler(this.timerSplash_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(504, 643);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "Loading...    ";
            // 
            // FSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 698);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbSplash);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FSplash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FSplash";
            this.Load += new System.EventHandler(this.FSplash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSplash)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSplash;
        private System.Windows.Forms.Timer timerSplash;
        private System.Windows.Forms.Label label1;
    }
}