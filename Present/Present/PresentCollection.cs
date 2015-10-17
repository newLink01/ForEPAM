﻿using System;
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
        public PresentCollection(ICollection<material> col,int maxPresentWeight)
        {
            this.sweetColleсtion = col;
            this.maxPresentWeight = maxPresentWeight;
          
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
#endregion
        

        public void SortSweets(Comparison<material> compDelegate) {

            lock (this.sweetColleсtion)
            {
              List<material> copy = this.sweetColleсtion.ToList();
               copy.Sort(compDelegate);


               this.sweetColleсtion.Clear();
               this.CurrentPresentWeight = 0;
               foreach (var c in copy) {
                   this.Add(c);
               }
            }
        }
        public void FindSweetsBySugar(double left,double right) { 

            for(int i = 0;i<this.sweetColleсtion.Count;i++){
                if(this.sweetColleсtion.ElementAt<material>(i).Sugar>=left && this.sweetColleсtion.ElementAt<material>(i).Sugar<=right){
                    Console.WriteLine(this.sweetColleсtion.ElementAt<material>(i).Name + " Sugar : " + this.sweetColleсtion.ElementAt<material>(i).Sugar);
                }
            }
            }

        public void ShowAllSweets() {
 
            foreach(material m in this.sweetColleсtion){
                Console.WriteLine(m.ToString() + "\n");
                
            }
        }

        public IEnumerator<material> GetEnumerator() {
            return this.sweetColleсtion.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }
       

        }

    }

