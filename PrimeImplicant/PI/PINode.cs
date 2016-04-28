using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrimeImplicant.PI
{
    public class PINode
    {
        public LeafNode Implicant{set;get;}
        public PINode Next { set; get; }
    }
}
