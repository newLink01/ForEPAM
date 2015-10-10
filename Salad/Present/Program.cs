using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Present
{
    enum CaramelTypes { lollipop, filled };
    enum Tastes { apple, grape, mandarin, milk, nut};
    enum ChocolateTypes { withoutFilling,filled };
    enum ChocolateForms { StickOfChocolate,sweet};


    class Program
    {
        static void Main(string[] args)
        {
            PresentCollection<ISweet> col = new PresentCollection<ISweet>(50);
            
            


        }
    }
}
