using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Present
{
    class PresentCollection<material> : ICollection<material> where material:ISweet                                                                                        
    { 
        private ICollection<material> sweetColleсtion;

        private readonly double maxPresentWeight;
        public double MaxPresentWeight
        {
            get { return maxPresentWeight; }
        }
        private double currentPresentWeight;
        public double CurrentPresentWeight
        {
            get { return currentPresentWeight; }
            set { currentPresentWeight = value; }
        }
 
      
        public PresentCollection(int maxPresentWeight,ICollection<material> col=null)
        {
            if (col != null)
                this.sweetColleсtion = col;
            if (col == null) {
                this.sweetColleсtion = new List<material>();
            }
                this.maxPresentWeight = maxPresentWeight;

                foreach (var c in this.sweetColleсtion)
                {
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
            this.CurrentPresentWeight = 0;
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
#endregion
        public void SortSweets(Comparison<material> compDelegate) {

            lock (this.sweetColleсtion)
            {
              List<material> copy = this.sweetColleсtion.ToList();
              if (compDelegate != null)
              {
                  copy.Sort(compDelegate);
                  this.Clear();
                  foreach (var c in copy)
                  {
                      this.Add(c);
                  }
              }
            }
        }
        public void FindSweetsBySugar(double left,double right) {

            foreach (var c in this.sweetColleсtion) {
                if (c.Sugar >= left && c.Sugar <= right) {
                    Console.WriteLine("Sweet name : " + c.Name + "\nSugar : " + c.Sugar);
                }
            }
            }

        public override string ToString()
        {
            string str = null;

            foreach (material m in this.sweetColleсtion) {
                str += m.ToString() + "\n\n";
            }
            return str;
        }



        public IEnumerator<material> GetEnumerator() {
            return this.sweetColleсtion.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }
      
        }

    }

