using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;

public class Neuron //struktura przechowująca wszystkie dane neuronu
{
    private double _wartość;
    private double[] _wagi;
    private double[] _poprzednie_wagi;
    private double _błąd;
    private double _błądMSE;
    private double _e;
    private double _bias;
    private double _a;
    private double _próg;
    private double _poprzedni_próg;

    public Neuron()
    {
    }

    public double wartość
    {
        get
        {
            return _wartość;
        }
        set
        {
            _wartość = value;
        }
    }
    public double[] wagi
    {
        get
        {
            return _wagi;
        }
        set
        {
            _wagi = value;
        }
    }
    public double[] poprzednie_wagi
    {
        get
        {
            return _poprzednie_wagi;
        }
        set
        {
            _poprzednie_wagi = value;
        }
    }
    public double błąd
    {
        get
        {
            return _błąd;
        }
        set
        {
            _błąd = value;
        }
    }

    public double błądMSE
    {
        get
        {
            return _błądMSE;
        }
        set
        {
            _błądMSE = value;
        }
    }

    public double e
    {
        get
        {
            return _e;
        }
        set
        {
            _e = value;
        }
    }

    public double bias
    {
        get
        {
            return _bias;
        }

        set
        {
            _bias = value;
        }
    }

    public double a
    {
        get
        {
            return _a;
        }

        set
        {
            _a = value;
        }
    }

    public double próg
    {
        get
        {
            return _próg;
        }

        set
        {
            _próg = value;
        }
    }

    public double poprzedni_próg
    {
        get
        {
            return _poprzedni_próg;
        }

        set
        {
            _poprzedni_próg = value;
        }
    }
}

public class SiećNeuronowa
{
    private List<List<Neuron>> neurony;
    private double learning_rate;
    private double momentum;
    private double dół_wag; //dolny zakres przedziału wag
    private double góra_wag; //górny zakres przedziału wag
    private Random los; //do losowania wartości początkowych wag
    private double bias;
    private bool warunek_końca; //false - ilość epok, true - błąd
    private long ile_epok; //ilość epok do zakończenia
    private double błąd_min; //maksymalny dopuszczalny błąd
    private double[] poprawne_wyjście; //tablica przechowująca wartości jakie powinna dać sieć
    private List<string> uczący; //przechowuje dane zbioru uczącego
    private List<string> testowy; //przechowuje dane zbioru testowego
    private double[] linia_uczenie; //linia zawierająca wejście i wyjście do uczenia
    private double[] warstwa_wejściowa; //aktualne wejście
    private string plik_uczący;
    private string plik_testujący;
    bool pokaż_epokę;
    bool pokaż_błąd;
    private double _beta;
    //właściwości
    public double beta
    {
        get
        {
            return _beta;
        }
        set
        {
            _beta = value;
        }
    }
    public double learning_rateP
    {
        get
        {
            return learning_rate;
        }
        set
        {
            learning_rate = value;
        }
    }
    public double momentumP
    {
        get
        {
            return momentum;
        }
        set
        {
            learning_rate = value;
        }
    }
    public double dół_wagP
    {
        get
        {
            return dół_wag;
        }
        set
        {
            dół_wag = value;
        }
    }
    public double góra_wagP
    {
        get
        {
            return góra_wag;
        }
        set
        {
            góra_wag = value;
        }
    }
    public double biasP
    {
        get
        {
            return bias;
        }
        set
        {
            bias = value;
        }
    }
    public bool warunek_końcaP
    {
        get
        {
            return warunek_końca;
        }
        set
        {
            warunek_końca = value;
        }
    }
    public long ile_epokP
    {
        get
        {
            return ile_epok;
        }
        set
        {
            ile_epok = value;
        }
    }
    public double błąd_minP
    {
        get
        {
            return błąd_min;
        }
        set
        {
            błąd_min = value;
        }
    }

    public long[] struktura_sieciP
    {
        get
        {
            long[] struktura = new long[neurony.Count];
            for (int i = 0; i < struktura.Length; i++)
            {
                struktura[i] = neurony[i].Count;
            }
            return struktura;
        }
    }

    public string plik_uczącyP
    {
        get
        {
            return plik_uczący;
        }
        set
        {
            plik_uczący = value;
        }
    }

    public string plik_testującyP
    {
        get
        {
            return plik_testujący;
        }
        set
        {
            plik_testujący = value;
        }
    }

    public bool pokaż_epokęP
    {
        get
        {
            return pokaż_epokę;
        }
        set
        {
            pokaż_epokę = value;
        }
    }
    public bool pokaż_błądP
    {
        get
        {
            return pokaż_błąd;
        }
        set
        {
            pokaż_błąd = value;
        }
    }

    //strumienie do zapisywania danych w celach testowych
    //StreamReader wagi = new StreamReader("~/wagi.txt");
    public SiećNeuronowa(int[] opis_warstw, double mom, double lr, double dół, double góra, double wart_bias, bool sposób, long max_epok, double min_mse) //konstruktor tworzący sieć neironową
    {
        //tworzenie parametrów sieci
        learning_rate = lr;
        momentum = mom;
        neurony = new List<List<Neuron>>();
        dół_wag = dół;
        góra_wag = góra;
        los = new Random();
        bias = wart_bias;
        warunek_końca = sposób;
        ile_epok = max_epok;
        błąd_min = min_mse;
        poprawne_wyjście = new double[opis_warstw[opis_warstw.Length - 1]]; //tyle wyjść ile neuronów na ostatniej warstwie
        uczący = new List<string>();
        testowy = new List<string>();
        //tworzenie sieci
        List<Neuron> tmp = new List<Neuron>();
        for (int i = 0; i < opis_warstw.Length; i++)
        {
            for (int j = 0; j < opis_warstw[i]; j++)
            {
                tmp.Add(new Neuron());
                tmp[j].wartość = 0;
                if (i == opis_warstw.Length - 1) //ostatnia warstwa
                {
                    tmp[j].wagi = new double[0];
                    tmp[j].poprzednie_wagi = new double[0];
                }
                else
                {
                    tmp[j].wagi = new double[opis_warstw[i + 1]];
                    tmp[j].poprzednie_wagi = new double[opis_warstw[i + 1]];
                    //inicjalizacja wag i progu
                    for (int k = 0; k < tmp[j].wagi.Length; k++)
                    {
                        tmp[j].wagi[k] = (double)los.NextDouble() * (góra_wag - dół_wag) + dół_wag;
                        tmp[j].próg = (double)los.NextDouble() * (góra_wag - dół_wag) + dół_wag;
                        tmp[j].poprzednie_wagi[k] = 0;
                    }
                }
            }
            neurony.Add(new List<Neuron>(tmp));
            tmp.Clear();
        }
        for (int i = 0; i < neurony[neurony.Count - 1].Count; i++)
        {
            neurony[neurony.Count - 1][i].błąd = (double)0.0;
        }
        plik_testujący = null;
        plik_uczący = null;
        beta = 1.0;
    }

    public void InicjalizujWagiLosowo() //losowanie początkowych wartości wag
    {
        for (int i = 0; i < neurony.Count; i++)
        {
            for (int j = 0; j < neurony[i].Count; j++)
            {
                for (int k = 0; k < neurony[i][j].wagi.Length; k++)
                {
                    neurony[i][j].wagi[k] = (double)los.NextDouble() * (góra_wag - dół_wag) + dół_wag;
                    neurony[i][j].poprzednie_wagi[k] = 0;
                }
            }
        }
    }

    public bool UstawWagiRęcznie(double[] w, int nr_warstwy, int nr_neuronu)
    {
        if (nr_warstwy < 0 || nr_warstwy >= neurony.Count) //czy podano dobry numer warstwy
        {
            return false;
        }
        if (nr_neuronu < 0 || nr_neuronu >= neurony[nr_warstwy].Count) //czy podano dobry numer neuronu
        {
            return false;
        }
        if (neurony[nr_warstwy][nr_neuronu].wagi.Length != w.Length) //czy długość podanych danych zgadza się z ilością połączeń neuronu
            return false;
        for (int i = 0; i < w.Length; i++)
        {
            neurony[nr_warstwy][nr_neuronu].wagi[i] = w[i];
            neurony[nr_warstwy][nr_neuronu].poprzednie_wagi[i] = 0;
        }
        return true;
    }

    public bool UstawWagiRęcznie(double[] w)
    {
        long ile_wag = 0;
        for (int i = 0; i < neurony.Count - 1; i++)
            ile_wag += neurony[i].Count * neurony[i + 1].Count;
        if (ile_wag != w.Length)
            return false;
        long indeks = 0;
        for (int i = 0; i < neurony.Count - 1; i++)
        {
            for (int j = 0; j < neurony[i].Count; j++)
            {
                for (int k = 0; k < neurony[i][j].wagi.Length; k++)
                {
                    neurony[i][j].wagi[k] = w[indeks];
                    indeks++;
                }
            }
        }
        return true;
    }

    public bool UstawWartościPoczątkowe(double[] wart) //ustawia wartości na warstwie wejściowej
    {
        //czy ilość wartości = liczba neuronów pierwszej warstwy
        if (wart.Length != neurony[0].Count)
            return false;
        for (int i = 0; i < neurony[0].Count; i++)
        {
            neurony[0][i].wartość = wart[i];
        }
        return true;
    }

    public double FunkcjaAktywacji(double x) //funkcja aktywacji, wyniki zapisywane są do pliku jeśli możliwe
    {
        return (double)1.0 / (1.0 + Math.Exp((double)(-beta * x)));
    }

    public double PochodnaAktywacji(double x, StreamWriter s)
    {
        return beta * (1 - FunkcjaAktywacji(x)) * FunkcjaAktywacji(x);
    }

    public double[] UruchomSieć() //funkcja obliczająca odpowiedź sieci
    {
        double[] wynik;
        wynik = new double[neurony[neurony.Count - 1].Count];
        //StreamWriter akt = new StreamWriter("aktywacja.txt");
        for (int i = 1; i < neurony.Count; i++) //warstwy od 1 ukrytej do wyjściowej
        {
            for (int j = 0; j < neurony[i].Count; j++) //przejście przez neurony warstwy
            {
                double suma = 0;
                for (int k = 0; k < neurony[i - 1].Count; k++)
                {
                    suma += neurony[i - 1][k].wartość * neurony[i - 1][k].wagi[j];
                    //if (double.IsNaN(suma))
                    //{
                    //    throw new Exception();
                    //}
                    //neurony[i][j].wartość = FunkcjaAktywacji(suma, null);
                }
                //suma -= neurony[i][j].próg;
                suma += bias;
                neurony[i][j].e = suma;
                neurony[i][j].wartość = FunkcjaAktywacji(suma);
            }
        }
        //);
        for (int i = 0; i < wynik.Length; i++)
            wynik[i] = neurony[neurony.Count - 1][i].wartość;
        return wynik;
    }

    public void Przygotuj(int m, List<string> dane) //przygotowuje dane wejjścia i poprawnych i oczekiwanych wyjść
    {
        //dane do pliku wejście w 1 linii
        linia_uczenie = Rozbij(dane[m], neurony[0].Count + neurony[neurony.Count - 1].Count); //rozbijanie m-tej linii zbioru uczącego na pojedyncze wartości double 
        //przygotowywanie danych wejściowych
        warstwa_wejściowa = new double[neurony[0].Count];
        for (int o = 0; o < neurony[0].Count; o++)
            warstwa_wejściowa[o] = linia_uczenie[o];
        //przygotowywanie danych wyjściowych
        poprawne_wyjście = new double[neurony[neurony.Count - 1].Count];
        for (int o = 0; o < neurony[neurony.Count - 1].Count; o++)
            poprawne_wyjście[o] = linia_uczenie[neurony[0].Count + o];
        UstawWartościPoczątkowe(warstwa_wejściowa);
        UruchomSieć(); //obliczenie odpowiedzi sieci przy danych wartościach wag
    }

    private double[] Rozbij(string linia, int rozmiar)//rozbija stringa na tablicę doubli
    {
        while (linia[linia.Length - 1] == ' ')
            linia = linia.Substring(0, linia.Length - 1); //obetnij 1 znak
        double[] wynik = new double[rozmiar];
        int indeks = 0;
        string tmp = null;
        for (int i = 0; i < linia.Length + 1; i++)
        {
            if (i == linia.Length || linia[i] == ' ')
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
}
