using BinaryTrees.BT;
using FaultTrees.FT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisualBinaryTree
{
    class Build_BDD_Tree
    {
       public  BinaryTreeNode FAT_BDD(FaultTreeNode FAT)
       {
        	if(FAT.Node_Type==0)
          	{
	          	BinaryTreeNode BDD,left,right;
         	    BDD=new BinaryTreeNode();
         		left=new BinaryTreeNode();
        		right=new BinaryTreeNode();
        		BDD.Node_Num=FAT.Node_Num;
                BDD.Data = FAT.Node_Num.ToString();
        		left.Node_Num=1;
                left.Data = "1";
        		right.Node_Num=0;
                right.Data = "0";
        	    BDD.Left=left;
	            BDD.Right=right;
	        	return BDD;
         	}
         	FaultTreeNode p,q;
        	q=FAT.Child;
        	p=q.Sibling;
        	BinaryTreeNode itep,iteq;
        	iteq=FAT_BDD(q);
        	while(p!=null)
        	{
	         	itep=FAT_BDD(p);
        		iteq=ToolFunction.APPLY(FAT.Gate_Type,iteq,itep);
        		p=p.Sibling;
        	}
         	if(FAT.Gate_Type==3)
      	     	iteq=ToolFunction.OPPOSE(iteq);
         	return iteq;
        }
    }
}
