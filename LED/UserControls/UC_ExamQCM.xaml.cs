using LED.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LED.UserControls
{
    /// <summary>
    /// Logique d'interaction pour UC_ExamQCM.xaml
    /// </summary>
    public partial class UC_ExamQCM : UserControl
    {
        private ViewExamQCM m_view = null;

        public UC_ExamQCM()
        {
            InitializeComponent();
        }

        public UC_ExamQCM(List<ItemQCM> question)
        {
            InitializeComponent();

            m_view = new ViewExamQCM(question);
            
            uc_dg_Questions.DataContext = m_view;
        }


        internal bool Validate()
        {
            return m_view.Validate();
        }

    }
}
