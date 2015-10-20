using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Present
{
    class Caramel :SweetClass,ICaramel
    {
       
       public CaramelTypes CaramelType { set; get; }
       public Tastes Taste { set; get; }

       public Caramel(int calories, double sugar, double weight, string name, CaramelTypes caramelType, Tastes caramelTaste)
                        :base(calories,sugar,weight,name,caramelTaste)
       {
           this.CaramelType = caramelType;
           this.Taste = caramelTaste;
       }

       public override string ToString()
       {
            if (Name != null)
                return "Name : " + Name + "\nCalories : " + Calories + "\nSugar : " + Sugar + "\nWeight : " + Weight + "\nType : " + CaramelType +
                         "\nTaste : " + Taste;
            else return "Elements are not initialized";
       }
    }
}
