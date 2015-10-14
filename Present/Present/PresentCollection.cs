using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Present
{
    class PresentCollection<material, Collection> where material:ISweet
                                                  where Collection : ICommon<material>
                                                                      
           //Collection<material> where material: ISweet where Collection : ICollection<material>, ICloneable                           
    { //сделать наследование от icollection  и Iclonable в 1 интерфейс и записать вместо Collection
        
//        public IComparer<material> ComparisonDelegate{get;set;}
        private readonly ICollection<material> sweetColleсtion;
        private double maxPresentWeight;

        public double MaxPresentWeight
        {
            get { return maxPresentWeight; }
            set { maxPresentWeight = value; }
        }
        private double currentPresentWeight;
        public double CurrentPresentWeight
        {
            get { return currentPresentWeight; }
            set { currentPresentWeight = value; }
        }
        
        public PresentCollection(){}
        public PresentCollection(ICollection<material> arr, int maxPresentWeight, IComparer<material> comparer = null)
        {
            this.sweetColleсtion = arr;// new List<material>();
            this.maxPresentWeight = maxPresentWeight;
            //this.currentPresentWeight = 

            foreach (var c in this.sweetColleсtion) {
                this.currentPresentWeight += c.Weight;
            }
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

        private object Clone() {
            ICollection<material> cloneCollection = this.sweetColleсtion;
            return cloneCollection;
        }


     
        public void SortSweets<T>(Func<material,T> keySelector, IComparer<T> comparer) { //сделать копию

            ICollection<material> copy = this.Clone() as ICollection<material>;

                 this.sweetColleсtion = this.sweetColleсtion.OrderBy(x=>keySelector(x), comparer).ToList();
             
             return;
        }
        







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
            return this.GetEnumerator();
        }
       
#endregion
        }

    }

