using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Present
{
    interface IChocolate : ISweet
    {
        Tastes ChocolateTaste { set; get; }
        ChocolateTypes ChocolateType { set; get; }
        ChocolateForms ChocolateForm { set; get; } 
    }
}
