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

    class first {
        public int per;
            public int asd;
    }
    class second :first{
        public string str;
    }


    class Program
    {
        
         static void Main(string[] args)
        {
            List<ISweet> arr = new List<ISweet>();
            PresentCollection<ISweet,List<ISweet>> present = new PresentCollection<ISweet,List<ISweet>>(arr, 300);
            present.Add(new Chocolate(50,20,100,"AlpenGold",ChocolateTypes.filled,ChocolateForms.StickOfChocolate,Tastes.mandarin));
            present.Add(new Chocolate(50, 20, 30, "Milka", ChocolateTypes.filled, ChocolateForms.StickOfChocolate, Tastes.mandarin));

            
            foreach (var c in present) { Console.WriteLine(c.Weight + " Name :" + c.Name); }

            present.SortSweets();
            foreach (var c in present) { Console.WriteLine(c.Weight + " Name :" + c.Name); }

            


            Console.ReadLine();
        }
    }
}
