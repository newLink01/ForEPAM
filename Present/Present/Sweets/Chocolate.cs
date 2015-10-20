using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Present
{
    class Chocolate :SweetClass,IChocolate
    {
        public ChocolateTypes ChocolateType { set; get; }
        public ChocolateForms ChocolateForm { set; get; }


        public Chocolate(int calories, double sugar, double weight, string name, ChocolateTypes chocolateType, ChocolateForms chocolateForm, Tastes taste)
                         :base(calories,sugar,weight,name,taste)
        { 
            this.ChocolateType = chocolateType;
            this.ChocolateForm = chocolateForm;
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
