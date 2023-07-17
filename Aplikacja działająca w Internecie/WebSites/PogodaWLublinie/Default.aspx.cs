using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Globalization;

public partial class _Default : System.Web.UI.Page
{
    SiećNeuronowa[] sn;
    private double[, ,] dane;
    NumberFormatInfo nfi;
    TextBox[,] tb;
    DropDownList[] dd;
    CheckBox[,] cb;
    List<string> weryfikacja;

    public void TwórzDostępDoKomponentów()
    {
        //tworzenie dostępu do komponentów
        tb = new TextBox[4, 6];
        int indeks = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                while (!(form1.Controls[indeks] is TextBox))
                {
                    indeks++;
                }
                tb[i, j] = (TextBox)form1.Controls[indeks];
                indeks++;
            }
        }

        cb = new CheckBox[4, 2];
        indeks = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                while (!(form1.Controls[indeks] is CheckBox))
                {
                    indeks++;
                }
                cb[i, j] = (CheckBox)form1.Controls[indeks];
                indeks++;
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        int[][] ow = new int[10][];
        //sieć nr 1 - temp MAX
        ow[0] = new int[3];
        ow[0][0] = 16;
        ow[0][1] = 160;
        ow[0][2] = 1;
        //sieć nr 2 - temp MIN
        ow[1] = new int[3];
        ow[1][0] = 16;
        ow[1][1] = 80;
        ow[1][2] = 1;
        //sieć nr 3 - ciśnienie
        ow[2] = new int[4];
        ow[2][0] = 32;
        ow[2][1] = 15;
        ow[2][2] = 4;
        ow[2][3] = 1;
        sn = new SiećNeuronowa[10];
        for(int i=0;i<3;i++)
            sn[i] = new SiećNeuronowa(ow[i], 0.3, 0.1, -0.5, 0.5, 0, true, 10, 0.001);
        dane = new double[5, 4, 14];
        nfi = new CultureInfo(CultureInfo.CurrentCulture.Name).NumberFormat;
        nfi.NumberDecimalSeparator = ",";
        TwórzDostępDoKomponentów();
        DateTime data_test = new DateTime(1980, 1, 5);
        int indeks = cbData.SelectedIndex;
        cbData.Items.Clear();
        for (int i = 0; i < 225; i++)
        {
            cbData.Items.Add(data_test.ToString());
            data_test = data_test.AddDays(1);
        }
        cbData.SelectedIndex = indeks;
        weryfikacja = new List<string>();
        Lublin();
    }
    
    protected void cbMiasto_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void tbTempMaxW_TextChanged(object sender, EventArgs e)
    {
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
                if (!double.TryParse(tmp, out wynik[indeks]))
                {
                    wynik[0] = -9999E-999; //wartość oznaczająca niepowodzenie
                }
                tmp = null;
                indeks++;
            }
            else
            {
                if (CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator != linia[i].ToString() && (linia[i] == '.' || linia[i] == ','))
                    tmp = tmp + CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
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

    protected void buLicz_Click(object sender, EventArgs e)
    {

        //sprawdzanie poprawności wprowadzonych danych
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                double tmp;
                if (!double.TryParse(tb[i, j].Text, out tmp))
                {
                    Response.Write("<script>alert('Wprowadzono błędne dane.')</script>");
                    return;
                }
            }
        }

        //utworzenie tablicy

        double[, ,] temp = new double[1, 4, 15];
        for (int i = 0; i < 4; i++)
        {
            int m = i / 4; //miasto
            int n = i % 4; //dzień
            temp[m, n, 2] = double.Parse(tb[i, 0].Text); //temp. MAX
            temp[m, n, 3] = double.Parse(tb[i, 2].Text); //temp. MIN
            temp[m, n, 4] = double.Parse(tb[i, 4].Text); //temp. punktu rosy
            temp[m, n, 5] = double.Parse(tb[i, 5].Text); //ciśnienie
            temp[m, n, 6] = double.Parse(tb[i, 1].Text); //prędkość wiatru
            temp[m, n, 14] = double.Parse(tb[i, 3].Text); //zonal indeks

            //zjawiska pogodowe
            if (cb[i, 0].Checked) //deszcz
                temp[m, n, 9] = 1;
            else
                temp[m, n, 9] = 0;
            if (cb[i, 1].Checked) //śnieg
                temp[m, n, 12] = 1;
            else
                temp[m, n, 12] = 0;
        }

        //jeżeli złe jednostki zamień
        if (cbSystem.SelectedIndex == 0) //metryczny
        {
            //zamiana jednostek
            for (int i = 0; i < 1; i++) //miasta
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 2; k <= 8; k++)
                    {
                        switch (k)
                        {
                            case 2:
                            case 3:
                            case 4:
                                temp[i, j, k] = 9.0 / 5.0 * temp[i, j, k] + 32; //temperatura
                                break;
                            case 6:
                                temp[i, j, k] = temp[i, j, k] * 1.9438444924406064; //wiatr
                                break;
                        }
                    }
                }
            }
        }
        //normalizuj i twórz wejście
        string[] linia = new string[9];
        for (int i = 0; i < 9; i++)
            linia[i] = null;
        /*
            0 - temperatura MAX
            1 - temperatura MIN
            2 - ciśnienie
            3 - prędkość wiatru
            4 - opady
            5 - mgła
            6 - deszcz
            7 - śnieg
            8 - grad
            9 - burza
        */
        for (int j = 0; j < 4; j++) //dni
        {
            /*
            switch ((int)temp[0, j, 0])
            {
                case 0: //zima
                    linia += "0,1 -1 0,2 0,7 ";
                    break;
                case 1: //przedwiośnie
                    linia += "0,6 -1 -1 0,3 ";
                    break;
                case 2: //wiosna
                    linia += "0,7 0,1 -1 0,2 ";
                    break;
                case 3: //przedlecie
                    linia += "0,4 0,6 -1 -1 ";
                    break;
                case 4: //lato
                    linia += "0,2 0,8 -1 -1 ";
                    break;
                case 5: //polecie
                    linia += "-1 0,7 0,3 -1 ";
                    break;
                case 6: //jesień
                    linia += "-1 0,1 0,8 0,1 ";
                    break;
                case 7: //przedzimie
                    linia += "-1 -1 0,5 0,5 ";
                    break;
            }
            */
            //for (int i = 0; i < 5; i++) //miasta wszystkie
            for (int i = 0; i < 1; i++) //tylko Lublin
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
                //opady


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
                if(temp[i, j, 10] == 1) //burza
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

        //parametry[0] = new StreamReader(WebRequest.Create("http://aspspider.ws/kzez1986/wagi/wagi_Lublin_lato_12par_200_100_lr_0-9.txt").GetResponse().GetResponseStream());
        switch (cbPoraRokuGłówna.SelectedIndex)
        {
            case 0:
                parametry[0] = new StreamReader(WebRequest.Create("http://aspspider.ws/kzez1986/wagi/wagi_Lublin_zima_indeks.txt").GetResponse().GetResponseStream());
                parametry[1] = new StreamReader(WebRequest.Create("http://aspspider.ws/kzez1986/wagi/wagi_Lublin_zima_min.txt").GetResponse().GetResponseStream());
                parametry[2] = new StreamReader(WebRequest.Create("http://aspspider.ws/kzez1986/wagi/wagi_Lublin_ciśnienie_zimny.txt").GetResponse().GetResponseStream());
                break;
            case 1:
                parametry[0] = new StreamReader(WebRequest.Create("http://aspspider.ws/kzez1986/wagi/wagi_Lublin_przedwiosnie_indeks.txt").GetResponse().GetResponseStream());
                parametry[1] = new StreamReader(WebRequest.Create("http://aspspider.ws/kzez1986/wagi/wagi_Lublin_przedwiosnie_min.txt").GetResponse().GetResponseStream());
                parametry[2] = new StreamReader(WebRequest.Create("http://aspspider.ws/kzez1986/wagi/wagi_Lublin_ciśnienie_zimny.txt").GetResponse().GetResponseStream());
                break;
            case 2:
                parametry[0] = new StreamReader(WebRequest.Create("http://aspspider.ws/kzez1986/wagi/wagi_Lublin_wiosna_indeks.txt").GetResponse().GetResponseStream());
                parametry[1] = new StreamReader(WebRequest.Create("http://aspspider.ws/kzez1986/wagi/wagi_Lublin_wiosna_min.txt").GetResponse().GetResponseStream());
                parametry[2] = new StreamReader(WebRequest.Create("http://aspspider.ws/kzez1986/wagi/wagi_Lublin_ciśnienie_zimny.txt").GetResponse().GetResponseStream());
                break;
            case 3:
                parametry[0] = new StreamReader(WebRequest.Create("http://aspspider.ws/kzez1986/wagi/wagi_Lublin_przedlecie_indeks.txt").GetResponse().GetResponseStream());
                parametry[1] = new StreamReader(WebRequest.Create("http://aspspider.ws/kzez1986/wagi/wagi_Lublin_przedlecie_min.txt").GetResponse().GetResponseStream());
                parametry[2] = new StreamReader(WebRequest.Create("http://aspspider.ws/kzez1986/wagi/wagi_Lublin_ciśnienie_ciepły.txt").GetResponse().GetResponseStream());
                break;
            case 4:
                parametry[0] = new StreamReader(WebRequest.Create("http://aspspider.ws/kzez1986/wagi/wagi_Lublin_lato_indeks.txt").GetResponse().GetResponseStream());
                parametry[1] = new StreamReader(WebRequest.Create("http://aspspider.ws/kzez1986/wagi/wagi_Lublin_lato_min.txt").GetResponse().GetResponseStream());
                parametry[2] = new StreamReader(WebRequest.Create("http://aspspider.ws/kzez1986/wagi/wagi_Lublin_ciśnienie_ciepły.txt").GetResponse().GetResponseStream());
                break;
            case 5:
                parametry[0] = new StreamReader(WebRequest.Create("http://aspspider.ws/kzez1986/wagi/wagi_Lublin_polecie_indeks.txt").GetResponse().GetResponseStream());
                parametry[1] = new StreamReader(WebRequest.Create("http://aspspider.ws/kzez1986/wagi/wagi_Lublin_polecie_min.txt").GetResponse().GetResponseStream());
                parametry[2] = new StreamReader(WebRequest.Create("http://aspspider.ws/kzez1986/wagi/wagi_Lublin_ciśnienie_ciepły.txt").GetResponse().GetResponseStream());
                break;
            case 6:
                parametry[0] = new StreamReader(WebRequest.Create("http://aspspider.ws/kzez1986/wagi/wagi_Lublin_jesien_indeks.txt").GetResponse().GetResponseStream());
                parametry[1] = new StreamReader(WebRequest.Create("http://aspspider.ws/kzez1986/wagi/wagi_Lublin_jesien_min.txt").GetResponse().GetResponseStream());
                parametry[2] = new StreamReader(WebRequest.Create("http://aspspider.ws/kzez1986/wagi/wagi_Lublin_ciśnienie_zimny.txt").GetResponse().GetResponseStream());
                break;
            case 7:
                parametry[0] = new StreamReader(WebRequest.Create("http://aspspider.ws/kzez1986/wagi/wagi_Lublin_przedzimie_indeks.txt").GetResponse().GetResponseStream());
                parametry[1] = new StreamReader(WebRequest.Create("http://aspspider.ws/kzez1986/wagi/wagi_Lublin_przedzimie_min.txt").GetResponse().GetResponseStream());
                parametry[2] = new StreamReader(WebRequest.Create("http://aspspider.ws/kzez1986/wagi/wagi_Lublin_ciśnienie_zimny.txt").GetResponse().GetResponseStream());
                break;
        }
        double[][] linie_wag = new double[10][];
        int[] ilość_wag = new int[9];
        ilość_wag[0] = 2720; //temp. MAX
        ilość_wag[1] = 1360; //temp. MIN
        ilość_wag[2] = 544; //ciśnienie
        int[] ilość_wejść = new int[9];
        ilość_wejść[0] = 16;
        ilość_wejść[1] = 16;
        ilość_wejść[2] = 32;
        //1 parametr tylko Lublin temp MAX
        for (int i = 0; i < 3; i++)
            linie_wag[i] = Rozbij(parametry[i].ReadLine(), ilość_wag[i]);
        //dla zbioru z wszystkim
        //for (int i = 0; i < 2; i++)
        //    linie_wag[i] = Rozbij(parametry[i].ReadLine(), 25300);
        for (int i = 0; i < 3; i++)
        {
            if (!sn[i].UstawWagiRęcznie(linie_wag[i]))
            {
                Response.Write("<script>alert('Błąd wczytywania wag.')</script>");
                return;
            }
        }
        for (int i = 0; i < 3; i++)
            parametry[i].Close();
        //uruchom sieć
        //double[] wejście = Rozbij(linia, 76); //dla całości
        double[][] wejście = new double[10][]; 
        for(int i=0;i<3;i++)
            wejście[i] = Rozbij(linia[i], ilość_wejść[i]); //dla 1 parametru
        for (int i = 0; i < 3; i++)
            if (!sn[i].UstawWartościPoczątkowe(wejście[i]))
            {
                Response.Write("<script>alert('Struktura sieci niezgodna z danymi wejściowymi.')</script>");
                return;
            }

        double[][] wyniki = new double[10][];
        for (int i = 0; i < 3; i++)
            wyniki[i] = sn[i].UruchomSieć();
        //zdenormalizuj
        wyniki[0][0] = NormalizacjaLiniowa(wyniki[0][0], 0, 1, -22, 104); //temp. maks
        wyniki[1][0] = NormalizacjaLiniowa(wyniki[1][0], 0, 1, -49, 77); //temp. min
        wyniki[2][0] = NormalizacjaLiniowa(wyniki[2][0], 0, 1, 965, 1060); //ciśnienie
        //wyniki[4] = NormalizacjaLiniowa(wyniki[4], -1, 1, 0, 5); //opady
        //zamień jednostki jeśli trzeba
        if (cbSystem.SelectedIndex == 0)
        {
            //wyniki[0][0] = wyniki[0][0] * 0.0394;
            wyniki[0][0] = 5.0 / 9.0 * (wyniki[0][0] - 32);
            wyniki[1][0] = 5.0 / 9.0 * (wyniki[1][0] - 32);
        }
        //pokaż wyniki
        tbTempMaxW.Text = wyniki[0][0].ToString();
        tbTempMinW.Text = wyniki[1][0].ToString();
        tbCiśnienieW.Text = wyniki[2][0].ToString();
        /*
        tbWiatrPrW.Text = wyniki[1].ToString();
        tbOpadW.Text = wyniki[4].ToString();
        if (wyniki[5] < 0)
            cbMgłaW.Checked = false;
        else
            cbMgłaW.Checked = true;
        if (wyniki[6] < 0)
            cbDeszczW.Checked = false;
        else
            cbDeszczW.Checked = true;
        if (wyniki[7] < 0)
            cbŚniegW.Checked = false;
        else
            cbŚniegW.Checked = true;
        if (wyniki[8] < 0)
            cbGradW.Checked = false;
        else
            cbGradW.Checked = true;
        if (wyniki[9] < 9)
            cbBurzaW.Checked = false;
        else
            cbBurzaW.Checked = true;
        */
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Random los = new Random();
        for (int i = 0; i < 4; i++)
        {
            double tmp = los.NextDouble() * 80 - 40; //temp. MAX
            if(cbSystem.SelectedIndex == 1) //angielski system
                tmp = 9/5 * tmp + 32;
            tb[i, 0].Text = tmp.ToString();
            tmp = los.NextDouble() * 20; //prędkość wiatru
            if (cbSystem.SelectedIndex == 1) //angielski system
                tmp = tmp * 1.944;
            tb[i, 1].Text = tmp.ToString();
            tmp = los.NextDouble() * 80 - 40; //temp. MIN
            if (cbSystem.SelectedIndex == 1) //angielski system
                tmp = 9 / 5 * tmp + 32;
            tb[i, 2].Text = tmp.ToString();
            tmp = los.NextDouble() * 20 - 20; //temp. punktu rosy
            if (cbSystem.SelectedIndex == 1) //angielski system
                tmp = 9 / 5 * tmp + 32;
            tb[i, 4].Text = tmp.ToString();
            if (cbSystem.SelectedIndex == 1) //angielski system
                tmp = tmp * 0.39;
            tb[i, 4].Text = tmp.ToString();
            tmp = los.NextDouble() * 50 + 1000; //ciśnienie
            tb[i, 5].Text = tmp.ToString();
            tmp = los.NextDouble() * 10 - 10; //zonal index
            tb[i, 3].Text = tmp.ToString();
        }
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                if (los.Next(2) == 1)
                {
                    cb[i, j].Checked = true;
                }
                else
                {
                    cb[i, j].Checked = false;
                }
            }
        }
    }
    
    protected void cbScenariusz_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void buGenerujScenariusz_Click(object sender, EventArgs e)
    {
        Random los = new Random();
        //temperatura - pora roku ważna
        double temp_max = 0;
        double różnica_dni;
        double[] różnica_miasta = new double[4];
        double różnica_doba;
        switch (cbPoraRoku.SelectedIndex)
        {
            case 0: //zima
                switch (cbCzyCiepło.SelectedIndex)
                {
                    case 0: //zimno
                        temp_max = los.NextDouble() * -10 - 5;
                        break;
                    case 1: //normalnie
                        temp_max = los.NextDouble() * -6 + 1;
                        break;
                    case 2: //ciepło
                        temp_max = los.NextDouble() * 12;
                        break;
                }
                break;
            case 1: //przedwiośnie
                switch (cbCzyCiepło.SelectedIndex)
                {
                    case 0: //zimno
                        temp_max = los.NextDouble() * -5;
                        break;
                    case 1: //normalnie
                        temp_max = los.NextDouble() * 5;
                        break;
                    case 2: //ciepło
                        temp_max = los.NextDouble() * 5 + 5;
                        break;
                }
                break;
            case 2: //wiosna
                switch (cbCzyCiepło.SelectedIndex)
                {
                    case 0: //zimno
                        temp_max = los.NextDouble() * 7 - 2;
                        break;
                    case 1: //normalnie
                        temp_max = los.NextDouble() * 10 + 5;
                        break;
                    case 2: //ciepło
                        temp_max = los.NextDouble() * 15 + 5;
                        break;
                }
                break;
            case 3: //przedlecie
                switch (cbCzyCiepło.SelectedIndex)
                {
                    case 0: //zimno
                        temp_max = los.NextDouble() * 10 + 5;
                        break;
                    case 1: //normalnie
                        temp_max = los.NextDouble() * 5 + 15;
                        break;
                    case 2: //ciepło
                        temp_max = los.NextDouble() * 10 + 20;
                        break;
                }
                break;
            case 4: //lato
                switch (cbCzyCiepło.SelectedIndex)
                {
                    case 0: //zimno
                        temp_max = los.NextDouble() * 10 + 10;
                        break;
                    case 1: //normalnie
                        temp_max = los.NextDouble() * 5 + 20;
                        break;
                    case 2: //ciepło
                        temp_max = los.NextDouble() * 10 + 25;
                        break;
                }
                break;
            case 5: //polecie
                switch (cbCzyCiepło.SelectedIndex)
                {
                    case 0: //zimno
                        temp_max = los.NextDouble() * 10 + 5;
                        break;
                    case 1: //normalnie
                        temp_max = los.NextDouble() * 5 + 15;
                        break;
                    case 2: //ciepło
                        temp_max = los.NextDouble() * 10 + 20;
                        break;
                }
                break;
            case 6: //jesień
                switch (cbCzyCiepło.SelectedIndex)
                {
                    case 0: //zimno
                        temp_max = los.NextDouble() * 10;
                        break;
                    case 1: //normalnie
                        temp_max = los.NextDouble() * 5 + 10;
                        break;
                    case 2: //ciepło
                        temp_max = los.NextDouble() * 10 + 15;
                        break;
                }
                break;
            case 7: //przedzimie
                switch (cbCzyCiepło.SelectedIndex)
                {
                    case 0: //zimno
                        temp_max = los.NextDouble() * 10 - 5;
                        break;
                    case 1: //normalnie
                        temp_max = los.NextDouble() * 5 + 5;
                        break;
                    case 2: //ciepło
                        temp_max = los.NextDouble() * 10 + 10;
                        break;
                }
                break;
        }
        //różnica dni
        double temp_min;

        for (int i = 0; i < 4; i++) //uzupełnienie 4 dni Lublina i temperatury
        {
            różnica_doba = los.NextDouble() * 12;
            temp_min = temp_max - różnica_doba;
            if (cbSystem.SelectedIndex == 1) //system angielski
            {
                tb[i, 0].Text = (9 / 5 * temp_max + 32).ToString();
                tb[i, 2].Text = (9 / 5 * temp_min + 32).ToString();
            }
            else
            {
                tb[i, 0].Text = temp_max.ToString();
                tb[i, 2].Text = temp_min.ToString();
            }
            if (cbCzyStabilnie.SelectedIndex == 0 && (cbPoraRoku.SelectedIndex == 0 || cbPoraRoku.SelectedIndex == 1 || cbPoraRoku.SelectedIndex == 2 || cbPoraRoku.SelectedIndex == 5 || cbPoraRoku.SelectedIndex == 6 || cbPoraRoku.SelectedIndex == 7))
            {
                //ochłodzenie w okresie zimniejszym
                różnica_dni = los.NextDouble() * -5 - 1;
                tb[i, 3].Text = (los.NextDouble() * -4 - 4).ToString();
            }
            else if(cbCzyStabilnie.SelectedIndex == 0) //ochłodzenie w okresie letnim
            {
                int wiatr = los.Next(2) + 6;
                if (i == 0) //przejście frontu
                    różnica_dni = los.NextDouble() * -10 - 5;
                else
                    różnica_dni = los.NextDouble() * -10 + 5;
                tb[i, 3].Text = (los.NextDouble() * 4 + 4).ToString();
            }
            else if (cbCzyStabilnie.SelectedIndex == 1) //stabilnie
            {
                int wiatr = los.Next(8);
                różnica_dni = los.NextDouble() * 2 - 4;
                tb[i, 3].Text = (los.NextDouble() - 1).ToString();
            }
            else if (cbCzyStabilnie.SelectedIndex == 2 && (cbPoraRoku.SelectedIndex == 0 || cbPoraRoku.SelectedIndex == 1 || cbPoraRoku.SelectedIndex == 2 || cbPoraRoku.SelectedIndex == 5 || cbPoraRoku.SelectedIndex == 6 || cbPoraRoku.SelectedIndex == 7)) //ocieplenie
            {
                //ocieplenie w okresie chłodniejszym
                int wiatr = los.Next(4) + 4;
                różnica_dni = los.NextDouble() * 2 + 4;
                tb[i, 3].Text = (los.NextDouble() * 4 + 2).ToString();
            }
            else
            {
                //ocieplenie w okresie cieplejszym
                int wiatr = los.Next(5);
                różnica_dni = los.NextDouble() * 2 + 4;
                tb[i, 3].Text = (los.NextDouble() * -6).ToString();
            }
            double punkt_rosy;
            punkt_rosy = temp_min + los.NextDouble() * 6 - 3;
            if (cbSystem.SelectedIndex == 1) //system angielski
                tb[i, 4].Text = (9 / 5 * punkt_rosy + 32).ToString();
            else
                tb[i, 4].Text = punkt_rosy.ToString();
            temp_max += różnica_dni;
        }
        //prędkość wiatr - pora roku nie ma znaczenia
        for (int i = 0; i < 4; i++)
        {
            double prędkość_wiatru = los.NextDouble() * 10;
            if (cbSystem.SelectedIndex == 1) //system angielski
                prędkość_wiatru = prędkość_wiatru * 1.944;
            tb[i, 1].Text = prędkość_wiatru.ToString();
        }

        //zjawiska pogodowe - pora roku ważna
        for (int i = 0; i < 4; i++)
        {
            //deszcz i śnieg
            temp_min = double.Parse(tb[i, 2].Text);
            temp_max = double.Parse(tb[i, 0].Text);
            if (temp_min >= -1 && temp_min < 5)
            {
                cb[i, 0].Checked = true;
                cb[i, 1].Checked = true;
            }
            else if (temp_min < -1)
            {
                cb[i, 0].Checked = false;
                cb[i, 1].Checked = true;
            }
            else
            {
                cb[i, 0].Checked = true;
                cb[i, 1].Checked = false;
            }
        }

        //ciśnienie - pora roku trochę ważna
        double ciśnienie;

        if (cbPoraRoku.SelectedIndex == 0 && cbCzyCiepło.SelectedIndex == 0) //zima
        {
            ciśnienie = los.NextDouble() * 30 + 1020;
        }
        else if (cbPoraRoku.SelectedIndex == 1 && cbCzyCiepło.SelectedIndex == 0) //zima
        {
            ciśnienie = los.NextDouble() * 30 + 1015;
        }
        else if (cbPoraRoku.SelectedIndex == 3 && cbCzyCiepło.SelectedIndex == 0) //zima
        {
            ciśnienie = los.NextDouble() * 30 + 1010;
        }
        else if (cbPoraRoku.SelectedIndex == 7 && cbCzyCiepło.SelectedIndex == 0) //zima
        {
            ciśnienie = los.NextDouble() * 30 + 1015;
        }
        else if (cbPoraRoku.SelectedIndex == 6 && cbCzyCiepło.SelectedIndex == 0) //zima
        {
            ciśnienie = los.NextDouble() * 30 + 1010;
        }
        else
        {
            ciśnienie = los.NextDouble() * 30 + 990;
        }
        for (int i = 0; i < 4; i++)
        {
            tb[i, 5].Text = ciśnienie.ToString();
            double różnica_ciśnienia;
            if (cbCzyStabilnie.SelectedIndex == 0 && (cbPoraRoku.SelectedIndex == 6 || cbPoraRoku.SelectedIndex == 7 || cbPoraRoku.SelectedIndex == 0 || cbPoraRoku.SelectedIndex == 1 || cbPoraRoku.SelectedIndex == 2))
            {
                różnica_ciśnienia = los.NextDouble() * 10 + 5;
            }
            else if (cbCzyStabilnie.SelectedIndex == 2 && (cbPoraRoku.SelectedIndex == 6 || cbPoraRoku.SelectedIndex == 7 || cbPoraRoku.SelectedIndex == 0 || cbPoraRoku.SelectedIndex == 1 || cbPoraRoku.SelectedIndex == 2))
            {
                różnica_ciśnienia = los.NextDouble() * -10 - 5;
            }
            else
            {
                różnica_ciśnienia = los.NextDouble() * -10 + 5;
            }
            ciśnienie += różnica_ciśnienia;
        }
    }

    public void Lublin()
    {

        string temp;
        string dana = "";
        double min_p = 0, max_p = 0, cis_p = 0, tpr_p = 0, w_p = 0, o_p = 0;
        StreamReader sr =  new StreamReader("Lublin_2010.txt");
        StreamReader sr2 = new StreamReader("indeks_2010.txt");
        double wynik;
        DateTime dt = new DateTime(2010, 1, 1);
        while (!sr.EndOfStream)
        {
            string linia = null;
            temp = sr.ReadLine(); //wczytaj linię z danymi 1 dnia
            int miesiąc = int.Parse(temp[18].ToString() + temp[19].ToString());
            int dzień = int.Parse(temp[20].ToString() + temp[21].ToString());
            //if (dt.Day != dzień)
            //    MessageBox.Show("Błąd");
            //dt = dt.AddDays(1.0);
             
            //konwersja dnia na porę roku
            if (miesiąc == 2 && dzień >= 16 || miesiąc == 3) //przedwiośnie
                linia += "1 ";
            else if (miesiąc == 4 || miesiąc == 5 && dzień <= 15) //wiosna
                linia += "2 ";
            else if (miesiąc == 5 && dzień > 15 || miesiąc == 6 && dzień <= 15) //przedlecie
                linia += "3 ";
            else if (miesiąc == 6 && dzień > 15 || miesiąc == 7 || miesiąc == 8 && dzień <= 15) //lato
                linia += "4 ";
            else if (miesiąc == 8 && dzień > 15 || miesiąc == 9 && dzień <= 20) //polecie
                linia += "5 ";
            else if (miesiąc == 9 && dzień > 20 || miesiąc == 10) //jesień
                linia += "6 ";
            else if (miesiąc == 11 || miesiąc == 12 && dzień <= 10) //przedzimie
                linia += "7 ";
            else
                linia += "0 ";



            //temperatura punktu rosy (35 - 40)
            dana = "";
            for (int i = 35; i <= 40; i++)
            {
                if (temp[i] != ' ' && temp[i] != '.' && temp[i] != ',')
                    dana = dana + temp[i];
                else if(temp[i] == '.' || temp[i] == ',')
                    dana = dana + CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            }
            wynik = double.Parse(dana);
            if (wynik != 9999.9)
                //sw.Write(wynik);
                linia += wynik.ToString() + " ";
            else
                //sw.Write(tpr_p);
                linia += tpr_p.ToString() + " ";
            //ciśnienie (46 - 51)
            dana = "";
            for (int i = 46; i <= 51; i++)
            {
                if (temp[i] != ' ' && temp[i] != '.' && temp[i] != ',')
                    dana = dana + temp[i];
                else if (temp[i] == '.' || temp[i] == ',')
                    dana = dana + CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            }
            wynik = double.Parse(dana);
            if (wynik != 9999.9)
                //sw.Write(wynik);
                linia += wynik.ToString() + " ";
            else
                //sw.Write(cis_p);
                linia += cis_p.ToString() + " ";
            //prędkość wiatru (78-82)
            dana = "";
            for (int i = 78; i <= 82; i++)
            {
                if (temp[i] != ' ' && temp[i] != '.' && temp[i] != ',')
                    dana = dana + temp[i];
                else if (temp[i] == '.' || temp[i] == ',')
                    dana = dana + CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            }
            wynik = double.Parse(dana);
            if (wynik != 999.9)
                //sw.Write(wynik);
                linia += wynik.ToString() + " ";
            else
                //sw.Write(w_p);
                linia += w_p.ToString() + " ";

            //maksymalna temperatura (102-107)
            dana = "";
            for (int i = 102; i <= 107; i++)
            {
                if (temp[i] != ' ' && temp[i] != '.' && temp[i] != ',')
                    dana = dana + temp[i];
                else if (temp[i] == '.' || temp[i] == ',')
                    dana = dana + CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            }
            wynik = double.Parse(dana);
            if (wynik != 9999.9)
                //sw.Write(wynik);
                linia += wynik.ToString() + " ";
            else
                //sw.Write(max_p);
                linia += max_p.ToString() + " ";

            //minimalna temperatura (110-115)
            dana = "";
            for (int i = 110; i <= 115; i++)
            {
                if (temp[i] != ' ' && temp[i] != '.' && temp[i] != ',')
                    dana = dana + temp[i];
                else if (temp[i] == '.' || temp[i] == ',')
                    dana = dana + CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            }
            wynik = double.Parse(dana);
            if (wynik != 9999.9)
                //sw.Write(wynik);
                linia += wynik.ToString() + " ";
            else
                //sw.Write(min_p);
                linia += min_p.ToString() + " ";
            //opady (118-122)
            dana = "";
            for (int i = 118; i <= 122; i++)
            {
                if (temp[i] != ' ' && temp[i] != '.' && temp[i] != ',')
                    dana = dana + temp[i];
                else if (temp[i] == '.' || temp[i] == ',')
                    dana = dana + CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            }
            wynik = double.Parse(dana);
            if (wynik < 99)
                //sw.Write(wynik);
                linia += wynik.ToString() + " ";
            else
                //sw.Write(o_p);
                linia += o_p.ToString() + " ";
            //132 - 137 zjawiska pogodowe
            for (int i = 132; i <= 136; i++)
            {
                if (temp[i] == '0')
                    linia += "0 ";
                else
                    linia += "1 ";
            }
            //zonal index
            linia = linia + sr2.ReadLine();
            linia = linia + " ";
            weryfikacja.Add(linia);

        }
        sr.Close();
        sr2.Close();
    }
    protected void buWynikiTestu_Click(object sender, EventArgs e)
    {
        //rozbić odpowiednie linie
        double[][] dni = new double[5][];
        for (int i = 0; i < 5; i++)
            dni[i] = Rozbij(weryfikacja[cbData.SelectedIndex + i], 13);
        //zamień jednostki jeśli trzeba
        /*
        Strukktura wyników
         * 0. pora roku
         * 1. punkt rosy
         * 2. ciśnienie
         * 3. prędkość wiatru
         * 4. temp. max
         * 5. temp. min
         * 6. wielkość opadów
         * 7. mgła
         * 8. deszcz
         * 9. śnieg
         * 10. grad
         * 11. burza
         * 12. zonal index
        */
        if (cbSystem.SelectedIndex == 0)
        {
            for (int i = 0; i < 5; i++)
            {
                dni[i][1] = 5.0 / 9.0 * (dni[i][1] - 32); //F => C
                dni[i][4] = 5.0 / 9.0 * (dni[i][4] - 32);
                dni[i][5] = 5.0 / 9.0 * (dni[i][5] - 32);
                dni[i][3] = dni[i][3] * 0.5144444444444440; //knoty => m/s
            }
        }
        //wpisz dane i wyniki do textboxów
        cbPoraRokuGłówna.SelectedIndex = (int)dni[4][0];
        for (int i = 0; i < 4; i++)
        {
            tb[i, 0].Text = dni[i][4].ToString();
            tb[i, 1].Text = dni[i][3].ToString();
            tb[i, 2].Text = dni[i][5].ToString();
            tb[i, 3].Text = dni[i][12].ToString();
            tb[i, 4].Text = dni[i][1].ToString();
            tb[i, 5].Text = dni[i][2].ToString();
            if (dni[i][8] == 0)
                cb[i, 0].Checked = false;
            else
                cb[i, 0].Checked = true;
            if (dni[i][9] == 0)
                cb[i, 1].Checked = false;
            else
                cb[i, 1].Checked = true;
        }
        tbTempMaxW0.Text = dni[4][4].ToString();
        tbTempMinW0.Text = dni[4][5].ToString();
        tbCiśnienieW0.Text = dni[4][2].ToString();
    }
    protected void buWynikiWszystkie_Click(object sender, EventArgs e)
    {
        StreamWriter sw = new StreamWriter("\\wyniki\\roznica_ciśnienie.txt");
        double wynik = 0;
        for (int i = 0; i < 361; i++)
        {
            buWynikiTestu_Click(null, null);
            buLicz_Click(null, null);
            wynik = Math.Abs(double.Parse(tbCiśnienieW0.Text) - double.Parse(tbCiśnienieW.Text));
            sw.Write(tbCiśnienieW.Text + " ");
            sw.Write(tbCiśnienieW0.Text + " ");
            sw.Write(wynik);
            sw.Write("\n");
            if(i != 360) //nie wykonuj dla ostatniego
                cbData.SelectedIndex++;
        }
        sw.Close();
    }
}