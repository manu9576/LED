using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LED.Models
{
    public class ViewExam : INotifyPropertyChanged
    {

        public string TestName { get; private set; }
        public string TestObservations { get; private set; }

        private string questionName;
        public string QuestionName
        {
            get
            {
                return questionName;
            }
            private set
            {
                SetField(ref questionName, value);
            }
        }

        private string questionContextPhrase;
        public string QuestionContextPhrase
        {
            get
            {
                return questionContextPhrase;
            }
            private set
            {
                SetField(ref questionContextPhrase, value);
            }
        }

        private int questionTimeLimite;
        public int QuestionTimeLimite
        {
            get
            {
                return questionTimeLimite;
            }
            private set
            {
                SetField(ref questionTimeLimite, value);
            }
        }

        private TypeTest questionTestType;
        public TypeTest QuestionTestType
        {
            get
            {
                return questionTestType;
            }
            private set
            {
                SetField(ref questionTestType, value);
            }
        }

        private List<ItemIntrus> questionsIntrus;
        public List<ItemIntrus> QuestionsIntrus
        {
            get
            {
                return questionsIntrus;
            }
            private set
            {
                SetField(ref questionsIntrus, value);
            }
        }

        private List<ItemOrderBy> questionsOrderedBy;
        public List<ItemOrderBy> QuestionsOrderedBy
        {
            get
            {
                return questionsOrderedBy;
            }
            private set
            {
                SetField(ref questionsOrderedBy, value);
            }
        }

        private List<ItemOrdered> questionsOrdered;
        public List<ItemOrdered> QuestionsOrdered
        {
            get
            {
                return questionsOrdered;
            }
            private set
            {
                SetField(ref questionsOrdered, value);
            }
        }

        private List<ItemQCM> questionQCM;
        public List<ItemQCM> QuestionsQCM
        {
            get
            {
                return questionQCM;
            }
            private set
            {
                SetField(ref questionQCM, value);
            }
        }

        private List<ItemTrueFalse> questionTrueFalse;
        public List<ItemTrueFalse> QuestionsTrueFalse
        {
            get
            {
                return questionTrueFalse;
            }
            private set
            {
                SetField(ref questionTrueFalse, value);
            }
        }

        public Question CurrentQuestion
        {
            get
            {
                return m_test.Questions[m_indiceQuestion];
            }
        }

        private Test m_test = null;
        private int m_indiceQuestion = 0;

        // boiler-plate
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetField<T>(ref T field, T value,[CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public ViewExam()
        {
            m_test = null;
            m_indiceQuestion = 0;

            TestName = "Nom par défaut";
            TestObservations = "Obsevations";

            QuestionName = "Nom de la question";
            QuestionContextPhrase = "Phrase de contexte";
            QuestionTimeLimite = -1;
            QuestionTestType = TypeTest.INTRUS;


            QuestionsIntrus = new List<ItemIntrus>();
            QuestionsOrderedBy = new List<ItemOrderBy>();
            QuestionsOrdered = new List<ItemOrdered>();
            QuestionsQCM = new List<ItemQCM>();
            QuestionsTrueFalse = new List<ItemTrueFalse>();

            
        }

        public ViewExam(Test test)
        {
            m_test = test;
            m_indiceQuestion = 0;

            TestName = m_test.Name;
            TestObservations = m_test.Observations;

            if (m_test.Questions.Count > 0)
            {
                ReadCurrentQuestion();
            }
        }

        public bool IsLastQuestion
        {
            get
            {
                return m_indiceQuestion+1 >= m_test.Questions.Count;
            }
        }

        public void NextQuestion()
        {
            if(!IsLastQuestion)
            {
                m_indiceQuestion++;
                ReadCurrentQuestion();
            }
        }

        private void ReadCurrentQuestion()
        {

            QuestionName = m_test.Questions[m_indiceQuestion].Name;
            QuestionContextPhrase = m_test.Questions[m_indiceQuestion].ContextPhrase;
            QuestionTimeLimite = m_test.Questions[m_indiceQuestion].TimeLimite;
            QuestionTestType = m_test.Questions[m_indiceQuestion].TestType;

            QuestionsIntrus = m_test.Questions[m_indiceQuestion].QuestionsIntrus;
            QuestionsOrderedBy = m_test.Questions[m_indiceQuestion].QuestionsOrderedBy;
            QuestionsOrdered = m_test.Questions[m_indiceQuestion].QuestionsOrdered;
            QuestionsQCM = m_test.Questions[m_indiceQuestion].QuestionsQCM;
            QuestionsTrueFalse = m_test.Questions[m_indiceQuestion].QuestionsTrueFalse;
        }
    }
}
