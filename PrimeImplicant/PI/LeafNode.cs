using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrimeImplicant.PI
{
    public class LeafNode
    {
        public LeafNode() { }
        public LeafNode Next { get; set; }
        public int flag { get; set; }
        public int Node_Num { get; set; }
  //      static int node_number = 0;
    }
}
