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
        
        public Comparison<material> ComparisonDelegate;
        private List<material> sweetColleсtion;
        private double maxPresentWeight;
        private double currentPresentWeight;
        public PresentCollection(int maxPresentWeight) {
            this.sweetColleсtion = new List<material>();
            this.maxPresentWeight = maxPresentWeight;
            this.currentPresentWeight = 0;
            ComparisonDelegate = new Comparison<material>(this.ComparerbyCalories); //по дефолту можно сравнивать по каллориям
          
        }
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

       


        public int ComparerbyCalories(material obj1, material obj2) {
            return obj1.Calories.CompareTo(obj2.Calories);
            }
        public int ComparerByWeight(material obj1, material obj2) {

            return obj1.Weight.CompareTo(obj2.Weight);

        }
        public void SortSweets() {
            if (this.ComparisonDelegate != null)
            {
                this.sweetColleсtion.Sort(this.ComparisonDelegate);
            }
            return;
       }

        public void FindSweetsBySugar(double left,double right) { //возвращает индекс конфеты

            for(int i = 0;i<this.sweetColleсtion.Count;i++){
                if(this.sweetColleсtion[i].Sugar>=left && this.sweetColleсtion[i].Sugar<=right){
                    Console.WriteLine(this.sweetColleсtion[i].Name + " Sugar : " + this.sweetColleсtion[i].Sugar);
                }
            }
            }

        public IEnumerator<material> GetEnumerator() {
            return this.sweetColleсtion.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return this.sweetColleсtion.GetEnumerator();
        }
       
        }

    }

