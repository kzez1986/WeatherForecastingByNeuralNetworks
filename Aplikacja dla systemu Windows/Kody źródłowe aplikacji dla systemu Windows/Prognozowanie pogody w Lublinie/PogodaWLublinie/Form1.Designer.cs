namespace PogodaWLublinie
{
    partial class foPogoda
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ącyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wczytajPlikTestującyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wczytajPlikWagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapiszPlikWagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.siećToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wstawParametryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uczToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jednostkaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metrycznyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.angielskiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbDane = new System.Windows.Forms.GroupBox();
            this.tbZonalIndeks = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPoraRokuGłówna = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbDzień = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbWiatrPr = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbTempMin = new System.Windows.Forms.TextBox();
            this.tbTempPR = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTempMax = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbŚnieg = new System.Windows.Forms.CheckBox();
            this.cbDeszcz = new System.Windows.Forms.CheckBox();
            this.cbMiasto = new System.Windows.Forms.ComboBox();
            this.tbCiśnienie = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buLicz = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tbTempMaxW = new System.Windows.Forms.TextBox();
            this.tbTempMinW = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbCiśnienieW = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.gbWyniki = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.gbDane.SuspendLayout();
            this.gbWyniki.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.siećToolStripMenuItem,
            this.jednostkaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(614, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ącyToolStripMenuItem,
            this.wczytajPlikTestującyToolStripMenuItem,
            this.wczytajPlikWagToolStripMenuItem,
            this.zapiszPlikWagToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(34, 20);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // ącyToolStripMenuItem
            // 
            this.ącyToolStripMenuItem.Name = "ącyToolStripMenuItem";
            this.ącyToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.ącyToolStripMenuItem.Text = "Wczytaj plik uczący...";
            this.ącyToolStripMenuItem.Click += new System.EventHandler(this.ącyToolStripMenuItem_Click);
            // 
            // wczytajPlikTestującyToolStripMenuItem
            // 
            this.wczytajPlikTestującyToolStripMenuItem.Name = "wczytajPlikTestującyToolStripMenuItem";
            this.wczytajPlikTestującyToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.wczytajPlikTestującyToolStripMenuItem.Text = "Wczytaj plik testujący...";
            this.wczytajPlikTestującyToolStripMenuItem.Click += new System.EventHandler(this.wczytajPlikTestującyToolStripMenuItem_Click);
            // 
            // wczytajPlikWagToolStripMenuItem
            // 
            this.wczytajPlikWagToolStripMenuItem.Name = "wczytajPlikWagToolStripMenuItem";
            this.wczytajPlikWagToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.wczytajPlikWagToolStripMenuItem.Text = "Wczytaj plik wag...";
            this.wczytajPlikWagToolStripMenuItem.Click += new System.EventHandler(this.wczytajPlikWagToolStripMenuItem_Click);
            // 
            // zapiszPlikWagToolStripMenuItem
            // 
            this.zapiszPlikWagToolStripMenuItem.Name = "zapiszPlikWagToolStripMenuItem";
            this.zapiszPlikWagToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.zapiszPlikWagToolStripMenuItem.Text = "Zapisz plik wag...";
            this.zapiszPlikWagToolStripMenuItem.Click += new System.EventHandler(this.zapiszPlikWagToolStripMenuItem_Click);
            // 
            // siećToolStripMenuItem
            // 
            this.siećToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wstawParametryToolStripMenuItem,
            this.uczToolStripMenuItem});
            this.siećToolStripMenuItem.Name = "siećToolStripMenuItem";
            this.siećToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.siećToolStripMenuItem.Text = "Sieć";
            this.siećToolStripMenuItem.Click += new System.EventHandler(this.siećToolStripMenuItem_Click);
            // 
            // wstawParametryToolStripMenuItem
            // 
            this.wstawParametryToolStripMenuItem.Name = "wstawParametryToolStripMenuItem";
            this.wstawParametryToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.wstawParametryToolStripMenuItem.Text = "Twórz/ Modyfikuj sieć...";
            this.wstawParametryToolStripMenuItem.Click += new System.EventHandler(this.wstawParametryToolStripMenuItem_Click);
            // 
            // uczToolStripMenuItem
            // 
            this.uczToolStripMenuItem.Name = "uczToolStripMenuItem";
            this.uczToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.uczToolStripMenuItem.Text = "Ucz / testuj...";
            this.uczToolStripMenuItem.Click += new System.EventHandler(this.uczToolStripMenuItem_Click);
            // 
            // jednostkaToolStripMenuItem
            // 
            this.jednostkaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.metrycznyToolStripMenuItem,
            this.angielskiToolStripMenuItem});
            this.jednostkaToolStripMenuItem.Name = "jednostkaToolStripMenuItem";
            this.jednostkaToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.jednostkaToolStripMenuItem.Text = "Jednostka";
            // 
            // metrycznyToolStripMenuItem
            // 
            this.metrycznyToolStripMenuItem.Checked = true;
            this.metrycznyToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metrycznyToolStripMenuItem.Name = "metrycznyToolStripMenuItem";
            this.metrycznyToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.metrycznyToolStripMenuItem.Text = "Metryczny";
            this.metrycznyToolStripMenuItem.Click += new System.EventHandler(this.metrycznyToolStripMenuItem_Click);
            // 
            // angielskiToolStripMenuItem
            // 
            this.angielskiToolStripMenuItem.Name = "angielskiToolStripMenuItem";
            this.angielskiToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.angielskiToolStripMenuItem.Text = "Angielski";
            this.angielskiToolStripMenuItem.Click += new System.EventHandler(this.angielskiToolStripMenuItem_Click);
            // 
            // gbDane
            // 
            this.gbDane.Controls.Add(this.tbZonalIndeks);
            this.gbDane.Controls.Add(this.label1);
            this.gbDane.Controls.Add(this.cbPoraRokuGłówna);
            this.gbDane.Controls.Add(this.label15);
            this.gbDane.Controls.Add(this.cbDzień);
            this.gbDane.Controls.Add(this.label7);
            this.gbDane.Controls.Add(this.label6);
            this.gbDane.Controls.Add(this.tbWiatrPr);
            this.gbDane.Controls.Add(this.label5);
            this.gbDane.Controls.Add(this.tbTempMin);
            this.gbDane.Controls.Add(this.tbTempPR);
            this.gbDane.Controls.Add(this.label4);
            this.gbDane.Controls.Add(this.tbTempMax);
            this.gbDane.Controls.Add(this.label3);
            this.gbDane.Controls.Add(this.cbŚnieg);
            this.gbDane.Controls.Add(this.cbDeszcz);
            this.gbDane.Controls.Add(this.cbMiasto);
            this.gbDane.Controls.Add(this.tbCiśnienie);
            this.gbDane.Controls.Add(this.label2);
            this.gbDane.Location = new System.Drawing.Point(12, 42);
            this.gbDane.Name = "gbDane";
            this.gbDane.Size = new System.Drawing.Size(590, 230);
            this.gbDane.TabIndex = 1;
            this.gbDane.TabStop = false;
            this.gbDane.Text = "Wprowadź dane";
            this.gbDane.Enter += new System.EventHandler(this.gbDane_Enter);
            // 
            // tbZonalIndeks
            // 
            this.tbZonalIndeks.Location = new System.Drawing.Point(364, 78);
            this.tbZonalIndeks.Name = "tbZonalIndeks";
            this.tbZonalIndeks.Size = new System.Drawing.Size(100, 20);
            this.tbZonalIndeks.TabIndex = 26;
            this.tbZonalIndeks.Text = "0";
            this.tbZonalIndeks.TextChanged += new System.EventHandler(this.tbZonalIndeks_TextChanged);
            this.tbZonalIndeks.Leave += new System.EventHandler(this.tbWiatrPr_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(263, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Zonal indeks:";
            // 
            // cbPoraRokuGłówna
            // 
            this.cbPoraRokuGłówna.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPoraRokuGłówna.FormattingEnabled = true;
            this.cbPoraRokuGłówna.Items.AddRange(new object[] {
            "Zima (11 grudzień - 14 luty)",
            "Przedwiośnie (16 luty - 31 marzec)",
            "Wiosna (1 kwiecień - 15 maj)",
            "Przedlecie (16 maj - 15 czerwiec)",
            "Lato (16 czerwiec - 15 sierpień)",
            "Polecie (16 sierpień - 20 wrzesień)",
            "Jesień (21 wrzesień - 31 październik)",
            "Przedzimie (1 listopad - 10 grudzień)"});
            this.cbPoraRokuGłówna.Location = new System.Drawing.Point(349, 20);
            this.cbPoraRokuGłówna.Name = "cbPoraRokuGłówna";
            this.cbPoraRokuGłówna.Size = new System.Drawing.Size(197, 21);
            this.cbPoraRokuGłówna.TabIndex = 24;
            this.cbPoraRokuGłówna.SelectedIndexChanged += new System.EventHandler(this.cbPoraRoku_SelectedIndexChanged_1);
            this.cbPoraRokuGłówna.Leave += new System.EventHandler(this.cbPoraRoku_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(287, 23);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 13);
            this.label15.TabIndex = 23;
            this.label15.Text = "Pora roku:";
            // 
            // cbDzień
            // 
            this.cbDzień.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDzień.FormattingEnabled = true;
            this.cbDzień.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cbDzień.Location = new System.Drawing.Point(146, 19);
            this.cbDzień.Name = "cbDzień";
            this.cbDzień.Size = new System.Drawing.Size(121, 21);
            this.cbDzień.TabIndex = 22;
            this.cbDzień.SelectedIndexChanged += new System.EventHandler(this.cbMiasto_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(263, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Prędkość wiatru";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Temperatura punktu rosy";
            // 
            // tbWiatrPr
            // 
            this.tbWiatrPr.Location = new System.Drawing.Point(364, 46);
            this.tbWiatrPr.Name = "tbWiatrPr";
            this.tbWiatrPr.Size = new System.Drawing.Size(100, 20);
            this.tbWiatrPr.TabIndex = 15;
            this.tbWiatrPr.Text = "0";
            this.tbWiatrPr.Leave += new System.EventHandler(this.tbWiatrPr_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Temperatura MIN";
            // 
            // tbTempMin
            // 
            this.tbTempMin.Location = new System.Drawing.Point(146, 78);
            this.tbTempMin.Name = "tbTempMin";
            this.tbTempMin.Size = new System.Drawing.Size(100, 20);
            this.tbTempMin.TabIndex = 13;
            this.tbTempMin.Text = "0";
            this.tbTempMin.TextChanged += new System.EventHandler(this.tbTempMin_TextChanged);
            this.tbTempMin.Leave += new System.EventHandler(this.tbWiatrPr_Leave);
            // 
            // tbTempPR
            // 
            this.tbTempPR.Location = new System.Drawing.Point(146, 107);
            this.tbTempPR.Name = "tbTempPR";
            this.tbTempPR.Size = new System.Drawing.Size(100, 20);
            this.tbTempPR.TabIndex = 13;
            this.tbTempPR.Text = "0";
            this.tbTempPR.Leave += new System.EventHandler(this.tbWiatrPr_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Temperatura MAX";
            // 
            // tbTempMax
            // 
            this.tbTempMax.Location = new System.Drawing.Point(146, 50);
            this.tbTempMax.Name = "tbTempMax";
            this.tbTempMax.Size = new System.Drawing.Size(100, 20);
            this.tbTempMax.TabIndex = 11;
            this.tbTempMax.Text = "0";
            this.tbTempMax.Leave += new System.EventHandler(this.tbWiatrPr_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-304, -180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "label3";
            // 
            // cbŚnieg
            // 
            this.cbŚnieg.AutoSize = true;
            this.cbŚnieg.Location = new System.Drawing.Point(497, 81);
            this.cbŚnieg.Name = "cbŚnieg";
            this.cbŚnieg.Size = new System.Drawing.Size(53, 17);
            this.cbŚnieg.TabIndex = 8;
            this.cbŚnieg.Text = "Śnieg";
            this.cbŚnieg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbŚnieg.UseVisualStyleBackColor = true;
            this.cbŚnieg.CheckedChanged += new System.EventHandler(this.cbMgła_CheckedChanged);
            this.cbŚnieg.Leave += new System.EventHandler(this.cbMgła_Leave);
            // 
            // cbDeszcz
            // 
            this.cbDeszcz.AutoSize = true;
            this.cbDeszcz.Location = new System.Drawing.Point(497, 52);
            this.cbDeszcz.Name = "cbDeszcz";
            this.cbDeszcz.Size = new System.Drawing.Size(61, 17);
            this.cbDeszcz.TabIndex = 5;
            this.cbDeszcz.Text = "Deszcz";
            this.cbDeszcz.UseVisualStyleBackColor = true;
            this.cbDeszcz.CheckedChanged += new System.EventHandler(this.cbMgła_CheckedChanged);
            this.cbDeszcz.Leave += new System.EventHandler(this.cbMgła_Leave);
            // 
            // cbMiasto
            // 
            this.cbMiasto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMiasto.FormattingEnabled = true;
            this.cbMiasto.Items.AddRange(new object[] {
            "Lublin"});
            this.cbMiasto.Location = new System.Drawing.Point(15, 20);
            this.cbMiasto.Name = "cbMiasto";
            this.cbMiasto.Size = new System.Drawing.Size(121, 21);
            this.cbMiasto.TabIndex = 4;
            this.cbMiasto.SelectedIndexChanged += new System.EventHandler(this.cbMiasto_TextChanged);
            // 
            // tbCiśnienie
            // 
            this.tbCiśnienie.Location = new System.Drawing.Point(146, 133);
            this.tbCiśnienie.Name = "tbCiśnienie";
            this.tbCiśnienie.Size = new System.Drawing.Size(100, 20);
            this.tbCiśnienie.TabIndex = 3;
            this.tbCiśnienie.Text = "0";
            this.tbCiśnienie.Leave += new System.EventHandler(this.tbWiatrPr_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ciśnienie:";
            // 
            // buLicz
            // 
            this.buLicz.Location = new System.Drawing.Point(12, 287);
            this.buLicz.Name = "buLicz";
            this.buLicz.Size = new System.Drawing.Size(177, 23);
            this.buLicz.TabIndex = 4;
            this.buLicz.Text = "Podaj prognozę";
            this.buLicz.UseVisualStyleBackColor = true;
            this.buLicz.Click += new System.EventHandler(this.buLicz_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tbTempMaxW
            // 
            this.tbTempMaxW.Location = new System.Drawing.Point(140, 47);
            this.tbTempMaxW.Name = "tbTempMaxW";
            this.tbTempMaxW.ReadOnly = true;
            this.tbTempMaxW.Size = new System.Drawing.Size(100, 20);
            this.tbTempMaxW.TabIndex = 16;
            this.tbTempMaxW.Text = "0";
            // 
            // tbTempMinW
            // 
            this.tbTempMinW.Location = new System.Drawing.Point(140, 78);
            this.tbTempMinW.Name = "tbTempMinW";
            this.tbTempMinW.ReadOnly = true;
            this.tbTempMinW.Size = new System.Drawing.Size(100, 20);
            this.tbTempMinW.TabIndex = 17;
            this.tbTempMinW.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Temperatura MAX";
            // 
            // tbCiśnienieW
            // 
            this.tbCiśnienieW.Location = new System.Drawing.Point(140, 109);
            this.tbCiśnienieW.Name = "tbCiśnienieW";
            this.tbCiśnienieW.ReadOnly = true;
            this.tbCiśnienieW.Size = new System.Drawing.Size(100, 20);
            this.tbCiśnienieW.TabIndex = 19;
            this.tbCiśnienieW.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Temperatura MIN";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 116);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Ciśnienie:";
            // 
            // gbWyniki
            // 
            this.gbWyniki.Controls.Add(this.label12);
            this.gbWyniki.Controls.Add(this.label10);
            this.gbWyniki.Controls.Add(this.tbCiśnienieW);
            this.gbWyniki.Controls.Add(this.label11);
            this.gbWyniki.Controls.Add(this.tbTempMinW);
            this.gbWyniki.Controls.Add(this.tbTempMaxW);
            this.gbWyniki.Location = new System.Drawing.Point(12, 330);
            this.gbWyniki.Name = "gbWyniki";
            this.gbWyniki.Size = new System.Drawing.Size(590, 175);
            this.gbWyniki.TabIndex = 5;
            this.gbWyniki.TabStop = false;
            this.gbWyniki.Text = "Wyniki";
            this.gbWyniki.Enter += new System.EventHandler(this.gbWyniki_Enter);
            // 
            // foPogoda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 517);
            this.Controls.Add(this.gbWyniki);
            this.Controls.Add(this.buLicz);
            this.Controls.Add(this.gbDane);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "foPogoda";
            this.Text = "Prognozowanie pogody w Lublinie";
            this.Load += new System.EventHandler(this.foPogoda_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbDane.ResumeLayout(false);
            this.gbDane.PerformLayout();
            this.gbWyniki.ResumeLayout(false);
            this.gbWyniki.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ącyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wczytajPlikTestującyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wczytajPlikWagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapiszPlikWagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem siećToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wstawParametryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uczToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbDane;
        private System.Windows.Forms.TextBox tbCiśnienie;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMiasto;
        private System.Windows.Forms.TextBox tbTempMax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbŚnieg;
        private System.Windows.Forms.CheckBox cbDeszcz;
        private System.Windows.Forms.TextBox tbTempPR;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buLicz;
        private System.Windows.Forms.TextBox tbWiatrPr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbTempMin;
        private System.Windows.Forms.ToolStripMenuItem jednostkaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem metrycznyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem angielskiToolStripMenuItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbDzień;
        private System.Windows.Forms.ComboBox cbPoraRokuGłówna;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox tbTempMaxW;
        private System.Windows.Forms.TextBox tbTempMinW;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbCiśnienieW;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox gbWyniki;
        private System.Windows.Forms.TextBox tbZonalIndeks;
        private System.Windows.Forms.Label label1;
    }
}

