using LED.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace LED.UserControls
{
   
    /// <summary>
    /// Logique d'interaction pour UC_ExamIntrus.xaml
    /// </summary>
    public partial class UC_ExamIntrus : UserControl, IUC_Exam
    {
        ViewExamIntrus m_view = null;

        public UC_ExamIntrus()
        {
            InitializeComponent();
        }


        public UC_ExamIntrus(List<ItemIntrus> question)
        {
            InitializeComponent();

            m_view = new ViewExamIntrus(question);

            uc_dg_Questions.DataContext = m_view;
        }


        public bool Validate()
        {
            return m_view.Validate();
        }

        public void Enabled(bool etat)
        {
            if (this.Dispatcher.Thread != Thread.CurrentThread)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() => Enabled(etat)));
            else
                IsEnabled = etat;
        }
    }
}
