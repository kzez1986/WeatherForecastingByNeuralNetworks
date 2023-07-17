using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace PogodaWLublinie
{
    public partial class UczTestuj : Form
    {
        foPogoda adres;
        SiećNeuronowa.SiećNeuronowa sn;
        private Thread watek;
        private bool uczenie, testowanie;
        private bool koniec;

        public Thread Wątek
        {
            get
            {
                return watek;
            }
        }

        public bool Zakończ
        {
            get
            {
                return koniec;
            }
            set
            {
                koniec = value;
            }
        }

        public UczTestuj(foPogoda bazowa, SiećNeuronowa.SiećNeuronowa s)
        {
            InitializeComponent();
            adres = bazowa;
            sn = s;
            koniec = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UczTestuj_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(watek != null)
                watek.Abort();
            adres.Enabled = true;
        }

        private void UczTestuj_Load(object sender, EventArgs e)
        {
            if (sn.plik_uczącyP == null)
            {
                MessageBox.Show("Nie wczytano pliku uczącego. Nie będzie możliwości uczenia sieci.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buUcz.Enabled = false;
                uczenie = false;
            }
            else
            {
                buUcz.Enabled = true;
                uczenie = true;
            }
            if (sn.plik_testującyP == null)
            {
                MessageBox.Show("Nie wczytano pliku testowego. Nie będzie możliwości testowania sieci.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buTestuj.Enabled = false;
                testowanie = false;
            }
            else
            {
                buTestuj.Enabled = true;
                testowanie = true;
            }
            sn.pokaż_błądP = cbBłąd.Checked;
            sn.pokaż_epokęP = cbNrEpoki.Checked;
            sn.utP = this;
        }

        private void buUcz_Click(object sender, EventArgs e)
        {
            buUcz.Enabled = false;
            buTestuj.Enabled = false;
            buStop.Enabled = true;
            watek = new Thread(new ThreadStart(sn.WstecznaPropagacja));
            watek.Start();
        }

        private void buTestuj_Click(object sender, EventArgs e)
        {
            buUcz.Enabled = false;
            buTestuj.Enabled = false;
            buStop.Enabled = true;
            sn.Testuj();
        }

        private void cbNrEpoki_CheckedChanged(object sender, EventArgs e)
        {
            sn.pokaż_epokęP = cbNrEpoki.Checked;
        }

        private void cbBłąd_CheckedChanged(object sender, EventArgs e)
        {
            sn.pokaż_błądP = cbBłąd.Checked;
        }

        public CheckBox PokażEpoki
        {
            get
            {
                return cbNrEpoki;
            }
        }
        public CheckBox PokażBłąd
        {
            get
            {
                return cbBłąd;
            }
        }
        public Label Błąd
        {
            get
            {
                return laBłąd;
            }
        }
        public Label NrEpoki
        {
            get
            {
                return laNumerEpoki;
            }
        }

        public Button Zatrzymaj
        {
            get
            {
                return buStop;
            }
        }

        public Button Ucz
        {
            get
            {
                return buUcz;
            }
        }

        public Button Testuj
        {
            get
            {
                return buTestuj;
            }
        }

        public void buStop_Click(object sender, EventArgs e)
        {
            buStop.Enabled = false;
            if(uczenie)
                buUcz.Enabled = true;
            if(testowanie)
                buTestuj.Enabled = true;
            //if(watek != null)
            //    watek.Abort();
            koniec = true;
        }

        private void buResetujWagi_Click(object sender, EventArgs e)
        {
            sn.InicjalizujWagiLosowo();
        }
    }
}
