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
            
           /*  present.Add(new Chocolate(20,30,100,"AlpenGold",ChocolateTypes.filled,ChocolateForms.StickOfChocolate,Tastes.nut));
             present.Add(new Caramel(30,10,20,"lak",CaramelTypes.lollipop,Tastes.mandarin));
             present.Add(new Chocolate(10, 5, 10, "milka", ChocolateTypes.withoutFilling, ChocolateForms.StickOfChocolate, Tastes.milk));
             present.Add(null);
             Console.WriteLine(present);
             Console.WriteLine("\n\nSorted by calories:\n\n");

             ComparatorsForISweet.CompDelegate += ComparatorsForISweet.WeightCompare;
             present.SortSweets(ComparatorsForISweet.CaloriesCompare);
            

             Console.WriteLine(present);*/


            List<int> a = new List<int>() { 5, 4, 3, 2, 1 };
            a.Sort();
            //foreach (var c in a) { Console.WriteLine(c); }

             /*Console.WriteLine("\n\n");

             List<string> obj = new List<string>();
             obj.Add(null);
             obj.Add(null);

             Console.WriteLine(obj.Count);*/

            /* present.FindSweetsBySugar(10, 20);

             */
             
            #endregion
            Console.ReadLine();
        }
    }
}
