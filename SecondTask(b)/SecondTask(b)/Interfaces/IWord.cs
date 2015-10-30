using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondTask_b_.Interfaces
{
    public interface IWord
    {
        string WordValue { set; get; }
        int Count { set; get; }
        List<int> LineIndexes { set; get; }
        bool IsRepeats { set; get; }


    }
}
