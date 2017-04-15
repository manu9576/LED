using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LED.Models
{
    public class ItemOrderBy
    {
        public string Contenaire { get; set; }
        public string Items { get; set; }


        public override string ToString()
        {
            return "Contenaire : " + Contenaire + " Items : "+ Items;
        }
    }
}
