using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Present
{
    class PresentCollection<material> : ICollection<material> where material: ISweet                           
    {
        private List<material> sweetColletion;

        public PresentCollection() {
            this.sweetColletion = new List<material>();
        }

        public int Count() {
            return this.sweetColletion.Count;
        }


    }
}
