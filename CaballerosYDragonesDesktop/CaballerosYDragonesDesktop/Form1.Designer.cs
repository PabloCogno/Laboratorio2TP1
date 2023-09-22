namespace CaballerosYDragonesDesktop
{
    partial class FormPrincipal
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
            this.lbResultados = new System.Windows.Forms.ListBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnJugar = new System.Windows.Forms.Button();
            this.btnListarHistorial = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbResultados
            // 
            this.lbResultados.FormattingEnabled = true;
            this.lbResultados.ItemHeight = 16;
            this.lbResultados.Location = new System.Drawing.Point(1373, 27);
            this.lbResultados.Name = "lbResultados";
            this.lbResultados.Size = new System.Drawing.Size(539, 564);
            this.lbResultados.TabIndex = 0;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(1239, 39);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(117, 59);
            this.btnNuevo.TabIndex = 1;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnJugar
            // 
            this.btnJugar.Enabled = false;
            this.btnJugar.Location = new System.Drawing.Point(1239, 128);
            this.btnJugar.Name = "btnJugar";
            this.btnJugar.Size = new System.Drawing.Size(117, 59);
            this.btnJugar.TabIndex = 4;
            this.btnJugar.Text = "Jugar";
            this.btnJugar.UseVisualStyleBackColor = true;
            this.btnJugar.Click += new System.EventHandler(this.btnJugar_Click);
            // 
            // btnListarHistorial
            // 
            this.btnListarHistorial.Location = new System.Drawing.Point(1239, 224);
            this.btnListarHistorial.Name = "btnListarHistorial";
            this.btnListarHistorial.Size = new System.Drawing.Size(117, 59);
            this.btnListarHistorial.TabIndex = 5;
            this.btnListarHistorial.Text = "Historial";
            this.btnListarHistorial.UseVisualStyleBackColor = true;
            this.btnListarHistorial.Click += new System.EventHandler(this.btnListarHistorial_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1924, 603);
            this.Controls.Add(this.btnListarHistorial);
            this.Controls.Add(this.btnJugar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.lbResultados);
            this.Name = "FormPrincipal";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbResultados;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnJugar;
        private System.Windows.Forms.Button btnListarHistorial;
    }
}

