using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Present
{
    static class Comparators
    {
        static public Comparison<ISweet> compDelegate;
        static public int ComparerbyCalories(ISweet obj1, ISweet obj2)
        {
            return obj1.Calories.CompareTo(obj2.Calories);
        }
        static public int ComparerByWeight(ISweet obj1, ISweet obj2)
        {

            return obj1.Weight.CompareTo(obj2.Weight);

        }


       // public ISweet SetMethodsInCompDelegate { set { compDelegate = value; } }
        static void AddMethod(int ComparerBy) { 
          
        }
    }
}
