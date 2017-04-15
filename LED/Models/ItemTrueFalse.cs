using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LED.Models
{
    public class ItemTrueFalse
    {
        public string Phrase { get; set; }
        public bool IsTrue { get; set; }

        public ItemTrueFalse()
        {
            Phrase = "Exemple";
            IsTrue = false;
        }

        public override string ToString()
        {
            return "Phrase : " + Phrase + " IsTrue : " + IsTrue;
        }
    }
}
