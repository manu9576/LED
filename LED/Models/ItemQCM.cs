using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LED.Models
{
    public class ItemQCM
    {
        [DisplayName("Affirmation")]
        public string Phrase { get; set; }

        [DisplayName("Est vrai")]
        public bool IsTrue { get; set; }

        public override string ToString()
        {
            return "Phrase : " + Phrase + " IsTrue : " + IsTrue;
        }
    }
}
