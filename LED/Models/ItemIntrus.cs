using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LED.Models
{
    public class ItemIntrus
    {

        [DisplayName("Affirmation")]
        public string Phrase { get; set; }

        [DisplayName("Est l'intrus")]
        public bool IsIntrus { get; set; }

        public override string ToString()
        {
            return "Phrase : " + Phrase + " IsIntrus : " + IsIntrus;
        }
    }
}
