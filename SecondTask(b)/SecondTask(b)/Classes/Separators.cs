using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondTask_b_.Classes
{
   public class Separators
    {
      private string[] sentenceSeparators = new string[] { "?", "!", ".", "...", "?!", ";", ":",",","(",")" };
      private  string[] wordSeparators = new string[] { " ", " - " };
      public IEnumerable<string> GetAllSeparators() {
          return this.sentenceSeparators.AsEnumerable().Concat(this.wordSeparators.AsEnumerable());
      }
    }
}
