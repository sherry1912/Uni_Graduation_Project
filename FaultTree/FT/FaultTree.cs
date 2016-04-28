using System;
using System.Collections.Generic;

namespace FaultTrees.FT
{
    /// <summary>
    /// A basic binary tree, that supports search, deletion and all modes of tree traversal
    /// </summary>
    public partial class FaultTree
    {
        FaultTreeNode _rootNode;

        FaultTreeNode _mostRecentlyAddedNode;

        int _maxSize;
        int _numOfElements;
        string _lastError;
        public FaultTree() : this(50) { }
        public FaultTree(int maxSize)
        {
            _maxSize = maxSize;
        }

        public bool Push(string value, string parentValue)
        {
            bool pushSucceeded;

            if (_numOfElements == _maxSize)
            {
                _lastError = "The tree has exceeded the maximum amount of nodes permitted in the tree" +
                ", increase the maximum size of the tree first.";
                return false;
            }
            if (_rootNode == null)
            {
                _rootNode = new FaultTreeNode(value);
                _mostRecentlyAddedNode = _rootNode;
                pushSucceeded = true;
            }
            else
            {
                try
                {
                    pushSucceeded = PushIn(value,parentValue);

                    if (!pushSucceeded)
                        _lastError = "Duplicate value already exists inside the tree.";
                }
                catch (Exception e)
                {
                    _lastError = e.Message;
                    return false;
                }
            }

            if (pushSucceeded)
                _numOfElements++;

            return pushSucceeded;
        }



        /// <summary>
        /// Clears the tree by removing the reference to the root node
        /// </summary>
        public void Clear()
        {
            _rootNode = null;
            _numOfElements = 0;
        }

        /// <summary>
        /// Gets the total number of nodes stored in the BST
        /// </summary>
        public int NumOfNodes
        {
            get { return _numOfElements; }
        }


        /// <summary>
        /// Gets a bool indicating whether or not the tree is empty
        /// </summary>
        public bool IsEmpty
        {
            get { return _numOfElements == 0; }
        }

        /// <summary>
        /// Gets the most recently added node to the tree
        /// </summary>
        public FaultTreeNode MostRecentAddedNode
        {
            get { return _mostRecentlyAddedNode; }
        }


        /// <summary>
        /// Gets the most root node of the tree
        /// </summary>
        public FaultTreeNode RootNode
        {
            get { return _rootNode; }
        }

        /// <summary>
        /// Gets or sets the maximum amount of nodes allowed for the tree, the error member will be set if the\r\n
        /// size entered is less than the number of nodes in the tree
        /// </summary>
        public int MaxSize
        {
            set
            {
                if(_numOfElements > value)
                    _lastError = "New maximum tree size entered is less than the number of nodes present in the tree, "
                    + "the maximum size of the tree has not been changed";
                else
                    _maxSize = value;
            }
            get { return _maxSize; }
        }

        /// <summary>
        /// Gets the most recent error message, if there has been one
        /// </summary>
        public string PrevErrorMsg
        {
            get { return _lastError; }
        }
    }
}
