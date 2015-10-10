using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Present
{
    class Caramel : ICaramel
    {
       public int Calories { set; get; }
       public double Sugar { set; get; }
       public double Weight { set; get; }
       public string Name { set; get; }
       public CaramelTypes CaramelType { set; get; }
       public Tastes CaramelTaste { set; get; }

       

    }
}
