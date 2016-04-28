
using FaultTrees.FT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisualBinaryTree
{
    class Build_Uncertainty_Tree
    {
        private FaultTreeNode root;
        private FaultTreeNode root_uncertainty;
        public Build_Uncertainty_Tree(FaultTreeNode root)
        {
            this.root = root;
        }
        public FaultTreeNode Get_uncertainty_Tree()
        {
            Build_UFT(root, ref root_uncertainty);
            return root_uncertainty;
        }
        private bool Build_UFT(FaultTreeNode FAT, ref FaultTreeNode FAT_UNCERTAINTY)
        {
            bool flag = false;
        	if(FAT.Node_Type==0)
	        {
         		if(FAT.Edge_Uncertainty==1)
	        	{
	         		FAT_UNCERTAINTY=COPY(FAT);
	        		flag=true;
        		}
        		return flag;
         	}
         	FaultTreeNode p_FAT,p_UNCERTAINTY=null,q_UNCERTAINTY=null;
        	p_FAT=FAT.Child;
        	if(FAT.Gate_Type==3)
         	{
	        	if(Build_UFT(p_FAT,ref p_UNCERTAINTY)==true)
	        	{
	        		FAT_UNCERTAINTY=new FaultTreeNode();
	        		FAT_UNCERTAINTY.Edge_Uncertainty=FAT.Edge_Uncertainty;
		        	FAT_UNCERTAINTY.Node_Type=FAT.Node_Type;
                	FAT_UNCERTAINTY.Node_Num=FAT.Node_Num;
              		FAT_UNCERTAINTY.Gate_Type=FAT.Gate_Type;
                    FAT_UNCERTAINTY.Data = FAT.Data;
        			FAT_UNCERTAINTY.Child=p_UNCERTAINTY;
	        		flag=true;
		         }
	        	else if(FAT.Edge_Uncertainty==1)
	        	{
        			flag=true;
	        		FAT_UNCERTAINTY=COPY(FAT);
	        	}
	        	return flag;	
            }
	        if(FAT.Gate_Type==2)    
            {
	        	while(p_FAT!=null)
		        {
		        	if(Build_UFT(p_FAT,ref p_UNCERTAINTY)==true)
		        	{
		         		if(flag==false)
		         		{
			        		FAT_UNCERTAINTY=new FaultTreeNode();
	 	                	FAT_UNCERTAINTY.Edge_Uncertainty=FAT.Edge_Uncertainty;
	             	    	FAT_UNCERTAINTY.Node_Type=FAT.Node_Type;
                         	FAT_UNCERTAINTY.Node_Num=FAT.Node_Num;
                 		    FAT_UNCERTAINTY.Gate_Type=FAT.Gate_Type;
                            FAT_UNCERTAINTY.Data = FAT.Data;
	        			}
	        			flag=true;
		        		if(FAT_UNCERTAINTY.Child==null)
			        		FAT_UNCERTAINTY.Child=q_UNCERTAINTY=p_UNCERTAINTY;
	                 	else 
	                 	{
				        	q_UNCERTAINTY.Sibling=p_UNCERTAINTY;
		        	        q_UNCERTAINTY=p_UNCERTAINTY;
	                	}
		    	     }
		          	p_FAT=p_FAT.Sibling;
    		    }
        		if(FAT.Edge_Uncertainty==1)
	        	{
	        		flag=true;
	        		FAT_UNCERTAINTY = COPY(FAT);
	        	}
	        	return flag;
	         }
        	if(FAT.Gate_Type==1)
        	{
        		FAT_UNCERTAINTY=new FaultTreeNode();
        	 	FAT_UNCERTAINTY.Edge_Uncertainty=FAT.Edge_Uncertainty;
        		FAT_UNCERTAINTY.Node_Type=FAT.Node_Type;
        		FAT_UNCERTAINTY.Node_Num=FAT.Node_Num;
        		FAT_UNCERTAINTY.Gate_Type=FAT.Gate_Type;
                FAT_UNCERTAINTY.Data = FAT.Data;
        		while(p_FAT!=null)
        		{
        			if(Build_UFT(p_FAT,ref p_UNCERTAINTY)==true)
        				flag=true;
        			else p_UNCERTAINTY=COPY(p_FAT);
        			if(FAT_UNCERTAINTY.Child==null)
        				FAT_UNCERTAINTY.Child=q_UNCERTAINTY=p_UNCERTAINTY;
        	       	else 
	             	{
		            	q_UNCERTAINTY.Sibling=p_UNCERTAINTY;
		              	q_UNCERTAINTY=p_UNCERTAINTY;
	           	    }
	        		p_FAT=p_FAT.Sibling;
	         	}
    		    if(FAT.Edge_Uncertainty==1)
	        		flag=true;
	        	if(flag==false)
	        	{
	        	//	FREE_FAT_NODE(FAT_UNCERTAINTY);
	        		FAT_UNCERTAINTY=null;
	        	}
	        	return flag;
            }
            return flag;
        }
        
        private FaultTreeNode COPY(FaultTreeNode node)
        {
            FaultTreeNode node_copy, node_child, node_copy_p, node_copy_q=null;
            node_copy = new FaultTreeNode();
            node_copy.Gate_Type = node.Gate_Type;
            node_copy.Node_Num = node.Node_Num;
            node_copy.Node_Type = node.Node_Type;
            node_copy.Edge_Uncertainty = node.Edge_Uncertainty;
            node_copy.Data = node.Data;
            node_child = node.Child;
            while (node_child != null)
            {
                node_copy_p = COPY(node_child);
                if (node_copy.Child == null)
                    node_copy.Child = node_copy_q = node_copy_p;
                else
                {
                    node_copy_q.Sibling = node_copy_p;
                    node_copy_q = node_copy_p;
                }
                node_child = node_child.Sibling;
            }
            return node_copy;
        }
    }
}
