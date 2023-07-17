namespace PogodaWLublinie
{
    partial class ParametrySieci
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
            this.nuIleWarstwUkrytych = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nuWejście = new System.Windows.Forms.NumericUpDown();
            this.nuWyjście = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nu1u = new System.Windows.Forms.NumericUpDown();
            this.nu2u = new System.Windows.Forms.NumericUpDown();
            this.nu3u = new System.Windows.Forms.NumericUpDown();
            this.nu4u = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.nuBias = new System.Windows.Forms.NumericUpDown();
            this.nuLearningRate = new System.Windows.Forms.NumericUpDown();
            this.nuMomentum = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.nuGóraWag = new System.Windows.Forms.NumericUpDown();
            this.nuDółWag = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.cbSposób = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.nuBłądMin = new System.Windows.Forms.NumericUpDown();
            this.nuEpoki = new System.Windows.Forms.NumericUpDown();
            this.buOK = new System.Windows.Forms.Button();
            this.buAnuluj = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nuIleWarstwUkrytych)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuWejście)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuWyjście)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nu1u)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nu2u)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nu3u)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nu4u)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuBias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuLearningRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuMomentum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuGóraWag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuDółWag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuBłądMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuEpoki)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Iloość warstw ukrytych:";
            // 
            // nuIleWarstwUkrytych
            // 
            this.nuIleWarstwUkrytych.Location = new System.Drawing.Point(126, 13);
            this.nuIleWarstwUkrytych.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nuIleWarstwUkrytych.Name = "nuIleWarstwUkrytych";
            this.nuIleWarstwUkrytych.Size = new System.Drawing.Size(68, 20);
            this.nuIleWarstwUkrytych.TabIndex = 1;
            this.nuIleWarstwUkrytych.ValueChanged += new System.EventHandler(this.nuIleWarstwUkrytych_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Liczba neuronów na wejściu:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Liczba neuronów na wyjściu:";
            // 
            // nuWejście
            // 
            this.nuWejście.Location = new System.Drawing.Point(163, 50);
            this.nuWejście.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nuWejście.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuWejście.Name = "nuWejście";
            this.nuWejście.Size = new System.Drawing.Size(94, 20);
            this.nuWejście.TabIndex = 4;
            this.nuWejście.Value = new decimal(new int[] {
            236,
            0,
            0,
            0});
            // 
            // nuWyjście
            // 
            this.nuWyjście.Location = new System.Drawing.Point(163, 82);
            this.nuWyjście.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nuWyjście.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuWyjście.Name = "nuWyjście";
            this.nuWyjście.Size = new System.Drawing.Size(94, 20);
            this.nuWyjście.TabIndex = 5;
            this.nuWyjście.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(274, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "1 warstwa ukryta:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(274, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "2 warstwa ukryta:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(274, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "3 warstwa ukryta:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(274, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "4 warstwa ukryta:";
            // 
            // nu1u
            // 
            this.nu1u.Enabled = false;
            this.nu1u.Location = new System.Drawing.Point(370, 50);
            this.nu1u.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nu1u.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nu1u.Name = "nu1u";
            this.nu1u.Size = new System.Drawing.Size(120, 20);
            this.nu1u.TabIndex = 10;
            this.nu1u.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nu2u
            // 
            this.nu2u.Enabled = false;
            this.nu2u.Location = new System.Drawing.Point(370, 82);
            this.nu2u.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nu2u.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nu2u.Name = "nu2u";
            this.nu2u.Size = new System.Drawing.Size(120, 20);
            this.nu2u.TabIndex = 11;
            this.nu2u.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nu3u
            // 
            this.nu3u.Enabled = false;
            this.nu3u.Location = new System.Drawing.Point(370, 111);
            this.nu3u.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nu3u.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nu3u.Name = "nu3u";
            this.nu3u.Size = new System.Drawing.Size(120, 20);
            this.nu3u.TabIndex = 12;
            this.nu3u.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nu4u
            // 
            this.nu4u.Enabled = false;
            this.nu4u.Location = new System.Drawing.Point(370, 140);
            this.nu4u.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nu4u.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nu4u.Name = "nu4u";
            this.nu4u.Size = new System.Drawing.Size(120, 20);
            this.nu4u.TabIndex = 13;
            this.nu4u.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 191);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Bias:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 223);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Learning rate:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 256);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Momentum:";
            // 
            // nuBias
            // 
            this.nuBias.DecimalPlaces = 1;
            this.nuBias.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nuBias.Location = new System.Drawing.Point(91, 189);
            this.nuBias.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nuBias.Name = "nuBias";
            this.nuBias.Size = new System.Drawing.Size(120, 20);
            this.nuBias.TabIndex = 17;
            // 
            // nuLearningRate
            // 
            this.nuLearningRate.DecimalPlaces = 1;
            this.nuLearningRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nuLearningRate.Location = new System.Drawing.Point(91, 221);
            this.nuLearningRate.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nuLearningRate.Name = "nuLearningRate";
            this.nuLearningRate.Size = new System.Drawing.Size(120, 20);
            this.nuLearningRate.TabIndex = 18;
            this.nuLearningRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // nuMomentum
            // 
            this.nuMomentum.DecimalPlaces = 1;
            this.nuMomentum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nuMomentum.Location = new System.Drawing.Point(91, 254);
            this.nuMomentum.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nuMomentum.Name = "nuMomentum";
            this.nuMomentum.Size = new System.Drawing.Size(120, 20);
            this.nuMomentum.TabIndex = 19;
            this.nuMomentum.Value = new decimal(new int[] {
            3,
            0,
            0,
            65536});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(230, 228);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(173, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Dolna wartość wag początkowych:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(230, 191);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(174, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Górna wartość wag początkowych:";
            // 
            // nuGóraWag
            // 
            this.nuGóraWag.DecimalPlaces = 1;
            this.nuGóraWag.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nuGóraWag.Location = new System.Drawing.Point(410, 189);
            this.nuGóraWag.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nuGóraWag.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.nuGóraWag.Name = "nuGóraWag";
            this.nuGóraWag.Size = new System.Drawing.Size(120, 20);
            this.nuGóraWag.TabIndex = 22;
            this.nuGóraWag.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nuGóraWag.ValueChanged += new System.EventHandler(this.nuGóraWag_ValueChanged);
            // 
            // nuDółWag
            // 
            this.nuDółWag.DecimalPlaces = 1;
            this.nuDółWag.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nuDółWag.Location = new System.Drawing.Point(410, 223);
            this.nuDółWag.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nuDółWag.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.nuDółWag.Name = "nuDółWag";
            this.nuDółWag.Size = new System.Drawing.Size(120, 20);
            this.nuDółWag.TabIndex = 23;
            this.nuDółWag.Value = new decimal(new int[] {
            5,
            0,
            0,
            -2147418112});
            this.nuDółWag.ValueChanged += new System.EventHandler(this.numericUpDown5_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 318);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "Warunek końca:";
            // 
            // cbSposób
            // 
            this.cbSposób.FormattingEnabled = true;
            this.cbSposób.Items.AddRange(new object[] {
            "Błąd mniejszy niż...",
            "Liczba epok wynosi..."});
            this.cbSposób.Location = new System.Drawing.Point(91, 315);
            this.cbSposób.Name = "cbSposób";
            this.cbSposób.Size = new System.Drawing.Size(121, 21);
            this.cbSposób.TabIndex = 25;
            this.cbSposób.SelectedIndexChanged += new System.EventHandler(this.cbSposób_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(274, 297);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "Minimalny błąd:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(274, 332);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(68, 13);
            this.label15.TabIndex = 27;
            this.label15.Text = "Liczba epok:";
            // 
            // nuBłądMin
            // 
            this.nuBłądMin.DecimalPlaces = 5;
            this.nuBłądMin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nuBłądMin.Location = new System.Drawing.Point(370, 295);
            this.nuBłądMin.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nuBłądMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            this.nuBłądMin.Name = "nuBłądMin";
            this.nuBłądMin.Size = new System.Drawing.Size(120, 20);
            this.nuBłądMin.TabIndex = 28;
            this.nuBłądMin.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // nuEpoki
            // 
            this.nuEpoki.Enabled = false;
            this.nuEpoki.Location = new System.Drawing.Point(370, 330);
            this.nuEpoki.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nuEpoki.Name = "nuEpoki";
            this.nuEpoki.Size = new System.Drawing.Size(120, 20);
            this.nuEpoki.TabIndex = 29;
            // 
            // buOK
            // 
            this.buOK.Location = new System.Drawing.Point(163, 363);
            this.buOK.Name = "buOK";
            this.buOK.Size = new System.Drawing.Size(75, 23);
            this.buOK.TabIndex = 30;
            this.buOK.Text = "OK";
            this.buOK.UseVisualStyleBackColor = true;
            this.buOK.Click += new System.EventHandler(this.buOK_Click);
            // 
            // buAnuluj
            // 
            this.buAnuluj.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buAnuluj.Location = new System.Drawing.Point(277, 363);
            this.buAnuluj.Name = "buAnuluj";
            this.buAnuluj.Size = new System.Drawing.Size(75, 23);
            this.buAnuluj.TabIndex = 31;
            this.buAnuluj.Text = "Anuluj";
            this.buAnuluj.UseVisualStyleBackColor = true;
            this.buAnuluj.Click += new System.EventHandler(this.buAnuluj_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 163);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(439, 13);
            this.label16.TabIndex = 32;
            this.label16.Text = "Zmiana struktury sieci spowoduje utratę aktualnych informacji przechowywanych prz" +
                "ez sieć!";
            // 
            // ParametrySieci
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buAnuluj;
            this.ClientSize = new System.Drawing.Size(530, 395);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.buAnuluj);
            this.Controls.Add(this.buOK);
            this.Controls.Add(this.nuEpoki);
            this.Controls.Add(this.nuBłądMin);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cbSposób);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.nuDółWag);
            this.Controls.Add(this.nuGóraWag);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.nuMomentum);
            this.Controls.Add(this.nuLearningRate);
            this.Controls.Add(this.nuBias);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nu4u);
            this.Controls.Add(this.nu3u);
            this.Controls.Add(this.nu2u);
            this.Controls.Add(this.nu1u);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nuWyjście);
            this.Controls.Add(this.nuWejście);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nuIleWarstwUkrytych);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "ParametrySieci";
            this.Text = "Parametry sieci";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ParametrySieci_FormClosed);
            this.Load += new System.EventHandler(this.ParametrySieci_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nuIleWarstwUkrytych)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuWejście)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuWyjście)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nu1u)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nu2u)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nu3u)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nu4u)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuBias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuLearningRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuMomentum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuGóraWag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuDółWag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuBłądMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuEpoki)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nuIleWarstwUkrytych;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nuWejście;
        private System.Windows.Forms.NumericUpDown nuWyjście;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nu1u;
        private System.Windows.Forms.NumericUpDown nu2u;
        private System.Windows.Forms.NumericUpDown nu3u;
        private System.Windows.Forms.NumericUpDown nu4u;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nuBias;
        private System.Windows.Forms.NumericUpDown nuLearningRate;
        private System.Windows.Forms.NumericUpDown nuMomentum;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown nuGóraWag;
        private System.Windows.Forms.NumericUpDown nuDółWag;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbSposób;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown nuBłądMin;
        private System.Windows.Forms.NumericUpDown nuEpoki;
        private System.Windows.Forms.Button buOK;
        private System.Windows.Forms.Button buAnuluj;
        private System.Windows.Forms.Label label16;
    }
}