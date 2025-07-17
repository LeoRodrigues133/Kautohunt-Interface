using Microsoft.Win32;
using System.Windows.Forms;

namespace Kautohunt.WinApp
{
    partial class TelaPrincipalForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbProcessos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNomeChar = new System.Windows.Forms.Label();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblHpChar = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSpChar = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMaxSpChar = new System.Windows.Forms.Label();
            this.lblMaxHpChar = new System.Windows.Forms.Label();
            this.cmbMapa = new System.Windows.Forms.ComboBox();
            this.chkListMobs = new System.Windows.Forms.CheckedListBox();
            this.btnSelecionarPasta = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.listCacando = new System.Windows.Forms.ListBox();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.rtxLog = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente:";
            // 
            // cmbProcessos
            // 
            this.cmbProcessos.FormattingEnabled = true;
            this.cmbProcessos.Location = new System.Drawing.Point(12, 38);
            this.cmbProcessos.Name = "cmbProcessos";
            this.cmbProcessos.Size = new System.Drawing.Size(193, 21);
            this.cmbProcessos.TabIndex = 1;
            this.cmbProcessos.SelectedIndexChanged += new System.EventHandler(this.cmbProcessos_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome:";
            // 
            // lblNomeChar
            // 
            this.lblNomeChar.AutoSize = true;
            this.lblNomeChar.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeChar.Location = new System.Drawing.Point(59, 19);
            this.lblNomeChar.Name = "lblNomeChar";
            this.lblNomeChar.Size = new System.Drawing.Size(16, 17);
            this.lblNomeChar.TabIndex = 3;
            this.lblNomeChar.Text = "--";
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(211, 37);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(83, 22);
            this.btnAtualizar.TabIndex = 4;
            this.btnAtualizar.Text = "Recarregar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Hp:";
            // 
            // lblHpChar
            // 
            this.lblHpChar.AutoSize = true;
            this.lblHpChar.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHpChar.Location = new System.Drawing.Point(57, 36);
            this.lblHpChar.Name = "lblHpChar";
            this.lblHpChar.Size = new System.Drawing.Size(16, 17);
            this.lblHpChar.TabIndex = 3;
            this.lblHpChar.Text = "--";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Sp:";
            // 
            // lblSpChar
            // 
            this.lblSpChar.AutoSize = true;
            this.lblSpChar.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpChar.Location = new System.Drawing.Point(57, 53);
            this.lblSpChar.Name = "lblSpChar";
            this.lblSpChar.Size = new System.Drawing.Size(16, 17);
            this.lblSpChar.TabIndex = 3;
            this.lblSpChar.Text = "--";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMaxSpChar);
            this.groupBox1.Controls.Add(this.lblMaxHpChar);
            this.groupBox1.Controls.Add(this.lblSpChar);
            this.groupBox1.Controls.Add(this.lblHpChar);
            this.groupBox1.Controls.Add(this.lblNomeChar);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 102);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informações do Personagem";
            // 
            // lblMaxSpChar
            // 
            this.lblMaxSpChar.AutoSize = true;
            this.lblMaxSpChar.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxSpChar.Location = new System.Drawing.Point(119, 53);
            this.lblMaxSpChar.Name = "lblMaxSpChar";
            this.lblMaxSpChar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblMaxSpChar.Size = new System.Drawing.Size(30, 17);
            this.lblMaxSpChar.TabIndex = 3;
            this.lblMaxSpChar.Text = "[ -- ]";
            // 
            // lblMaxHpChar
            // 
            this.lblMaxHpChar.AutoSize = true;
            this.lblMaxHpChar.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxHpChar.Location = new System.Drawing.Point(119, 36);
            this.lblMaxHpChar.Name = "lblMaxHpChar";
            this.lblMaxHpChar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblMaxHpChar.Size = new System.Drawing.Size(30, 17);
            this.lblMaxHpChar.TabIndex = 3;
            this.lblMaxHpChar.Text = "[ -- ]";
            // 
            // cmbMapa
            // 
            this.cmbMapa.FormattingEnabled = true;
            this.cmbMapa.Location = new System.Drawing.Point(12, 229);
            this.cmbMapa.Name = "cmbMapa";
            this.cmbMapa.Size = new System.Drawing.Size(193, 21);
            this.cmbMapa.TabIndex = 6;
            this.cmbMapa.SelectedIndexChanged += new System.EventHandler(this.cmbMapa_SelectedIndexChanged);
            // 
            // chkListMobs
            // 
            this.chkListMobs.FormattingEnabled = true;
            this.chkListMobs.Location = new System.Drawing.Point(12, 288);
            this.chkListMobs.Name = "chkListMobs";
            this.chkListMobs.Size = new System.Drawing.Size(130, 124);
            this.chkListMobs.TabIndex = 7;
            // 
            // btnSelecionarPasta
            // 
            this.btnSelecionarPasta.Location = new System.Drawing.Point(211, 228);
            this.btnSelecionarPasta.Name = "btnSelecionarPasta";
            this.btnSelecionarPasta.Size = new System.Drawing.Size(83, 21);
            this.btnSelecionarPasta.TabIndex = 8;
            this.btnSelecionarPasta.Text = "Pasta";
            this.btnSelecionarPasta.UseVisualStyleBackColor = true;
            this.btnSelecionarPasta.Click += new System.EventHandler(this.btnSelecionarPasta_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(12, 418);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(130, 38);
            this.btnAdicionar.TabIndex = 8;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.Location = new System.Drawing.Point(164, 418);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(130, 38);
            this.btnRemover.TabIndex = 8;
            this.btnRemover.Text = "Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // listCacando
            // 
            this.listCacando.FormattingEnabled = true;
            this.listCacando.Location = new System.Drawing.Point(164, 291);
            this.listCacando.Name = "listCacando";
            this.listCacando.Size = new System.Drawing.Size(130, 121);
            this.listCacando.TabIndex = 9;
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(12, 477);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(282, 38);
            this.btnIniciar.TabIndex = 10;
            this.btnIniciar.Text = "Iniciar Caça";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // rtxLog
            // 
            this.rtxLog.Location = new System.Drawing.Point(12, 559);
            this.rtxLog.Name = "rtxLog";
            this.rtxLog.ReadOnly = true;
            this.rtxLog.Size = new System.Drawing.Size(282, 170);
            this.rtxLog.TabIndex = 11;
            this.rtxLog.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 537);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Log:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "Pasta do Script:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 266);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 19);
            this.label7.TabIndex = 0;
            this.label7.Text = "Mobs Detectáveis:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(160, 266);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 19);
            this.label8.TabIndex = 0;
            this.label8.Text = "Caçando:";
            // 
            // TelaPrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 741);
            this.Controls.Add(this.rtxLog);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.listCacando);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.btnSelecionarPasta);
            this.Controls.Add(this.chkListMobs);
            this.Controls.Add(this.cmbMapa);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.cmbProcessos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Name = "TelaPrincipalForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kautohunt.Interface";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbProcessos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNomeChar;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblHpChar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSpChar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblMaxSpChar;
        private System.Windows.Forms.Label lblMaxHpChar;
        private System.Windows.Forms.ComboBox cmbMapa;
        private System.Windows.Forms.CheckedListBox chkListMobs;
        private System.Windows.Forms.Button btnSelecionarPasta;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.ListBox listCacando;
        private System.Windows.Forms.Button btnIniciar;
        private RichTextBox rtxLog;
        private Label label4;
        private Label label6;
        private Label label7;
        private Label label8;
    }
}

