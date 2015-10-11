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
            PresentCollection<ISweet> present = new PresentCollection<ISweet>(200);

            present.Add(new Chocolate(200, 20, 100, "AlpenGold", ChocolateTypes.filled, ChocolateForms.StickOfChocolate, Tastes.nut));
            present.Add(new Caramel(100, 15, 10, "caramelka", CaramelTypes.lollipop, Tastes.grape));
            present.Add(new Chocolate(50, 10, 300, "Milka", ChocolateTypes.withoutFilling, ChocolateForms.StickOfChocolate, Tastes.milk));

            foreach (var c in present) {
                Console.WriteLine(c.Weight + " Name : " + c.Name);
            }
            Console.WriteLine();


            present.ComparisonDelegate -= present.ComparerbyCalories;
            present.ComparisonDelegate += present.ComparerByWeight;
            present.SortSweets();

            foreach (var c in present)
            {
                Console.WriteLine(c.Weight + " Name : " + c.Name);
            }



            Console.WriteLine();
            Console.WriteLine(present[present.FindSweetBySugar(5,11)].Name);

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
