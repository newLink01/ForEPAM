using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondTask_b_.Interfaces;

namespace SecondTask_b_.Classes
{
   public class Word : IWord
    {

       public string WordValue
       {
           set;
           get;
       }
       public int Count { set; get; }
       public List<int> LineIndexes { set; get; }
       
      // public bool IsRepeats { set; get; }

       public Word() {
           Count = 0;
           LineIndexes = new List<int>();
       }

       public Word(string word) {
           Count = 0;
           this.WordValue = word;
           LineIndexes = new List<int>();
        }

       public Word(string word, int stringIndex) {
           LineIndexes = new List<int>();
           Count = 0;
           this.WordValue = word;
        }


       public string ToLower() {
           return this.WordValue.ToLower();
       }



    }
}
