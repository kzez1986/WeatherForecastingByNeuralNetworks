using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using PogodaWLublinie;

namespace SiećNeuronowa
{
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
        private UczTestuj ut;
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
        public UczTestuj utP
        {
            get
            {
                return ut;
            }
            set
            {
                ut = value;
            }
        }

        //strumienie do zapisywania danych w celach testowych

        public SiećNeuronowa(int[] opis_warstw, double mom, double lr, double dół, double góra, double wart_bias, bool sposób, long max_epok, double min_mse) //konstruktor tworzący sieć neironową
        {
            //tworzenie parametrów sieci
            beta = 1.0;
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
                            tmp[j].wagi[k] = los.NextDouble() * (góra_wag - dół_wag) + dół_wag;
                            tmp[j].próg = los.NextDouble() * (góra_wag - dół_wag) + dół_wag;
                            tmp[j].poprzednie_wagi[k] = 0;
                        }
                    }
                }
                neurony.Add(new List<Neuron>(tmp));
                tmp.Clear();
            }
            for (int i = 0; i < neurony[neurony.Count - 1].Count; i++)
            {
                neurony[neurony.Count - 1][i].błąd = 0.0;
            }
            plik_testujący = null;
            plik_uczący = null;
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

        public double PochodnaAktywacji(double x)
        {
            return beta * (1 - FunkcjaAktywacji(x)) * FunkcjaAktywacji(x);
        }

        public void LiczBłąd()
        {
            for (int i = 0; i < neurony[neurony.Count - 1].Count; i++)
            {
                neurony[neurony.Count - 1][i].błąd = poprawne_wyjście[i] - neurony[neurony.Count - 1][i].wartość; //błąd służący do nauki sieci
                neurony[neurony.Count - 1][i].błądMSE = neurony[neurony.Count - 1][i].błąd * neurony[neurony.Count - 1][i].błąd; //wartość służąca do obliczenia błędu średniokwadratowego dla całego wyjścia
            }
        }

        public void LiczBłąd(StreamWriter sw)
        {
            for (int i = 0; i < neurony[neurony.Count - 1].Count; i++)
            {
                LiczBłąd();
                sw.Write(neurony[neurony.Count - 1][i].błąd + " ");
            }
            sw.WriteLine();
        }

        public double MSE()
        {
            //obliczenie błędu średniokwadratowego dla sieci i zapisanie go do pliku
            double błąd = 0;
            for (int i = 0; i < neurony[neurony.Count - 1].Count; i++) //obliczenie sumy błędów na wszystkich neuronach
            {
                błąd += neurony[neurony.Count - 1][i].błądMSE;
            }
            błąd /= neurony[neurony.Count - 1].Count; //obliczenie błędu średniokwadratowego dla sieci
            return błąd;
        }

        public double[] UruchomSieć() //funkcja obliczająca odpowiedź sieci
        {
            double[] wynik;
            wynik = new double[neurony[neurony.Count - 1].Count];
            //StreamWriter akt = new StreamWriter("aktywacja.txt");
            for (int i = 1; i < neurony.Count; i++) //warstwy od 1 ukrytej do wyjściowej
            {
                Parallel.For(0, neurony[i].Count, (j) =>
                //for (int j = 0; j < neurony[i].Count; j++) //przejście przez neurony warstwy
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
                );
            }
            //);
            for (int i = 0; i < wynik.Length; i++)
                wynik[i] = neurony[neurony.Count - 1][i].wartość;
            return wynik;
        }

        public void PropagacjaBłędu() //funkcja odliczająca wartości błędów na warstwach ukrytych
        {
            //propagacja błędu
            for (int i = 0; i < neurony[neurony.Count - 1].Count; i++)
            {
                neurony[neurony.Count - 1][i].a = PochodnaAktywacji(neurony[neurony.Count - 1][i].e) * neurony[neurony.Count - 1][i].błąd;
            }
            Parallel.For(0, neurony.Count, (i) =>
            //for (int i = neurony.Count - 2; i >= 0; i--) //warstwy ukryte
            {
                //Parallel.For(0, neurony[i].Count, (j) =>
                for (int j = 0; j < neurony[i].Count; j++) //przejście po neuronach warstwy
                {
                    double suma = 0;
                    double suma2 = 0;
                    Parallel.For(0, neurony[i][j].wagi.Length, (k) =>
                    //for (int k = 0; k<neurony[i][j].wagi.Length; k++) //przejście po wagach
                    {
                        suma += neurony[i][j].wagi[k] * neurony[i + 1][k].a;
                        suma2 += neurony[i][j].wagi[k] * neurony[i + 1][k].błąd; 
                    }
                    );
                    neurony[i][j].a = suma;
                    neurony[i][j].błąd = suma2;
                }
            }
            );
        }

        public void AktualizacjaWag() //obliczanie nowych wartości wag
        {
            //zmiana wartości wag
            for (int i = 0; i < neurony.Count; i++) //warstwy bez ostatniej
            {
                for (int j = 0; j < neurony[i].Count; j++) //neurony
                {
                    Parallel.For(0, neurony[i][j].wagi.Length, (k) =>
                    //for (int k = 0; k < neurony[i][j].wagi.Length; k++) //wagi
                    {
                        double temp = neurony[i][j].wagi[k];
                        double temp2 = neurony[i][j].próg;
                        //Console.WriteLine(learning_rate * neurony[i + 1][k].błąd * PochodnaAktywacji(neurony[i + 1][k].e) * neurony[i][j].wartość + momentum * (neurony[i][j].wagi[k] - neurony[i][j].poprzednie_wagi[k]));
                        //if (double. IsNaN(PochodnaAktywacji(neurony[i+1][k].e)))
                        //    throw new Exception();
                        //zmiana.WriteLine(learning_rate * neurony[i + 1][k].błąd * PochodnaAktywacji(neurony[i + 1][k].e, p_a) * neurony[i][j].wartość + momentum * (neurony[i][j].wagi[k] - neurony[i][j].poprzednie_wagi[k])); //zapis do pliku zmian
                        neurony[i][j].wagi[k] += learning_rate * PochodnaAktywacji(neurony[i + 1][k].e) * neurony[i + 1][k].błąd * neurony[i][j].wartość - momentum * (neurony[i][j].wagi[k] - neurony[i][j].poprzednie_wagi[k]);
                        //neurony[i][j].wagi[k] += learning_rate * neurony[i + 1][k].a * neurony[i][j].wartość + momentum * (neurony[i][j].wagi[k] - neurony[i][j].poprzednie_wagi[k]);
                        //neurony[i][j].próg -= learning_rate * neurony[i + 1][k].a + momentum * (neurony[i][j].próg - neurony[i][j].poprzedni_próg);
                        //if (double.IsNaN(neurony[i][j].wagi[k]))
                        //    throw new Exception();
                        neurony[i][j].poprzednie_wagi[k] = temp;
                        neurony[i][j].poprzedni_próg = temp2;
                    }
                    );
                }
            }
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

        public void WstecznaPropagacja() //algorytm wstecznej propagacji błędów
        {
            int n = 0;
            for (n = 0; ; n++) //epoki
            {
                double średni_błąd = 0;
                if (ut.PokażEpoki.Checked)
                    WyświetlNumerEpoki(n);
                for (int m = 0; m < uczący.Count; m++) //zbiór uczący
                {
                    Przygotuj(m, uczący);
                    LiczBłąd(); //obliczenie wartości błędu dla danej próbki danych
                    double błąd = MSE(); //obliczenie błędu średniokwadratowego dla danej próbki danych
                    średni_błąd += błąd;
                    PropagacjaBłędu(); //oblicz błędy na warstwach ukrytych
                    AktualizacjaWag(); //zmień wartości wag
                }
                //ZapiszWagi(wagi); //zapisz wagi wyjściowe do pliku
                średni_błąd /= uczący.Count();
                if (!warunek_końca && n + 1 == ile_epok) //jeżeli ustawiono warunek końca uczenia na ilość epok i zakończono ostatnią epokę, zakończ
                {

                    return; //koniec uczenia
                }
                Console.WriteLine(" " + średni_błąd);
                if (ut.PokażBłąd.Checked)
                {
                    WyświetlBłąd(średni_błąd);
                }
                if (warunek_końca && średni_błąd <= błąd_min) //jeżeli ustawiono warunek końca na minimalny błąd i ten błąd jest mniejszy od minimalnego zakończ
                {
                    return; //koniec uczenia
                }
            }
        }

        private void WyświetlNumerEpoki(int epoka)
        {
            if (ut.NrEpoki.InvokeRequired)
                ut.NrEpoki.Invoke(new Action<int>(WyświetlNumerEpoki), epoka);
            else
                ut.NrEpoki.Text = epoka.ToString();
        }

        private void WyświetlBłąd(double śb)
        {
            if (ut.Błąd.InvokeRequired)
                ut.Błąd.Invoke(new Action<double>(WyświetlBłąd), śb);
            else
                ut.Błąd.Text = śb.ToString();
        }

        public bool WarunekKońca //właściwość ustawiająca prywatną zmienną decydującą o warunku końca uczenia 
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

        public void WczytajZbiórUczący(string nazwa) //wczytaj do listy dane z pliku uczącego
        {
            StreamReader sr = new StreamReader(nazwa);
            plik_uczący = nazwa;
            uczący.Clear();
            while (!sr.EndOfStream)
            {
                uczący.Add(sr.ReadLine());
            }
            sr.Close();
        }

        public void WczytajZbiórTestowy(string nazwa) //wczytaj do listy dane z pliku testowego
        {
            StreamReader sr = new StreamReader(nazwa);
            plik_testujący = nazwa;
            testowy.Clear();
            while (!sr.EndOfStream)
            {
                testowy.Add(sr.ReadLine());
            }
            sr.Close();
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

        public void ZapiszWagi(string nazwa) //zapisuje wagi do pliku
        {
            StreamWriter sw = new StreamWriter(nazwa);
            for (int i = 0; i < neurony.Count; i++)
            {
                for (int j = 0; j < neurony[i].Count; j++)
                {
                    for (int k = 0; k < neurony[i][j].wagi.Length; k++)
                    {
                        sw.Write(neurony[i][j].wagi[k] + " ");
                    }
                }
            }
            sw.WriteLine();
            sw.Close();
        }

        public void Testuj()
        {
            StreamWriter sw = new StreamWriter("test.txt");
            double błąd = 0;
            double błąd_tmp;
            for (int i = 0; i < testowy.Count; i++)
            {
                Przygotuj(i, testowy); //przygotowuje próbkę danych do testowania
                LiczBłąd();
                błąd_tmp = MSE();
                sw.WriteLine(błąd_tmp);
                błąd += błąd_tmp;
            }
            sw.WriteLine();
            sw.WriteLine(błąd);
            sw.Close();
        }
    }
}
