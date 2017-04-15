using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LED.Models
{
    public class ItemIntrus
    {
        public string Phrase { get; set; }
        public bool IsIntrus { get; set; }

        public override string ToString()
        {
            return "Phrase : " + Phrase + " IsIntrus : " + IsIntrus;
        }
    }
}
