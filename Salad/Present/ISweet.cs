using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Present
{
    interface ISweet
    {
        int Calories { set; get; }
        double Sugar { set; get; }
        double Weight { set; get; }
        string Name { set; get; }

    }
    
}
