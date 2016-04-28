using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BinaryTrees.BT;
using PrimeImplicant.PI;

namespace VisualBinaryTree
{
    class Build_Meta_Tree
    {
       

        private int compare(BinaryTreeNode left, BinaryTreeNode right)
        {
            if (left.Node_Num == right.Node_Num)
            {
                if (left.Left == null && right.Left == null && left.Right == null && right.Right == null)
                    return 1;
                if (compare(left.Left, right.Left) == 1)
                    if (compare(left.Right, right.Right) == 1)
                        return 1;
                return 0;
            }
            return 0;
        }

        private BinaryTreeNode SIMPLIFY(BinaryTreeNode node)
        {
            if (node == null) return null;
            node.Left = SIMPLIFY(node.Left);
            node.Right = SIMPLIFY(node.Right);
            if (node.Left!=null && node.Right!=null && compare(node.Left, node.Right) == 1)
                node = node.Left;
            return node;
        }

        public BinaryTreeNode BUILD_META_TREE(BinaryTreeNode bdd, LeafNode leaf)
        {
            BinaryTreeNode P,P10,P1,P0,_P10, P_left;
            P=new BinaryTreeNode();
        	if(leaf!=null)
        	{
        		if(bdd.Node_Num==leaf.Node_Num)
        		{
          			P.flag=1;
	        		P.Node_Num=bdd.Node_Num;
                    P.Data = "p" + P.Node_Num.ToString();
         			P10=ToolFunction.APPLY(1,bdd.Left,bdd.Right);
        			P10=SIMPLIFY(P10);
        			P.Right=BUILD_META_TREE(P10,leaf.Next); 
          		//	_P10=BUILD_META_TREE(P10,NULL);
        			_P10=ToolFunction.OPPOSE(P.Right);
        			P_left=new BinaryTreeNode();
	        		P_left.flag=2;
         			P_left.Node_Num=bdd.Node_Num;
                    P_left.Data = "q" + P_left.Node_Num.ToString();
        			P1=BUILD_META_TREE(bdd.Left,leaf.Next);
          		//	P_left->LEFT_CHILD=APPLY(1,P1,_P10);
	        		P_left.Left=SIMPLIFY(ToolFunction.APPLY(1,P1,_P10));
        			P0=BUILD_META_TREE(bdd.Right,leaf.Next);
	        	//	P_left->RIGHT_CHILD=APPLY(1,P0,_P10);
        			P_left.Right=SIMPLIFY(ToolFunction.APPLY(1,P0,_P10));
	        		P.Left=P_left;
        		}
        		else 
        		{
	         		P.flag=1;
	        		P.Node_Num=leaf.Node_Num;
                    P.Data = "p" + P.Node_Num.ToString();
	        		P_left=new BinaryTreeNode();
	         		P_left.flag=0;
        			P_left.Node_Num=0;
                    P_left.Data = P_left.Node_Num.ToString();
        			P_left.Left=P_left.Right=null;
        			P.Left=P_left;
	        		P.Right=BUILD_META_TREE(bdd,leaf.Next);
          		}
        	}
        	else 
        	{
        		if(bdd.Node_Num==0||bdd.Node_Num==1)
	        	{
	        		P.flag=0;
         			P.Node_Num=bdd.Node_Num;
                    P.Data = P.Node_Num.ToString();
        			P.Left=P.Right=null;
         		}
        	}
        	SIMPLIFY(P);
        	return P;
        }
    }
}
