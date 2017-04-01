using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LED.models
{
    class Test
    {
        string Name { get; set; }
        string Observations { get; set; }

        QCM[] Questions { get; set; }

        List<Category> TestCategory { get; set; }
    }
}
