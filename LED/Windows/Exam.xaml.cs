using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LED.Models;

namespace LED.Windows
{
    /// <summary>
    /// Logique d'interaction pour PassTest.xaml
    /// </summary>
    public partial class Exam : Window
    {
        Test m_test = null;
        ViewExam m_view = null;

        public Exam(Test test)
        {
            InitializeComponent();

            m_test = test;
            m_view = new ViewExam(test);

            DataContext = m_view;

        }

        private void Wf_bt_Next_Click(object sender, RoutedEventArgs e)
        {
            if(m_view.IsLastQuestion)
            {

            }
            else
            {
                m_view.NextQuestion();

            }
        }
    }
}
