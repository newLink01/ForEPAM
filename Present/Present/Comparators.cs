using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Present
{
   static class Comparators
    {
        private static Comparison<ISweet> compDelegate;
        internal static Comparison<ISweet> CompDelegate
        {
            get { return Comparators.compDelegate; }
            set { Comparators.compDelegate = value; }
        }

        public static int WeightCompare(ISweet obj1,ISweet obj2){
            if(obj1.Weight>obj2.Weight){return 1;}
            if(obj1.Weight<obj2.Weight){return -1;}
            else return 0;
        }
        public static int CaloriesCompare(ISweet obj1, ISweet obj2) {
            if (obj1.Calories > obj2.Calories) { return 1; }
            if (obj1.Calories < obj2.Calories) { return -1; }
            else return 0;
        }

       
    }
}
