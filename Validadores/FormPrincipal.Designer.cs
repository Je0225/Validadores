namespace Validadores
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
      this.lblCpf = new System.Windows.Forms.Label();
      this.lblIe = new System.Windows.Forms.Label();
      this.lblCnpj = new System.Windows.Forms.Label();
      this.lblResultado = new System.Windows.Forms.Label();
      this.tbIe = new System.Windows.Forms.TextBox();
      this.tbCpf = new System.Windows.Forms.TextBox();
      this.tbCnpj = new System.Windows.Forms.TextBox();
      this.cbUf = new System.Windows.Forms.ComboBox();
      this.btnValidaCpf = new System.Windows.Forms.Button();
      this.btnValidarIe = new System.Windows.Forms.Button();
      this.btnValidarCnpj = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // lblCpf
      // 
      this.lblCpf.AutoSize = true;
      this.lblCpf.Location = new System.Drawing.Point(15, 11);
      this.lblCpf.Name = "lblCpf";
      this.lblCpf.Size = new System.Drawing.Size(27, 13);
      this.lblCpf.TabIndex = 0;
      this.lblCpf.Text = "CPF";
      // 
      // lblIe
      // 
      this.lblIe.AutoSize = true;
      this.lblIe.Location = new System.Drawing.Point(25, 72);
      this.lblIe.Name = "lblIe";
      this.lblIe.Size = new System.Drawing.Size(17, 13);
      this.lblIe.TabIndex = 1;
      this.lblIe.Text = "IE";
      // 
      // lblCnpj
      // 
      this.lblCnpj.AutoSize = true;
      this.lblCnpj.Location = new System.Drawing.Point(8, 41);
      this.lblCnpj.Name = "lblCnpj";
      this.lblCnpj.Size = new System.Drawing.Size(34, 13);
      this.lblCnpj.TabIndex = 2;
      this.lblCnpj.Text = "CNPJ";
      // 
      // lblResultado
      // 
      this.lblResultado.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.lblResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblResultado.ForeColor = System.Drawing.SystemColors.ControlText;
      this.lblResultado.Location = new System.Drawing.Point(0, 94);
      this.lblResultado.Name = "lblResultado";
      this.lblResultado.Size = new System.Drawing.Size(396, 27);
      this.lblResultado.TabIndex = 4;
      this.lblResultado.Text = "label5";
      this.lblResultado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // tbIe
      // 
      this.tbIe.Location = new System.Drawing.Point(46, 70);
      this.tbIe.Name = "tbIe";
      this.tbIe.Size = new System.Drawing.Size(171, 20);
      this.tbIe.TabIndex = 4;
      this.tbIe.Tag = "IE";
      // 
      // tbCpf
      // 
      this.tbCpf.Location = new System.Drawing.Point(46, 8);
      this.tbCpf.Name = "tbCpf";
      this.tbCpf.Size = new System.Drawing.Size(171, 20);
      this.tbCpf.TabIndex = 0;
      this.tbCpf.Tag = "CPF";
      // 
      // tbCnpj
      // 
      this.tbCnpj.Location = new System.Drawing.Point(46, 38);
      this.tbCnpj.Name = "tbCnpj";
      this.tbCnpj.Size = new System.Drawing.Size(171, 20);
      this.tbCnpj.TabIndex = 2;
      this.tbCnpj.Tag = "CNPJ";
      // 
      // cbUf
      // 
      this.cbUf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbUf.FormattingEnabled = true;
      this.cbUf.Location = new System.Drawing.Point(226, 69);
      this.cbUf.Name = "cbUf";
      this.cbUf.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.cbUf.Size = new System.Drawing.Size(75, 21);
      this.cbUf.TabIndex = 5;
      // 
      // btnValidaCpf
      // 
      this.btnValidaCpf.Location = new System.Drawing.Point(226, 7);
      this.btnValidaCpf.Name = "btnValidaCpf";
      this.btnValidaCpf.Size = new System.Drawing.Size(75, 23);
      this.btnValidaCpf.TabIndex = 1;
      this.btnValidaCpf.Text = "Validar";
      this.btnValidaCpf.UseVisualStyleBackColor = true;
      this.btnValidaCpf.Click += new System.EventHandler(this.btnValidaCpf_Click);
      // 
      // btnValidarIe
      // 
      this.btnValidarIe.Location = new System.Drawing.Point(307, 68);
      this.btnValidarIe.Name = "btnValidarIe";
      this.btnValidarIe.Size = new System.Drawing.Size(75, 23);
      this.btnValidarIe.TabIndex = 6;
      this.btnValidarIe.Text = "Validar";
      this.btnValidarIe.UseVisualStyleBackColor = true;
      this.btnValidarIe.Click += new System.EventHandler(this.btnValidarIe_Click);
      // 
      // btnValidarCnpj
      // 
      this.btnValidarCnpj.Location = new System.Drawing.Point(226, 37);
      this.btnValidarCnpj.Name = "btnValidarCnpj";
      this.btnValidarCnpj.Size = new System.Drawing.Size(75, 23);
      this.btnValidarCnpj.TabIndex = 3;
      this.btnValidarCnpj.Text = "Validar";
      this.btnValidarCnpj.UseVisualStyleBackColor = true;
      this.btnValidarCnpj.Click += new System.EventHandler(this.btnValidarCnpj_Click);
      // 
      // FormPrincipal
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(396, 121);
      this.Controls.Add(this.btnValidarCnpj);
      this.Controls.Add(this.btnValidarIe);
      this.Controls.Add(this.btnValidaCpf);
      this.Controls.Add(this.cbUf);
      this.Controls.Add(this.tbCnpj);
      this.Controls.Add(this.tbCpf);
      this.Controls.Add(this.tbIe);
      this.Controls.Add(this.lblResultado);
      this.Controls.Add(this.lblCnpj);
      this.Controls.Add(this.lblIe);
      this.Controls.Add(this.lblCpf);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
      this.MaximizeBox = false;
      this.Name = "FormPrincipal";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Validadores";
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCpf;
        private System.Windows.Forms.Label lblIe;
        private System.Windows.Forms.Label lblCnpj;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.TextBox tbIe;
        private System.Windows.Forms.TextBox tbCpf;
        private System.Windows.Forms.TextBox tbCnpj;
        private System.Windows.Forms.ComboBox cbUf;
        private System.Windows.Forms.Button btnValidaCpf;
        private System.Windows.Forms.Button btnValidarIe;
        private System.Windows.Forms.Button btnValidarCnpj;
    }
}

