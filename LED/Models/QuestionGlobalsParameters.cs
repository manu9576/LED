using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LED.models
{
    public enum TypeTest {QCM,ORDERED,BY_TYPE,INTRUS,TRUE_FALSE } 
    public enum QuestionStat { UNDONE, GOOD, FALSE}


    public class QuestionGlobalsParameters
    {
        public string Name { get; set; }
        public string ContextPhrase { get; set; }
        public int TimeLimite { get; set; }
        public TypeTest TestType { get; set; }
        public Dictionary<Category,int> Notation { get; set; }
        public QuestionStat State { get; set; }
    }
}
