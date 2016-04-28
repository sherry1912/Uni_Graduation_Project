using PrimeImplicant.PI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VisualBinaryTree.Forms
{
    public partial class ChooseFile : Form
    {
        private FaultTrees.FT.FaultTreeNode _rootFaultTree;
        private FaultTrees.FT.FaultTreeNode _rootFaultTree_Uncertainty;
        private BinaryTrees.BT.BinaryTreeNode _rootBDDTree;
        private BinaryTrees.BT.BinaryTreeNode _rootBDDTree_Uncertainty;
        private BinaryTrees.BT.BinaryTreeNode _rootMetaTree;
        private BinaryTrees.BT.BinaryTreeNode _rootMetaTree_Uncertainty;
        private LeafNode _leaflists;
        private LeafNode _leaflists_Uncertainty;
        private PINode _prime_lists;
        private PINode _prime_lists_Uncertainty;
    //    StreamReader file;
        public ChooseFile()
        {
            InitializeComponent();
        }


        private void button_UFT_Click(object sender, EventArgs e)
        {
            if (_rootFaultTree_Uncertainty==null)
            {
                MessageBox.Show("please choose input file and click ok!");
                return;
            }
            VisualFaultTree UFT = new VisualFaultTree(_rootFaultTree_Uncertainty);
            UFT.Show();
        }

        private void button_browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string filename = dlg.FileName;
                filenameBox.Text = filename;
            }
        }

        private void button_FT_Click(object sender, EventArgs e)
        {
            if (_rootFaultTree == null)
            {
                MessageBox.Show("please choose input file and click ok!");
                return;
            }
            VisualFaultTree FT = new VisualFaultTree(_rootFaultTree);
            FT.Show();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (filenameBox.Text.ToString() == null)
            {
                MessageBox.Show("please choose input file!");
                return;
            }
            Build_Fault_Tree build_T = new Build_Fault_Tree();
            _rootFaultTree = build_T.Build_fault_tree(filenameBox.Text.ToString());
            _leaflists = new Build_Leaf_lists(_rootFaultTree).Get_leaflists();
            Build_Uncertainty_Tree build_UT = new Build_Uncertainty_Tree(_rootFaultTree);
            _rootFaultTree_Uncertainty = build_UT.Get_uncertainty_Tree();
            _leaflists_Uncertainty = new Build_Leaf_lists(_rootFaultTree_Uncertainty).Get_leaflists();
            Build_BDD_Tree build_BDD = new Build_BDD_Tree();
            _rootBDDTree = build_BDD.FAT_BDD(_rootFaultTree);
            _rootBDDTree_Uncertainty = build_BDD.FAT_BDD(_rootFaultTree_Uncertainty);
            Build_Meta_Tree build_Meta = new Build_Meta_Tree();
            _rootMetaTree = build_Meta.BUILD_META_TREE(_rootBDDTree, _leaflists);
            _rootMetaTree_Uncertainty = build_Meta.BUILD_META_TREE(_rootBDDTree_Uncertainty, _leaflists_Uncertainty);
            Prime_Implicants build_PI = new Prime_Implicants(_rootMetaTree);
            _prime_lists = build_PI.get_First_Prime();
            Prime_Implicants build_UPI = new Prime_Implicants(_rootMetaTree_Uncertainty);
            _prime_lists_Uncertainty = build_UPI.get_First_Prime();
        }

        private void button_FT_BDD_Click(object sender, EventArgs e)
        {
            if (_rootFaultTree == null)
            {
                MessageBox.Show("please choose input file and click ok!");
                return;
            }
            VisualBinaryTree BDDT = new VisualBinaryTree(_rootBDDTree);
            BDDT.Show();
        }

        private void button_FT_meta_BDD_Click(object sender, EventArgs e)
        {
            if (_rootFaultTree == null)
            {
                MessageBox.Show("please choose input file and click ok!");
                return;
            }
            VisualBinaryTree MetaT = new VisualBinaryTree(_rootMetaTree);
            MetaT.Show();
        }

        private string Get_Prime_Info(PINode primeList)
        {
            PINode PI = primeList;
            string upper = "{";
            while (PI != null)
            {
                upper = upper + " {";
                LeafNode leaf = PI.Implicant;
                while (leaf != null)
                {
                    if (leaf.flag == 2)
                        upper = upper + "~";
                    else upper = upper + " ";
                    upper = upper + "N" + leaf.Node_Num.ToString();
                    leaf = leaf.Next;
                }
                upper = upper + "}";
                PI = PI.Next;
            }
            upper = upper + " }";
            return upper;
        }
        private void button_PI_Click(object sender, EventArgs e)
        {
            if (_rootFaultTree == null)
            {
                MessageBox.Show("please choose input file and click ok!");
                return;
            }
            
            MessageBox.Show("upper approximation\n"+Get_Prime_Info(_prime_lists)
                +"\n\nUncertainty\n"+Get_Prime_Info(_prime_lists_Uncertainty));
        }

        private void button_UFT_BDD_Click(object sender, EventArgs e)
        {
            if (_rootFaultTree == null)
            {
                MessageBox.Show("please choose input file and click ok!");
                return;
            }
            VisualBinaryTree BDDUT = new VisualBinaryTree(_rootBDDTree_Uncertainty);
            BDDUT.Show();
        }

        private void button_UFT_meta_BDD_Click(object sender, EventArgs e)
        {
            if (_rootFaultTree == null)
            {
                MessageBox.Show("please choose input file and click ok!");
                return;
            }
            VisualBinaryTree MetaUT = new VisualBinaryTree(_rootMetaTree_Uncertainty);
            MetaUT.Show();
        }     
    }
}
