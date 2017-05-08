using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LED.Models
{
    public class ViewExamTrueFalse
    {
        public List<ItemTrueFalse> Questions { get; set; }
        public List<ItemTrueFalse> Answers { get; set; }


        public ViewExamTrueFalse()
        {
            Questions = new List<ItemTrueFalse>() { new ItemTrueFalse { Phrase = "exemple question" } };
            Answers = new List<ItemTrueFalse>() { new ItemTrueFalse { Phrase = "exemple repnose", IsTrue = false } };
        }

        public ViewExamTrueFalse(List<ItemTrueFalse> question)
        {
            Answers = question;


            Questions = new List<ItemTrueFalse>();

            foreach (ItemTrueFalse item in Answers)
            {
                Questions.Add(new ItemTrueFalse { Phrase = item.Phrase, IsTrue = false });
            }
        }

        internal bool Validate()
        {
            foreach(ItemTrueFalse answer in Answers)
            {
                ItemTrueFalse question = Questions.Find(q => q.Phrase == answer.Phrase);

                if (question == null || question.IsTrue != answer.IsTrue)
                    return false;
            }

            return true;
        }
    }
}
