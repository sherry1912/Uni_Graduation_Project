using FaultTrees.FT;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PrimeImplicant.PI;

namespace VisualBinaryTree
{
    class Build_Fault_Tree
    {
        private string filename;
        private StreamReader file;
    //    public LeafNode leaflists { set; get; }
        public FaultTreeNode Build_fault_tree(string filename)
        {
            this.filename = filename;
            file = File.OpenText(filename);
            FaultTreeNode root = Build_FAT();
            return root;
            file.Close();
        }
        private FaultTreeNode Build_FAT()
        {
            FaultTreeNode node, p, q=null;
            string endMark;
            node = new FaultTreeNode();
            node.Edge_Uncertainty =Int32.Parse( file.ReadLine());
            node.Node_Type = Int32.Parse(file.ReadLine());
            node.Node_Num = Int32.Parse(file.ReadLine());
            if (node.Node_Type == 1)
            {
                node.Gate_Type = Int32.Parse(file.ReadLine());
                node.Data = "G" + node.Node_Num.ToString();
                do
                {
                    p = Build_FAT();
                    if (node.Child == null)
                        node.Child = p;
                    else q.Sibling = p;
                    q = p;
                    endMark = file.ReadLine();
                } while (endMark.Equals("Y"));
            }
            else
            {
                node.Data = node.Node_Num.ToString();
          //      Add_Leaf_Node(node.Node_Num);
            }
            return node;
        }
        
    }
}
