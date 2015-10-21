using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Present
{
  public static class ComparatorsForISweet
    {
        private static Comparison<SweetClass> compDelegate;
        internal static Comparison<SweetClass> CompDelegate
        {
            get { return ComparatorsForISweet.compDelegate; }
            set { ComparatorsForISweet.compDelegate = value; }
        }
        public static int WeightCompare(SweetClass obj1,SweetClass obj2){

            try
            {
                if (obj1.Weight > obj2.Weight) { return 1; }
                if (obj1.Weight < obj2.Weight) { return -1; }
                else return 0;
            }
            catch (NullReferenceException) {
                return 0;
            }
            
        }
        public static int CaloriesCompare(SweetClass obj1, SweetClass obj2) {

            try
            {
                if (obj1.Calories > obj2.Calories) { return 1; }
                if (obj1.Calories < obj2.Calories) { return -1; }
                else return 0;
            }
            catch (NullReferenceException) {
                return 0;
            }
        }  
    }



 
}
