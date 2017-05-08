using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LED.Models
{
    public class ViewExamOrderBy
    {
        public List<ItemOrderBy> Answers { get; set; }
        public List<ItemOrderBy> Questions { get; set; }
        public List<string> Contenaires { get; set; }
        public string Items { get; set; }

        public ViewExamOrderBy()
        {
            Answers = new List<ItemOrderBy>() { new ItemOrderBy { Contenaire = "Contaires" , Items ="item1; item2"} };
            Contenaires = new List<string>() { "Contenaire1","Contenaire2"};
            Items =  "item1;item2" ;
        }

        public ViewExamOrderBy(List<ItemOrderBy> questions)
        {
            Questions = questions;
            Answers = questions;


            Contenaires = new List<string>();
            Items = string.Empty;

            foreach (ItemOrderBy item in Answers)
            {
                Contenaires.Add(item.Items);
                Items += ";" + item.Items;
            }
        }

        public bool Validate()
        {
            foreach(ItemOrderBy answer in Answers)
            {
                ItemOrderBy reponse = Questions.Find(q => q.Contenaire == answer.Contenaire);

                if (reponse == null || reponse.Items != answer.Items)
                    return false;
            }

            return true;
        }
    }
}
