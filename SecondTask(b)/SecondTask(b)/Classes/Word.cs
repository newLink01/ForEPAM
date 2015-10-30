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

       public Word() { }

       public Word(string word) {
           this.WordValue = word;
        }

       public Word(string word, int stringIndex) {
           LineIndexes = new List<int>();

           this.WordValue = word;
        }


       public string ToLower() {
           return this.WordValue.ToLower();
       }



    }
}
