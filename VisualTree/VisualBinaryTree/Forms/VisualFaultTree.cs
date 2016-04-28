using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using FaultTrees.FT;



namespace VisualBinaryTree
{
    public partial class VisualFaultTree : Form
    {
        private Graphics _pictureBoxGraphics;
        private dynamic _graphicalTree;

        public static Size DrawAreaSize { get; set; }

        public VisualFaultTree(FaultTrees.FT.FaultTreeNode _rootFaultTree)
        {
            InitializeComponent();

            _pictureBoxGraphics = pbVisualTree.CreateGraphics();

            DrawAreaSize = pbVisualTree.Size;

            this.MouseWheel += new MouseEventHandler(Form1_MouseWheel);

            _graphicalTree = new TreeRendererFaultTree();
            ResetUI();
            if (tmrDraw.Enabled)
            {
                GC.Collect();
            }
         //   _treeDataType = _graphicalTree.GetType().GetGenericArguments()[0];
          //  CheckScrollBars();
            tmrDraw.Enabled = true;
            _graphicalTree.Add(_rootFaultTree);
            CheckScrollBars();
        }

        void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (vsbTree.Visible)
            {
                if (Math.Abs(e.Delta) < 100)
                    return;

                int newScrollValue = vsbTree.Value - (5 * (e.Delta / 100));
                int currentScrollValue = vsbTree.Value;

                newScrollValue = (newScrollValue >= vsbTree.Minimum && newScrollValue <= vsbTree.Maximum) ? newScrollValue :
                    (newScrollValue < vsbTree.Minimum) ? vsbTree.Minimum : vsbTree.Maximum;

                ScrollEventArgs se = new ScrollEventArgs(ScrollEventType.ThumbTrack, currentScrollValue, newScrollValue);

                vsbTree.Value = newScrollValue;
                vsbTree_Scroll(sender, se);
            }
        }

        private void tmrDraw_Tick(object sender, EventArgs e)
        {
            _graphicalTree.Draw(_pictureBoxGraphics);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string temp = txtValue.Text;
            string[] strings = temp.Split(' ');
            if (!_graphicalTree.Add(strings[0],strings[1]))
                return;
            CheckScrollBars();

            // Reset the view

            _graphicalTree.ViewX = 0.0f;
            _graphicalTree.ViewY = 0.0f;

            // Update the text display

            txtValue.Text = "";
            lblNodeCount.Text = "Node Count: " + _graphicalTree.NodeCount.ToString() + " \\ " + _graphicalTree.MaxSize;
            lblDeepestLevel.Text = "Deepest Level: " + (_graphicalTree.DeepestLevel == 0 ? (_graphicalTree.NodeCount == 0 ? "N\\A" : "Root") : _graphicalTree.DeepestLevel.ToString());
        }

        private void vsbTree_Scroll(object sender, ScrollEventArgs e)
        {
            _graphicalTree.ViewY = -e.NewValue;
        }

        private void hsbTree_Scroll(object sender, ScrollEventArgs e)
        {
            _graphicalTree.ViewX = -e.NewValue;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you wish to delete all the nodes in the tree?","Binary Tree",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                _graphicalTree.ClearAll();

            ResetUI();
        }

        private void ResetUI()
        {
            lblNodeCount.Text = "Node Count: 0 \\ " + _graphicalTree.MaxSize;
            lblDeepestLevel.Text = "Deepest Level: N\\A";
        }

        private void CheckScrollBars()
        {
            if (_graphicalTree.NodeCount > 0)
            {
                ScrollExtents se = _graphicalTree.GetTreeExtents();

                vsbTree.Minimum = 0;
                vsbTree.Maximum = se.Bottom;
                hsbTree.Minimum = se.Left;
                hsbTree.Maximum = se.Right;

                // If the height and width of the tree is greater than the picturebox then display scrollbars

                vsbTree.Visible = (se.Bottom > pbVisualTree.Size.Height);
                hsbTree.Visible = (se.Left < 0|| (se.Right > pbVisualTree.Size.Width));
            }
            else
            {
                vsbTree.Visible = false;
                hsbTree.Visible = false;
            }
        }

       

     
      
    }
}
