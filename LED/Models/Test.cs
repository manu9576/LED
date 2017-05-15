using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LED.Models
{
    public class Test
    {

        [DisplayName("Nom du test")]
        public string Name { get; set; }

        [DisplayName("Commentaires")]
        public string Observations { get; set; }

        [DisplayName("Liste des questions du test")]
        public List<Question> Questions { get; set; }

        [DisplayName("Listes des catégories du test")]
        public List<Category> TestCategory
        {
            get
            {
                return m_testCategory;
            }
            set
            {  
                m_testCategory = value;
            }
        }


        private List<Category> m_testCategory;


        /// <summary>
        /// For each question, we need a list of the categorie of the question
        /// </summary>
        public void UpdateCategory()
        {
            foreach (Category c in m_testCategory)
            {
                foreach (Question q in Questions)
                {
                    IEnumerable<Category> questionCats = q.Notation.Select(n => n.Category);
                    // if list empty, or list without this cat, we add it
                    if (questionCats == null || (questionCats != null && !questionCats.Contains(c)))
                    {
                        q.Notation.Add(new Bareme { Category = c, Points = 0 });
                    }     
                }
            }

            foreach (Question q in Questions)
            {
                IEnumerable<Category> questionCats = q.Notation.Select(n => n.Category);
                // if list empty, or list without this cat, we add it
                List<Bareme> baremes = new List<Bareme>(q.Notation);

                foreach (Bareme bareme in baremes)
                {
                    if (!m_testCategory.Contains(bareme.Category))
                    {
                        q.Notation.Remove(bareme);
                    }
                }
            }

        }

        public Test()
        {
            Name = "Nouveau test";
            Observations = string.Empty;

            Questions = new List<Question>();

            m_testCategory = new List<Category>();

            UpdateCategory();
        }

        public Test(Test copie)
        {
            Name = copie.Name;
            Observations = copie.Name;

            Questions = new List<Question>(copie.Questions);

            m_testCategory = new List<Category>(copie.TestCategory);

            UpdateCategory();
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Test name : " + Name);
            sb.AppendLine("test observation : " + Observations);

            sb.AppendLine("Category : ");
            foreach (Category cat in TestCategory)
                sb.AppendLine("\t" + cat.Name);

            sb.AppendLine("Questions : ");
            foreach (Question quest in Questions)
                sb.AppendLine(quest.ToString());

            return sb.ToString();
        }
    }
}
