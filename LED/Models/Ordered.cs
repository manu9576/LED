using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LED.models
{
    public class Ordered : QuestionGlobalsParameters
    {
        List<Tuple<string,int>> Questions { get; set; }
    }
}
