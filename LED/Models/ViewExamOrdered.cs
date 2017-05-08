using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LED.Models
{
    public class ViewExamOrdered
    {
        public List<string> Items { get; set; }
        public List<ItemOrdered> Answers { get; set; }
        public List<ItemOrdered> Question { get; set; }

        public ViewExamOrdered()
        {
            Items = new List<string>() { "item 1", "item2 " };
            Answers = new List<ItemOrdered>()
            {
                new ItemOrdered { Name = "item 1",  Place = 1 },
                new ItemOrdered { Name = "item 2",  Place = 2}
            };
        }

        public ViewExamOrdered(List<ItemOrdered> question)
        {
            Question = question;


            Items = new List<string>();

            foreach (ItemOrdered item in Question)
            {
                Items.Add(item.Name);
            }
        }

        public bool Validate()
        {
            // we check that the order of each eleement is identical
            Answers = Answers.OrderBy(o => o.Place).ToList();
            Question = Question.OrderBy(o => o.Place).ToList();

            if (Answers.Count == Question.Count)
            {
                for (int i = 0; i < Answers.Count; i++)
                {
                    if (Answers[i].Name != Question[i].Name)
                        return false;
                }
            }
            else
                return false;

            return true;
        }

    }
}
