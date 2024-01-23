namespace Offerte
{
    partial class MainForm
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
            this.groupBoxDatiAzienda = new System.Windows.Forms.GroupBox();
            this.comboBoxNomeAzienda = new System.Windows.Forms.ComboBox();
            this.textBoxCitta = new System.Windows.Forms.TextBox();
            this.labelCitta = new System.Windows.Forms.Label();
            this.textBoxIndirizzo = new System.Windows.Forms.TextBox();
            this.labelIndirizzo = new System.Windows.Forms.Label();
            this.textBoxCAP = new System.Windows.Forms.TextBox();
            this.labelCAP = new System.Windows.Forms.Label();
            this.labelNomeAzienda = new System.Windows.Forms.Label();
            this.groupBoxDettagli = new System.Windows.Forms.GroupBox();
            this.textBoxAttenzioneDi = new System.Windows.Forms.TextBox();
            this.labelAttenzioneDi = new System.Windows.Forms.Label();
            this.textBoxCondizionePagamento = new System.Windows.Forms.TextBox();
            this.labelCondizionePagamento = new System.Windows.Forms.Label();
            this.textBoxAnno = new System.Windows.Forms.TextBox();
            this.labelAnno = new System.Windows.Forms.Label();
            this.groupBoxContenuti = new System.Windows.Forms.GroupBox();
            this.textBoxDescrizioneCartella = new System.Windows.Forms.TextBox();
            this.labelDescrizioneCartella = new System.Windows.Forms.Label();
            this.textBoxNomeTecnico = new System.Windows.Forms.TextBox();
            this.labelNomeTecnico = new System.Windows.Forms.Label();
            this.buttonCrea = new System.Windows.Forms.Button();
            this.buttonAnnulla = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.groupBoxDatiAzienda.SuspendLayout();
            this.groupBoxDettagli.SuspendLayout();
            this.groupBoxContenuti.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxDatiAzienda
            // 
            this.groupBoxDatiAzienda.Controls.Add(this.comboBoxNomeAzienda);
            this.groupBoxDatiAzienda.Controls.Add(this.textBoxCitta);
            this.groupBoxDatiAzienda.Controls.Add(this.labelCitta);
            this.groupBoxDatiAzienda.Controls.Add(this.textBoxIndirizzo);
            this.groupBoxDatiAzienda.Controls.Add(this.labelIndirizzo);
            this.groupBoxDatiAzienda.Controls.Add(this.textBoxCAP);
            this.groupBoxDatiAzienda.Controls.Add(this.labelCAP);
            this.groupBoxDatiAzienda.Controls.Add(this.labelNomeAzienda);
            this.groupBoxDatiAzienda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDatiAzienda.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBoxDatiAzienda.Location = new System.Drawing.Point(13, 13);
            this.groupBoxDatiAzienda.Name = "groupBoxDatiAzienda";
            this.groupBoxDatiAzienda.Size = new System.Drawing.Size(717, 86);
            this.groupBoxDatiAzienda.TabIndex = 0;
            this.groupBoxDatiAzienda.TabStop = false;
            this.groupBoxDatiAzienda.Text = "DATI AZIENDA";
            // 
            // comboBoxNomeAzienda
            // 
            this.comboBoxNomeAzienda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxNomeAzienda.FormattingEnabled = true;
            this.comboBoxNomeAzienda.Location = new System.Drawing.Point(10, 45);
            this.comboBoxNomeAzienda.Name = "comboBoxNomeAzienda";
            this.comboBoxNomeAzienda.Size = new System.Drawing.Size(233, 28);
            this.comboBoxNomeAzienda.TabIndex = 8;
            this.comboBoxNomeAzienda.SelectedValueChanged += new System.EventHandler(this.comboBoxNomeAzienda_SelectedValueChanged);
            // 
            // textBoxCitta
            // 
            this.textBoxCitta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCitta.Location = new System.Drawing.Point(544, 45);
            this.textBoxCitta.Name = "textBoxCitta";
            this.textBoxCitta.Size = new System.Drawing.Size(167, 29);
            this.textBoxCitta.TabIndex = 7;
            // 
            // labelCitta
            // 
            this.labelCitta.AutoSize = true;
            this.labelCitta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCitta.Location = new System.Drawing.Point(540, 18);
            this.labelCitta.Name = "labelCitta";
            this.labelCitta.Size = new System.Drawing.Size(45, 24);
            this.labelCitta.TabIndex = 6;
            this.labelCitta.Text = "Città";
            // 
            // textBoxIndirizzo
            // 
            this.textBoxIndirizzo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIndirizzo.Location = new System.Drawing.Point(316, 45);
            this.textBoxIndirizzo.Name = "textBoxIndirizzo";
            this.textBoxIndirizzo.Size = new System.Drawing.Size(222, 29);
            this.textBoxIndirizzo.TabIndex = 5;
            // 
            // labelIndirizzo
            // 
            this.labelIndirizzo.AutoSize = true;
            this.labelIndirizzo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIndirizzo.Location = new System.Drawing.Point(312, 18);
            this.labelIndirizzo.Name = "labelIndirizzo";
            this.labelIndirizzo.Size = new System.Drawing.Size(79, 24);
            this.labelIndirizzo.TabIndex = 4;
            this.labelIndirizzo.Text = "Indirizzo";
            // 
            // textBoxCAP
            // 
            this.textBoxCAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCAP.Location = new System.Drawing.Point(249, 45);
            this.textBoxCAP.Name = "textBoxCAP";
            this.textBoxCAP.Size = new System.Drawing.Size(61, 29);
            this.textBoxCAP.TabIndex = 3;
            // 
            // labelCAP
            // 
            this.labelCAP.AutoSize = true;
            this.labelCAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCAP.Location = new System.Drawing.Point(245, 18);
            this.labelCAP.Name = "labelCAP";
            this.labelCAP.Size = new System.Drawing.Size(48, 24);
            this.labelCAP.TabIndex = 2;
            this.labelCAP.Text = "CAP";
            // 
            // labelNomeAzienda
            // 
            this.labelNomeAzienda.AutoSize = true;
            this.labelNomeAzienda.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomeAzienda.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelNomeAzienda.Location = new System.Drawing.Point(6, 18);
            this.labelNomeAzienda.Name = "labelNomeAzienda";
            this.labelNomeAzienda.Size = new System.Drawing.Size(136, 24);
            this.labelNomeAzienda.TabIndex = 1;
            this.labelNomeAzienda.Text = "Nome Azienda";
            // 
            // groupBoxDettagli
            // 
            this.groupBoxDettagli.Controls.Add(this.textBoxAttenzioneDi);
            this.groupBoxDettagli.Controls.Add(this.labelAttenzioneDi);
            this.groupBoxDettagli.Controls.Add(this.textBoxCondizionePagamento);
            this.groupBoxDettagli.Controls.Add(this.labelCondizionePagamento);
            this.groupBoxDettagli.Controls.Add(this.textBoxAnno);
            this.groupBoxDettagli.Controls.Add(this.labelAnno);
            this.groupBoxDettagli.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDettagli.Location = new System.Drawing.Point(13, 105);
            this.groupBoxDettagli.Name = "groupBoxDettagli";
            this.groupBoxDettagli.Size = new System.Drawing.Size(717, 85);
            this.groupBoxDettagli.TabIndex = 1;
            this.groupBoxDettagli.TabStop = false;
            this.groupBoxDettagli.Text = "DETTAGLI";
            // 
            // textBoxAttenzioneDi
            // 
            this.textBoxAttenzioneDi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAttenzioneDi.Location = new System.Drawing.Point(497, 45);
            this.textBoxAttenzioneDi.Name = "textBoxAttenzioneDi";
            this.textBoxAttenzioneDi.Size = new System.Drawing.Size(214, 29);
            this.textBoxAttenzioneDi.TabIndex = 5;
            // 
            // labelAttenzioneDi
            // 
            this.labelAttenzioneDi.AutoSize = true;
            this.labelAttenzioneDi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAttenzioneDi.Location = new System.Drawing.Point(497, 18);
            this.labelAttenzioneDi.Name = "labelAttenzioneDi";
            this.labelAttenzioneDi.Size = new System.Drawing.Size(151, 24);
            this.labelAttenzioneDi.TabIndex = 4;
            this.labelAttenzioneDi.Text = "All\' Attenzione Di";
            // 
            // textBoxCondizionePagamento
            // 
            this.textBoxCondizionePagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCondizionePagamento.Location = new System.Drawing.Point(116, 46);
            this.textBoxCondizionePagamento.Name = "textBoxCondizionePagamento";
            this.textBoxCondizionePagamento.Size = new System.Drawing.Size(375, 29);
            this.textBoxCondizionePagamento.TabIndex = 3;
            // 
            // labelCondizionePagamento
            // 
            this.labelCondizionePagamento.AutoSize = true;
            this.labelCondizionePagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCondizionePagamento.Location = new System.Drawing.Point(116, 18);
            this.labelCondizionePagamento.Name = "labelCondizionePagamento";
            this.labelCondizionePagamento.Size = new System.Drawing.Size(207, 24);
            this.labelCondizionePagamento.TabIndex = 2;
            this.labelCondizionePagamento.Text = "Condizione Pagamento";
            // 
            // textBoxAnno
            // 
            this.textBoxAnno.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAnno.Location = new System.Drawing.Point(10, 46);
            this.textBoxAnno.Name = "textBoxAnno";
            this.textBoxAnno.Size = new System.Drawing.Size(100, 29);
            this.textBoxAnno.TabIndex = 1;
            // 
            // labelAnno
            // 
            this.labelAnno.AutoSize = true;
            this.labelAnno.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnno.Location = new System.Drawing.Point(6, 18);
            this.labelAnno.Name = "labelAnno";
            this.labelAnno.Size = new System.Drawing.Size(56, 24);
            this.labelAnno.TabIndex = 0;
            this.labelAnno.Text = "Anno";
            // 
            // groupBoxContenuti
            // 
            this.groupBoxContenuti.Controls.Add(this.textBoxDescrizioneCartella);
            this.groupBoxContenuti.Controls.Add(this.labelDescrizioneCartella);
            this.groupBoxContenuti.Controls.Add(this.textBoxNomeTecnico);
            this.groupBoxContenuti.Controls.Add(this.labelNomeTecnico);
            this.groupBoxContenuti.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxContenuti.Location = new System.Drawing.Point(13, 197);
            this.groupBoxContenuti.Name = "groupBoxContenuti";
            this.groupBoxContenuti.Size = new System.Drawing.Size(717, 204);
            this.groupBoxContenuti.TabIndex = 2;
            this.groupBoxContenuti.TabStop = false;
            this.groupBoxContenuti.Text = "CONTENUTI";
            // 
            // textBoxDescrizioneCartella
            // 
            this.textBoxDescrizioneCartella.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDescrizioneCartella.Location = new System.Drawing.Point(6, 105);
            this.textBoxDescrizioneCartella.Name = "textBoxDescrizioneCartella";
            this.textBoxDescrizioneCartella.Size = new System.Drawing.Size(705, 29);
            this.textBoxDescrizioneCartella.TabIndex = 3;
            // 
            // labelDescrizioneCartella
            // 
            this.labelDescrizioneCartella.AutoSize = true;
            this.labelDescrizioneCartella.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescrizioneCartella.Location = new System.Drawing.Point(245, 77);
            this.labelDescrizioneCartella.Name = "labelDescrizioneCartella";
            this.labelDescrizioneCartella.Size = new System.Drawing.Size(235, 24);
            this.labelDescrizioneCartella.TabIndex = 2;
            this.labelDescrizioneCartella.Text = "Descrizione Cartella Offerta";
            // 
            // textBoxNomeTecnico
            // 
            this.textBoxNomeTecnico.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNomeTecnico.Location = new System.Drawing.Point(139, 45);
            this.textBoxNomeTecnico.Name = "textBoxNomeTecnico";
            this.textBoxNomeTecnico.Size = new System.Drawing.Size(426, 29);
            this.textBoxNomeTecnico.TabIndex = 1;
            // 
            // labelNomeTecnico
            // 
            this.labelNomeTecnico.AutoSize = true;
            this.labelNomeTecnico.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomeTecnico.Location = new System.Drawing.Point(245, 18);
            this.labelNomeTecnico.Name = "labelNomeTecnico";
            this.labelNomeTecnico.Size = new System.Drawing.Size(230, 24);
            this.labelNomeTecnico.TabIndex = 0;
            this.labelNomeTecnico.Text = "Nome Tecnico per Report";
            // 
            // buttonCrea
            // 
            this.buttonCrea.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCrea.Location = new System.Drawing.Point(494, 407);
            this.buttonCrea.Name = "buttonCrea";
            this.buttonCrea.Size = new System.Drawing.Size(104, 48);
            this.buttonCrea.TabIndex = 3;
            this.buttonCrea.Text = "CREA";
            this.buttonCrea.UseVisualStyleBackColor = true;
            this.buttonCrea.Click += new System.EventHandler(this.buttonCrea_Click);
            // 
            // buttonAnnulla
            // 
            this.buttonAnnulla.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAnnulla.Location = new System.Drawing.Point(604, 407);
            this.buttonAnnulla.Name = "buttonAnnulla";
            this.buttonAnnulla.Size = new System.Drawing.Size(126, 48);
            this.buttonAnnulla.TabIndex = 4;
            this.buttonAnnulla.Text = "ANNULLA";
            this.buttonAnnulla.UseVisualStyleBackColor = true;
            // 
            // buttonHelp
            // 
            this.buttonHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHelp.Location = new System.Drawing.Point(12, 407);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(46, 48);
            this.buttonHelp.TabIndex = 5;
            this.buttonHelp.Text = "?";
            this.buttonHelp.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 466);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.buttonAnnulla);
            this.Controls.Add(this.buttonCrea);
            this.Controls.Add(this.groupBoxContenuti);
            this.Controls.Add(this.groupBoxDettagli);
            this.Controls.Add(this.groupBoxDatiAzienda);
            this.Name = "MainForm";
            this.Text = "Creazione Offerte e Report";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBoxDatiAzienda.ResumeLayout(false);
            this.groupBoxDatiAzienda.PerformLayout();
            this.groupBoxDettagli.ResumeLayout(false);
            this.groupBoxDettagli.PerformLayout();
            this.groupBoxContenuti.ResumeLayout(false);
            this.groupBoxContenuti.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxDatiAzienda;
        private System.Windows.Forms.Label labelNomeAzienda;
        private System.Windows.Forms.Label labelCAP;
        private System.Windows.Forms.TextBox textBoxCitta;
        private System.Windows.Forms.Label labelCitta;
        private System.Windows.Forms.TextBox textBoxIndirizzo;
        private System.Windows.Forms.Label labelIndirizzo;
        private System.Windows.Forms.TextBox textBoxCAP;
        private System.Windows.Forms.GroupBox groupBoxDettagli;
        private System.Windows.Forms.TextBox textBoxCondizionePagamento;
        private System.Windows.Forms.Label labelCondizionePagamento;
        private System.Windows.Forms.TextBox textBoxAnno;
        private System.Windows.Forms.Label labelAnno;
        private System.Windows.Forms.TextBox textBoxAttenzioneDi;
        private System.Windows.Forms.Label labelAttenzioneDi;
        private System.Windows.Forms.GroupBox groupBoxContenuti;
        private System.Windows.Forms.Label labelDescrizioneCartella;
        private System.Windows.Forms.TextBox textBoxNomeTecnico;
        private System.Windows.Forms.Label labelNomeTecnico;
        private System.Windows.Forms.ComboBox comboBoxNomeAzienda;
        private System.Windows.Forms.Button buttonCrea;
        private System.Windows.Forms.Button buttonAnnulla;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.TextBox textBoxDescrizioneCartella;
    }
}