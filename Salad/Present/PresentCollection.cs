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
        private double presentWeight;

        public PresentCollection(int presentWeight) {
            this.sweetColleсtion = new List<material>();
            this.presentWeight = presentWeight;
            ComparisonDelegate = new Comparison<material>(this.ComparerbyCalories); //по дефолту можно сравнивать по каллориям
        }
        public int Count {
            get{return this.sweetColleсtion.Count;}
        }
        public bool IsReadOnly {
            get{return false;}
        }
        public void Add(material obj) {

            if ((this.presentWeight += obj.Weight) <= this.presentWeight)
            {
                this.sweetColleсtion.Add(obj);
            }

            else { Console.WriteLine("Excess weight"); return; }

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

        public material this[int index] {
            set { this.sweetColleсtion[index] = value; }
            get { return this.sweetColleсtion[index]; }
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

        public int FindSweetBySugar(double left,double right) { //возвращает индекс конфеты

            for(int i = 0;i<this.sweetColleсtion.Count;i++){
                if(this.sweetColleсtion[i].Sugar>=left && this.sweetColleсtion[i].Sugar<=right){
                    return i;
                }
            }
            return -1;
            }

        public IEnumerator<material> GetEnumerator() {
            return this.sweetColleсtion.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return this.sweetColleсtion.GetEnumerator();
        }
       
        }

    }

