using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Present
{
    
    interface ICaramel : ISweet
    {
        CaramelTypes CaramelType { set; get; }
    }
}
