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
    /// Logique d'interaction pour UC_ExamTrueFalse.xaml
    /// </summary>
    public partial class UC_ExamTrueFalse : UserControl, IUC_Exam
    {
        private ViewExamTrueFalse m_view = null;

        public UC_ExamTrueFalse()
        {
            InitializeComponent();
        }

        public UC_ExamTrueFalse(List<ItemTrueFalse> question)
        {
            InitializeComponent();

            m_view = new ViewExamTrueFalse(question);

            uc_dg_Questions.DataContext = m_view;
        }

        public bool Validate()
        {
            return m_view.Validate();
        }
    }
}
