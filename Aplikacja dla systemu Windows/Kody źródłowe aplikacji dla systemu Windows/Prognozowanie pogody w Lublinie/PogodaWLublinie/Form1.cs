using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PogodaWLublinie
{
    public partial class foPogoda : Form
    {
        private SiećNeuronowa.SiećNeuronowa sn;
        public SiećNeuronowa.SiećNeuronowa snP
        {
            get
            {
                return sn;
            }
            set
            {
                sn = value;
            }
        }

        private ParametrySieci ps;
        private double[, ,] dane;

        public foPogoda()
        {
            InitializeComponent();
            dane = new double[1, 4, 15];
        }

        private void foPogoda_Load(object sender, EventArgs e)
        {
            cbMiasto.SelectedIndex = 0;
            cbDzień.SelectedIndex = 0;
            cbPoraRokuGłówna.SelectedIndex = 0;
        }

        private void ącyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sn == null)
            {
                MessageBox.Show("Nie utworzono sieci!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (!TestujPlik())
                {
                    sn.plik_uczącyP = null;
                    return;
                }
                sn.plik_uczącyP = openFileDialog1.FileName;
                sn.WczytajZbiórUczący(openFileDialog1.FileName);
            }
        }

        public bool TestujPlik() //true - uczący i testujący, false - wag
        {
            //sprawdzenie czy plik jest poprawnym plikiem uczącym
            StreamReader sr = new StreamReader(openFileDialog1.FileName);
            while (!sr.EndOfStream)
            {
                string linia = sr.ReadLine();
                long[] struktura = sn.struktura_sieciP;
                if (LiczSłowa(linia) != struktura[0] + struktura[struktura.Length - 1]) //sprawdzenie czy liczba danych przekazywanych do sieci jest zgodna z sumąwejścia i wyjścia
                {
                    MessageBox.Show("Liczba danych w pliku nie zgadza się z liczbą neuronów na warstwie wejściowej + wyjściowej. Wczytywanie przerwane.", "Błąd wczytywania zbioru uczącego", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sr.Close();
                    return false;
                }
                double[] tmp = Rozbij(linia, (int)(struktura[0] + struktura[struktura.Length - 1]));
                if (tmp[0] == -9999E100) //sprawdzenie, czy w pliku są poprawne wartości
                {
                    MessageBox.Show("Jedna lub więcej wartości w pliku nie są poprawnymi liczbami. Wczytywanie przerwane.", "Błąd wczytywania zbioru uczącego", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sr.Close();
                    return false;
                }
            }
            sr.Close();
            return true;
        }

        private void gbDane_Enter(object sender, EventArgs e)
        {
            
        }

        private void metrycznyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (metrycznyToolStripMenuItem.Checked == false)
            {
                metrycznyToolStripMenuItem.Checked = true;
                angielskiToolStripMenuItem.Checked = false;

                tbTempMax.Text = (5.0 / 9.0 * (double.Parse(tbTempMax.Text) - 32)).ToString();
                tbTempMin.Text = (5.0 / 9.0 * (double.Parse(tbTempMin.Text) - 32)).ToString();
                tbTempPR.Text = (5.0 / 9.0 * (double.Parse(tbTempPR.Text) - 32)).ToString();
                tbWiatrPr.Text = (double.Parse(tbWiatrPr.Text) * 0.5144).ToString();

                tbTempMaxW.Text = (5.0 / 9.0 * (double.Parse(tbTempMaxW.Text) - 32)).ToString();
                tbTempMinW.Text = (5.0 / 9.0 * (double.Parse(tbTempMinW.Text) - 32)).ToString();
            }
        }

        private void buLicz_Click(object sender, EventArgs e)
        {
            if(!File.Exists("opis_sieci.txt"))
            {
                MessageBox.Show("Brak pliku z opisem sieci neuronowych. PRzerwanie działania sieci.");
                return;
            }
            StreamReader opis = new StreamReader("opis_sieci.txt");
            SiećNeuronowa.SiećNeuronowa[] sne;
            int[] ow;
            sne = new SiećNeuronowa.SiećNeuronowa[10];
            for (int i = 0; i < 3; i++)
            {
                ow = new int[int.Parse(opis.ReadLine()) + 2];
                if (i == 2)
                    ow[0] = 32;
                else
                    ow[0] = 16;
                for (int j = 0; j < ow.Length - 2; j++)
                    ow[j + 1] = int.Parse(opis.ReadLine());
                ow[ow.Length - 1] = 1;
                sne[i] = new SiećNeuronowa.SiećNeuronowa(ow, 0.3, 0.1, -0.5, 0.5, double.Parse(opis.ReadLine()), true, 1, 0.01);
            }
            opis.Close();
            if (sne != null)
            {
                //jeżeli złe jednostki zamień
                double[, ,] temp = new double[5, 4, 15];
                Array.Copy(dane, temp, dane.Length);
                if (metrycznyToolStripMenuItem.Checked)
                {
                    //zamiana jednostek
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            for (int k = 1; k <= 7; k++)
                            {
                                switch (k)
                                {
                                    case 1:
                                    case 2:
                                    case 3:
                                    case 4:
                                        temp[i, j, k] = 9.0 / 5.0 * temp[i, j, k] + 32; //temperatura
                                        break;
                                    case 6:
                                        temp[i, j, k] = temp[i, j, k] * 1.9438; //wiatr
                                        break;

                                }
                            }
                        }
                    }
                }
                //normalizuj i twórz wejście
                string[] linia = new string[9];
                for (int j = 0; j < 4; j++)
                {
                    for (int i = 0; i < 1; i++)
                    {
                        //temp. punktu rosy
                        linia[2] += (NormalizacjaLiniowa(temp[i, j, 4], -30, 80, 0, 1)).ToString() + " ";
                        //ciśnienie
                        linia[0] += (NormalizacjaLiniowa(temp[i, j, 5], 965, 1060, 0, 1)).ToString() + " ";
                        linia[1] += (NormalizacjaLiniowa(temp[i, j, 5], 965, 1060, 0, 1)).ToString() + " ";
                        linia[2] += (NormalizacjaLiniowa(temp[i, j, 5], 965, 1060, 0, 1)).ToString() + " ";
                        //prędkość wiatru
                        linia[2] += (NormalizacjaLiniowa(temp[i, j, 6], 0, 25, -1, 1)).ToString() + " ";
                        //temp. maks
                        linia[0] += (NormalizacjaLiniowa(temp[i, j, 2], -22, 104, 0, 1)).ToString() + " ";
                        linia[1] += (NormalizacjaLiniowa(temp[i, j, 2], -22, 104, 0, 1)).ToString() + " ";
                        linia[2] += (NormalizacjaLiniowa(temp[i, j, 2], -22, 104, 0, 1)).ToString() + " ";
                        //temp min
                        linia[0] += (NormalizacjaLiniowa(temp[i, j, 3], -49, 77, 0, 1)).ToString() + " ";
                        linia[1] += (NormalizacjaLiniowa(temp[i, j, 3], -49, 77, 0, 1)).ToString() + " ";
                        linia[2] += (NormalizacjaLiniowa(temp[i, j, 3], -49, 77, 0, 1)).ToString() + " ";
                        if (temp[i, j, 13] == 1) //mgła
                        {

                        }
                        else
                        {

                        }

                        if (temp[i, j, 9] == 1) //deszcz
                        {
                            linia[2] += "1 ";
                        }
                        else
                        {
                            linia[2] += "-1 ";
                        }
                        if (temp[i, j, 12] == 1) //śnieg
                        {
                            linia[2] += "1 ";
                        }
                        else
                        {
                            linia[2] += "-1 ";
                        }

                        if (temp[i, j, 11] == 1) //grad
                        {

                        }
                        else
                        {
                        }
                        if (temp[i, j, 10] == 1) //burza
                        {

                        }
                        else
                        {

                        }

                        //zonal indeks
                        linia[0] += (NormalizacjaLiniowa(temp[i, j, 14], -11, 17, 0, 1)).ToString() + " ";
                        linia[1] += (NormalizacjaLiniowa(temp[i, j, 14], -11, 17, 0, 1)).ToString() + " ";
                        linia[2] += (NormalizacjaLiniowa(temp[i, j, 14], -11, 17, 0, 1)).ToString() + " ";
                    }
                }
                //wczytaj wagi
                StreamReader[] parametry = new StreamReader[10];
                if(!File.Exists("pliki_wag.txt"))
                {
                    MessageBox.Show("Nie znaleziono listy plików wag. Działanie sieci przerwano.");
                    return;
                }
                StreamReader pliki_wag = new StreamReader("pliki_wag.txt");
                List<string> lista_plików_wag = new List<string>();
                while (!pliki_wag.EndOfStream)
                {
                    string nazwa_pliku = pliki_wag.ReadLine();
                    if (!File.Exists(nazwa_pliku))
                    {
                        MessageBox.Show("Nie znaleziono jednego z plików wag. Działanie sieci przerwano.");
                        return;
                    }
                    lista_plików_wag.Add(nazwa_pliku);
                }
                if (lista_plików_wag.Count != 18)
                {
                    MessageBox.Show("Zła liczba wpisów na liście plików wag. Działanie sieci przerwano.");
                    return;
                }
                pliki_wag.Close();
                switch (cbPoraRokuGłówna.SelectedIndex)
                {
                    case 0:
                        parametry[0] = new StreamReader(lista_plików_wag[0]);
                        parametry[1] = new StreamReader(lista_plików_wag[1]);
                        parametry[2] = new StreamReader(lista_plików_wag[16]);
                        break;
                    case 1:
                        parametry[0] = new StreamReader(lista_plików_wag[2]);
                        parametry[1] = new StreamReader(lista_plików_wag[3]);
                        parametry[2] = new StreamReader(lista_plików_wag[16]);
                        break;
                    case 2:
                        parametry[0] = new StreamReader(lista_plików_wag[4]);
                        parametry[1] = new StreamReader(lista_plików_wag[5]);
                        parametry[2] = new StreamReader(lista_plików_wag[16]);
                        break;
                    case 3:
                        parametry[0] = new StreamReader(lista_plików_wag[6]);
                        parametry[1] = new StreamReader(lista_plików_wag[7]);
                        parametry[2] = new StreamReader(lista_plików_wag[17]);
                        break;
                    case 4:
                        parametry[0] = new StreamReader(lista_plików_wag[8]);
                        parametry[1] = new StreamReader(lista_plików_wag[9]);
                        parametry[2] = new StreamReader(lista_plików_wag[17]);
                        break;
                    case 5:
                        parametry[0] = new StreamReader(lista_plików_wag[10]);
                        parametry[1] = new StreamReader(lista_plików_wag[11]);
                        parametry[2] = new StreamReader(lista_plików_wag[17]);
                        break;
                    case 6:
                        parametry[0] = new StreamReader(lista_plików_wag[12]);
                        parametry[1] = new StreamReader(lista_plików_wag[13]);
                        parametry[2] = new StreamReader(lista_plików_wag[16]);
                        break;
                    case 7:
                        parametry[0] = new StreamReader(lista_plików_wag[14]);
                        parametry[1] = new StreamReader(lista_plików_wag[15]);
                        parametry[2] = new StreamReader(lista_plików_wag[16]);
                        break;
                }
                double[][] linie_wag = new double[10][];
                int[] ilość_wejść = new int[9];
                ilość_wejść[0] = (int)sne[0].struktura_sieciP[0];
                ilość_wejść[1] = (int)sne[1].struktura_sieciP[0];
                ilość_wejść[2] = (int)sne[2].struktura_sieciP[0];
                //1 parametr tylko Lublin temp MAX
                for (int i = 0; i < 3; i++)
                {
                    string wagi = parametry[i].ReadLine();
                    linie_wag[i] = Rozbij(wagi, IleSłów(wagi));
                }
                for (int i = 0; i < 3; i++)
                {
                    if (!sne[i].UstawWagiRęcznie(linie_wag[i]))
                    {
                        MessageBox.Show("Błąd wczytywania wag.");
                        return;
                    }
                }
                for (int i = 0; i < 3; i++)
                    parametry[i].Close();
                //uruchom sieć
                //double[] wejście = Rozbij(linia, 76); //dla całości
                double[][] wejście = new double[10][];
                for (int i = 0; i < 3; i++)
                    wejście[i] = Rozbij(linia[i], ilość_wejść[i]); //dla 1 parametru
                for (int i = 0; i < 3; i++)
                    if (!sne[i].UstawWartościPoczątkowe(wejście[i]))
                    {
                        MessageBox.Show("Struktura sieci niezgodna z danymi wejściowymi");
                        return;
                    }

                double[][] wyniki = new double[10][];
                for (int i = 0; i < 3; i++)
                    wyniki[i] = sne[i].UruchomSieć();
                //zdenormalizuj
                wyniki[2][0] = NormalizacjaLiniowa(wyniki[2][0], 0, 1, 965, 1060); //ciśnienie
                wyniki[0][0] = NormalizacjaLiniowa(wyniki[0][0], 0, 1, -22, 104); //temp. maks
                wyniki[1][0] = NormalizacjaLiniowa(wyniki[1][0], 0, 1, -49, 77); //temp. min
                //zamień jednostki jeśli trzeba
                if (metrycznyToolStripMenuItem.Checked)
                {
                    wyniki[0][0] = 5.0 / 9.0 * (wyniki[0][0] - 32);
                    wyniki[1][0] = 5.0 / 9.0 * (wyniki[1][0] - 32);
                }
                //pokaż wyniki
                tbTempMaxW.Text = wyniki[0][0].ToString();
                tbTempMinW.Text = wyniki[1][0].ToString();
                tbCiśnienieW.Text = wyniki[2][0].ToString();
            }
            else
            {
                MessageBox.Show("Sieć neuronowa nie jest utworzona!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double[] Rozbij(string linia, int rozmiar)
        {
            if (linia[linia.Length - 1] != ' ')
                linia = linia + " ";
            double[] wynik = new double[rozmiar];
            int indeks = 0;
            string tmp = null;
            for (int i = 0; i < linia.Length; i++)
            {
                if (linia[i] == ' ' || i == linia.Length)
                {
                    if (!double.TryParse(tmp,out wynik[indeks]))
                    {
                        wynik[0] = -9999E100; //wartość oznaczająca niepowodzenie
                    }
                    tmp = null;
                    indeks++;
                }
                else
                {
                    if (linia[i] == '.')
                        tmp = tmp + ',';
                    else
                        tmp = tmp + linia[i];
                }
            }
            return wynik;
        }

        private double NormalizacjaLiniowa(double co, double src_min, double src_max, double dest_min, double dest_max)
        {
            //sprowadzanie przedziału do od 0 do czegoś
            src_max -= src_min;
            co -= src_min;
            src_min = 0;
            //jaką część maxa stanowi co
            double wskaźnik = co / src_max;
            double kopia = dest_min;
            dest_max -= kopia;
            dest_min = 0;
            double znormalizowana = dest_max * wskaźnik;
            return znormalizowana + kopia;
        }

        private void tbWiatrPr_Leave(object sender, EventArgs e)
        {
            TextBox temp = (TextBox)sender;
            double wynik;
            if (!double.TryParse(temp.Text, out wynik))
            {
                MessageBox.Show("Podana wartość nie jest liczbą.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                temp.Focus();
            }
            else
                Zapisz();
        }

        public void Zapisz()
        {
            dane[cbMiasto.SelectedIndex, cbDzień.SelectedIndex, 0] = cbPoraRokuGłówna.SelectedIndex;
            dane[cbMiasto.SelectedIndex, cbDzień.SelectedIndex, 2] = double.Parse(tbTempMax.Text);
            dane[cbMiasto.SelectedIndex, cbDzień.SelectedIndex, 3] = double.Parse(tbTempMin.Text);
            dane[cbMiasto.SelectedIndex, cbDzień.SelectedIndex, 4] = double.Parse(tbTempPR.Text);
            dane[cbMiasto.SelectedIndex, cbDzień.SelectedIndex, 5] = double.Parse(tbCiśnienie.Text);
            dane[cbMiasto.SelectedIndex, cbDzień.SelectedIndex, 6] = double.Parse(tbWiatrPr.Text);
            if(cbDeszcz.Checked)
                dane[cbMiasto.SelectedIndex, cbDzień.SelectedIndex, 9] = 1;
            else
                dane[cbMiasto.SelectedIndex, cbDzień.SelectedIndex, 9] = 0;
            if(cbŚnieg.Checked)
                dane[cbMiasto.SelectedIndex, cbDzień.SelectedIndex, 12] = 1;
            else
                dane[cbMiasto.SelectedIndex, cbDzień.SelectedIndex, 12] = 0;
            dane[cbMiasto.SelectedIndex, cbDzień.SelectedIndex, 14] = double.Parse(tbZonalIndeks.Text);
        }

        private void cbMgła_CheckedChanged(object sender, EventArgs e)
        {
            //Zapisz();
        }

        private void cbPoraRoku_TextChanged(object sender, EventArgs e)
        {
            Zapisz();
        }

        private void cbMiasto_TextChanged(object sender, EventArgs e)
        {
            if (cbMiasto.SelectedIndex >= 0 && cbDzień.SelectedIndex >= 0)
            {
                cbPoraRokuGłówna.SelectedIndex = (int)dane[cbMiasto.SelectedIndex, cbDzień.SelectedIndex, 0];
                tbTempMax.Text = dane[cbMiasto.SelectedIndex, cbDzień.SelectedIndex, 2].ToString();
                tbTempMin.Text = dane[cbMiasto.SelectedIndex, cbDzień.SelectedIndex, 3].ToString();
                tbTempPR.Text = dane[cbMiasto.SelectedIndex, cbDzień.SelectedIndex, 4].ToString();
                tbCiśnienie.Text = dane[cbMiasto.SelectedIndex, cbDzień.SelectedIndex, 5].ToString();
                tbWiatrPr.Text = dane[cbMiasto.SelectedIndex, cbDzień.SelectedIndex, 6].ToString();
                if (dane[cbMiasto.SelectedIndex, cbDzień.SelectedIndex, 9] == 1)
                    cbDeszcz.Checked = true;
                else
                    cbDeszcz.Checked = false;
                if (dane[cbMiasto.SelectedIndex, cbDzień.SelectedIndex, 12] == 1)
                    cbŚnieg.Checked = true;
                else
                    cbŚnieg.Checked = false;
                tbZonalIndeks.Text = dane[cbMiasto.SelectedIndex, cbDzień.SelectedIndex, 14].ToString();
            }
        }

        private void wstawParametryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ps = new ParametrySieci(sn, this);
            ps.Visible = true;
            this.Enabled = false;
        }

        private void cbPoraRoku_SelectedIndexChanged(object sender, EventArgs e)
        {
            Zapisz();
        }

        private void cbMgła_Leave(object sender, EventArgs e)
        {
            Zapisz();
        }

        private void cbPoraRoku_Leave(object sender, EventArgs e)
        {
            Zapisz();
        }

        private void cbWiatrKi_Leave(object sender, EventArgs e)
        {
            Zapisz();
        }

        private void angielskiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (angielskiToolStripMenuItem.Checked == false)
            {
                metrycznyToolStripMenuItem.Checked = false;
                angielskiToolStripMenuItem.Checked = true;

                tbTempMax.Text = (9.0 / 5.0 * double.Parse(tbTempMax.Text) + 32).ToString();
                tbTempMin.Text = (9.0 / 5.0 * double.Parse(tbTempMin.Text) + 32).ToString();
                tbTempPR.Text = (9.0 / 5.0 * double.Parse(tbTempPR.Text) + 32).ToString();
                tbWiatrPr.Text = (double.Parse(tbWiatrPr.Text) * 1.9438).ToString();

                tbTempMaxW.Text = (9.0 / 5.0 * double.Parse(tbTempMaxW.Text) + 32).ToString();
                tbTempMinW.Text = (9.0 / 5.0 * double.Parse(tbTempMinW.Text) + 32).ToString();
            }
        }

        private void uczToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sn != null)
            {
                UczTestuj ucz = new UczTestuj(this, sn);
                ucz.Visible = true;
                this.Enabled = false;
            }
            else
            {
                MessageBox.Show("Nie utworzono sieci!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void siećToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public long LiczSłowa(string linia)
        {
            while (linia[linia.Length - 1] == ' ')
                linia = linia.Substring(0, linia.Length - 1);
            int ile = 0;
            for (int i = 0; i < linia.Length; i++)
            {
                if (linia[i] == ' ')
                    ile++;
            }
            ile++;
            return ile;
        }

        private void wczytajPlikTestującyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sn == null)
            {
                MessageBox.Show("Nie utworzono sieci!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (!TestujPlik())
                {
                    sn.plik_testującyP = null;
                    return;
                }
                sn.plik_testującyP = openFileDialog1.FileName;
                sn.WczytajZbiórTestowy(openFileDialog1.FileName);
            }
        }

        private void zapiszPlikWagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sn == null)
            {
                MessageBox.Show("Nie utworzono sieci!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                sn.ZapiszWagi(saveFileDialog1.FileName);
            }
        }

        private void wczytajPlikWagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sn == null)
            {
                MessageBox.Show("Nie utworzono sieci!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                double[] temp = new double[0];
                while (!sr.EndOfStream)
                {
                    string linia = sr.ReadLine();
                    temp = Rozbij(linia, (int)LiczSłowa(linia));
                    if (temp[0] == -9999E-999)
                    {
                        MessageBox.Show("Jedna lub więcej wartości w pliku nie są poprawnymi liczbami. Wczytywanie przerwane.", "Błąd wczytywania zbioru uczącego", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        sr.Close();
                        return;
                    }
                }
                sr.Close();
                if (!sn.UstawWagiRęcznie(temp))
                {
                    MessageBox.Show("Brak zgodności liczby wag w sieci z wielkością tablicy wag. Dane nie zostały wczytane.", "Błąd wczytywania zbioru uczącego", MessageBoxButtons.OK, MessageBoxIcon.Error);  
                }
            }
        }

        private void cbPoraRoku_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void gbWyniki_Enter(object sender, EventArgs e)
        {

        }

        private void zapiszScenariuszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("scenariusze.txt", true);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 14; k++)
                    {
                        sw.Write(dane[i, j, k]);
                        sw.Write(" ");
                    }
                    sw.WriteLine();
                }
            }
            sw.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void tbTempMin_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbZonalIndeks_TextChanged(object sender, EventArgs e)
        {

        }

        public int IleSłów(string linia)
        {
            while (linia[linia.Length - 1] == ' ')
                linia = linia.Substring(0, linia.Length - 1);
            int ile = 0;
            for (int i = 0; i < linia.Length; i++)
            {
                if (linia[i] == ' ')
                    ile++;
            }
            ile++;
            return ile;
        }
    }
}
