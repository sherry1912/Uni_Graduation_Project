using System;
using System.Collections.Generic;

namespace BinaryTrees.BT
{
    /// <summary>
    /// A basic binary tree, that supports search, deletion and all modes of tree traversal
    /// </summary>
    public partial class BinaryTree
    {
        BinaryTreeNode _rootNode;

        BinaryTreeNode _mostRecentlyAddedNode;

        int _maxSize;
        int _numOfElements;
        string _lastError;
        public BinaryTree() : this(50) { }

        /// <summary>
        /// Create a new binary tree with a limit of n nodes
        /// </summary>
        /// <param name="maxSize">The maximum number of nodes that can be added to the tree</param>
        public BinaryTree(int maxSize)
        {
            _maxSize = maxSize;
        }

        public bool Push(string value)
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
                _rootNode = new BinaryTreeNode(value);
                _mostRecentlyAddedNode = _rootNode;
                pushSucceeded = true;
            }
            else
            {
                try
                {
                    pushSucceeded = Push(_rootNode, value,1);

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
        /// Search the tree for a value
        /// </summary>
        /// <param name="value">The value to search for</param>
        /// <returns>A bool indicating wether the node could be found</returns>
        /// 

        public bool Search(string value)
        {
            if (IsEmpty)
            {
                _lastError = "Tree is empty.";
                return false;
            }

            BinaryTreeNode foundNode = Search(value, _rootNode);

            if (foundNode == null)
            {
                _lastError = "Value not found.";
                return false;
            }

            return true;
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
        public BinaryTreeNode MostRecentAddedNode
        {
            get { return _mostRecentlyAddedNode; }
        }


        /// <summary>
        /// Gets the most root node of the tree
        /// </summary>
        public BinaryTreeNode RootNode
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
