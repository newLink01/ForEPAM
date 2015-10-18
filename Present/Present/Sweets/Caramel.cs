using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Present
{
    class Caramel : ICaramel
    {
       public int Calories { set; get; }
       public double Sugar { set; get; }
       public double Weight { set; get; }
       public string Name { set; get; }
       public CaramelTypes CaramelType { set; get; }
       public Tastes Taste { set; get; }

       public Caramel(int calories, double sugar, double weight, string name, CaramelTypes caramelType, Tastes caramelTaste) {
           this.Calories = calories;
           this.Sugar = sugar;
           this.Weight = weight;
           this.Name = name;
           this.CaramelType = caramelType;
           this.Taste = caramelTaste;
       }
       public Caramel() { }

       public override string ToString()
       {
            if (Name != null)
                return "Name : " + Name + "\nCalories : " + Calories + "\nSugar : " + Sugar + "\nWeight : " + Weight + "\nType : " + CaramelType +
                         "\nTaste : " + Taste;
            else return "Elements are not initialized";
       }
    }
}
