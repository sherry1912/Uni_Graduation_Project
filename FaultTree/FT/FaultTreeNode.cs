namespace FaultTrees.FT
{
    
    public class FaultTreeNode
    {
        public FaultTreeNode() { }
        public FaultTreeNode(string cData)
        {
            Data = cData;
        }
           
        public string Data { get; set; }
        public int Depth { get;  set; }

        public int Edge_Uncertainty {get;  set;}
        public int Node_Type { get;  set; }
        public int Gate_Type { get;  set; }
        public int Node_Num { get;  set; }

        public FaultTreeNode Child { get;  set; }
        public FaultTreeNode Sibling { get;  set; }
    }
}
