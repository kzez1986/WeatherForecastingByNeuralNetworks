namespace PogodaWLublinie
{
    partial class UczTestuj
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
            this.cbNrEpoki = new System.Windows.Forms.CheckBox();
            this.cbBłąd = new System.Windows.Forms.CheckBox();
            this.buUcz = new System.Windows.Forms.Button();
            this.buTestuj = new System.Windows.Forms.Button();
            this.buStop = new System.Windows.Forms.Button();
            this.buZamknij = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.laNumerEpoki = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.laBłąd = new System.Windows.Forms.Label();
            this.buResetujWagi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbNrEpoki
            // 
            this.cbNrEpoki.AutoSize = true;
            this.cbNrEpoki.Location = new System.Drawing.Point(123, 82);
            this.cbNrEpoki.Name = "cbNrEpoki";
            this.cbNrEpoki.Size = new System.Drawing.Size(117, 17);
            this.cbNrEpoki.TabIndex = 0;
            this.cbNrEpoki.Text = "Pokaż numer epoki";
            this.cbNrEpoki.UseVisualStyleBackColor = true;
            this.cbNrEpoki.CheckedChanged += new System.EventHandler(this.cbNrEpoki_CheckedChanged);
            // 
            // cbBłąd
            // 
            this.cbBłąd.AutoSize = true;
            this.cbBłąd.Location = new System.Drawing.Point(12, 82);
            this.cbBłąd.Name = "cbBłąd";
            this.cbBłąd.Size = new System.Drawing.Size(81, 17);
            this.cbBłąd.TabIndex = 1;
            this.cbBłąd.Text = "Pokaż błąd";
            this.cbBłąd.UseVisualStyleBackColor = true;
            this.cbBłąd.CheckedChanged += new System.EventHandler(this.cbBłąd_CheckedChanged);
            // 
            // buUcz
            // 
            this.buUcz.Location = new System.Drawing.Point(12, 115);
            this.buUcz.Name = "buUcz";
            this.buUcz.Size = new System.Drawing.Size(75, 23);
            this.buUcz.TabIndex = 2;
            this.buUcz.Text = "Ucz";
            this.buUcz.UseVisualStyleBackColor = true;
            this.buUcz.Click += new System.EventHandler(this.buUcz_Click);
            // 
            // buTestuj
            // 
            this.buTestuj.Location = new System.Drawing.Point(106, 115);
            this.buTestuj.Name = "buTestuj";
            this.buTestuj.Size = new System.Drawing.Size(75, 23);
            this.buTestuj.TabIndex = 3;
            this.buTestuj.Text = "Testuj";
            this.buTestuj.UseVisualStyleBackColor = true;
            this.buTestuj.Click += new System.EventHandler(this.buTestuj_Click);
            // 
            // buStop
            // 
            this.buStop.Enabled = false;
            this.buStop.Location = new System.Drawing.Point(204, 115);
            this.buStop.Name = "buStop";
            this.buStop.Size = new System.Drawing.Size(75, 23);
            this.buStop.TabIndex = 4;
            this.buStop.Text = "Stop";
            this.buStop.UseVisualStyleBackColor = true;
            this.buStop.Click += new System.EventHandler(this.buStop_Click);
            // 
            // buZamknij
            // 
            this.buZamknij.Location = new System.Drawing.Point(307, 115);
            this.buZamknij.Name = "buZamknij";
            this.buZamknij.Size = new System.Drawing.Size(75, 23);
            this.buZamknij.TabIndex = 5;
            this.buZamknij.Text = "Zamknij";
            this.buZamknij.UseVisualStyleBackColor = true;
            this.buZamknij.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Numer epoki:";
            // 
            // laNumerEpoki
            // 
            this.laNumerEpoki.AutoSize = true;
            this.laNumerEpoki.Location = new System.Drawing.Point(89, 13);
            this.laNumerEpoki.Name = "laNumerEpoki";
            this.laNumerEpoki.Size = new System.Drawing.Size(0, 13);
            this.laNumerEpoki.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Błąd:";
            // 
            // laBłąd
            // 
            this.laBłąd.AutoSize = true;
            this.laBłąd.Location = new System.Drawing.Point(92, 42);
            this.laBłąd.Name = "laBłąd";
            this.laBłąd.Size = new System.Drawing.Size(0, 13);
            this.laBłąd.TabIndex = 9;
            // 
            // buResetujWagi
            // 
            this.buResetujWagi.Location = new System.Drawing.Point(12, 160);
            this.buResetujWagi.Name = "buResetujWagi";
            this.buResetujWagi.Size = new System.Drawing.Size(169, 23);
            this.buResetujWagi.TabIndex = 10;
            this.buResetujWagi.Text = "Resetuj wagi";
            this.buResetujWagi.UseVisualStyleBackColor = true;
            this.buResetujWagi.Click += new System.EventHandler(this.buResetujWagi_Click);
            // 
            // UczTestuj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 197);
            this.Controls.Add(this.buResetujWagi);
            this.Controls.Add(this.laBłąd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.laNumerEpoki);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buZamknij);
            this.Controls.Add(this.buStop);
            this.Controls.Add(this.buTestuj);
            this.Controls.Add(this.buUcz);
            this.Controls.Add(this.cbBłąd);
            this.Controls.Add(this.cbNrEpoki);
            this.Name = "UczTestuj";
            this.Text = "Uczenie i testowanie sieci";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UczTestuj_FormClosed);
            this.Load += new System.EventHandler(this.UczTestuj_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbNrEpoki;
        private System.Windows.Forms.CheckBox cbBłąd;
        private System.Windows.Forms.Button buUcz;
        private System.Windows.Forms.Button buTestuj;
        private System.Windows.Forms.Button buStop;
        private System.Windows.Forms.Button buZamknij;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label laNumerEpoki;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label laBłąd;
        private System.Windows.Forms.Button buResetujWagi;
    }
}