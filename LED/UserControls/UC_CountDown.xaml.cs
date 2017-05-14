using LED.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LED.UserControls
{
    public delegate void TimeOut();

    /// <summary>
    /// Logique d'interaction pour Uc_CountDown.xaml
    /// </summary>
    public partial class Uc_CountDown : UserControl
    {
        private ViewCountDown m_view = null;

        private const int INTERVAL_MS = 10;

        public event TimeOut OnTimeOut;

        public Uc_CountDown()
        {

            InitializeComponent();
            m_view = new ViewCountDown(5);
            DataContext = m_view;
           

        }


        public void Start(double timeoutInSecond)
        {
            m_view = new ViewCountDown(timeoutInSecond);
            DataContext = m_view;
            m_view.Start();
            m_view.OnTimeOut += Finish;

        }

        private void Finish()
        {
            OnTimeOut?.Invoke();
        }

        internal void Release()
        {
            m_view.Release();
        }
    }
}
