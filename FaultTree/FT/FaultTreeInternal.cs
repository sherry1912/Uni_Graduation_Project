using System;
using System.Collections.Generic;

namespace FaultTrees.FT
{
    public partial class FaultTree
    {
        enum MinOrMax { NODE_MIN, NODE_MAX };

        bool PushIn(string value, string parentValue)
        {
            bool pushSuccessful = false;
            FaultTreeNode parent = GetParent(parentValue, _rootNode);
            if (parent == null)
                return pushSuccessful;
            if (parent.Child == null)
            {
                parent.Child = new FaultTreeNode(value);
                parent.Child.Depth =parent.Depth+1;
                _mostRecentlyAddedNode = parent.Child;
                return true;
            }
            FaultTreeNode temp = parent.Child;
            while (temp.Sibling != null)
                temp = temp.Sibling;
            temp.Sibling = new FaultTreeNode(value);
            temp.Sibling.Depth = parent.Depth+1;
            _mostRecentlyAddedNode = temp.Sibling;
            pushSuccessful = true;
            return pushSuccessful;
        }
        FaultTreeNode GetParent(string parentValue, FaultTreeNode parentNode)
        {
            if (parentNode.Data.Equals(parentValue))
                return parentNode;
            FaultTreeNode child = parentNode.Child;
            FaultTreeNode parent=null;
            while (child != null)
            {
                parent = GetParent(parentValue, child);
                if (parent != null)
                    break;
                child = child.Sibling;
            }
            return parent;
        }
      
    }
}
