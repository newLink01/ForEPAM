using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondTask_b_.Interfaces;

namespace SecondTask_b_.Classes
{
   public class Line : ILine,ICollection<IWord>
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
        public void Add(IWord item)
        {
            this.items.Add(item);
        }
        public void Clear()
        {
            this.items.Clear();
        }
        public bool Contains(IWord item)
        {
            return this.items.Contains(item);
        }
        public void CopyTo(IWord[] array, int arrayIndex)
        {
            this.items.CopyTo(array, arrayIndex);
        }
        public int Count
        {
            get { return this.items.Count; }
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public bool Remove(IWord item)
        {
            return this.items.Remove(item);
        }
    }
}
