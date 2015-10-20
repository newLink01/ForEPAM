using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Present
{
   public class PresentCollection<M> : ICollection<M> where M:SweetClass                                                                                       
    { 
        private ICollection<M> sweetColleсtion;

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

        public void CalculateCurrentPresentWeight() {
            foreach (var c in this.sweetColleсtion)
            {
                this.currentPresentWeight += c.Weight;
            }
        }
      
        public PresentCollection(int maxPresentWeight,ICollection<M> col=null)
        {
            if (col != null)
                this.sweetColleсtion = col;
            if (col == null) {
                this.sweetColleсtion = new List<M>();
            }
                this.maxPresentWeight = maxPresentWeight;
                CalculateCurrentPresentWeight();          
        }


        #region
        public int Count {
            get{return this.sweetColleсtion.Count;}
        }
        public bool IsReadOnly {
            get{return false;}
        }
        public void Add(M obj) {

          
            if (obj != null)
            {
                if ((this.currentPresentWeight + obj.Weight) <= this.maxPresentWeight)
                {
                    this.sweetColleсtion.Add(obj);
                    this.currentPresentWeight += obj.Weight;
                }

                else { Console.WriteLine("You can't add more. Exceeding the maximum weight..."); return; }
            }

            else this.sweetColleсtion.Add(obj);
        }




        public void Clear() {
            this.CurrentPresentWeight = 0;
            this.sweetColleсtion.Clear();
        }
        public bool Contains(M obj) {
            return this.sweetColleсtion.Contains(obj);
        }
        public void CopyTo(M [] arr, int arrayIndex) {
            this.sweetColleсtion.CopyTo(arr, arrayIndex);
        }
        public bool Remove(M obj) {

            if(this.sweetColleсtion.Contains(obj))
            this.CurrentPresentWeight -= obj.Weight;

            return this.sweetColleсtion.Remove(obj);
           
        }
#endregion
    
        public void SortSweets(Comparison<M> compDelegate)
        {

            if (compDelegate != null)
            {
              // this.sweetColleсtion.

               /* this.Clear();
                foreach (var c in)
                {
                    this.Add(c);
                }*/
            }
        }

        public void SortSweets(Func<M, double> keySelector) { 
            


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

            foreach (M m in this.sweetColleсtion) {
                if(m!=null)
                str += m.ToString() + "\n\n";
            }
            return str;
        }
        public IEnumerator<M> GetEnumerator() {
            return this.sweetColleсtion.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }
      
        }

    }

/*1)НАСЛЕДОВАНИЕ                                                                         +
  2)сортировка(не делать копию)
  3)карент презент в сделать отдельную функцию которая считает карент веит               +
  4)имплементо компараторов для null (исключение) выбросить исключение в компараторах    +
  5)области видимости в классах явно                                                     +
 *6)енамы вынести куданить (в каждой сущности свой файл) но тут для всех один файл       +
 *
 */