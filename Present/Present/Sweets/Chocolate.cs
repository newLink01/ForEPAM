using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Present
{
    class Chocolate : IChocolate
    {
        public int Calories { set; get; }
        public double Sugar { set; get; }
        public double Weight { set; get; }
        public string Name { set; get; }
        public ChocolateTypes ChocolateType { set; get; }
        public ChocolateForms ChocolateForm { set; get; }
        public Tastes Taste { set; get; }


        public Chocolate() { }
        public Chocolate(int calories, double sugar, double weight, string name, ChocolateTypes chocolateType, ChocolateForms chocolateForm, Tastes taste) {
            this.Calories = calories;
            this.Sugar = sugar;
            this.Weight = weight;
            this.Name = name;
            this.ChocolateType = chocolateType;
            this.ChocolateForm = chocolateForm;
            this.Taste = taste;
        }

        public override string ToString()
        {
            if (Name != null)
                return  "Name : " + Name + "\nCalories : " + Calories + "\nSugar : " + Sugar + "\nWeight : " + Weight  + "\nType : " + ChocolateType +
                        "\nForm : " + ChocolateForm + "\nTaste : " + Taste;
            else return "Elements are not initialized";
        }
    }
}
