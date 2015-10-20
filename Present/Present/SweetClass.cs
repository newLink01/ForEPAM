using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Present
{
   public abstract class SweetClass
    {
       public int Calories { set; get; }
       public double Sugar { set; get; }
       public double Weight { set; get; }
       public string Name { set; get; }
       public Tastes Taste { set; get; }

        public SweetClass(int calories,double sugar,double weight,string name,Tastes taste) {
            Calories = calories;
            Sugar = sugar;
            Weight = weight;
            Name = name;
            Taste = taste;
        }



    }
}
