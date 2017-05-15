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
using LED.UserControls;

namespace LED.Windows
{
    /// <summary>
    /// Logique d'interaction pour PassTest.xaml
    /// </summary>
    public partial class Exam : Window
    {
        Test m_test = null;
        ViewExam m_view = null;
        UC_ExamWaiting m_waiting = null;
        UC_ExamGoodAnswer m_good = null;
        UC_ExamWrongAnswer m_wrong = null;
        IUC_Exam m_exam = null;

        public Exam(Test test)
        {
            InitializeComponent();

            m_test = test;
            m_view = new ViewExam(test);

            DataContext = m_view;

            m_waiting = new UC_ExamWaiting()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,

            };
            m_good = new UC_ExamGoodAnswer()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,

            };
            m_wrong = new UC_ExamWrongAnswer()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,

            };

            WF_cc_questions.Content = m_waiting;
            Wf_bt_Next.IsEnabled = false;
            Wf_cd_CountDown.OnTimeOut += Wf_cd_CountDown_OnTimeOut;

        }

        private void Wf_bt_Next_Click(object sender, RoutedEventArgs e)
        {

            if (m_view.Phase == State.Answering)
            {
                m_view.Phase = State.QuestionResult;
                Wf_cd_CountDown.Release();

                if (m_exam != null)
                {

                    if (m_exam.Validate())
                    {
                        m_view.CurrentQuestion.State = QuestionStat.GOOD;
                        WF_cc_questions.Content = m_good;
                    }
                    else
                    {
                        m_view.CurrentQuestion.State = QuestionStat.FALSE;
                        WF_cc_questions.Content = m_wrong;
                    }
                }
            }

            else if (m_view.Phase == State.QuestionResult)
            {
                if (m_view.IsLastQuestion)
                {
                    m_view.Phase = State.TestResult;
                    MessageBox.Show("Affichage des résultats !!");


                }
                else
                {
                    m_view.Phase = State.Waiting;
                    WF_cc_questions.Content = m_waiting;
                    m_view.NextQuestion();

                    Wf_bt_Next.IsEnabled = false;
                    Wf_bt_start.IsEnabled = true;
                }
            }
        }

        private void Wf_bt_start_Click(object sender, RoutedEventArgs e)
        {
            m_exam = null;
            m_view.Phase = State.Answering;


            switch (m_view.CurrentQuestion.TestType)
            {
                case TypeTest.INTRUS:
                    m_exam = new UC_ExamIntrus(m_view.CurrentQuestion.QuestionsIntrus);
                    break;

                case TypeTest.ORDERBY:
                    m_exam = new UC_ExamOrderBy(m_view.CurrentQuestion.QuestionsOrderedBy);
                    break;

                case TypeTest.ORDERED:
                    m_exam = new UC_ExamOrdered(m_view.CurrentQuestion.QuestionsOrdered);
                    break;

                case TypeTest.QCM:
                    m_exam = new UC_ExamQCM(m_view.CurrentQuestion.QuestionsQCM);
                    break;

                case TypeTest.TRUE_FALSE:
                    m_exam = new UC_ExamTrueFalse(m_view.CurrentQuestion.QuestionsTrueFalse);
                    break;

            }

            if (m_exam != null)
            {
                WF_cc_questions.Content = m_exam;

                m_exam.Enabled(true);

                Wf_cd_CountDown.Start(m_view.CurrentQuestion.TimeLimite);
                    
                Wf_bt_Next.IsEnabled = true;
                Wf_bt_start.IsEnabled = false;
            }
            else
                WF_cc_questions.Content = m_waiting;
        }

        private void Wf_cd_CountDown_OnTimeOut()
        {
            m_exam.Enabled(false);
           
            m_view.TimeOut();
        }
    }
}
