using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows;

namespace LED.Models
{
    public delegate void TimeOut();

    public class ViewCountDown : INotifyPropertyChanged
    {
        public event TimeOut OnTimeOut;

        private System.Timers.Timer m_timer = null;
        
        public double Time { get; set; }

        private Visibility m_visible;
        public Visibility Visible
        {
            get
            {
                return m_visible;
            }
            set
            {
                SetField(ref m_visible, value);
            }
        }

        private int m_percentage;
        public int Percentage
        {
            get
            {
                return m_percentage;
            }
            set
            {
                SetField(ref m_percentage, value);

                double timeLeft =(100- m_percentage) *Time /100;
                TextTime = timeLeft.ToString("0.0") + " s.";

                if (m_percentage < 70)
                {
                    BarColor = System.Windows.Media.Brushes.Green;
                }
                else if (m_percentage < 90)
                {
                    BarColor = System.Windows.Media.Brushes.Orange;  
                }
                else
                {
                    BarColor = System.Windows.Media.Brushes.Red;
                }

            }
        }

        private System.Windows.Media.Brush m_barColor;
        public System.Windows.Media.Brush BarColor
        {
            get
            {
                return m_barColor;
            }

            private set
            {
                SetField(ref m_barColor, value);
            }
        }

        private string m_TextTime;
        public string TextTime
        {
            get
            {
                return m_TextTime;
            }

            private set
            {
                SetField(ref m_TextTime, value);
            }
        }

        public ViewCountDown()
        {
            Time = 5.0;
            Percentage = 20;
            BarColor = System.Windows.Media.Brushes.Green;
            Visible = Visibility.Hidden;
        }
        public ViewCountDown(double time)
        {
            Time = time;
            BarColor = System.Windows.Media.Brushes.Green;
            Percentage = 0;
            Visible = Visibility.Hidden;
        }

        public void Start()
        {
            if (Time > 0.0)
            {
                m_timer = new System.Timers.Timer()
                {
                    Interval = Time * 10
                };

                m_timer.Elapsed += Tick;
                m_timer.Start();

                Visible = Visibility.Visible;
            }
            else
            {
                OnTimeOut?.Invoke();
            }
        }


        public void Release()
        {
            if (m_timer != null)
                m_timer.Stop();

            Visible = Visibility.Hidden;

            Percentage = 100;
        }

        private void Tick(object sender, ElapsedEventArgs e)
        {
            Percentage++;


            if (Percentage == 100)
            {
                m_timer.Stop();
                TextTime = "Temps écoulé";
                OnTimeOut?.Invoke();
                Visible = Visibility.Hidden;
            }
        }




        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string porpName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(porpName));
        }
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion
    }
}
