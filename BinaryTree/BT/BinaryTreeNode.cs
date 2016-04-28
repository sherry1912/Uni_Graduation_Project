namespace BinaryTrees.BT
{
    /// <summary>
    /// A node for the binary tree providing read-only get methods
    /// </summary>
    /// <typeparam name="T">A class or ValueType, T must match the type T for BinaryTree&lt;T&gt;</typeparam>
    public class BinaryTreeNode
    {
       
        public BinaryTreeNode() { }
        public BinaryTreeNode(string cData)
        {
            Data = cData;
        }
        public BinaryTreeNode Left { get; set; }
        public BinaryTreeNode Right { get; set; }
        public string Data { get; set; }
        public int Depth { get; set; }
        public int flag { get; set; }
        public int Node_Num { get; set; }
    }
}
