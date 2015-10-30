using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondTask_b_.Interfaces;

namespace SecondTask_b_.Classes
{
   public class Line : ILine
    {
        public List<IWord> items { set; get; }

        public Line() {
            items = new List<IWord>();
        }

    

       public IWord this[int index]{
           get { return items[index]; }

       }
      
        



        public IEnumerator<IWord> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
