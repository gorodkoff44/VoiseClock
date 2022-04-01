using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Speech.AudioFormat;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Говорящие_часы
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        void Timer_Tick(object sender, EventArgs e)
        {
            lblTime.Content = DateTime.Now.ToLongTimeString();
        }
        public void StartVoise(System.Speech.Synthesis.VoiceGender gender, System.Speech.Synthesis.VoiceAge age)
        {

        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            string text = (string)lblTime.Content; //Перенос времени в другую переменную
            string[] words = text.Split(new char[] { ':' }); //разделение данных переменной до :
            string first = words[0]; //часы
            string second = words[1]; //минуты
            //string second = "01"; //вручную задать минуты
            int h = int.Parse(first);
            int min = int.Parse(second);
            string hr = "";
            string secc=""; //минуты из чисел в слово
            string okk = ""; //окончание
            string ok = ""; //окончание
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();

            //поправка озвучки
            if ((h==0)||(h >= 5) & (h < 21) || (h > 21))
            {
                okk = "ов";
                //Console.WriteLine(okk);
            }
            if ((h > 1) & (h < 5)||(h>21))
            {
                okk = "а";
                //Console.WriteLine(okk);
            }

            switch (min)
            {
                case 1 :
                    secc = "одна";
                    ok = "а";
                    break;
                case 2:
                    secc = "две";
                    ok = "ы";
                    break;
                case 3:
                    ok = "ы";
                    break;
                case 4:
                    ok = "ы";
                    break;
                case 21:
                    secc = "двадцать одна";
                    ok = "а";
                    break;
                case 22 :
                    secc = "двадцать две";
                    ok = "ы";
                        break;
                case 23:
                    ok = "ы";
                    break;
                case 24:
                    ok = "ы";
                    break;
                case 31:
                    secc = "тридцать одна";
                    ok = "а";
                    break;
                case 32:
                    secc = "тридцать две";
                    ok = "ы";
                    break;
                case 33:
                    secc = "тридцать две";
                    ok = "ы";
                    break;
                case 34:
                    secc = "тридцать две";
                    ok = "ы";
                    break;
                case 41:
                    secc = "сорок одна";
                    ok = "а";
                    break;
                case 42:
                    secc = "сорок две";
                    ok = "ы";
                    break;
                case 43:
                    ok = "ы";
                    break;
                case 44:
                    ok = "ы";
                    break;
                case 51:
                    secc = "пятьдесят одна";
                    ok = "а";
                    break;
                case 52:
                    secc = "пятьдесят две";
                    ok = "ы";
                    break;
                case 53:
                    ok = "ы";
                    break;
                case 54:
                    ok = "ы";
                    break;
            }
            //Console.WriteLine(ok + "   " + secc);
            synthesizer.Speak("Время " + first + " час"+ okk + " " + min + " минут" + ok);

            //вывод в консоль
            Console.WriteLine("Время: " + first + " час" + okk + " " + min + " минут" + ok);
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            if (lblTime.Content != "Остановлено")
            {
                timer.Stop();
                lblTime.Content = "Остановлено";
                payse.Content = "Возобновить";
                speak.IsEnabled = false;
            }
            else
            {
                timer.Start();
                payse.Content = "Остановить";
                speak.IsEnabled = true;
            }
        }
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
