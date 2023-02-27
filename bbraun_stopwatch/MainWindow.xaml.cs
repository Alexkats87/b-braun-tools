using System;
using System.Windows;
using System.Windows.Media;

namespace Stopwatch
{
    
    public partial class MainWindow : Window
    {
        // Create timer in separate thread
        System.Timers.Timer timer = new System.Timers.Timer(); 
      
        public MainWindow()
        {
            InitializeComponent();
            // Hook up the Elapsed event for the timer
            timer.Elapsed += Timer_Elapsed;
            timer.Interval = 500;
        }
        int s = 0;
        int m = 0;

        public static void UiInvoke(Action a)
        {
            Application.Current.Dispatcher.Invoke(a);
        }

        public void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            // Using UiInvoke: access from a separate thread (Timer)
            if (dots.IsVisible == true)
            {
                if (s < 59)
                {
                    s++;
                    if (s < 10)
                        UiInvoke(() => sek.Text = "0" + s.ToString());
                    else
                        UiInvoke(() => sek.Text = s.ToString());
                }
                else
                {
                    if (m < 59)
                    {
                        m++;
                        if (m < 10)
                            UiInvoke(() => min.Text = "0" + m.ToString());
                        else
                            UiInvoke(() => min.Text = m.ToString());
                        s = 0;
                        UiInvoke(() => sek.Text = "00");
                    }
                    else
                    {
                        m = 0;
                        UiInvoke(() => min.Text = "00");
                    }
                }
                UiInvoke(() => dots.Visibility = Visibility.Hidden);
            }
            else
                UiInvoke(() => dots.Visibility = Visibility.Visible);



            if ((m == 5) && ((s == 25) || (s == 45)))
            {               
                System.Media.SystemSounds.Beep.Play();
            }
            if ((m == 6) && (s == 0))
            {
                System.Media.SystemSounds.Hand.Play();
            }
            if ((m == 6) && (s == 35))
            {               
                System.Media.SystemSounds.Hand.Play();
                MessageBox.Show("Остановите насос!", "Внимание !");
            }
        }

        private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            if (timer.Enabled == true)
            {              
                timer.Enabled = false;
                Start_button.Content = "Start";
                Clear_button.IsEnabled = true;
                dots.Visibility = Visibility.Visible;
            }
            else
            {
                timer.Enabled = true;
                Start_button.Content = "Stop";
                Clear_button.IsEnabled = false;
                dots.Visibility = Visibility.Visible;
            }

        }

        private void Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            m = 0;
            s = 0;
            sek.Text = "00";
            min.Text = "00";
            dots.Visibility = Visibility.Visible;
        }

        private void Calculate_button_click(object sender, RoutedEventArgs e)
        {

            int s = Convert.ToInt32(sek.Text);
            int m = Convert.ToInt32(min.Text);
            int sf  = 0;
            int dev = 0;
            string _deviation_text = Deviation.Text;
            string _scale_factor_text = Scale_factor.Text;

            if (m != 5 && m != 6)
            {
                sf = 100;
            }

            else
            {
                if (m == 6)
                {
                    switch (s)
                    {
                        case 0: sf = 0; break;
                        case 1: sf = 0; break;
                        case 2: sf = -1; break;
                        case 3: sf = -2; break;
                        case 4: sf = -3; break;
                        case 5: sf = -3; break;
                        case 6: sf = -4; break;
                        case 7: sf = -5; break;
                        case 8: sf = -6; break;
                        case 9: sf = -6; break;
                        case 10: sf = -7; break;
                        case 11: sf = -8; break;
                        case 12: sf = -8; break;
                        case 13: sf = -9; break;
                        case 14: sf = -10; break;
                        case 15: sf = -11; break;
                        case 16: sf = -11; break;
                        case 17: sf = -12; break;
                        case 18: sf = -13; break;
                        case 19: sf = -13; break;
                        case 20: sf = -14; break;
                        case 21: sf = -14; break;
                        case 22: sf = -15; break;
                        case 23: sf = -16; break;
                        case 24: sf = -17; break;
                        case 25: sf = -18; break;
                        case 26: sf = -18; break;
                        case 27: sf = -19; break;
                        case 28: sf = -19; break;
                        case 29: sf = -20; break;
                        case 30: sf = -21; break;
                        case 31: sf = -22; break;
                        case 32: sf = -23; break;
                        case 33: sf = -23; break;
                        case 34: sf = -24; break;
                        case 35: sf = -25; break;
                        case 36: sf = -25; break;
                        default: sf = 100; break;
                    }
                }
                if (m == 5)
                {
                    switch (s)
                    {
                        case 0: sf = 0; break;
                        case 59: sf = 0; break;
                        case 58: sf = 1; break;
                        case 57: sf = 2; break;
                        case 56: sf = 3; break;
                        case 55: sf = 3; break;
                        case 54: sf = 4; break;
                        case 53: sf = 5; break;
                        case 52: sf = 6; break;
                        case 51: sf = 6; break;
                        case 50: sf = 7; break;
                        case 49: sf = 8; break;
                        case 48: sf = 8; break;
                        case 47: sf = 9; break;
                        case 46: sf = 10; break;
                        case 45: sf = 11; break;
                        case 44: sf = 11; break;
                        case 43: sf = 12; break;
                        case 42: sf = 13; break;
                        case 41: sf = 13; break;
                        case 40: sf = 14; break;
                        case 39: sf = 14; break;
                        case 38: sf = 15; break;
                        case 37: sf = 16; break;
                        case 36: sf = 17; break;
                        case 35: sf = 18; break;
                        case 34: sf = 18; break;
                        case 33: sf = 19; break;
                        case 32: sf = 19; break;
                        case 31: sf = 20; break;
                        case 30: sf = 21; break;
                        case 29: sf = 21; break;
                        case 28: sf = 22; break;
                        case 27: sf = 22; break;
                        case 26: sf = 23; break;
                        case 25: sf = 24; break;
                        case 24: sf = 25; break;
                        default: sf = 100; break;
                    }

                }
            } // test comment
			// test comment 2
            if (sf == 100)
            {
                Result_label.Background = Brushes.Red;
                MessageBox.Show("Отклонение слишком велико!", "Отклонение");               
            }
            else
            {
                dev = (int)(sf / 2.5);                
                Deviation.Text = "Deviation %   : " + dev.ToString();
                Scale_factor.Text = "Scale Factor   : " + sf.ToString();

                if (Math.Abs(dev) < 3) 
                    { Result_label.Background = Brushes.LightGreen; }          
                else 
                    if ((Math.Abs(dev) < 4) && (Math.Abs(dev) >= 3))
                        { Result_label.Background = Brushes.Yellow; }
                else { Result_label.Background = Brushes.Red; }             
            }           

        }
       
    }
}

// test comment


