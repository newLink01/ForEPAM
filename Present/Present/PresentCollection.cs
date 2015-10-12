using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Present
{
    class PresentCollection<material> : ICollection<material> where material: ISweet                           
    {
        
       // public Comparison<material> ComparisonDelegate;
        private ICollection<material> sweetColleсtion;
        private double maxPresentWeight;
        private double currentPresentWeight;
        public PresentCollection(){}
        public PresentCollection(ICollection<material> arr, int maxPresentWeight, int currentPresentWeight)
        { // объект передать как параметр , вынести проверки в статический класс
            this.sweetColleсtion = arr;// new List<material>();
            this.maxPresentWeight = maxPresentWeight;
            this.currentPresentWeight = currentPresentWeight;
            /*ComparisonDelegate = new Comparison<material>(this.ComparerbyCalories); *///по дефолту можно сравнивать по каллориям
          
        }
        #region
        public int Count {
            get{return this.sweetColleсtion.Count;}
        }
        public bool IsReadOnly {
            get{return false;}
        }
        public void Add(material obj) {

            if ((this.currentPresentWeight + obj.Weight) <= this.maxPresentWeight)
            {
                this.sweetColleсtion.Add(obj);
                this.currentPresentWeight += obj.Weight;
            }

            else { Console.WriteLine("You can't add more. Exceeding the maximum weight..."); return; }

        }
        public void Clear() {
            this.sweetColleсtion.Clear();
        }
        public bool Contains(material obj) {
            return this.sweetColleсtion.Contains(obj);
        }
        public void CopyTo(material [] arr, int arrayIndex) {
            this.sweetColleсtion.CopyTo(arr, arrayIndex);
        }
        public bool Remove(material obj) {
            return this.sweetColleсtion.Remove(obj);
        }

       


        /*public int ComparerbyCalories(material obj1, material obj2) {
            return obj1.Calories.CompareTo(obj2.Calories);
            }
        public int ComparerByWeight(material obj1, material obj2) {

            return obj1.Weight.CompareTo(obj2.Weight);

        }*/
       /* public void SortSweets() { //сделать копию
            if (this.ComparisonDelegate != null)
            {
                this.sweetColleсtion.Sort(this.ComparisonDelegate);
            }
            return;
       }*/

        public void FindSweetsBySugar(double left,double right) { 

            for(int i = 0;i<this.sweetColleсtion.Count;i++){
                if(this.sweetColleсtion.ElementAt<material>(i).Sugar>=left && this.sweetColleсtion.ElementAt<material>(i).Sugar<=right){
                    Console.WriteLine(this.sweetColleсtion.ElementAt<material>(i).Name + " Sugar : " + this.sweetColleсtion.ElementAt<material>(i).Sugar);
                    
                }
            }
            }

        public IEnumerator<material> GetEnumerator() {
            return this.sweetColleсtion.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return this.sweetColleсtion.GetEnumerator();
        }
       
#endregion
        }

    }

