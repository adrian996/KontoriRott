using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.Windows.Threading;
using MahApps.Metro.Controls.Dialogs;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.Runtime.InteropServices;


namespace mahapps_testing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        DispatcherTimer dt = new DispatcherTimer();
        DispatcherTimer dt2 = new DispatcherTimer();
        DispatcherTimer monitorTick = new DispatcherTimer();
        private static string[] faktid = { "Umbkaudu 70% maailma mageveest on liustikes",
            "Ligikaudu 70% inimese ajust moodustab vesi", "Vaid 1% kogu maailma veest on kõlblik inimtarbimiseks",
            "Aju veepuudusest annab märki väsimus ja kontsentratsioonivõime langus", "Meie süda pumpab üle 7000 liitri verd iga päev",
            "70 kilo kaaluva inimese päevane veevajadus on umbes 2.7 liitrit" };
        public static int randomNumber;
        string[] toidud = { "banaan", "õun", "apelsin", "maasikas", "pirn",
                "šokolaad", "kohuke", "jogurt", "pähklid", "küpsised"};
        decimal[] kalorid = { 100, 51, 39, 40, 60, 557, 133, 89, 170, 350 };
        decimal kaloriteSumma = 0;
        public static int fadeDelay = 13;
        public int valik = 0;
        public static double veevalue = 0;
        public static double kaalvalue = 80;
        public static int incr = 0;


        public MainWindow()
        {
            InitializeComponent();
            lblAktiivsusDate.Content = DateTime.Now.ToShortDateString();
            
            dt2.Tick += dt2Ticker;
            dt.Tick += dtTicker;
            monitorTick.Tick += monitorTicker;
            timer3.Tick += timer3Ticker;
            timer();
            randomFakt();
            ToidudListi();
            TegevusedListi();
            IntensiivsusListi();
        }


        private async void KaloriKalk_Click(object sender, RoutedEventArgs e)
        {
            PeamenyyP1.Visibility = PeamenyyP2.Visibility = Visibility.Hidden;
            valik = 1;
            S2tted.Visibility = Visibility.Hidden;
            FadeOut(Peamenyy, fadeDelay);
            await Task.Delay(150);
            Kalorikalkulaator.IsEnabled = true;
            Peamenyy.IsEnabled = false;
            FadeIn(Kalorikalkulaator, fadeDelay);
            Kalorikalkulaator.Visibility = Visibility.Visible;
            KalorP1.Visibility = KalorP2.Visibility = Visibility.Visible;
        }

        private async void Veem66dik_Click(object sender, RoutedEventArgs e)
        {
            //System.Environment.Exit(1);
            PeamenyyP1.Visibility = PeamenyyP2.Visibility = Visibility.Hidden;
            valik = 2;
            S2tted.Content = "seaded";
            S2tted.Visibility = Visibility.Visible;
            FadeOut(Peamenyy, fadeDelay);
            await Task.Delay(150);
            Veemoodik.IsEnabled = true;
            Peamenyy.IsEnabled = false;
            FadeIn(Veemoodik, fadeDelay);
            Veemoodik.Visibility = Visibility.Visible;
            MinaP1.Visibility = MinaP3.Visibility = Visibility.Visible;
        }

        private async void Monitooring_Click(object sender, RoutedEventArgs e)
        {
            PeamenyyP1.Visibility = PeamenyyP2.Visibility = Visibility.Hidden;
            valik = 3;
            S2tted.Visibility = Visibility.Hidden;
            FadeOut(Peamenyy, fadeDelay);
            await Task.Delay(150);
            Monitor.IsEnabled = true;
            Peamenyy.IsEnabled = false;
            FadeIn(Monitor, fadeDelay);
            Monitor.Visibility = Visibility.Visible;
            monitorvasakPaneel.Visibility = Visibility.Visible;
            MinaP1.Visibility = MinaP3.Visibility = Visibility.Visible;
        }

        private async void Aktiivsus_Click(object sender, RoutedEventArgs e)
        {
            PeamenyyP1.Visibility = PeamenyyP2.Visibility = Visibility.Hidden;
            S2tted.Visibility = Visibility.Hidden;
            valik = 4;
            FadeOut(Peamenyy, fadeDelay);
            await Task.Delay(150);
            AktiivsusP.IsEnabled = true;
            Peamenyy.IsEnabled = false;
            FadeIn(AktiivsusP, fadeDelay);
            AktiivsusP.Visibility = Visibility.Visible;
            AktiivsusP1.Visibility = AktiivsusP2.Visibility = Visibility.Visible;
        }



        private async void Mina_Click(object sender, RoutedEventArgs e)
        {
            PeamenyyP1.Visibility = PeamenyyP2.Visibility = Visibility.Hidden;
            valik = 6;
            S2tted.Content = "seaded";
            S2tted.Visibility = Visibility.Visible;
            FadeOut(Peamenyy, fadeDelay);
            await Task.Delay(150);
            MinaP.IsEnabled = true;
            Peamenyy.IsEnabled = false;
            FadeIn(MinaP, fadeDelay);
            MinaP.Visibility = Visibility.Visible;
            MinaP1.Visibility = MinaP2.Visibility = MinaP3.Visibility = Visibility.Visible;

        }




        private async void BackButton_Click(object sender, RoutedEventArgs e)
        {
            switch (valik)
            {
                
                case 1:
                    KalorP1.Visibility = KalorP2.Visibility = Visibility.Hidden;
                    FadeOut(Kalorikalkulaator, fadeDelay);
                    await Task.Delay(150);
                    Kalorikalkulaator.Visibility = Visibility.Hidden;
                    Kalorikalkulaator.IsEnabled = false;
                    randomFakt();
                    FadeIn(Peamenyy, fadeDelay);
                    Peamenyy.IsEnabled = true;
                    Peamenyy.Visibility = Visibility.Visible;
                    PeamenyyP1.Visibility = PeamenyyP2.Visibility = Visibility.Visible;
                    valik = 0;
                    S2tted.Content = "välju";
                    S2tted.Visibility = Visibility.Visible;
                    break;
                case 2:
                    MinaP1.Visibility = MinaP3.Visibility = Visibility.Hidden;
                    FadeOut(Veemoodik, fadeDelay);
                    await Task.Delay(150);
                    Veemoodik.Visibility = Visibility.Hidden;
                    Veemoodik.IsEnabled = false;
                    randomFakt();
                    FadeIn(Peamenyy, fadeDelay);
                    Peamenyy.IsEnabled = true;
                    Peamenyy.Visibility = Visibility.Visible;
                    PeamenyyP1.Visibility = PeamenyyP2.Visibility = Visibility.Visible;
                    valik = 0;
                    S2tted.Content = "välju";
                    S2tted.Visibility = Visibility.Visible;
                    break;
                case 3:
                    MinaP1.Visibility = MinaP3.Visibility = Visibility.Hidden;
                    FadeOut(Monitor, fadeDelay);
                    await Task.Delay(150);
                    Monitor.Visibility = Visibility.Hidden;
                    Monitor.IsEnabled = false;
                    randomFakt();
                    FadeIn(Peamenyy, fadeDelay);
                    Peamenyy.IsEnabled = true;
                    Peamenyy.Visibility = Visibility.Visible;
                    PeamenyyP1.Visibility = PeamenyyP2.Visibility = Visibility.Visible;
                    valik = 0;
                    S2tted.Content = "välju";
                    S2tted.Visibility = Visibility.Visible;
                    break;
                case 4:
                    AktiivsusP1.Visibility = AktiivsusP2.Visibility = Visibility.Hidden;
                    FadeOut(AktiivsusP, fadeDelay);
                    await Task.Delay(150);
                    AktiivsusP.Visibility = Visibility.Hidden;
                    AktiivsusP.IsEnabled = false;
                    randomFakt();
                    FadeIn(Peamenyy, fadeDelay);
                    Peamenyy.IsEnabled = true;
                    Peamenyy.Visibility = Visibility.Visible;
                    PeamenyyP1.Visibility = PeamenyyP2.Visibility = Visibility.Visible;
                    valik = 0;
                    S2tted.Content = "välju";
                    S2tted.Visibility = Visibility.Visible;
                    break;
                case 6:
                    MinaP1.Visibility = MinaP2.Visibility = MinaP3.Visibility = Visibility.Hidden;
                    FadeOut(MinaP, fadeDelay);
                    await Task.Delay(150);
                    MinaP.Visibility = Visibility.Hidden;
                    MinaP.IsEnabled = false;
                    randomFakt();
                    FadeIn(Peamenyy, fadeDelay);
                    Peamenyy.IsEnabled = true;
                    S2tted.Content = "välju";
                    S2tted.Visibility = Visibility.Visible;
                    Peamenyy.Visibility = Visibility.Visible;
                    PeamenyyP1.Visibility = PeamenyyP2.Visibility = Visibility.Visible;
                    valik = 0;
                   
                    break;


            }
        }

        private async void FadeOut(Grid o, int interval = 80)
        {
            //Object is fully visible. Fade it out
            while (o.Opacity > 0.0)
            {
                await Task.Delay(interval);
                o.Opacity -= 0.25;
            }
            o.Opacity = 0; //make fully invisible       
        }

        private async void FadeIn(Grid o, int interval = 80)
        {
            //Object is not fully invisible. Fade it in
            while (o.Opacity < 1.0)
            {
                await Task.Delay(interval);
                o.Opacity += 0.25;
            }
            o.Opacity = 1; //make fully visible       
        }

        private void timer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Content = DateTime.Now.ToString("HH:mm");
            //lblAktiivsusTime.Content = DateTime.Now.ToString("HH:mm");
        }

        private void randomFakt()
        {
            Random nr = new Random();
            randomNumber = nr.Next(0, 5);
            faktiKast.Text = faktid[randomNumber].ToString();
        }

        private void ToidudListi()
        {
            for (int i = 0; i < toidud.Length; toidulist.Items.Add(toidud[i]), i++) ;
        }



        private async void ArvutaToit_Click(object sender, RoutedEventArgs e)
        {
            int i = toidulist.SelectedIndex;
            decimal temp;

            if (toidulist.SelectedIndex != -1)
            {
                var valik = toidulist.SelectedItem.ToString();
                //MessageBox.Show(valik);
                if (kogusKast.Value != null)
                {
                    // MessageBox.Show(i.ToString() + " " + kalorid[i] + " " + ((int)(kogusKast.Value)).ToString() + " ");

                    temp = (kalorid[i] * (int)(kogusKast.Value)) / 100;


                    toidurida.Text += valik + "\t\t  " + kalorid[toidulist.SelectedIndex] + "\t            " + kogusKast.Value.ToString() + "\t   " +
                        ((kalorid[i] * (int)(kogusKast.Value)) / 100).ToString() + "\n";

                    kaloriteSumma = kaloriteSumma + temp;
                    //MessageBox.Show(kaloriteSumma.ToString());
                    kaloridKokku.Content = "Kalorid kokku: " + kaloriteSumma.ToString() + " kcal";
                    minaKalorid.Text = "Kaloreid tarbitud : " + kaloriteSumma.ToString() + " kcal";
                }
                else
                    await this.ShowMessageAsync("Sisesta kogus!", "");
            }
            else
            {
                await this.ShowMessageAsync("Pole midagi lisada", "Proovi uuesti!");
            }
            //puhtaksNupp.IsEnabled = true;
        }

        private void ToidukastPuhtaks_Click(object sender, RoutedEventArgs e)
        {
            toidurida.Text = "";
            kaloridKokku.Content = "Kalorid kokku: - kcal";
            minaKalorid.Text = "Kaloreid tarbitud : - kcal";
            toidulist.SelectedIndex = -1;
            kogusKast.Value = null;
            //MessageBox.Show();
        }

        private async void LisauusToit_Click(object sender, RoutedEventArgs e)
        {
            var tempfood = "";
            var tempkalorsus = "";
            double value;
            do
            {
                tempfood = await this.ShowInputAsync("Toiduaine", "");
                if (tempfood == null)
                    break;
            }
            while (double.TryParse(tempfood, out value) || tempfood == null);


            if (tempfood != null)
            {
                do
                {
                    tempkalorsus = await this.ShowInputAsync("Kalorsus", "");
                    if (tempkalorsus == null)
                        break;
                }
                while (!double.TryParse(tempkalorsus, out value));

                if (tempkalorsus != null)
                {
                    Array.Resize(ref toidud, toidud.Length + 1);
                    toidud[toidud.Length - 1] = tempfood;

                    Array.Resize(ref kalorid, kalorid.Length + 1);
                    kalorid[kalorid.Length - 1] = Convert.ToDecimal(tempkalorsus);
                    toidulist.Items.Add(tempfood);
                }
            }


        }

        private async void LisaVesi_Click(object sender, RoutedEventArgs e)
        {
            var temp = "";
            double temp2 = 0;
            //MessageBox.Show(veevalue.ToString() + " 1.kord");
            do
            {
                temp = await this.ShowInputAsync("Veekogus (milliliitrites)", "");
                if (temp == null)
                    break;
            }
            while (!double.TryParse(temp, out temp2));

            if (temp != null)
            {
                //MessageBox.Show(veevalue.ToString() + " 2.kord");
                veevalue += temp2;
                veeMeeter.Value += ((veevalue * 100) / (kaalvalue*30));
                t2naneTarbimine.Text = "Tarbimine: " + (veevalue / 1000) + " l";
                minaVesi.Text = "Vett joodud: " + (veevalue / 1000) + " l";
                veeProtsent.Text = "Progress: " + ((veevalue * 100) / (kaalvalue*30)).ToString("0.##") + "%";
            }
        }

        private async void TyhjendaVesi_Click(object sender, RoutedEventArgs e)
        {
            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Jah, tühjenda",
                NegativeButtonText = "Ei, tagasi "
            };
            var result = await this.ShowMessageAsync("Tahad kõik tühjendada?", "Kogu vee mõõtmine nullitakse", MessageDialogStyle.AffirmativeAndNegative, mySettings);

            if (result == MessageDialogResult.Affirmative)
            {
                veeMeeter.Value = 0;
                veevalue = 0;
                t2naneTarbimine.Text = "Tarbimine: 0 l";
                minaVesi.Text = "Vett joodud: - l";
                veeProtsent.Text = "Progress: 0 %";
            }
        }

        private async void S2tted_Click(object sender, RoutedEventArgs e)
        {
            var temp = "";

            switch (valik)
            {
                case 0:
                    {
                        System.Environment.Exit(1);
                        
                        break;
                    }
                case 6:
                    do
                    {
                        temp = await this.ShowInputAsync("Sisesta nimi!", "");
                        if (temp == null)
                            break;
                    }
                    while (double.TryParse(temp, out kaalvalue));

                    if (temp != null)
                    {
                        nimeKast.Content = "Tere, " + temp + " !";
                    }
                    break;
                case 2:
                    do
                    {
                        temp = await this.ShowInputAsync("Sisesta uus kehakaal (kg)", "Logimine tühjendatakse");
                        if (temp == null)
                            break;
                    }
                    while (!double.TryParse(temp, out kaalvalue) || kaalvalue <= 20);
                    if (temp != null)
                    {
                        kehaKaalkast.Text = "Kehakaal: " + temp + " kg";
                        soovKogus.Text = "Soovitatav kogus: " + (kaalvalue * 0.03) + " l";
                        veeMeeter.Value = 0;
                        veevalue = 0;
                        t2naneTarbimine.Text = "Tarbimine: 0 l";
                        veeProtsent.Text = "Progress: 0 %";
                    }
                    break;
                    
                default:
                    return;
            }

        }




        private async void VesiAlarm_Click(object sender, RoutedEventArgs e)
        {
            var tempvesi = "";
            bool alarm;
            int value = 0;
            do
            {
                tempvesi = await this.ShowInputAsync("Meeldetuletuse aeg (minutites)", "");
                if (tempvesi == null)
                    break;
            }
            while (!int.TryParse(tempvesi, out value) || value <= 0);

            if (tempvesi != null)
            {
                alarm = true;
                incr = value;
                dt.Interval = new TimeSpan(0, 0, 1);
                dt.Start();
            }
            /*else if (alarm == false)
            {

            }*/

        }

        private int increment = 0;
        private async void dtTicker(object sender, EventArgs e)
        {
            incr--;
            //timerLabel.Content = incr.ToString();
            if (incr == 0)
            {
                dt.Stop();

                this.WindowState = WindowState.Normal;
                this.Activate();

                await this.ShowMessageAsync("Meeldetuletus!", "Joo vett");
            }
        }


        private void timer_tick(object sender, EventArgs e)
        {
            increment++;
            pckasutusTB.Text = TimeSpan.FromSeconds(increment).ToString();

        }






        DispatcherTimer timer2 = new DispatcherTimer();
        string[] skript;
        double[] nums;
        private async void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            valik = 3;

            timer2.Interval = TimeSpan.FromSeconds(1);
            timer2.Tick += timer_tick;
            
            /*
             * SEE OSA, KUI RIISTVARA ON KÜLJES ja LOEB DATAFAILIST

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                ScriptEngine engine = Python.CreateEngine();
                engine.ExecuteFile("C:/Users/Franklin/Desktop/test.py");
            }).Start();
            await Task.Delay(5800);

            while (true)
            {
                //MessageBox.Show("valmis");
                //skript = File.ReadAllLines("data.txt");
                //skript = File.OpenRead("data.txt");
                //MessageBox.Show(skript[0]);

                
                    // Actions you perform on the reader.

                await Task.Delay(3480);
                
                skript = File.ReadAllLines("data.txt");
                            if (skript[0] != "")
                                nums = Array.ConvertAll(skript[0].Split(','), double.Parse);
                            else
                                nums = Array.ConvertAll(skript[1].Split(','), double.Parse);

                            hetkeneKogus.Text = "Hetkkaal: " + nums[1] + " ml";
                            toitKaal.Text = "Hetkkaal: " + nums[1] + " g";
                //MessageBox.Show(nums[1].ToString());

                if (nums[0] != 0)
                                timer2.Start();
                            else
                                timer2.Stop();
                skript[1] = skript[0] = "";
                            
                //File.Delete(@"C:/Users/Franklin/Desktop/data.txt");

            

            }

            */

        }



        public static int incr2 = 0;
        private void MonitorReminder_Click(object sender, RoutedEventArgs e)
        {
            incr2 = (int)too;

            monitorTick.Interval = new TimeSpan(0, 0, 1);
            monitorTick.Start();

        }

        [DllImport("user32.dll")]
        static extern bool BlockInput(bool fBlockIt);
        DispatcherTimer timer3 = new DispatcherTimer();
        private void monitorTicker(object sender, EventArgs e)
        {
            incr2--;
            //timerLabel.Content = incr.ToString();
            if (incr2 == 0)
            {
                monitorTick.Stop();
                
                //await Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(delegate ()
                //{
                this.WindowState = WindowState.Normal;
                this.Activate();
                BlockInput(true);
                tabalukk.Visibility = Visibility.Visible;
                timer2.Stop();
                bbut.Visibility = Visibility.Hidden;
                Monitor.Visibility = Visibility.Visible;
                monitorvasakPaneel.Visibility = Visibility.Hidden;
                monitorLukusPaneel.Visibility = Visibility.Visible;
                koguPuhkus += (int)puhkus;
                minaPuhke.Text = "Puhkeperiood kokku: " + (koguPuhkus / 60) + " h " + (koguPuhkus % 60) + " min";
                
                
                //Siia tuleb taimer, kui kaua lukus
                timer3.Interval = new TimeSpan(0, 0, 1);
                timer3.Start();
                
                /*
                 * SCRIPT MIS LOEB TEKSTIFAILI VMS
                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    
                    ScriptEngine engine = Python.CreateEngine();
                    //var paths = engine.GetSearchPaths();
                    //paths.Add("ironpython\\Lib\\");
                    //paths.Add(@"C:\Python27\Lib"); // or you can add the CPython libs instead
                    //engine.SetSearchPaths(paths);
                    engine.ExecuteFile("disable.py");
                }).Start();

                */
                //})
                //);
            }
        }



        private void MonitorTyhjenda_Click(object sender, RoutedEventArgs e)
        {
            increment = 0;
            puhkus = 0;
            pausiPikkusTB.Text = "";
            too = 0;
            arvutikasutTB.Text = "";
        }

        double puhkus = 0;
        double too = 0;
        private int koguPuhkus = 0;
        private int koguToo = 0;
        private int incrementLukk = 0;
        private async void MonitorSeaded_Click(object sender, RoutedEventArgs e)
        {
            var temp = "";
            do
            {
                temp = await this.ShowInputAsync("Puhkuseperiood ", "minutites");
                if (temp == null)
                    break;
            }
            while (!double.TryParse(temp, out puhkus) || puhkus <= 0);

            if (temp != null)
            {
                do
                {
                    temp = await this.ShowInputAsync("Tööperiood ", "minutites");
                    if (temp == null)
                        break;
                }
                while (!double.TryParse(temp, out too) || too <= 0);

                // puhkus * 60, siis teeb minutites
                // too * 60 , siis minutites
                incrementLukk = (int)puhkus;

                pausiPikkusTB.Text = ((int)puhkus / 60) + " h " + ((int)puhkus % 60) + " min";
                arvutikasutTB.Text = ((int)too / 60) + " h " + ((int)too % 60) + " min";
                monitorReminder.IsEnabled = true;
            }

        }


        private void timer3Ticker(object sender, EventArgs e)
        {
            incrementLukk--;
            MonLukusAeg.Text = incrementLukk.ToString();

            if (incrementLukk == 0)
            {
                timer3.Stop();
                koguToo += (int)too;
                minaToo.Text = "Tööperiood kokku: " + (koguToo / 60) + " h " + (koguToo % 60) + " min";
                tabalukk.Visibility = Visibility.Hidden;
                bbut.Visibility = Visibility.Visible;
                monitorvasakPaneel.Visibility = Visibility.Visible;

                /*new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    
                    ScriptEngine engine = Python.CreateEngine();
                    engine.ExecuteFile("enable.py");
                }).Start();
                */

                BlockInput(false);
                

                monitorLukusPaneel.Visibility = Visibility.Hidden;
                incrementLukk = (int)puhkus;
                timer2.Start();

            }

        }


        string[] tegevused = { "jooksmine", "ujumine", "jalutamine", "rattasõit", "pallimängud",
                "jõusaal", "suusatamine", "tantsimine", "maadlemine"};
        decimal[] tegevusKalorid = { 10, 55, 66, 87, 95, 23, 45, 234, 55 };
        string[] intensiivsused = { "madal", "keskmine", "kõrge" };

        private void TegevusedListi()
        {
            for (int i = 0; i < tegevused.Length; tegevusList.Items.Add(tegevused[i]), i++) ;
        }

        private void IntensiivsusListi()
        {
            for (int i = 0; i < intensiivsused.Length; intensiivsusList.Items.Add(intensiivsused[i]), i++) ;
        }



        private void aktClear_Click(object sender, RoutedEventArgs e)
        {
            kestusKokku = 0;
            aktList.Text = "";
            kestusKokkuLabel.Content = "Kestus kokku: ";
            intensiivsusList.SelectedIndex = tegevusList.SelectedIndex = -1;
            tegevusKestus.Value = null;

        }



        public int increment2 = 0;
        public int incr3 = 0;
        string tegevus = "";

        public async void aktRemind_Click(object sender, RoutedEventArgs e)
        {
            var temp = "";
            var tempt = "";

            bool alarm;
            int value = 0;
            do
            {
                tempt = await this.ShowInputAsync("Tegevus", "");
                if (tempt == null)
                    break;
            }
            while (int.TryParse(tempt, out value) || tempt == null);

            if (tempt != null)
            {
                do
                {
                    temp = await this.ShowInputAsync("Meeldetuletuse aeg (minutites)", "");
                    if (temp == null)
                        break;
                }
                while (!int.TryParse(temp, out value) || value <= 0);

                if (temp != null)
                {
                    tegevus = tempt;
                    alarm = true;
                    incr3 = value;
                    dt2.Interval = new TimeSpan(0, 0, 1);
                    dt2.Start();
                }
            }
        }

        

        private async void dt2Ticker(object sender, EventArgs e)
        {
            incr3--;
            //timerLabel.Content = incr.ToString();
            if (incr3 == 0)
            {
                dt2.Stop();

                this.WindowState = WindowState.Normal;
                this.Activate();

                
                await this.ShowMessageAsync("Meeldetuletus!", tegevus);
            }
        }


        private void timer2_tick(object sender, EventArgs e)
        {
            increment2++;
           
        }

        private int kestusKokku = 0;
        private async void tegevusLisa_Click(object sender, RoutedEventArgs e)
        {
            int i = tegevusList.SelectedIndex;
            decimal temp;

            if (tegevusList.SelectedIndex != -1 && tegevusList.SelectedIndex != -1 && tegevusKestus.Value > 0 && tegevusKestus.Value <= 500)
            {
                var valik = tegevusList.SelectedItem.ToString();
                var valik2 = intensiivsusList.SelectedItem.ToString();
                aktList.Text += valik + "\t\t  " + valik2 + "\t         " + (int)tegevusKestus.Value + "\t  " + "\n";
                kestusKokku += (int)tegevusKestus.Value;
                kestusKokkuLabel.Content = "Kestus kokku: " + ((int)kestusKokku / 60) + " h " + ((int)kestusKokku % 60) + " min";
                minaAkt.Text = "Kehaline aktiivsus: " + ((int)kestusKokku / 60) + "h " + ((int)kestusKokku % 60) + "min";
            }
            else
            {
                await this.ShowMessageAsync("Pole midagi lisada", "Proovi uuesti!");
            }
        }

        
            
        private async void saveLog_Click(object sender, RoutedEventArgs e)
        {
            
            using (StreamWriter writer = new StreamWriter("logi.txt", true))
            {
                writer.WriteLine(lblAktiivsusDate.Content);
                writer.WriteLine(minaKaal.Text);
                writer.WriteLine(minaKalorid.Text);
                writer.WriteLine(minaVesi.Text);
                writer.WriteLine(minaToo.Text);
                writer.WriteLine(minaPuhke.Text);
                writer.WriteLine(minaAkt.Text);
                writer.WriteLine("END");
                writer.Write("\n");
                await this.ShowMessageAsync("Logi salvestatud", "" + lblAktiivsusDate.Content);
            }
            kalender.Text = null;
            
        }
        string[] lines = File.ReadAllLines("logi.txt");
        private async void getLog_Click(object sender, RoutedEventArgs e)
        {
            int pos = Array.IndexOf(lines, kalender.Text);
            if (pos >= 0 && pos <= lines.Length)
            {
                while (lines[pos] != "END")
                {
                    lblAktiivsusDate.Content = lines[pos];
                    pos++;
                    minaKaal.Text = lines[pos];
                    pos++;
                    minaKalorid.Text = lines[pos];
                    pos++;
                    minaVesi.Text = lines[pos];
                    pos++;
                    minaToo.Text = lines[pos];
                    pos++;
                    minaPuhke.Text = lines[pos];
                    pos++;
                    minaAkt.Text = lines[pos];
                    pos++;
                }
                await this.ShowMessageAsync("Logi saadud", "" + lblAktiivsusDate.Content);
            }
            else
            {
                await this.ShowMessageAsync("Logi ei eksisteeri", "" + kalender.Text);
            }
        }

        private void kalender_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            getLog.IsEnabled = true;
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
            
        }
    }
}
