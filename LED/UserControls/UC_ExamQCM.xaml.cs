using LED.Models;
using System.Collections.Generic;
using System.Windows.Controls;

namespace LED.UserControls
{
    /// <summary>
    /// Logique d'interaction pour UC_ExamQCM.xaml
    /// </summary>
    public partial class UC_ExamQCM : UserControl, IUC_Exam
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

        public bool Validate()
        {
            return m_view.Validate();
        }

    }
}
