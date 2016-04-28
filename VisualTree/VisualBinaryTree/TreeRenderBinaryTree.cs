using BinaryTrees.BT;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace VisualBinaryTree
{
    class TreeRenderBinaryTree
    {
        class DrawLocation
        {
            public DrawLocation(PointF drawPosition, BinaryTreeNode node)
            {
                DrawPosition = drawPosition;
                Node = node;
            }

            public PointF DrawPosition;
            public BinaryTreeNode Node;
        }

        class NodeLine
        {
            public PointF Start;
            public PointF End;
        }

        private BinaryTree _binaryTree;
        private Bitmap _renderBackBufferBitmap;
        private Graphics _renderBackBuffer;

        List<DrawLocation> _listOfDrawLocations;
        List<NodeLine> _listOfNodeLines;

        private Pen _pen;
        private SolidBrush _solBrush;
        private StringFormat _textFormatter;
        private Font _font;
        private PointF _viewPos;

        private int _maxCharLengthOfData;
        private int _maxNodeDepth;
        private Size _nodeDrawSize;


        public Color BackgroundColour { get; set; }
        public Color NodeFillColour { get; set; }
        public Color TextColour { get; set; }
        public Color LineColour { get; set; }

        public int NodeCount
        {
            get { return _binaryTree.NumOfNodes; }
        }

        public int DeepestLevel
        {
            get { return _maxNodeDepth; }
        }

        public int MaxSize
        {
            get { return _binaryTree.MaxSize; }
        }

        public float ViewY
        {
            set
            {
                _viewPos.Y = value;
            }
            get
            {
                return _viewPos.Y;
            }
        }

        public float ViewX
        {
            set
            {
                _viewPos.X = value;
            }
            get
            {
                return _viewPos.X;
            }
        }

        public TreeRenderBinaryTree()
        {
            _binaryTree = new BinaryTree();
            _listOfDrawLocations = new List<DrawLocation>();
            _listOfNodeLines = new List<NodeLine>();
            _pen = new Pen(Color.Blue);
            _solBrush = new SolidBrush(Color.Blue);

            _textFormatter = new StringFormat();
            _textFormatter.LineAlignment = StringAlignment.Center;
            _textFormatter.Alignment = StringAlignment.Center;
            _renderBackBufferBitmap = new Bitmap(VisualBinaryTree.DrawAreaSize.Width, VisualBinaryTree.DrawAreaSize.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            _renderBackBuffer = Graphics.FromImage(_renderBackBufferBitmap);

            _font = new Font("Arial", 12.0f);

            BackgroundColour = Color.White;
            TextColour = Color.Blue;
            LineColour = Color.Blue;
            NodeFillColour = Color.Yellow;

            _nodeDrawSize = new Size();
            _nodeDrawSize.Height = (int)(_font.Height * 2);
        }

        public void AdjustMaxSizeOfTree(int newMaxSize)
        {
            _binaryTree.MaxSize = newMaxSize;

            if (newMaxSize < _binaryTree.NumOfNodes)
                TreeError.DisplayError(_binaryTree.PrevErrorMsg);
        }

        public ScrollExtents GetTreeExtents()
        {
            float leftMostX = 0;
            float rightMostX = 0;
            float bottomMostY = 0;

            // find max/min extents for X and Y

            leftMostX = _listOfDrawLocations.Min(p => p.DrawPosition.X);
            rightMostX = _listOfDrawLocations.Max(p => p.DrawPosition.X);
            bottomMostY = _listOfDrawLocations.Max(p => p.DrawPosition.Y);

            leftMostX -= _nodeDrawSize.Width;
            rightMostX += _nodeDrawSize.Width;
            bottomMostY += _nodeDrawSize.Height;

            return new ScrollExtents((int)bottomMostY, (int)leftMostX, (int)rightMostX);
        }

        public bool Add(BinaryTreeNode node)
        {
            if (node == null) return true;
            _binaryTree.Push(node.Data);
            if (_binaryTree.NumOfNodes == 1)
                _listOfDrawLocations.Add(new DrawLocation(new PointF(425.0f, 15.0f), _binaryTree.MostRecentAddedNode));
            else
            {
                int currentNodeDepth = _binaryTree.MostRecentAddedNode.Depth;

                if (currentNodeDepth > _maxNodeDepth)
                    _maxNodeDepth = currentNodeDepth;

                // Find the added node in the list of draw locations, find its parent, add its child to this list

                for (int i = 0; i < _binaryTree.NumOfNodes - 1; ++i)
                {
                    if (_listOfDrawLocations[i].Node.Left == _binaryTree.MostRecentAddedNode)
                    {
                        PointF nodePos = _listOfDrawLocations[i].DrawPosition;
                        _listOfDrawLocations.Add(new DrawLocation(nodePos, _binaryTree.MostRecentAddedNode));

                        break;
                    }

                    if (_listOfDrawLocations[i].Node.Right == _binaryTree.MostRecentAddedNode)
                    {
                        PointF nodePos = _listOfDrawLocations[i].DrawPosition;
                        _listOfDrawLocations.Add(new DrawLocation(nodePos, _binaryTree.MostRecentAddedNode));

                        break;
                    }
                }

            }
            int charLengthOfNodeData = _binaryTree.MostRecentAddedNode.Data.ToString().Length;

            if (charLengthOfNodeData > _maxCharLengthOfData)
            {
                _maxCharLengthOfData = charLengthOfNodeData;
                _nodeDrawSize.Width = (int)(_font.Size * _maxCharLengthOfData * 1.25f);

                if (_nodeDrawSize.Width < _nodeDrawSize.Height)
                    _nodeDrawSize.Width = _nodeDrawSize.Height;
            }
            Add(node.Left);
            Add(node.Right);

            SetNodePositions(_binaryTree.RootNode);

            EstablishNodeLines();

            return true;
        }

        public bool Add(string value)
        {
            if (!_binaryTree.Push(value))
            {
                TreeError.DisplayError(_binaryTree.PrevErrorMsg);
                return false;
            }

            if (_binaryTree.NumOfNodes == 1)
                _listOfDrawLocations.Add(new DrawLocation(new PointF(425.0f, 15.0f), _binaryTree.MostRecentAddedNode));
            else
            {
                int currentNodeDepth = _binaryTree.MostRecentAddedNode.Depth;

                if (currentNodeDepth > _maxNodeDepth)
                    _maxNodeDepth = currentNodeDepth;

                // Find the added node in the list of draw locations, find its parent, add its child to this list

                for (int i = 0; i < _binaryTree.NumOfNodes-1; ++i)
                {
                    if (_listOfDrawLocations[i].Node.Left == _binaryTree.MostRecentAddedNode)
                    {
                        PointF nodePos = _listOfDrawLocations[i].DrawPosition;
                        _listOfDrawLocations.Add(new DrawLocation(nodePos, _binaryTree.MostRecentAddedNode));

                        break;
                    }

                    if (_listOfDrawLocations[i].Node.Right == _binaryTree.MostRecentAddedNode)
                    {
                        PointF nodePos = _listOfDrawLocations[i].DrawPosition;
                        _listOfDrawLocations.Add(new DrawLocation(nodePos, _binaryTree.MostRecentAddedNode));

                        break;
                    }
                }

            }

            int charLengthOfNodeData = _binaryTree.MostRecentAddedNode.Data.ToString().Length;

            if (charLengthOfNodeData > _maxCharLengthOfData)
            {
                _maxCharLengthOfData = charLengthOfNodeData;
                _nodeDrawSize.Width = (int)(_font.Size * _maxCharLengthOfData * 1.25f);

                if (_nodeDrawSize.Width < _nodeDrawSize.Height)
                    _nodeDrawSize.Width = _nodeDrawSize.Height;
            }

            SetNodePositions(_binaryTree.RootNode);

            EstablishNodeLines();

            return true;
        }

      

        public void Draw(Graphics treeGraphics)
        {
            _renderBackBuffer.Clear(BackgroundColour);

            _pen.Color = LineColour;

            for (int i = 0; i < _listOfNodeLines.Count; ++i)
            {
                // Offset the draw locations by the view position which is controlled by scroll bars

                PointF translatedLineStart = new PointF(_listOfNodeLines[i].Start.X + _viewPos.X, _listOfNodeLines[i].Start.Y + _viewPos.Y);
                PointF translatedLineEnd = new PointF(_listOfNodeLines[i].End.X + _viewPos.X, _listOfNodeLines[i].End.Y + _viewPos.Y);

                _renderBackBuffer.DrawLine(_pen, translatedLineStart, translatedLineEnd);
            }

            for (int i = 0; i < _binaryTree.NumOfNodes; ++i)
            {
                _solBrush.Color = NodeFillColour;
                _renderBackBuffer.FillEllipse(_solBrush, _listOfDrawLocations[i].DrawPosition.X + _viewPos.X, _listOfDrawLocations[i].DrawPosition.Y + _viewPos.Y, _nodeDrawSize.Width, _nodeDrawSize.Height);

                _renderBackBuffer.DrawEllipse(_pen, _listOfDrawLocations[i].DrawPosition.X + _viewPos.X, _listOfDrawLocations[i].DrawPosition.Y + _viewPos.Y, _nodeDrawSize.Width, _nodeDrawSize.Height);

                _solBrush.Color = TextColour;

                _renderBackBuffer.DrawString(_listOfDrawLocations[i].Node.Data.ToString(), _font, _solBrush, _listOfDrawLocations[i].DrawPosition.X + (_nodeDrawSize.Width / 2.0f) + _viewPos.X, _listOfDrawLocations[i].DrawPosition.Y + (_nodeDrawSize.Height / 2.0f) + _viewPos.Y, _textFormatter);
            }

            // Image is double-buffered, render it first to the back buffer then draw the bitamp to the graphics object
            // representing the graphics object for the tree

            treeGraphics.DrawImage(_renderBackBufferBitmap, 0, 0, _renderBackBufferBitmap.Width, _renderBackBufferBitmap.Height);
        }

        public void ClearAll()
        {
            _listOfDrawLocations.Clear();
            _listOfNodeLines.Clear();
            _binaryTree.Clear();
        }

        void SetNodePositions(BinaryTreeNode node)
        {
            if (node.Left != null)
            {
                // Set the distances between nodes at the same depth

                DrawLocation newDrawLocation = _listOfDrawLocations.Find(item => item.Node == node.Left);
                DrawLocation drawLocationOfCurrentNode = _listOfDrawLocations.Find(item => item.Node == node);
                int nodeDepth = node.Left.Depth;

                // Node distance 2^depth distance from max depth, node draw size is 3/2 to add a small distance
                // between nodes at the same depth, the value is divided by 2 (for each side of the tree)
                // bit-shifting is a more optimal solution for powers of 2

                int spacing = ((int)(_nodeDrawSize.Width * 1f) * (1 << (int)((_maxNodeDepth - nodeDepth)/1.5))) / 2;

                newDrawLocation.DrawPosition.X = drawLocationOfCurrentNode.DrawPosition.X - spacing;

                // Increase the Y distance by a base distance plus 10 for each level
                newDrawLocation.DrawPosition.Y = drawLocationOfCurrentNode.DrawPosition.Y + ((_nodeDrawSize.Height * nodeDepth) * 1f);

                SetNodePositions(node.Left);
            }

            if (node.Right != null)
            {
                DrawLocation newDrawLocation = _listOfDrawLocations.Find(item => item.Node == node.Right);
                DrawLocation drawLocationOfCurrentNode = _listOfDrawLocations.Find(item => item.Node == node);
                int nodeDepth = node.Right.Depth;

                int spacing = ((int)(_nodeDrawSize.Width * 1f) * (1 << (int)((_maxNodeDepth - nodeDepth)/1.5))) / 2;

                newDrawLocation.DrawPosition.X = drawLocationOfCurrentNode.DrawPosition.X + spacing;
                newDrawLocation.DrawPosition.Y = drawLocationOfCurrentNode.DrawPosition.Y + ((_nodeDrawSize.Height * nodeDepth) * 1f);

                SetNodePositions(node.Right);
            }
        }

        void EstablishNodeLines()
        {
            _listOfNodeLines.Clear();

            for (int i = 0; i < _binaryTree.NumOfNodes - 1; ++i)
            {
                if (_listOfDrawLocations[i].Node.Left != null)
                {
                    NodeLine newLine = new NodeLine();
                    DrawLocation currentDrawLocation = _listOfDrawLocations.Find(item => (item.Node == _listOfDrawLocations[i].Node.Left));

                    // Line start and end positions are translated to the center of each node

                    newLine.Start.X = _listOfDrawLocations[i].DrawPosition.X + (_nodeDrawSize.Width / 2.0f);
                    newLine.Start.Y = _listOfDrawLocations[i].DrawPosition.Y + (_nodeDrawSize.Height / 2.0f);
                    newLine.End.X = currentDrawLocation.DrawPosition.X + (_nodeDrawSize.Width / 2.0f);
                    newLine.End.Y = currentDrawLocation.DrawPosition.Y + (_nodeDrawSize.Height / 2.0f);

                    _listOfNodeLines.Add(newLine);
                }
                if (_listOfDrawLocations[i].Node.Right != null)
                {
                    NodeLine newLine = new NodeLine();
                    DrawLocation currentDrawLocation = _listOfDrawLocations.Find(item => (item.Node == _listOfDrawLocations[i].Node.Right));

                    newLine.Start.X = _listOfDrawLocations[i].DrawPosition.X + (_nodeDrawSize.Width / 2.0f);
                    newLine.Start.Y = _listOfDrawLocations[i].DrawPosition.Y + (_nodeDrawSize.Height / 2.0f);
                    newLine.End.X = currentDrawLocation.DrawPosition.X + (_nodeDrawSize.Width / 2.0f);
                    newLine.End.Y = currentDrawLocation.DrawPosition.Y + (_nodeDrawSize.Height / 2.0f);

                    _listOfNodeLines.Add(newLine);
                }
            }
        }
    }
}
