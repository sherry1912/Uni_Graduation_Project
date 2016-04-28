using System;
using System.Collections.Generic;

namespace BinaryTrees.BT
{
    public partial class BinaryTree
    {
        enum MinOrMax { NODE_MIN, NODE_MAX };

        bool Push(BinaryTreeNode node, string value, int currentDepth = 1)
        {
            // -1 if cData greater than value inside cNode
            bool pushSuccessful = false;
            if (node.Data.ToString().Equals("1") || node.Data.ToString().Equals("0"))
                return false;
            if (node.Left == null)
            {
                 node.Left = new BinaryTreeNode(value);
                 node.Left.Depth = currentDepth;
                 _mostRecentlyAddedNode = node.Left;
                 return true;
             }
            pushSuccessful = Push(node.Left, value, currentDepth + 1);
            if(pushSuccessful == true)
                return true;
            if (node.Right == null)
            {
                 node.Right = new BinaryTreeNode(value);
                 node.Right.Depth = currentDepth;
                 _mostRecentlyAddedNode = node.Right;
                 return true;
             }
            pushSuccessful = Push(node.Right, value, currentDepth + 1);
            return pushSuccessful;
        }
        BinaryTreeNode GetParent(string value, BinaryTreeNode rootOfSubtree, BinaryTreeNode returnNode = null)
        {
            if (rootOfSubtree == null)
                return returnNode;

            if (rootOfSubtree.Left != null)
            {
                int comparisonValue = rootOfSubtree.Left.Data.CompareTo(value);

                if (comparisonValue == 0)
                {
                    returnNode = rootOfSubtree;
                    return returnNode;
                }

                returnNode = GetParent(value, rootOfSubtree.Left, returnNode);
                returnNode = GetParent(value, rootOfSubtree.Right, returnNode);
            }

            if (rootOfSubtree.Right != null)
            {
                int comparisonValue = rootOfSubtree.Right.Data.CompareTo(value);

                if (comparisonValue == 0)
                {
                    returnNode = rootOfSubtree;
                    return returnNode;
                }
                returnNode = GetParent(value, rootOfSubtree.Left, returnNode);
                returnNode = GetParent(value, rootOfSubtree.Right, returnNode);
            }

            return returnNode;
        }

        BinaryTreeNode Search(string value, BinaryTreeNode rootOfSubtree, BinaryTreeNode returnNode = null)
        {
            if (rootOfSubtree == null)
                return returnNode;

            if (rootOfSubtree.Data.CompareTo(value) == 0)
                return rootOfSubtree;

            if (rootOfSubtree.Left != null)
            {
                int comparisonValue = rootOfSubtree.Left.Data.CompareTo(value);

                if (comparisonValue == 0)
                    return rootOfSubtree.Left;

                returnNode = Search(value, rootOfSubtree.Left, returnNode);
                returnNode = Search(value, rootOfSubtree.Right, returnNode);
            }

            if (rootOfSubtree.Right != null)
            {
                int comparisonValue = rootOfSubtree.Right.Data.CompareTo(value);

                if (comparisonValue == 0)
                    return rootOfSubtree.Right;

                returnNode = Search(value, rootOfSubtree.Left, returnNode);
                returnNode = Search(value, rootOfSubtree.Right, returnNode);
            }

            return returnNode;
        }

        void ResetDepths(BinaryTreeNode rootOfSubtree, int currentDepth = 1)
        {
            if (rootOfSubtree == null)
                return;

            if (rootOfSubtree.Left != null)
            {
                rootOfSubtree.Left.Depth = currentDepth;
                ResetDepths(rootOfSubtree.Left, currentDepth + 1);
                ResetDepths(rootOfSubtree.Right, currentDepth + 1);
            }
            if (rootOfSubtree.Right != null)
            {
                rootOfSubtree.Right.Depth = currentDepth;
                ResetDepths(rootOfSubtree.Left, currentDepth + 1);
                ResetDepths(rootOfSubtree.Right, currentDepth + 1);
            }
        }
    }
}
