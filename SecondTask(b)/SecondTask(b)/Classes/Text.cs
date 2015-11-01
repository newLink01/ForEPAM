using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondTask_b_.Interfaces;

namespace SecondTask_b_.Classes
{
   public class Text : ICollection<ILine>
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
       public void Add(ILine item)
       {
           this.text.Add(item);
       }
       public void Clear()
       {
           this.text.Clear();
       }
       public bool Contains(ILine item)
       {
           return this.text.Contains(item);
       }
       public void CopyTo(ILine[] array, int arrayIndex)
       {
           this.text.CopyTo(array, arrayIndex);
       }
       public int Count
       {
           get {return this.text.Count; }
       }
       public bool IsReadOnly
       {
           get { return false; }
       }
       public bool Remove(ILine item)
       {
           return this.text.Remove(item);
       }

     
    }
}
