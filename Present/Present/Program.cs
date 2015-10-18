using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

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

            #region
            PresentCollection<ISweet> present = new PresentCollection<ISweet>(200);
            
             present.Add(new Chocolate(20,30,100,"AlpenGold",ChocolateTypes.filled,ChocolateForms.StickOfChocolate,Tastes.nut));
             present.Add(new Caramel(30,10,20,"lak",CaramelTypes.lollipop,Tastes.mandarin));
             present.Add(new Chocolate(10, 5, 10, "milka", ChocolateTypes.withoutFilling, ChocolateForms.StickOfChocolate, Tastes.milk));
             present.ShowAllSweets();

             Console.WriteLine("\n\n");
             

             ComparatorsForISweet.CompDelegate += ComparatorsForISweet.CaloriesCompare;
             present.SortSweets(ComparatorsForISweet.CompDelegate);

            // present.FindSweetsBySugar(10,200);
             present.ShowAllSweets();
             

            //PresentCollection<ISweet> present = new PresentCollection<ISweet>(null, 100);
             
            #endregion
            Console.ReadLine();
        }
    }
}
