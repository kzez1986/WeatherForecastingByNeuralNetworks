using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Prognoza_pogody_dla_Lublina
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Lublin(string nazwa, string nazwa2)
        {

            string temp;
            string dana = "";
            double min_p = 0, max_p = 0, cis_p = 0, tpr_p = 0, w_p = 0, o_p = 0;
            StreamReader indeks = new StreamReader("indeks_zima.txt");
            StreamReader sr = new StreamReader(nazwa);
            StreamWriter sw = new StreamWriter(nazwa2);
            StreamReader sr2 = new StreamReader("kierunek_wiatru.txt");
            double wynik;
            DateTime dt = new DateTime(1986, 1, 1);
            while (!sr.EndOfStream)
            {
                temp = sr.ReadLine(); //wczytaj linię z danymi 1 dnia
                int miesiąc = int.Parse(temp[18].ToString() + temp[19].ToString());
                int dzień = int.Parse(temp[20].ToString() + temp[21].ToString());
                //if (dt.Day != dzień)
                //    MessageBox.Show("Błąd");
                //dt = dt.AddDays(1.0);
                //konwersja dnia na porę roku
                /*
                if (miesiąc == 2 && dzień >= 16 || miesiąc == 3) //przedwiośnie
                    sw.Write("0,6 -1 -1 0,3 ");
                else if (miesiąc == 4 || miesiąc == 5 && dzień <= 15) //wiosna
                    sw.Write("0,7 0,1 -1 0,2 ");
                else if (miesiąc == 5 && dzień > 15 || miesiąc == 6 && dzień <= 15) //przedlecie
                    sw.Write("0,4 0,6 -1 -1 ");
                else if (miesiąc == 6 && dzień > 15 || miesiąc == 7 || miesiąc == 8 && dzień <= 15) //lato
                    sw.Write("0,2 0,8 -1 -1 ");
                else if (miesiąc == 8 && dzień > 15 || miesiąc == 9 && dzień <= 20) //polecie
                    sw.Write("-1 0,7 0,3 -1 ");
                else if (miesiąc == 9 && dzień > 20 || miesiąc == 10) //jesień
                    sw.Write("-1 0,1 0,8 0,1 ");
                else if (miesiąc == 11 || miesiąc == 12 && dzień <= 10) //przedzimie
                    sw.Write("-1 -1 0,5 0,5 ");
                else
                    sw.Write("0,1 -1 0,2 0,7 ");
                */
                //temperatura punktu rosy (35 - 40)
                dana = "";
                for (int i = 35; i <= 40; i++)
                {
                    if (temp[i] != ' ' && temp[i] != '.')
                        dana = dana + temp[i];
                    else if (temp[i] == '.')
                        dana = dana + ',';
                }
                wynik = double.Parse(dana);
                if (wynik != 9999.9)
                    //sw.Write(wynik);
                    sw.Write(NormalizacjaLiniowa(wynik, -30, 80, 0, 1));
                else
                    //sw.Write(tpr_p);
                    sw.Write(NormalizacjaLiniowa(tpr_p, -30, 80, 0, 1));
                sw.Write(" ");
                tpr_p = wynik;
                //ciśnienie (46 - 51)
                dana = "";
                for (int i = 46; i <= 51; i++)
                {
                    if (temp[i] != ' ' && temp[i] != '.')
                        dana = dana + temp[i];
                    else if (temp[i] == '.')
                        dana = dana + ',';
                }
                wynik = double.Parse(dana);
                if (wynik != 9999.9)
                    //sw.Write(wynik);
                    sw.Write(NormalizacjaLiniowa(wynik, 965, 1060, 0, 1));
                else
                    //sw.Write(cis_p);
                    sw.Write(NormalizacjaLiniowa(cis_p, 965, 1060, 0, 1));
                sw.Write(" ");
                cis_p = wynik;
                //prędkość wiatru (78-82)
                dana = "";
                for (int i = 78; i <= 82; i++)
                {
                    if (temp[i] != ' ' && temp[i] != '.')
                        dana = dana + temp[i];
                    else if (temp[i] == '.')
                        dana = dana + ',';
                }
                wynik = double.Parse(dana);
                if (wynik != 999.9)
                    //sw.Write(wynik);
                    sw.Write(NormalizacjaLiniowa(wynik, 0, 25, 0, 1));
                else
                    //sw.Write(w_p);
                    sw.Write(NormalizacjaLiniowa(w_p, 0, 25, 0, 1));
                sw.Write(" ");
                w_p = wynik;
                //maksymalna temperatura (102-107)
                dana = "";
                for (int i = 102; i <= 107; i++)
                {
                    if (temp[i] != ' ' && temp[i] != '.')
                        dana = dana + temp[i];
                    else if (temp[i] == '.')
                        dana = dana + ',';
                }
                wynik = double.Parse(dana);
                if (wynik != 9999.9)
                    //sw.Write(wynik);
                    sw.Write(NormalizacjaLiniowa(wynik, -22, 104, 0, 1));
                else
                    //sw.Write(max_p);
                    sw.Write(NormalizacjaLiniowa(max_p, -22, 104, 0, 1));
                sw.Write(" ");
                max_p = wynik;

                //minimalna temperatura (110-115)
                dana = "";
                for (int i = 110; i <= 115; i++)
                {
                    if (temp[i] != ' ' && temp[i] != '.')
                        dana = dana + temp[i];
                    else if (temp[i] == '.')
                        dana = dana + ',';
                }
                wynik = double.Parse(dana);
                if (wynik != 9999.9)
                    //sw.Write(wynik);
                    sw.Write(NormalizacjaLiniowa(wynik, -49, 77, 0, 1));
                else
                    //sw.Write(min_p);
                    sw.Write(NormalizacjaLiniowa(min_p, -49, 77, 0, 1));
                sw.Write(" ");
                min_p = wynik;
                //opady (118-122)
                dana = "";
                for (int i = 118; i <= 122; i++)
                {
                    if (temp[i] != ' ' && temp[i] != '.')
                        dana = dana + temp[i];
                    else if (temp[i] == '.')
                        dana = dana + ',';
                }
                wynik = double.Parse(dana);
                if (wynik < 99)
                    //sw.Write(wynik);
                    sw.Write(NormalizacjaLiniowa(wynik, 0, 5, -1, 1));
                else
                    //sw.Write(o_p);
                    sw.Write(NormalizacjaLiniowa(o_p, 0, 5, -1, 1));
                sw.Write(" ");
                o_p = wynik;
                //132 - 136 zjawiska pogodowe
                for (int i = 132; i <= 136; i++)
                {
                    if (temp[i] == '0')
                        sw.Write("-1");
                    else
                        sw.Write("1");
                    sw.Write(" ");
                }
                //indeks cyrkulacji
                double indeks_double = double.Parse(indeks.ReadLine());
                sw.Write(NormalizacjaLiniowa(indeks_double, -11, 17, 0, 1));
                sw.Write(" ");
                /*
                string kierunek = sr2.ReadLine();
                try
                {
                    if (kierunek.Length == 0 || kierunek[0] == 'B')
                    {
                        sw.Write("-1 -1 -1 -1 ");
                    }
                    else
                    {
                        if (kierunek[0] == 'N')
                            sw.Write("1 -1 ");
                        else if (kierunek[0] == 'S')
                            sw.Write("-1 1 ");
                        else
                            sw.Write("-1 -1 ");
                        if (kierunek.Length == 1)
                        {
                            if (kierunek[0] == 'W')
                                sw.Write("1 -1 ");
                            else if (kierunek[0] == 'E')
                                sw.Write("-1 1 ");
                            else
                                sw.Write("-1 -1 ");
                        }
                        else
                        {
                            if (kierunek[1] == 'W')
                                sw.Write("1 -1 ");
                            else if (kierunek[1] == 'E')
                                sw.Write("-1 1 ");
                            else
                                sw.Write("-1 -1 ");
                        }
                    }
                }
                catch (Exception blad)
                {
                    MessageBox.Show("Blad");
                }
                */
                sw.Write("\n");
            }
            sr.Close();
            sw.Close();
            sr2.Close();
            indeks.Close();
        }

        public void OkresCiepłyZimny()
        {
            StreamReader sr_Lublin = new StreamReader("Lublin_dane.txt");
            StreamWriter[] wynik = new StreamWriter[2];
            wynik[0] = new StreamWriter("Lublin_ciepły.txt");
            wynik[1] = new StreamWriter("Lublin_zimny.txt");
            //indeks zapisz
            StreamWriter[] indeksy = new StreamWriter[2];
            indeksy[0] = new StreamWriter("indeks_ciepły.txt");
            indeksy[1] = new StreamWriter("indeks_zimny.txt");
            StreamReader indeks = new StreamReader("indeks.txt");
            DateTime dt = new DateTime(1986, 1, 1);
            string ind;
            string temp;
            while (!sr_Lublin.EndOfStream)
            {
                temp = sr_Lublin.ReadLine(); //wczytaj linię z danymi 1 dnia
                ind = indeks.ReadLine();
                int miesiąc = int.Parse(temp[18].ToString() + temp[19].ToString());
                int dzień = int.Parse(temp[20].ToString() + temp[21].ToString());
                //if (dt.Day != dzień)
                //    MessageBox.Show("Błąd");
                dt = dt.AddDays(1.0);

                //konwersja dnia na porę roku
                if ((miesiąc == 5 && dzień >= 16) || ((miesiąc > 5 && miesiąc < 9) || (miesiąc == 9 && dzień <= 20))) //okres ciepły
                {
                    wynik[0].WriteLine(temp);
                    indeksy[0].WriteLine(ind);
                }
                else //zimna pora
                {
                    wynik[1].WriteLine(temp);
                    indeksy[1].WriteLine(ind);
                }
            }
            for (int i = 0; i < 2; i++)
                indeksy[i].Close();
            indeks.Close();
            sr_Lublin.Close();
            //zamknij otwwarte strumienie
            for (int i = 0; i < 2; i++)
                wynik[i].Close();
        }
        public void  PoryRoku()
        {

            string[] temp = new string[5];
            StreamReader sr_Lublin = new StreamReader("Lublin_dane.txt");
            StreamReader sr_Legnica = new StreamReader("Legnica_dane.txt");
            StreamReader sr_Miskolc = new StreamReader("Miskolc_dane.txt");
            StreamReader sr_Mogilev = new StreamReader("Mogilev_dane.txt");
            StreamReader sr_Suwałki = new StreamReader("Suwałki_dane.txt");
            //zapisz dane do plików wybranych danych z podziałem na pory roku
            StreamWriter[,] wynik = new StreamWriter[5, 8];
            wynik[0, 0] = new StreamWriter("Lublin_zima.txt");
            wynik[0, 1] = new StreamWriter("Lublin_przedwiośnie.txt");
            wynik[0, 2] = new StreamWriter("Lublin_wiosna.txt");
            wynik[0, 3] = new StreamWriter("Lublin_przedlecie.txt");
            wynik[0, 4] = new StreamWriter("Lublin_lato.txt");
            wynik[0, 5] = new StreamWriter("Lublin_polecie.txt");
            wynik[0, 6] = new StreamWriter("Lublin_jesień.txt");
            wynik[0, 7] = new StreamWriter("Lublin_przedzimie.txt");
            wynik[1, 0] = new StreamWriter("Legnica_zima.txt");
            wynik[1, 1] = new StreamWriter("Legnica_przedwiośnie.txt");
            wynik[1, 2] = new StreamWriter("Legnica_wiosna.txt");
            wynik[1, 3] = new StreamWriter("Legnica_przedlecie.txt");
            wynik[1, 4] = new StreamWriter("Legnica_lato.txt");
            wynik[1, 5] = new StreamWriter("Legnica_polecie.txt");
            wynik[1, 6] = new StreamWriter("Legnica_jesień.txt");
            wynik[1, 7] = new StreamWriter("Legnica_przedzimie.txt");
            wynik[2, 0] = new StreamWriter("Mogilev_zima.txt");
            wynik[2, 1] = new StreamWriter("Mogilev_przedwiośnie.txt");
            wynik[2, 2] = new StreamWriter("Mogilev_wiosna.txt");
            wynik[2, 3] = new StreamWriter("Mogilev_przedlecie.txt");
            wynik[2, 4] = new StreamWriter("Mogilev_lato.txt");
            wynik[2, 5] = new StreamWriter("Mogilev_polecie.txt");
            wynik[2, 6] = new StreamWriter("Mogilev_jesień.txt");
            wynik[2, 7] = new StreamWriter("Mogilev_przedzimie.txt");
            wynik[3, 0] = new StreamWriter("Miskolc_zima.txt");
            wynik[3, 1] = new StreamWriter("Miskolc_przedwiośnie.txt");
            wynik[3, 2] = new StreamWriter("Miskolc_wiosna.txt");
            wynik[3, 3] = new StreamWriter("Miskolc_przedlecie.txt");
            wynik[3, 4] = new StreamWriter("Miskolc_lato.txt");
            wynik[3, 5] = new StreamWriter("Miskolc_polecie.txt");
            wynik[3, 6] = new StreamWriter("Miskolc_jesień.txt");
            wynik[3, 7] = new StreamWriter("Miskolc_przedzimie.txt");
            wynik[4, 0] = new StreamWriter("Suwałki_zima.txt");
            wynik[4, 1] = new StreamWriter("Suwałki_przedwiośnie.txt");
            wynik[4, 2] = new StreamWriter("Suwałki_wiosna.txt");
            wynik[4, 3] = new StreamWriter("Suwałki_przedlecie.txt");
            wynik[4, 4] = new StreamWriter("Suwałki_lato.txt");
            wynik[4, 5] = new StreamWriter("Suwałki_polecie.txt");
            wynik[4, 6] = new StreamWriter("Suwałki_jesień.txt");
            wynik[4, 7] = new StreamWriter("Suwałki_przedzimie.txt");
            //indeks zapisz
            StreamWriter[] indeksy = new StreamWriter[8];
            indeksy[0] = new StreamWriter("indeks_zima.txt");
            indeksy[1] = new StreamWriter("indeks_przedwiośnie.txt");
            indeksy[2] = new StreamWriter("indeks_wiosna.txt");
            indeksy[3] = new StreamWriter("indeks_przedlecie.txt");
            indeksy[4] = new StreamWriter("indeks_lato.txt");
            indeksy[5] = new StreamWriter("indeks_polecie.txt");
            indeksy[6] = new StreamWriter("indeks_jesień.txt");
            indeksy[7] = new StreamWriter("indeks_przedzimie.txt");
            StreamReader indeks = new StreamReader("indeks.txt");

            DateTime dt = new DateTime(1986, 1, 1);
            string ind;
            while (!sr_Lublin.EndOfStream)
            {
                temp[0] = sr_Lublin.ReadLine(); //wczytaj linię z danymi 1 dnia
                temp[1] = sr_Legnica.ReadLine();
                temp[2] = sr_Miskolc.ReadLine();
                temp[3] = sr_Mogilev.ReadLine();
                temp[4] = sr_Suwałki.ReadLine();
                ind = indeks.ReadLine();
                int miesiąc = int.Parse(temp[0][18].ToString() + temp[0][19].ToString());
                int dzień = int.Parse(temp[0][20].ToString() + temp[0][21].ToString());
                //if (dt.Day != dzień)
                //    MessageBox.Show("Błąd");
                dt = dt.AddDays(1.0);

                //konwersja dnia na porę roku
                if (miesiąc == 2 && dzień >= 16 || miesiąc == 3) //przedwiośnie
                {
                    for (int i = 0; i < 5; i++)
                        wynik[i, 1].WriteLine(temp[i]);
                    indeksy[1].WriteLine(ind);
                }
                else if (miesiąc == 4 || miesiąc == 5 && dzień <= 15) //wiosna
                {
                    for (int i = 0; i < 5; i++)
                        wynik[i, 2].WriteLine(temp[i]);
                    indeksy[2].WriteLine(ind);
                }
                else if (miesiąc == 5 && dzień > 15 || miesiąc == 6 && dzień <= 15) //przedlecie
                {
                    for (int i = 0; i < 5; i++)
                        wynik[i, 3].WriteLine(temp[i]);
                    indeksy[3].WriteLine(ind);
                }
                else if (miesiąc == 6 && dzień > 15 || miesiąc == 7 || miesiąc == 8 && dzień <= 15) //lato
                {
                    for (int i = 0; i < 5; i++)
                        wynik[i, 4].WriteLine(temp[i]);
                    indeksy[4].WriteLine(ind);
                }
                else if (miesiąc == 8 && dzień > 15 || miesiąc == 9 && dzień <= 20) //polecie
                {
                    for (int i = 0; i < 5; i++)
                        wynik[i, 5].WriteLine(temp[i]);
                    indeksy[5].WriteLine(ind);
                }
                else if (miesiąc == 9 && dzień > 20 || miesiąc == 10) //jesień
                {
                    for (int i = 0; i < 5; i++)
                        wynik[i, 6].WriteLine(temp[i]);
                    indeksy[6].WriteLine(ind);
                }
                else if (miesiąc == 11 || miesiąc == 12 && dzień <= 10) //przedzimie
                {
                    for (int i = 0; i < 5; i++)
                        wynik[i, 7].WriteLine(temp[i]);
                    indeksy[7].WriteLine(ind);
                }
                else
                {
                    for (int i = 0; i < 5; i++)
                        wynik[i, 0].WriteLine(temp[i]);
                    indeksy[0].WriteLine(ind);
                }

            }
            for (int i = 0; i < 8; i++)
                indeksy[i].Close();
            indeks.Close();
            sr_Lublin.Close();
            //zamknij otwwarte strumienie
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 8; j++)
                    wynik[i, j].Close();
        }

        public void MiastaPokrewne(string nazwa, string nazwa2)
        {

            string temp;
            string dana = "";
            double min_p = 0, max_p = 0, cis_p = 0, tpr_p = 0, w_p = 0, o_p = 0;
            StreamReader sr = new StreamReader(nazwa);
            StreamWriter sw = new StreamWriter(nazwa2);
            double wynik;
            DateTime dt = new DateTime(1986, 1, 1);
            while (!sr.EndOfStream)
            {
                temp = sr.ReadLine(); //wczytaj linię z danymi 1 dnia
                int miesiąc = int.Parse(temp[18].ToString() + temp[19].ToString());
                int dzień = int.Parse(temp[20].ToString() + temp[21].ToString());
                //if (dt.Day != dzień)
                //    MessageBox.Show("Błąd");
                //dt = dt.AddDays(1.0);

                //temperatura punktu rosy (35 - 40)
                dana = "";
                for (int i = 35; i <= 40; i++)
                {
                    if (temp[i] != ' ' && temp[i] != '.')
                        dana = dana + temp[i];
                    else if (temp[i] == '.')
                        dana = dana + ',';
                }
                wynik = double.Parse(dana);
                if (wynik != 9999.9)
                    //sw.Write(wynik);
                    sw.Write(NormalizacjaLiniowa(wynik, -30, 80, 0, 1));
                else
                    //sw.Write(tpr_p);
                    sw.Write(NormalizacjaLiniowa(tpr_p, -30, 80, 0, 1));
                sw.Write(" ");
                tpr_p = wynik;
                //ciśnienie (46 - 51)
                dana = "";
                for (int i = 46; i <= 51; i++)
                {
                    if (temp[i] != ' ' && temp[i] != '.')
                        dana = dana + temp[i];
                    else if (temp[i] == '.')
                        dana = dana + ',';
                }
                wynik = double.Parse(dana);
                if (wynik != 9999.9)
                    //sw.Write(wynik);
                    sw.Write(NormalizacjaLiniowa(wynik, 965, 1060, 0, 1));
                else
                    //sw.Write(cis_p);
                    sw.Write(NormalizacjaLiniowa(cis_p, 965, 1060, 0, 1));
                sw.Write(" ");
                cis_p = wynik;
                //prędkość wiatru (78-82)
                dana = "";
                for (int i = 78; i <= 82; i++)
                {
                    if (temp[i] != ' ' && temp[i] != '.')
                        dana = dana + temp[i];
                    else if (temp[i] == '.')
                        dana = dana + ',';
                }
                wynik = double.Parse(dana);
                if (wynik != 999.9)
                    //sw.Write(wynik);
                    sw.Write(NormalizacjaLiniowa(wynik, 0, 25, -1, 1));
                else
                    //sw.Write(w_p);
                    sw.Write(NormalizacjaLiniowa(w_p, 0, 25, -1, 1));
                sw.Write(" ");
                w_p = wynik;
                //maksymalna temperatura (102-107)
                dana = "";
                for (int i = 110; i <= 115; i++)
                {
                    if (temp[i] != ' ' && temp[i] != '.')
                        dana = dana + temp[i];
                    else if (temp[i] == '.')
                        dana = dana + ',';
                }
                wynik = double.Parse(dana);
                if (wynik != 9999.9)
                    //sw.Write(wynik);
                    sw.Write(NormalizacjaLiniowa(wynik, -22, 104, 0, 1));
                else
                    //sw.Write(max_p);
                    sw.Write(NormalizacjaLiniowa(max_p, -22, 104, 0, 1));
                sw.Write(" ");
                max_p = wynik;
                //minimalna temperatura (110-115)
                dana = "";
                for (int i = 110; i <= 115; i++)
                {
                    if (temp[i] != ' ' && temp[i] != '.')
                        dana = dana + temp[i];
                    else if (temp[i] == '.')
                        dana = dana + ',';
                }
                wynik = double.Parse(dana);
                if (wynik != 9999.9)
                    //sw.Write(wynik);
                    sw.Write(NormalizacjaLiniowa(wynik, -49, 77, 0, 1));
                else
                    //sw.Write(min_p);
                    sw.Write(NormalizacjaLiniowa(min_p, -49, 77, 0, 1));
                sw.Write(" ");
                min_p = wynik;
                //opady (118-122)
                dana = "";
                for (int i = 118; i <= 122; i++)
                {
                    if (temp[i] != ' ' && temp[i] != '.')
                        dana = dana + temp[i];
                    else if (temp[i] == '.')
                        dana = dana + ',';
                }
                wynik = double.Parse(dana);
                if (wynik != 99.99)
                    //sw.Write(wynik);
                    sw.Write(NormalizacjaLiniowa(wynik, 0, 5, -1, 1));
                else
                    //sw.Write(o_p);
                    sw.Write(NormalizacjaLiniowa(o_p, 0, 5, -1, 1));
                sw.Write(" ");
                o_p = wynik;
                //132 - 137 zjawiska pogodowe
                for (int i = 132; i <= 136; i++)
                {
                    if (temp[i] == '0')
                        sw.Write("-1");
                    else
                        sw.Write("1");
                    sw.Write(" ");
                }

                sw.Write("\n");
            }
            sr.Close();
            sw.Close();
        }

        private void buWczytajDane_Click(object sender, EventArgs e)
        {
            Lublin("Lublin_dane.txt", "Lublin.txt");
            //MiastaPokrewne("Legnica_dane.txt", "Legnica.txt");
            //MiastaPokrewne("Miskolc_dane.txt", "Miskolc.txt");
            //MiastaPokrewne("Mogilev_dane.txt", "Mogilev.txt");
            //MiastaPokrewne("Suwałki_dane.txt", "Suwałki.txt");
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

        private double BrakNormalizacji(double co)
        {
            return co;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader p1 = new StreamReader("Lublin.txt");
            //StreamReader p2 = new StreamReader("Suwałki.txt");
            //StreamReader p3 = new StreamReader("Miskolc.txt");
            //StreamReader p4 = new StreamReader("Legnica.txt");
            //StreamReader p5 = new StreamReader("Mogilev.txt");
            StreamWriter p6 = new StreamWriter("wejście.txt");
            string linia;
            while (!p1.EndOfStream)
            {
                linia = null;
                linia = linia + p1.ReadLine();
                //linia = linia + p2.ReadLine();
                //linia = linia + p3.ReadLine();
                //linia = linia + p4.ReadLine();
                //linia = linia + p5.ReadLine();
                p6.WriteLine(linia);
            }
            p1.Close();
            //p2.Close();
            //p3.Close();
            //p4.Close();
            //p5.Close();
            p6.Close();
        }

        public void TwórzWybraneWejście()
        {
            //otwarcie plików do tworzenia wejść
            StreamReader[,] wynik = new StreamReader[5, 8];
            wynik[0, 0] = new StreamReader("Lublin_zima_out.txt");
            wynik[0, 1] = new StreamReader("Lublin_przedwiośnie_out.txt");
            wynik[0, 2] = new StreamReader("Lublin_wiosna_out.txt");
            wynik[0, 3] = new StreamReader("Lublin_przedlecie_out.txt");
            wynik[0, 4] = new StreamReader("Lublin_lato_out.txt");
            wynik[0, 5] = new StreamReader("Lublin_polecie_out.txt");
            wynik[0, 6] = new StreamReader("Lublin_jesień_out.txt");
            wynik[0, 7] = new StreamReader("Lublin_przedzimie_out.txt");
            wynik[1, 0] = new StreamReader("Legnica_zima_out.txt");
            wynik[1, 1] = new StreamReader("Legnica_przedwiośnie_out.txt");
            wynik[1, 2] = new StreamReader("Legnica_wiosna_out.txt");
            wynik[1, 3] = new StreamReader("Legnica_przedlecie_out.txt");
            wynik[1, 4] = new StreamReader("Legnica_lato_out.txt");
            wynik[1, 5] = new StreamReader("Legnica_polecie_out.txt");
            wynik[1, 6] = new StreamReader("Legnica_jesień_out.txt");
            wynik[1, 7] = new StreamReader("Legnica_przedzimie_out.txt");
            wynik[2, 0] = new StreamReader("Mogilev_zima_out.txt");
            wynik[2, 1] = new StreamReader("Mogilev_przedwiośnie_out.txt");
            wynik[2, 2] = new StreamReader("Mogilev_wiosna_out.txt");
            wynik[2, 3] = new StreamReader("Mogilev_przedlecie_out.txt");
            wynik[2, 4] = new StreamReader("Mogilev_lato_out.txt");
            wynik[2, 5] = new StreamReader("Mogilev_polecie_out.txt");
            wynik[2, 6] = new StreamReader("Mogilev_jesień_out.txt");
            wynik[2, 7] = new StreamReader("Mogilev_przedzimie_out.txt");
            wynik[3, 0] = new StreamReader("Miskolc_zima_out.txt");
            wynik[3, 1] = new StreamReader("Miskolc_przedwiośnie_out.txt");
            wynik[3, 2] = new StreamReader("Miskolc_wiosna_out.txt");
            wynik[3, 3] = new StreamReader("Miskolc_przedlecie_out.txt");
            wynik[3, 4] = new StreamReader("Miskolc_lato_out.txt");
            wynik[3, 5] = new StreamReader("Miskolc_polecie_out.txt");
            wynik[3, 6] = new StreamReader("Miskolc_jesień_out.txt");
            wynik[3, 7] = new StreamReader("Miskolc_przedzimie_out.txt");
            wynik[4, 0] = new StreamReader("Suwałki_zima_out.txt");
            wynik[4, 1] = new StreamReader("Suwałki_przedwiośnie_out.txt");
            wynik[4, 2] = new StreamReader("Suwałki_wiosna_out.txt");
            wynik[4, 3] = new StreamReader("Suwałki_przedlecie_out.txt");
            wynik[4, 4] = new StreamReader("Suwałki_lato_out.txt");
            wynik[4, 5] = new StreamReader("Suwałki_polecie_out.txt");
            wynik[4, 6] = new StreamReader("Suwałki_jesień_out.txt");
            wynik[4, 7] = new StreamReader("Suwałki_przedzimie_out.txt");

            //otwarcie plików do zapisu
            StreamWriter[] wejścia = new StreamWriter[8];
            wejścia[0] = new StreamWriter("zima_wejście.txt");
            wejścia[1] = new StreamWriter("przedwiośnie_wejście.txt");
            wejścia[2] = new StreamWriter("wiosna_wejście.txt");
            wejścia[3] = new StreamWriter("przedlecie_wejście.txt");
            wejścia[4] = new StreamWriter("lato_wejście.txt");
            wejścia[5] = new StreamWriter("polecie_wejście.txt");
            wejścia[6] = new StreamWriter("jesień_wejście.txt");
            wejścia[7] = new StreamWriter("przedzimie_wejście.txt");

            //tworzenie wejść
            while (!wynik[0, 0].EndOfStream)
            {
                for (int i = 0; i < 8; i++) //pora roku
                {
                    string linia = null;
                    for (int j = 0; j < 5; j++) //miasto
                    {
                        linia = linia + wynik[j, i].ReadLine();
                    }
                    wejścia[i].WriteLine(linia);
                }
            }

            //zamknij otwwarte strumienie
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 8; j++)
                    wynik[i, j].Close();
            for (int i = 0; i < 8; i++)
                wejścia[i].Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int który_dzień = 1;
            Random los = new Random();
            StreamReader analiza = new StreamReader("wejście.txt");
            StreamWriter ucz = new StreamWriter("uczący.txt");
            StreamWriter test = new StreamWriter("testowy.txt");
            //przygotuj pierwszy klocek
            List<string> plik = new List<string>();
            while (!analiza.EndOfStream)
            {
                plik.Add(analiza.ReadLine());
            }
            //pętla z tworzeniem klocków i dopisywaniem ich do losowo wybranego zbioru
            string wynik = analiza.ReadLine(); //1 dzień naprzód
            for (int i = 0; i < plik.Count - 3 - który_dzień; i++)
            {
                int numer = los.Next(10);
                if (numer == 9) //daje to 10% zbiór testowy, 90% zbiór uczący
                {
                    double[] wyjście = Rozbij(plik[i + 4], 12);
                    string linia = null;
                    //for (int j = 5; j < 15; j++)
                    //    linia = linia + wyjście[j].ToString() + " ";
                    linia = linia + wyjście[7].ToString() + " ";
                    test.WriteLine(plik[i] + plik[i + 1] + plik[i + 2] + plik[i + 3] + linia);
                }
                else
                {
                    double[] wyjście = Rozbij(plik[i + 4], 12);
                    string linia = null;
                    //for (int j = 5; j < 15; j++)
                    //    linia = linia + wyjście[j].ToString() + " ";
                    //linia = linia + wyjście[6].ToString() + " ";
                    linia = linia + wyjście[7].ToString() + " ";
                    ucz.WriteLine(plik[i] + plik[i + 1] + plik[i + 2] + plik[i + 3] + linia);
                }

            }
            ucz.Close();
            test.Close();
            analiza.Close();
        }

        public void WybranyUczący()
        {
            //tylko Lublin różne
            StreamReader sr = new StreamReader("uczący_out.txt");
            StreamWriter sw = new StreamWriter("uczący.txt");
            while (!sr.EndOfStream)
            {
                string linia = null;
                for (int j = 0; j < 4; j++) //dane wejścia sieci
                    linia = linia + sr.ReadLine();
                for (int j = 0; j < 1; j++) //odpowiedzi sieci
                {
                    string temp = sr.ReadLine();
                    if (temp == null)
                        throw new Exception();
                    double[] wyjście = Rozbij(temp, 67);
                    linia = linia + wyjście[8].ToString() + " ";
                    //for (int k = 5; k < 15; k++)
                    //    linia = linia + wyjście[k].ToString() + " ";
                    sw.WriteLine(linia);
                }
            }
            //wszystkie miasta 40 przypadków
            /*
            //otwarcie plików do odczytu
            StreamReader[] wejścia = new StreamReader[8];
            wejścia[0] = new StreamReader("zima_wejście.txt");
            wejścia[1] = new StreamReader("przedwiośnie_wejście.txt");
            wejścia[2] = new StreamReader("wiosna_wejście.txt");
            wejścia[3] = new StreamReader("przedlecie_wejście.txt");
            wejścia[4] = new StreamReader("lato_wejście.txt");
            wejścia[5] = new StreamReader("polecie_wejście.txt");
            wejścia[6] = new StreamReader("jesień_wejście.txt");
            wejścia[7] = new StreamReader("przedzimie_wejście.txt");
            //otwarcie plików do zapisu
            StreamWriter[] uczący = new StreamWriter[8];
            uczący[0] = new StreamWriter("zima_uczący.txt");
            uczący[1] = new StreamWriter("przedwiośnie_uczący.txt");
            uczący[2] = new StreamWriter("wiosna_uczący.txt");
            uczący[3] = new StreamWriter("przedlecie_uczący.txt");
            uczący[4] = new StreamWriter("lato_uczący.txt");
            uczący[5] = new StreamWriter("polecie_uczący.txt");
            uczący[6] = new StreamWriter("jesień_uczący.txt");
            uczący[7] = new StreamWriter("przedzimie_uczący.txt");
            //twórz zbiór uczący
            while (!wejścia[0].EndOfStream)
            {
                for (int i = 0; i < 8; i++)
                {
                    string linia = null;
                    for (int j = 0; j < 4; j++) //dane wejścia sieci
                        linia = linia + wejścia[i].ReadLine();
                    for (int j = 0; j < 1; j++) //odpowiedzi sieci
                    {
                        string temp = wejścia[i].ReadLine();
                        if (temp == null)
                            throw new Exception();
                        double[] wyjście = Rozbij(temp, 67);
                        linia = linia + wyjście[8].ToString() + " ";
                        //for (int k = 5; k < 15; k++)
                        //    linia = linia + wyjście[k].ToString() + " ";
                    }
                    uczący[i].WriteLine(linia);
                }
            }
            //zamknij strumienie
            for (int i = 0; i < 8; i++)
            {
                wejścia[i].Close();
                uczący[i].Close();
            }
            */
        }

        private double[] Rozbij(string linia, int rozmiar)
        {
            double[] wynik = new double[rozmiar];
            int indeks = 0;
            string tmp = null;
            for (int i = 0; i < linia.Length; i++)
            {
                if (linia[i] == ' ' || i == linia.Length)
                {
                    wynik[indeks] = double.Parse(tmp);
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

        private void button3_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("burze.txt");
            StreamWriter sw = new StreamWriter("wynik.txt");
            string temp;
            double a, b;
            while (!sr.EndOfStream)
            {
                string linia = sr.ReadLine();
                temp = null;
                for (int j = 0; j < linia.Length; j++)
                {
                    if (linia[j] == '\t')
                        temp = temp + ' ';
                    else if (linia[j] != 'B' && linia[j] != 'T')
                    {
                        temp = temp + linia[j];
                    }
                    else if (linia[j] == 'B')
                    {
                        temp = temp + '1';
                        break;
                    }
                    else
                    {
                        temp = temp + '0';
                        break;
                    }
                }
                double[] wyniki;
                if (temp != null)
                {
                    wyniki = Rozbij(temp, 3);
                    //for (int i = 0; i < 2; i++)   
                    //wyniki[i] = NormalizacjaLiniowa(wyniki[i], 0, 180, 0, 1);
                    string linia_wy = wyniki[0].ToString() + " " + wyniki[1].ToString() + " " + wyniki[2].ToString();
                    sw.WriteLine(linia_wy);
                }
            }
            sr.Close();
            sw.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PoryRoku();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //otwieramy pliki z numerami linii wybranych danych
            StreamReader[] pory_roku = new StreamReader[8];
            
            
            pory_roku[0] = new StreamReader("zima_wybrane.txt");
            pory_roku[1] = new StreamReader("przedwiośnie_wybrane.txt");
            pory_roku[2] = new StreamReader("wiosna_wybrane.txt");
            pory_roku[3] = new StreamReader("przedlecie_wybrane.txt");
            pory_roku[4] = new StreamReader("lato_wybrane.txt");
            pory_roku[5] = new StreamReader("polecie_wybrane.txt");
            pory_roku[6] = new StreamReader("jesień_wybrane.txt");
            pory_roku[7] = new StreamReader("przedzimie_wybrane.txt");
            
            
            //wczytywanie danych do pamięci
            StreamReader[] dane = new StreamReader[5];
            dane[0] = new StreamReader("Lublin_dane.txt");
            dane[1] = new StreamReader("Legnica_dane.txt");
            dane[2] = new StreamReader("Mogilev_dane.txt");
            dane[3] = new StreamReader("Miskolc_dane.txt");
            dane[4] = new StreamReader("Suwałki_dane.txt");
            List<string>[] lista_danych = new List<string>[5];
            for (int i = 0; i < lista_danych.Length; i++)
                lista_danych[i] = new List<string>();
            while (!dane[0].EndOfStream)
            {
                for (int i = 0; i < lista_danych.Length; i++)
                {
                    lista_danych[i].Add(dane[i].ReadLine());
                }
            }
            for (int i = 0; i < dane.Length; i++)
                dane[i].Close();
            //zapisz dane do plików wybranych danych z podziałem na pory roku
            StreamWriter[,] wynik = new StreamWriter[5, 8];
            wynik[0, 0] = new StreamWriter("Lublin_zima.txt");
            wynik[0, 1] = new StreamWriter("Lublin_przedwiośnie.txt");
            wynik[0, 2] = new StreamWriter("Lublin_wiosna.txt");
            wynik[0, 3] = new StreamWriter("Lublin_przedlecie.txt");
            wynik[0, 4] = new StreamWriter("Lublin_lato.txt");
            wynik[0, 5] = new StreamWriter("Lublin_polecie.txt");
            wynik[0, 6] = new StreamWriter("Lublin_jesień.txt");
            wynik[0, 7] = new StreamWriter("Lublin_przedzimie.txt");
            wynik[1, 0] = new StreamWriter("Legnica_zima.txt");
            wynik[1, 1] = new StreamWriter("Legnica_przedwiośnie.txt");
            wynik[1, 2] = new StreamWriter("Legnica_wiosna.txt");
            wynik[1, 3] = new StreamWriter("Legnica_przedlecie.txt");
            wynik[1, 4] = new StreamWriter("Legnica_lato.txt");
            wynik[1, 5] = new StreamWriter("Legnica_polecie.txt");
            wynik[1, 6] = new StreamWriter("Legnica_jesień.txt");
            wynik[1, 7] = new StreamWriter("Legnica_przedzimie.txt");
            wynik[2, 0] = new StreamWriter("Mogilev_zima.txt");
            wynik[2, 1] = new StreamWriter("Mogilev_przedwiośnie.txt");
            wynik[2, 2] = new StreamWriter("Mogilev_wiosna.txt");
            wynik[2, 3] = new StreamWriter("Mogilev_przedlecie.txt");
            wynik[2, 4] = new StreamWriter("Mogilev_lato.txt");
            wynik[2, 5] = new StreamWriter("Mogilev_polecie.txt");
            wynik[2, 6] = new StreamWriter("Mogilev_jesień.txt");
            wynik[2, 7] = new StreamWriter("Mogilev_przedzimie.txt");
            wynik[3, 0] = new StreamWriter("Miskolc_zima.txt");
            wynik[3, 1] = new StreamWriter("Miskolc_przedwiośnie.txt");
            wynik[3, 2] = new StreamWriter("Miskolc_wiosna.txt");
            wynik[3, 3] = new StreamWriter("Miskolc_przedlecie.txt");
            wynik[3, 4] = new StreamWriter("Miskolc_lato.txt");
            wynik[3, 5] = new StreamWriter("Miskolc_polecie.txt");
            wynik[3, 6] = new StreamWriter("Miskolc_jesień.txt");
            wynik[3, 7] = new StreamWriter("Miskolc_przedzimie.txt");
            wynik[4, 0] = new StreamWriter("Suwałki_zima.txt");
            wynik[4, 1] = new StreamWriter("Suwałki_przedwiośnie.txt");
            wynik[4, 2] = new StreamWriter("Suwałki_wiosna.txt");
            wynik[4, 3] = new StreamWriter("Suwałki_przedlecie.txt");
            wynik[4, 4] = new StreamWriter("Suwałki_lato.txt");
            wynik[4, 5] = new StreamWriter("Suwałki_polecie.txt");
            wynik[4, 6] = new StreamWriter("Suwałki_jesień.txt");
            wynik[4, 7] = new StreamWriter("Suwałki_przedzimie.txt");
            for (int i = 0; i < 8; i++) //pory roku
            {
                while (!pory_roku[i].EndOfStream)
                {
                    int nr = int.Parse(pory_roku[i].ReadLine());
                    for (int k = 0; k < 5; k++)
                    {
                        for(int l=0;l<5;l++)
                            wynik[k, i].WriteLine(lista_danych[k][nr + l]);
                    }
                }
            }
            //zamknij otwwarte strumienie
            for (int i = 0; i < pory_roku.Length; i++)
                pory_roku[i].Close();
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 8; j++)
                    wynik[i, j].Close();
        }

        public void TestoweNumery()
        {
            //otwieramy pliki z numerami linii wybranych danych
            StreamReader[] pory_roku = new StreamReader[8];
            pory_roku[0] = new StreamReader("zima_wybrane.txt");
            pory_roku[1] = new StreamReader("przedwiośnie_wybrane.txt");
            pory_roku[2] = new StreamReader("wiosna_wybrane.txt");
            pory_roku[3] = new StreamReader("przedlecie_wybrane.txt");
            pory_roku[4] = new StreamReader("lato_wybrane.txt");
            pory_roku[5] = new StreamReader("polecie_wybrane.txt");
            pory_roku[6] = new StreamReader("jesień_wybrane.txt");
            pory_roku[7] = new StreamReader("przedzimie_wybrane.txt");
            //wczytywanie danych do pamięci
            StreamReader[] dane = new StreamReader[5];
            dane[0] = new StreamReader("Lublin_dane.txt");
            dane[1] = new StreamReader("Legnica_dane.txt");
            dane[2] = new StreamReader("Mogilev_dane.txt");
            dane[3] = new StreamReader("Miskolc_dane.txt");
            dane[4] = new StreamReader("Suwałki_dane.txt");
            List<string>[] lista_danych = new List<string>[5];
            for (int i = 0; i < lista_danych.Length; i++)
                lista_danych[i] = new List<string>();
            while (!dane[0].EndOfStream)
            {
                for (int i = 0; i < lista_danych.Length; i++)
                {
                    lista_danych[i].Add(dane[i].ReadLine());
                }
            }
            for (int i = 0; i < dane.Length; i++)
                dane[i].Close();
            //zapisz dane do plików wybranych danych z podziałem na pory roku
            StreamWriter[,] wynik = new StreamWriter[5, 8];
            wynik[0, 0] = new StreamWriter("Lublin_zima.txt");
            wynik[0, 1] = new StreamWriter("Lublin_przedwiośnie.txt");
            wynik[0, 2] = new StreamWriter("Lublin_wiosna.txt");
            wynik[0, 3] = new StreamWriter("Lublin_przedlecie.txt");
            wynik[0, 4] = new StreamWriter("Lublin_lato.txt");
            wynik[0, 5] = new StreamWriter("Lublin_polecie.txt");
            wynik[0, 6] = new StreamWriter("Lublin_jesień.txt");
            wynik[0, 7] = new StreamWriter("Lublin_przedzimie.txt");
            wynik[1, 0] = new StreamWriter("Legnica_zima.txt");
            wynik[1, 1] = new StreamWriter("Legnica_przedwiośnie.txt");
            wynik[1, 2] = new StreamWriter("Legnica_wiosna.txt");
            wynik[1, 3] = new StreamWriter("Legnica_przedlecie.txt");
            wynik[1, 4] = new StreamWriter("Legnica_lato.txt");
            wynik[1, 5] = new StreamWriter("Legnica_polecie.txt");
            wynik[1, 6] = new StreamWriter("Legnica_jesień.txt");
            wynik[1, 7] = new StreamWriter("Legnica_przedzimie.txt");
            wynik[2, 0] = new StreamWriter("Mogilev_zima.txt");
            wynik[2, 1] = new StreamWriter("Mogilev_przedwiośnie.txt");
            wynik[2, 2] = new StreamWriter("Mogilev_wiosna.txt");
            wynik[2, 3] = new StreamWriter("Mogilev_przedlecie.txt");
            wynik[2, 4] = new StreamWriter("Mogilev_lato.txt");
            wynik[2, 5] = new StreamWriter("Mogilev_polecie.txt");
            wynik[2, 6] = new StreamWriter("Mogilev_jesień.txt");
            wynik[2, 7] = new StreamWriter("Mogilev_przedzimie.txt");
            wynik[3, 0] = new StreamWriter("Miskolc_zima.txt");
            wynik[3, 1] = new StreamWriter("Miskolc_przedwiośnie.txt");
            wynik[3, 2] = new StreamWriter("Miskolc_wiosna.txt");
            wynik[3, 3] = new StreamWriter("Miskolc_przedlecie.txt");
            wynik[3, 4] = new StreamWriter("Miskolc_lato.txt");
            wynik[3, 5] = new StreamWriter("Miskolc_polecie.txt");
            wynik[3, 6] = new StreamWriter("Miskolc_jesień.txt");
            wynik[3, 7] = new StreamWriter("Miskolc_przedzimie.txt");
            wynik[4, 0] = new StreamWriter("Suwałki_zima.txt");
            wynik[4, 1] = new StreamWriter("Suwałki_przedwiośnie.txt");
            wynik[4, 2] = new StreamWriter("Suwałki_wiosna.txt");
            wynik[4, 3] = new StreamWriter("Suwałki_przedlecie.txt");
            wynik[4, 4] = new StreamWriter("Suwałki_lato.txt");
            wynik[4, 5] = new StreamWriter("Suwałki_polecie.txt");
            wynik[4, 6] = new StreamWriter("Suwałki_jesień.txt");
            wynik[4, 7] = new StreamWriter("Suwałki_przedzimie.txt");
            for (int i = 0; i < 8; i++) //pory roku
            {
                while (!pory_roku[i].EndOfStream)
                {
                    int nr = int.Parse(pory_roku[i].ReadLine());
                    for (int k = 0; k < 5; k++)
                    {
                        for (int l = 0; l < 5; l++)
                            wynik[k, i].WriteLine(lista_danych[k][nr + l]);
                    }
                }
            }
            //zamknij otwwarte strumienie
            for (int i = 0; i < pory_roku.Length; i++)
                pory_roku[i].Close();
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 8; j++)
                    wynik[i, j].Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            /*
            string[] miasta = new string[5];
            miasta[0] = "Lublin";
            miasta[1] = "Legnica";
            miasta[2] = "Miskolc";
            miasta[3] = "Mogilev";
            miasta[4] = "Suwałki";
            string[] pory_roku = new string[8];
            pory_roku[0] = "zima";
            pory_roku[1] = "przedwiośnie";
            pory_roku[2] = "wiosna";
            pory_roku[3] = "przedlecie";
            pory_roku[4] = "lato";
            pory_roku[5] = "polecie";
            pory_roku[6] = "jesień";
            pory_roku[7] = "przedzimie";
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i == 0)
                    {
                        Lublin(miasta[0] + "_" + pory_roku[j] + ".txt", miasta[0] + "_" + pory_roku[j] + "_out.txt");
                    }
                    else
                    {
                        MiastaPokrewne(miasta[i] + "_" + pory_roku[j] + ".txt", miasta[i] + "_" + pory_roku[j] + "_out.txt");
                    }
                }
            }
            */
            Lublin("uczący_tylko_Lublin_wybrane.txt", "uczący_out.txt");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TwórzWybraneWejście();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            WybranyUczący();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OkresCiepłyZimny();
        }
    }
}
