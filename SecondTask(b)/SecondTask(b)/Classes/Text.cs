using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondTask_b_.Interfaces;

namespace SecondTask_b_.Classes
{
   public class Text : IEnumerable<ILine>
    {
       public List<ILine> text{set;get;}

       public Text() {
           text = new List<ILine>();

       }

       public ILine this[int index]{
           get { return text[index]; }
           set { text[index] = value; }
       }



       public IEnumerator<ILine> GetEnumerator()
       {
           return text.GetEnumerator();
       }

       System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
       {
           return this.GetEnumerator();
       }
    }
}
