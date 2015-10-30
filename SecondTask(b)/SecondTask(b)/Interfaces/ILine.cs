using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondTask_b_.Classes;
namespace SecondTask_b_.Interfaces
{
  public interface ILine:IEnumerable<IWord>
    {
      List<IWord> items { set; get; }
    }
}
