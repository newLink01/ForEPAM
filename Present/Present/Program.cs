using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Present
{
   
  public class Program
    {
         static void Main(string[] args)
        {
           


            #region
            PresentCollection<SweetClass> present = new PresentCollection<SweetClass>(300);
            
             present.Add(new Chocolate(20,30,100,"AlpenGold",ChocolateTypes.filled,ChocolateForms.StickOfChocolate,Tastes.nut));
             present.Add(new Caramel(30,10,20,"lak",CaramelTypes.lollipop,Tastes.mandarin));
             present.Add(new Chocolate(10, 5, 10, "milka", ChocolateTypes.withoutFilling, ChocolateForms.StickOfChocolate, Tastes.milk));
             present.Add(null);
             Console.WriteLine(present);
             Console.WriteLine("\n\nSorted by calories:\n\n");

             foreach (var c in present.GetSortedSweets(x => x.Calories)) {
                 Console.WriteLine(c + "\n");
             }

             Console.WriteLine();
             Console.WriteLine();

             present.FindSweetsBySugar(1, 10);

            #endregion
            Console.ReadLine();
        }
    }
}
