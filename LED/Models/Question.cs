using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LED.Models
{
    public enum TypeTest { QCM, ORDERED, BY_TYPE, INTRUS, TRUE_FALSE }
    public enum QuestionStat { UNDONE, GOOD, FALSE }

    public class Question
    {
        public string Name { get; set; }
        public string ContextPhrase { get; set; }
        public int TimeLimite { get; set; }
        public TypeTest TestType { get; set; }
        public List<Bareme> Notation { get; set; }
        public QuestionStat State { get; set; }

        public List<ItemIntrus> QuestionsIntrus { get; set; }
        public List<ItemOrderBy> QuestionsOrderedBy { get; set; }
        public List<ItemOrdered> QuestionsOrdered { get; set; }
        public List<ItemQCM> QuestionsQCM { get; set; }
        public List<ItemTrueFalse> QuestionsTrueFalse { get; set; }

        public Question()
        {
            Name = "test1";
            TestType = TypeTest.INTRUS;

            Notation = new List<Bareme>();

            QuestionsIntrus = new List<ItemIntrus>();
            QuestionsOrderedBy = new List<ItemOrderBy>();
            QuestionsOrdered = new List<ItemOrdered>();
            QuestionsQCM = new List<ItemQCM>();
            QuestionsTrueFalse = new List<ItemTrueFalse>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("******* Question name : " + Name + "******");
            sb.AppendLine("** Phrase : " + ContextPhrase);
            sb.AppendLine("** Time limite  = " + TimeLimite);
            sb.AppendLine("** Test type : " + TestType);
            sb.AppendLine("** Notation : ");

            foreach (Bareme bar in Notation)
                sb.AppendLine("****** " + bar);
            sb.AppendLine("** State : " + State);

            sb.AppendLine("** Question : ");

            switch (TestType)
            {
                case TypeTest.BY_TYPE:

                    foreach (ItemOrderBy item in QuestionsOrderedBy)
                        sb.AppendLine("**\t" + item);
                    break;

                case TypeTest.INTRUS:

                    foreach (ItemIntrus item in QuestionsIntrus)
                        sb.AppendLine("**\t" + item);
                    break;

                case TypeTest.ORDERED:

                    foreach (ItemOrdered item in QuestionsOrdered)
                        sb.AppendLine("**\t" + item);
                    break;

                case TypeTest.QCM:

                    foreach (ItemQCM item in QuestionsQCM)
                        sb.AppendLine("**\t" + item);
                    break;

                case TypeTest.TRUE_FALSE:

                    foreach (ItemTrueFalse item in QuestionsTrueFalse)
                        sb.AppendLine("**\t" + item);
                    break;

            }

            return sb.ToString();
        }
    }
}
