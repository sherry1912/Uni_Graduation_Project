using BinaryTrees.BT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisualBinaryTree
{
    class ToolFunction
    {
        public static BinaryTreeNode APPLY(int type, BinaryTreeNode lnode, BinaryTreeNode rnode)
        {
        	BinaryTreeNode ite;
        	ite=new BinaryTreeNode();
        	if(lnode.Node_Num>1000&&rnode.Node_Num>1000)
        	{
        		if(lnode.Node_Num==rnode.Node_Num&&lnode.flag==rnode.flag)
	        	{
    	        	ite.Node_Num=lnode.Node_Num;
	        		ite.flag=lnode.flag;
    	        	ite.Left=APPLY(type,lnode.Left,rnode.Left);
            		ite.Right=APPLY(type,lnode.Right,rnode.Right);
         		}
        		else
	        	{
	          		if((lnode.Node_Num>rnode.Node_Num)||(lnode.Node_Num==rnode.Node_Num&&lnode.flag>rnode.flag))
     	    		{
	         			BinaryTreeNode temp;
		         		temp=lnode;
     		    		lnode=rnode;
     		    		rnode=temp;
     		    	}
    	    		ite.Node_Num=lnode.Node_Num;
     	    		ite.flag=lnode.flag;
     	    		ite.Left=APPLY(type,lnode.Left,rnode);
    	    		ite.Right=APPLY(type,lnode.Right,rnode);
     	    	}
	         }
        	else  
        	{
	        	if(type==1)
        		{
	        		if(lnode.Node_Num==0||rnode.Node_Num==0)
		          	{
		         		ite.flag=0;
		        		ite.Node_Num=0;
		         	}
		        	else if(lnode.Node_Num==1||rnode.Node_Num==1)
		        	{
		        		if(lnode.Node_Num==1&&rnode.Node_Num==1)
		        		{
		        			ite.flag=0;
		        			ite.Node_Num=1;
		        		}
		        		else if(lnode.Node_Num==1)
		        		{
		        			ite.flag=rnode.flag;
		        			ite.Left=rnode.Left;
		        			ite.Right=rnode.Right;
		         			ite.Node_Num=rnode.Node_Num;
		         		}
		        		else
		        		{
		        			ite.flag=lnode.flag;
		        			ite.Left=lnode.Left;
		        			ite.Right=lnode.Right;
		        			ite.Node_Num=lnode.Node_Num;
		        		}
		        	}
		        }
        		else if(type==2)
        		{
        			if(lnode.Node_Num==1||rnode.Node_Num==1)
	        		{
        				ite.flag=0;
	         			ite.Node_Num=1;
	        		}
        			else if(lnode.Node_Num==0||rnode.Node_Num==0)
        			{
	         			if(lnode.Node_Num==0&&rnode.Node_Num==0)
		        		{
	        				ite.flag=0;
		        			ite.Node_Num=0;
			        	}
	        			else if(lnode.Node_Num==0)
		        		{
	        				ite.flag=rnode.flag;
	        				ite.Left=rnode.Left;
	        				ite.Right=rnode.Right;
	        				ite.Node_Num=rnode.Node_Num;
        				}
	        			else
	        			{
	        				ite.flag=lnode.flag;
		        			ite.Left=lnode.Left;
			        		ite.Right=lnode.Right;
				        	ite.Node_Num=lnode.Node_Num;
	         			}
	        		}
	        	}
        	}
            if (ite.flag == 1)
                ite.Data = "p" + ite.Node_Num.ToString();
            else if (ite.flag == 2)
                ite.Data = "q" + ite.Node_Num.ToString();
            else ite.Data = ite.Node_Num.ToString();
        	return ite;
        }
        public static BinaryTreeNode  OPPOSE(BinaryTreeNode ite)
        {
        	if(ite==null) return null;
        	BinaryTreeNode _ite;
        	_ite=new BinaryTreeNode();
        	_ite.flag=ite.flag;
        	if(ite.Node_Num==1)
     	    	_ite.Node_Num=0;
        	else if(ite.Node_Num==0)
	          	_ite.Node_Num=1;
        	else 
        	{
        		_ite.Node_Num=ite.Node_Num;
	        	_ite.Left=OPPOSE(ite.Left);
        		_ite.Right=OPPOSE(ite.Right);
        	}
            _ite.Data = _ite.Node_Num.ToString();
        	return _ite;
        }
    }
}
