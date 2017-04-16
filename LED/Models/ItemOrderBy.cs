using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LED.Models
{
    public class ItemOrderBy
    {
        [DisplayName("Catégorie")]
        public string Contenaires { get; set; }

        [DisplayName("Elements")]
        public string Items { get; set; }


        public override string ToString()
        {
            return "Contenaire : " + Contenaires + " Items : "+ Items;
        }
    }
}
