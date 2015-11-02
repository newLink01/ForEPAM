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
    }
}
