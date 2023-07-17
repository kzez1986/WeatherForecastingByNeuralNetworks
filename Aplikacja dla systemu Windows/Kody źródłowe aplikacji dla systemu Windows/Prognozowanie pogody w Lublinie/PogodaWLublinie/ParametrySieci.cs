using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PogodaWLublinie
{
    public partial class ParametrySieci : Form
    {
        private foPogoda adres;
        private SiećNeuronowa.SiećNeuronowa sn;

        public ParametrySieci(SiećNeuronowa.SiećNeuronowa s, foPogoda bazowa)
        {
            InitializeComponent();
            adres = bazowa;
            sn = s;
        }

        private void ParametrySieci_Load(object sender, EventArgs e)
        {
            cbSposób.SelectedIndex = 0;
            if (sn != null)
            {
                long[] struktura = sn.struktura_sieciP;
                nuIleWarstwUkrytych.Value = struktura.Length - 2;
                nuWejście.Value = (decimal)struktura[0];
                nuWyjście.Value = (decimal)struktura[struktura.Length - 1];
                if (struktura.Length > 5)
                {
                    nu4u.Enabled = true;
                    nu4u.Value = (decimal)struktura[4];
                }
                if (struktura.Length > 4)
                {
                    nu3u.Enabled = true;
                    nu3u.Value = (decimal)struktura[3];
                }
                if (struktura.Length > 3)
                {
                    nu2u.Enabled = true;
                    nu2u.Value = (decimal)struktura[2];
                }
                if (struktura.Length > 2)
                {
                    nu1u.Enabled = true;
                    nu1u.Value = (decimal)struktura[1];
                }
                nuBias.Value = (decimal)sn.biasP;
                nuMomentum.Value = (decimal)sn.momentumP;
                nuLearningRate.Value = (decimal)sn.learning_rateP;
                nuDółWag.Value = (decimal)sn.dół_wagP;
                nuGóraWag.Value = (decimal)sn.góra_wagP;
                if (sn.warunek_końcaP)
                    cbSposób.SelectedIndex = 0;
                else
                    cbSposób.SelectedIndex = 1;
                nuBłądMin.Value = (decimal)sn.błąd_minP;
                nuEpoki.Value = (decimal)sn.ile_epokP;
            }
        }

        private void ParametrySieci_FormClosed(object sender, FormClosedEventArgs e)
        {
            adres.Enabled = true;
        }

        private void cbSposób_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbSposób.SelectedIndex)
            {
                case 0:
                    nuBłądMin.Enabled = true;
                    nuEpoki.Enabled = false;
                    break;
                case 1:
                    nuBłądMin.Enabled = false;
                    nuEpoki.Enabled = true;
                    break;
            }
        }

        private void buAnuluj_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nuIleWarstwUkrytych_ValueChanged(object sender, EventArgs e)
        {
            switch ((int)nuIleWarstwUkrytych.Value)
            {
                case 0:
                    {
                        nu1u.Enabled = false;
                        nu2u.Enabled = false;
                        nu3u.Enabled = false;
                        nu4u.Enabled = false;
                        break;
                    }
                case 1:
                    {
                        nu1u.Enabled = true;
                        nu2u.Enabled = false;
                        nu3u.Enabled = false;
                        nu4u.Enabled = false;
                        break;
                    }
                case 2:
                    {
                        nu1u.Enabled = true;
                        nu2u.Enabled = true;
                        nu3u.Enabled = false;
                        nu4u.Enabled = false;
                        break;
                    }
                case 3:
                    {
                        nu1u.Enabled = true;
                        nu2u.Enabled = true;
                        nu3u.Enabled = true;
                        nu4u.Enabled = false;
                        break;
                    }
                case 4:
                    {
                        nu1u.Enabled = true;
                        nu2u.Enabled = true;
                        nu3u.Enabled = true;
                        nu4u.Enabled = true;
                        break;
                    }
            }
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            if (nuGóraWag.Value < nuDółWag.Value)
                nuGóraWag.Value = nuDółWag.Value;
        }

        private void nuGóraWag_ValueChanged(object sender, EventArgs e)
        {
            if (nuGóraWag.Value < nuDółWag.Value)
                nuDółWag.Value = nuGóraWag.Value;
        }

        private void buOK_Click(object sender, EventArgs e)
        {
            //czy zmieniono strukturę?
            long[] struktura;
            if (sn != null)
                struktura = sn.struktura_sieciP;
            else
                struktura = new long[1]; //nie może być sieci z jedną warstwą więc na pewno będzie zmiana
            bool zmiana = false;
            if (struktura.Length != nuIleWarstwUkrytych.Value + 2) //+2 zer względu na warstwę wejściową i wyjściową
                zmiana = true;
            else
            {
                if (nuWejście.Value != struktura[0] || nuWyjście.Value != struktura[struktura.Length - 1])
                    zmiana = true;
                else
                {
                    if (nuIleWarstwUkrytych.Value > 3)
                        if (nu4u.Value != struktura[4])
                            zmiana = true;
                    if (nuIleWarstwUkrytych.Value > 2)
                        if (nu3u.Value != struktura[3])
                            zmiana = true;
                    if (nuIleWarstwUkrytych.Value > 1)
                        if (nu2u.Value != struktura[2])
                            zmiana = true;
                    if (nuIleWarstwUkrytych.Value > 0)
                        if (nu1u.Value != struktura[1])
                            zmiana = true;
                }
            }
            if (zmiana || sn == null) //tworzenie nowej sieci
            {
                int[] opis_warstw = new int[(int)nuIleWarstwUkrytych.Value + 2];
                opis_warstw[0] = (int)nuWejście.Value;
                if (nuIleWarstwUkrytych.Value > 3)
                    opis_warstw[4] = (int)nu4u.Value;
                if (nuIleWarstwUkrytych.Value > 2)
                    opis_warstw[3] = (int)nu3u.Value;
                if (nuIleWarstwUkrytych.Value > 1)
                    opis_warstw[2] = (int)nu2u.Value;
                if (nuIleWarstwUkrytych.Value > 0)
                    opis_warstw[1] = (int)nu1u.Value;
                opis_warstw[opis_warstw.Length - 1] = (int)nuWyjście.Value;
                bool koniec;
                if (cbSposób.SelectedIndex == 0)
                    koniec = true;
                else
                    koniec = false;
                if (zmiana == true || sn == null)
                    sn = new SiećNeuronowa.SiećNeuronowa(opis_warstw, (double)nuMomentum.Value, (double)nuLearningRate.Value, (double)nuDółWag.Value, (double)nuGóraWag.Value, (double)nuBias.Value, koniec, (long)nuEpoki.Value, (double)nuBłądMin.Value);
            }
            else //aktualizacja sieci istniejącej
            {
                sn.biasP = (double)nuBias.Value;
                sn.momentumP = (double)nuMomentum.Value;
                sn.learning_rateP = (double)nuLearningRate.Value;
                sn.dół_wagP = (double)nuDółWag.Value;
                sn.góra_wagP = (double)nuGóraWag.Value;
                sn.błąd_minP = (double)nuBłądMin.Value;
                sn.ile_epokP = (long)nuEpoki.Value;
                if (cbSposób.SelectedIndex == 0)
                    sn.warunek_końcaP = true;
                else
                    sn.warunek_końcaP = false;
            }
            adres.snP = sn;
            this.Close();
        }
    }
}
