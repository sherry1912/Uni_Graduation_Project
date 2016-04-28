using FaultTrees.FT;
using PrimeImplicant.PI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisualBinaryTree
{
    class Build_Leaf_lists
    {
        private LeafNode leaflists;
        public LeafNode Get_leaflists()
        {
            return leaflists;
        }
        public Build_Leaf_lists(FaultTreeNode rootNode)
        {
            Build_lists(rootNode);
        }
        private void Build_lists(FaultTreeNode node)
        {
            if (node.Node_Type == 0)
                Add_Leaf_Node(node.Node_Num);
            else
            {
                FaultTreeNode temp = node.Child;
                while (temp != null)
                {
                    Build_lists(temp);
                    temp = temp.Sibling;
                }
            }
        }
        private void Add_Leaf_Node(int num)
        {
            LeafNode p, q, temp;
            p = q = leaflists;
            while (p != null && p.Node_Num < num)
            {
                q = p;
                p = p.Next;
            }
            if (p == null)
            {
                p = new LeafNode();
                p.Node_Num = num;
                if (q == null) leaflists = p;
                else q.Next = p;
            }
            else
            {
                if (q.Node_Num == num) return;
                temp = new LeafNode();
                temp.Node_Num = num;
                temp.Next = p;
                q.Next = temp;
            }
            //     leaflists.Node_Num++;
        }
    }
}
