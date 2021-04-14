
namespace pfe
{
    partial class Fournisseur
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridFrs = new System.Windows.Forms.DataGridView();
            this.column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.searchBoxFrs = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button7 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ville = new System.Windows.Forms.TextBox();
            this.adresse = new System.Windows.Forms.TextBox();
            this.id_fiscale = new System.Windows.Forms.TextBox();
            this.registre_com = new System.Windows.Forms.TextBox();
            this.email_frs = new System.Windows.Forms.TextBox();
            this.tele_frs = new System.Windows.Forms.TextBox();
            this.raison_social = new System.Windows.Forms.TextBox();
            this.ICE = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFrs)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-3, 2);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1116, 649);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridFrs);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.searchBoxFrs);
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(1108, 620);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridFrs
            // 
            this.dataGridFrs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridFrs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column1,
            this.column2,
            this.column3,
            this.column4,
            this.column5,
            this.column6,
            this.column7,
            this.column8,
            this.column9});
            this.dataGridFrs.Location = new System.Drawing.Point(43, 69);
            this.dataGridFrs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridFrs.Name = "dataGridFrs";
            this.dataGridFrs.RowHeadersWidth = 51;
            this.dataGridFrs.Size = new System.Drawing.Size(1008, 356);
            this.dataGridFrs.TabIndex = 11;
            this.dataGridFrs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridFrs_CellContentClick);
            this.dataGridFrs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridFrs_CellDoubleClick);
            // 
            // column1
            // 
            this.column1.HeaderText = "ID";
            this.column1.MinimumWidth = 6;
            this.column1.Name = "column1";
            this.column1.Width = 125;
            // 
            // column2
            // 
            this.column2.HeaderText = "ICE";
            this.column2.MinimumWidth = 6;
            this.column2.Name = "column2";
            this.column2.Width = 125;
            // 
            // column3
            // 
            this.column3.HeaderText = "Raison Social";
            this.column3.MinimumWidth = 6;
            this.column3.Name = "column3";
            this.column3.Width = 125;
            // 
            // column4
            // 
            this.column4.HeaderText = "GSM";
            this.column4.MinimumWidth = 6;
            this.column4.Name = "column4";
            this.column4.Width = 125;
            // 
            // column5
            // 
            this.column5.HeaderText = "E-mail";
            this.column5.MinimumWidth = 6;
            this.column5.Name = "column5";
            this.column5.Width = 125;
            // 
            // column6
            // 
            this.column6.HeaderText = "Registre Commercial";
            this.column6.MinimumWidth = 6;
            this.column6.Name = "column6";
            this.column6.Width = 125;
            // 
            // column7
            // 
            this.column7.HeaderText = "ID Fiscale";
            this.column7.MinimumWidth = 6;
            this.column7.Name = "column7";
            this.column7.Width = 125;
            // 
            // column8
            // 
            this.column8.HeaderText = "Adresse";
            this.column8.MinimumWidth = 6;
            this.column8.Name = "column8";
            this.column8.Width = 125;
            // 
            // column9
            // 
            this.column9.HeaderText = "Ville";
            this.column9.MinimumWidth = 6;
            this.column9.Name = "column9";
            this.column9.Width = 125;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(63, 31);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "ID fournisseur";
            // 
            // searchBoxFrs
            // 
            this.searchBoxFrs.Location = new System.Drawing.Point(165, 31);
            this.searchBoxFrs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.searchBoxFrs.Name = "searchBoxFrs";
            this.searchBoxFrs.Size = new System.Drawing.Size(132, 22);
            this.searchBoxFrs.TabIndex = 9;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(305, 25);
            this.button6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(100, 28);
            this.button6.TabIndex = 8;
            this.button6.Text = "chercher";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(719, 433);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(176, 49);
            this.button5.TabIndex = 7;
            this.button5.Text = "afficher tout les fournisseurs / actualiser";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(903, 433);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 49);
            this.button4.TabIndex = 6;
            this.button4.Text = "nouveau";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button7);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.ville);
            this.tabPage2.Controls.Add(this.adresse);
            this.tabPage2.Controls.Add(this.id_fiscale);
            this.tabPage2.Controls.Add(this.registre_com);
            this.tabPage2.Controls.Add(this.email_frs);
            this.tabPage2.Controls.Add(this.tele_frs);
            this.tabPage2.Controls.Add(this.raison_social);
            this.tabPage2.Controls.Add(this.ICE);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(1108, 620);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(439, 517);
            this.button7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(100, 48);
            this.button7.TabIndex = 42;
            this.button7.Text = "Supprimer";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(581, 517);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 48);
            this.button3.TabIndex = 41;
            this.button3.Text = "Modifier";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(852, 517);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 48);
            this.button2.TabIndex = 40;
            this.button2.Text = "Fermer";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(289, 199);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 17);
            this.label9.TabIndex = 39;
            this.label9.Text = "Ville";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(289, 146);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 17);
            this.label8.TabIndex = 38;
            this.label8.Text = "Adresse";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(289, 414);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 37;
            this.label1.Text = "ID fiscale";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(289, 356);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 17);
            this.label6.TabIndex = 36;
            this.label6.Text = "Registre Commercial";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(289, 297);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 35;
            this.label5.Text = "E-mail";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(289, 247);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 17);
            this.label4.TabIndex = 34;
            this.label4.Text = "GSM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(289, 103);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 17);
            this.label3.TabIndex = 33;
            this.label3.Text = "Raison Social";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(289, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 17);
            this.label2.TabIndex = 32;
            this.label2.Text = "ICE";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(720, 517);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 48);
            this.button1.TabIndex = 30;
            this.button1.Text = "Ajouter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ville
            // 
            this.ville.Location = new System.Drawing.Point(501, 196);
            this.ville.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ville.Name = "ville";
            this.ville.Size = new System.Drawing.Size(219, 22);
            this.ville.TabIndex = 29;
            // 
            // adresse
            // 
            this.adresse.Location = new System.Drawing.Point(501, 143);
            this.adresse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.adresse.Multiline = true;
            this.adresse.Name = "adresse";
            this.adresse.Size = new System.Drawing.Size(268, 38);
            this.adresse.TabIndex = 28;
            // 
            // id_fiscale
            // 
            this.id_fiscale.Location = new System.Drawing.Point(501, 410);
            this.id_fiscale.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.id_fiscale.Name = "id_fiscale";
            this.id_fiscale.Size = new System.Drawing.Size(132, 22);
            this.id_fiscale.TabIndex = 27;
            // 
            // registre_com
            // 
            this.registre_com.Location = new System.Drawing.Point(501, 352);
            this.registre_com.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.registre_com.Name = "registre_com";
            this.registre_com.Size = new System.Drawing.Size(132, 22);
            this.registre_com.TabIndex = 26;
            // 
            // email_frs
            // 
            this.email_frs.Location = new System.Drawing.Point(501, 288);
            this.email_frs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.email_frs.Name = "email_frs";
            this.email_frs.Size = new System.Drawing.Size(132, 22);
            this.email_frs.TabIndex = 25;
            // 
            // tele_frs
            // 
            this.tele_frs.Location = new System.Drawing.Point(501, 244);
            this.tele_frs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tele_frs.Name = "tele_frs";
            this.tele_frs.Size = new System.Drawing.Size(132, 22);
            this.tele_frs.TabIndex = 24;
            // 
            // raison_social
            // 
            this.raison_social.Location = new System.Drawing.Point(501, 100);
            this.raison_social.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.raison_social.Name = "raison_social";
            this.raison_social.Size = new System.Drawing.Size(132, 22);
            this.raison_social.TabIndex = 23;
            // 
            // ICE
            // 
            this.ICE.Location = new System.Drawing.Point(501, 62);
            this.ICE.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ICE.Name = "ICE";
            this.ICE.Size = new System.Drawing.Size(132, 22);
            this.ICE.TabIndex = 22;
            // 
            // Fournisseur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 754);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Fournisseur";
            this.Text = "Fournisseur";
            this.Load += new System.EventHandler(this.Fournisseur_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFrs)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridFrs;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox searchBoxFrs;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox ville;
        private System.Windows.Forms.TextBox adresse;
        private System.Windows.Forms.TextBox id_fiscale;
        private System.Windows.Forms.TextBox registre_com;
        private System.Windows.Forms.TextBox email_frs;
        private System.Windows.Forms.TextBox tele_frs;
        private System.Windows.Forms.TextBox raison_social;
        private System.Windows.Forms.TextBox ICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn column9;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button3;
    }
}