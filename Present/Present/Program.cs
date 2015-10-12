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
           // PresentCollection<ISweet> present = new PresentCollection<ISweet>(200);

           /* present.Add(new Chocolate(200, 20, 100, "AlpenGold", ChocolateTypes.filled, ChocolateForms.StickOfChocolate, Tastes.nut));
            present.Add(new Caramel(100, 15, 10, "caramelka", CaramelTypes.lollipop, Tastes.grape));*/
           // present.Add(new Chocolate(50, 10, 300, "Milka", ChocolateTypes.withoutFilling, ChocolateForms.StickOfChocolate, Tastes.milk));
            //present.Add(new Chocolate(50, 10, 300, "Milka", ChocolateTypes.withoutFilling, ChocolateForms.StickOfChocolate, Tastes.milk));


           // Console.WriteLine(present.currentPresentWeight);


            #region
            


          /*  present.ComparisonDelegate -= present.ComparerbyCalories; //по дефолтку стоят каллории
            present.ComparisonDelegate += present.ComparerByWeight;
            present.SortSweets();

            foreach (var c in present)
            {
                Console.WriteLine(c.Weight + " Name : " + c.Name);
            }


            //доделать с нахождением конфеты по сахару
            Console.WriteLine();
            present.FindSweetsBySugar(10,15);
            //Console.WriteLine(present[present.FindSweetBySugar(5,11)].Name); // конфету находим по содержанию сахара
            Console.WriteLine();*/


            #endregion
            Console.ReadLine();
        }
    }
}
