using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrimeImplicant.PI;
using BinaryTrees.BT;

namespace VisualBinaryTree
{
    class Prime_Implicants
    {
        private PINode first_prime;
        public PINode get_First_Prime()
        {
            return first_prime;
        }
        public Prime_Implicants(BinaryTreeNode tree)
        {
            GET_PRIME_IMPLICANT(tree, null);
        }

        PINode GET_PRIME_IMPLICANT(BinaryTreeNode tree, PINode prime)
        {
        	if(tree.Node_Num==0) return null;
            if(tree.Node_Num==1)
        	{
	        	if(first_prime==null)
	        	{
	        		first_prime=new PINode();
	        		return first_prime;
        		}
        		else
	        	{
	        		PINode p,q;
		        	p=new PINode();
	        		q=first_prime;
	        		while(q.Next!=null)
		        		q=q.Next;
		        	q.Next=p;
	         		return p;
	        	}
        	}
        	if(tree.flag==1)
        	{
	        	PINode temp_left;
        		PINode temp_right;
	        	temp_left=GET_PRIME_IMPLICANT(tree.Left,prime);
	        	temp_right=GET_PRIME_IMPLICANT(tree.Right,prime);
	         	if(temp_left!=null)
	        		return temp_left;
	        	else 
	        		return temp_right;
         	}
	     //   if(tree.flag==2)
            else
        	{
        		PINode temp_left,prime_left=null;
	        	PINode temp_right,prime_right=null;
        		prime_left=GET_PRIME_IMPLICANT(tree.Left,prime);
	        	prime_right=GET_PRIME_IMPLICANT(tree.Right,prime);
	        	temp_left=prime_left;
        		temp_right=prime_right;
	            while(temp_left!=null)
	         	{
	            	LeafNode leaf;
	            	leaf=new LeafNode();
	            	leaf.Node_Num=tree.Node_Num;
        			leaf.flag=1;
	        	    LeafNode p=temp_left.Implicant;
        		   	if(p==null)
		          		temp_left.Implicant=leaf;
	             	else
	   	        	{
	   		        	while(p.Next!=null)
	   		        		p=p.Next;
	   		        	p.Next=leaf;
	        		}	
	        		temp_left=temp_left.Next;
        		}
          		while(temp_right!=null)
	        	{
	         		LeafNode leaf;
	         		leaf=new LeafNode();
	   	        	leaf.Node_Num=tree.Node_Num;
		        	leaf.flag=2;
    	         	LeafNode p=temp_right.Implicant;
	   	        	if(p==null)
	   	         		temp_right.Implicant=leaf;
	   	        	else
    	        	{
		        		while(p.Next!=null)
	    	     		p=p.Next;
	            		p.Next=leaf;
	    	        }	
		          	temp_right=temp_right.Next;
         		}
	        	if(prime_left!=null)
	         		return prime_left;
	        	else return prime_right;
        	}
        }
    }
}
