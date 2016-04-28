using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using FaultTrees.FT;

namespace VisualBinaryTree
{
    public class TreeRendererFaultTree
    {
        class DrawLocation
        {
            public DrawLocation(PointF drawPosition, FaultTreeNode node)
            {
                DrawPosition = drawPosition;
                Node = node;
            }

            public PointF DrawPosition;
            public FaultTreeNode Node;
        }

        class NodeLine
        {
            public PointF Start;
            public PointF End;
        }

        private FaultTree _faultTree;
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
            get { return _faultTree.NumOfNodes; }
        }

        public int DeepestLevel
        {
            get { return _maxNodeDepth; }
        }

        public int MaxSize
        {
            get { return _faultTree.MaxSize; }
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

        public TreeRendererFaultTree()
        {
            _faultTree = new FaultTree();
            _listOfDrawLocations = new List<DrawLocation>();
            _listOfNodeLines = new List<NodeLine>();
            _pen = new Pen(Color.Blue);
            _solBrush = new SolidBrush(Color.Blue);

            _textFormatter = new StringFormat();
            _textFormatter.LineAlignment = StringAlignment.Center;
            _textFormatter.Alignment = StringAlignment.Center;
            _renderBackBufferBitmap = new Bitmap(VisualFaultTree.DrawAreaSize.Width, VisualFaultTree.DrawAreaSize.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
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
            _faultTree.MaxSize = newMaxSize;

            if (newMaxSize < _faultTree.NumOfNodes)
                TreeError.DisplayError(_faultTree.PrevErrorMsg);
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

        public bool Add(FaultTreeNode root)
        {
            if (_faultTree.NumOfNodes == 0)
            {
                _faultTree.Push(root.Data, "null");
                _listOfDrawLocations.Add(new DrawLocation(new PointF(425.0f, 15.0f), _faultTree.MostRecentAddedNode));
            }
            FaultTreeNode child = root.Child;
            while (child != null)
            {
                _faultTree.Push(child.Data, root.Data);
                int currentNodeDepth = _faultTree.MostRecentAddedNode.Depth;
                if (currentNodeDepth > _maxNodeDepth)
                    _maxNodeDepth = currentNodeDepth;
                for (int i = 0; i < _faultTree.NumOfNodes - 1; ++i)
                {
                    if (_listOfDrawLocations[i].Node.Data == root.Data)
                    {
                        PointF nodePos = _listOfDrawLocations[i].DrawPosition;
                        _listOfDrawLocations.Add(new DrawLocation(nodePos, _faultTree.MostRecentAddedNode));
                        break;
                    }
                }
                Add(child);
                child = child.Sibling;
            }
            int charLengthOfNodeData = _faultTree.MostRecentAddedNode.Data.ToString().Length;

            if (charLengthOfNodeData > _maxCharLengthOfData)
            {
                _maxCharLengthOfData = charLengthOfNodeData;
                _nodeDrawSize.Width = (int)(_font.Size * _maxCharLengthOfData * 1.25f);

                if (_nodeDrawSize.Width < _nodeDrawSize.Height)
                    _nodeDrawSize.Width = _nodeDrawSize.Height;
            }

            SetNodePositions(_faultTree.RootNode);

            EstablishNodeLines();
            return true;
        }

        public bool Add(string value,string parentValue)
        {
            if (!_faultTree.Push(value,parentValue))
            {
                TreeError.DisplayError(_faultTree.PrevErrorMsg);
                return false;
            }

          if (_faultTree.NumOfNodes == 1)
                _listOfDrawLocations.Add(new DrawLocation(new PointF(425.0f, 15.0f), _faultTree.MostRecentAddedNode));
            else
            {
                int currentNodeDepth = _faultTree.MostRecentAddedNode.Depth;

                if (currentNodeDepth > _maxNodeDepth)
                    _maxNodeDepth = currentNodeDepth;

                // Find the added node in the list of draw locations, find its parent, add its child to this list

                for (int i = 0; i < _faultTree.NumOfNodes-1; ++i)
                {
                    FaultTreeNode temp = _listOfDrawLocations[i].Node.Child;
                    while (temp != null)
                    {
                        if (temp == _faultTree.MostRecentAddedNode)
                        {
                            PointF nodePos = _listOfDrawLocations[i].DrawPosition;
                            _listOfDrawLocations.Add(new DrawLocation(nodePos, _faultTree.MostRecentAddedNode));
                            break;
                        }
                        temp = temp.Sibling;
                    }
                }

            }

            int charLengthOfNodeData = _faultTree.MostRecentAddedNode.Data.ToString().Length;

            if (charLengthOfNodeData > _maxCharLengthOfData)
            {
                _maxCharLengthOfData = charLengthOfNodeData;
                _nodeDrawSize.Width = (int)(_font.Size * _maxCharLengthOfData * 1.2f);

                if (_nodeDrawSize.Width < _nodeDrawSize.Height)
                    _nodeDrawSize.Width = _nodeDrawSize.Height;
            }

            SetNodePositions(_faultTree.RootNode);

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

            for (int i = 0; i < _faultTree.NumOfNodes; ++i)
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
            _faultTree.Clear();
        }

        void SetNodePositions(FaultTreeNode node)
        {
            FaultTreeNode temp = node.Child;
            int childNumber = 0;
            while (temp != null)
            {
                childNumber++;
                temp = temp.Sibling;
            }
            temp = node.Child;
            int shift = childNumber / 2;
            while (temp != null)
            {
                DrawLocation newDrawLocation = _listOfDrawLocations.Find(item => item.Node == temp);
                DrawLocation drawLocationOfCurrentNode = _listOfDrawLocations.Find(item => item.Node == node);
                int nodeDepth = temp.Depth;
                // Node distance 2^depth distance from max depth, node draw size is 3/2 to add a small distance
                // between nodes at the same depth, the value is divided by 2 (for each side of the tree)
                // bit-shifting is a more optimal solution for powers of 2

                int spacing = ((int)(_nodeDrawSize.Width * 1f) * (1 << (2*(_maxNodeDepth - nodeDepth)))) / childNumber;

                newDrawLocation.DrawPosition.X = drawLocationOfCurrentNode.DrawPosition.X - shift * spacing;
                shift--;
                // Increase the Y distance by a base distance plus 10 for each level
         //       newDrawLocation.DrawPosition.Y = drawLocationOfCurrentNode.DrawPosition.Y + ((_nodeDrawSize.Height * nodeDepth) * 1.1f);
                newDrawLocation.DrawPosition.Y = drawLocationOfCurrentNode.DrawPosition.Y + 2f*_nodeDrawSize.Height;

                SetNodePositions(temp);
                temp = temp.Sibling;
           
            }
        }

        void EstablishNodeLines()
        {
            _listOfNodeLines.Clear();

            for (int i = 0; i < _faultTree.NumOfNodes - 1; ++i)
            {
                FaultTreeNode child = _listOfDrawLocations[i].Node.Child;
                while (child != null)
                {
                    NodeLine newLine = new NodeLine();
                    DrawLocation currentDrawLocation = _listOfDrawLocations.Find(item => (item.Node == child));
               //     DrawLocation currentDrawLocation = _listOfDrawLocations.Find(item => (item.Node == _listOfDrawLocations[i].Node.Child));
                    // Line start and end positions are translated to the center of each node

                    newLine.Start.X = _listOfDrawLocations[i].DrawPosition.X + (_nodeDrawSize.Width / 2.0f);
                    newLine.Start.Y = _listOfDrawLocations[i].DrawPosition.Y + (_nodeDrawSize.Height / 2.0f);
                    newLine.End.X = currentDrawLocation.DrawPosition.X + (_nodeDrawSize.Width / 2.0f);
                    newLine.End.Y = currentDrawLocation.DrawPosition.Y + (_nodeDrawSize.Height / 2.0f);
                    _listOfNodeLines.Add(newLine);
                    child = child.Sibling;
                }
            }
        }

    }
}
