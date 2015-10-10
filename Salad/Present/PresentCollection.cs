using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Present
{
    class PresentCollection<material> : ICollection<material>  where material: ISweet                           
    {
        
        public Comparison<material> ComparisonDelegate;
        private List<material> sweetColletion;
        private double presentWeight;
        public PresentCollection(int presentWeight) {
            this.sweetColletion = new List<material>();
            this.presentWeight = presentWeight;
            ComparisonDelegate = new Comparison<material>(this.ComparerbyCalories);
        }
        public int Count {
            get{return this.sweetColletion.Count;}
        }
        public bool IsReadOnly {
            get{return false;}
        }
        public void Add(material obj) {

            if ((this.presentWeight += obj.Weight) <= this.presentWeight)
            {
                this.sweetColletion.Add(obj);
            }

            else { Console.WriteLine("Excess weight"); return; }

        }
        public void Clear() {
            this.sweetColletion.Clear();
        }
        public bool Contains(material obj) {
            return this.sweetColletion.Contains(obj);
        }
        public void CopyTo(material [] arr, int arrayIndex) {
            this.sweetColletion.CopyTo(arr, arrayIndex);
        }
        public bool Remove(material obj) {
            return this.sweetColletion.Remove(obj);
        }




        public int ComparerbyCalories(material obj1, material obj2) {
            if (obj1.Calories > obj2.Calories)  return 1; 
            if(obj1.Calories == obj2.Calories) return 0;
            return -1;
            }
        public void CompareSweets(Comparison<material> CompDelegate) {
            this.sweetColletion.Sort(CompDelegate);
       }
        public int FindSweetBySugar(double left,double right) { //возвращает индекс конфеты

            for(int i = 0;i<this.sweetColletion.Count;i++){
                if(this.sweetColletion[i].Sugar>=left && this.sweetColletion[i].Sugar<=right){
                    return i;
                }
            }
            return -1;
            }

        public IEnumerator GetEnumerator() {
            return this.sweetColletion.GetEnumerator();
        }
     
       
        }

    }

