namespace VisualBinaryTree
{
    partial class VisualBinaryTree
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisualBinaryTree));
            this.txtValue = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tmrDraw = new System.Windows.Forms.Timer(this.components);
            this.pbVisualTree = new System.Windows.Forms.PictureBox();
            this.elementColourDialog = new System.Windows.Forms.ColorDialog();
            this.hsbTree = new System.Windows.Forms.HScrollBar();
            this.vsbTree = new System.Windows.Forms.VScrollBar();
            this.lblNodeCount = new System.Windows.Forms.Label();
            this.lblDeepestLevel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTreeFileDlalog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pbVisualTree)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(6, 377);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(142, 21);
            this.txtValue.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(167, 377);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(57, 18);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tmrDraw
            // 
            this.tmrDraw.Interval = 10;
            this.tmrDraw.Tick += new System.EventHandler(this.tmrDraw_Tick);
            // 
            // pbVisualTree
            // 
            this.pbVisualTree.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbVisualTree.Location = new System.Drawing.Point(12, 25);
            this.pbVisualTree.Name = "pbVisualTree";
            this.pbVisualTree.Size = new System.Drawing.Size(832, 331);
            this.pbVisualTree.TabIndex = 2;
            this.pbVisualTree.TabStop = false;
            // 
            // hsbTree
            // 
            this.hsbTree.LargeChange = 50;
            this.hsbTree.Location = new System.Drawing.Point(9, 356);
            this.hsbTree.Name = "hsbTree";
            this.hsbTree.Size = new System.Drawing.Size(819, 16);
            this.hsbTree.SmallChange = 10;
            this.hsbTree.TabIndex = 4;
            this.hsbTree.Visible = false;
            this.hsbTree.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbTree_Scroll);
            // 
            // vsbTree
            // 
            this.vsbTree.LargeChange = 50;
            this.vsbTree.Location = new System.Drawing.Point(828, 25);
            this.vsbTree.Name = "vsbTree";
            this.vsbTree.Size = new System.Drawing.Size(16, 331);
            this.vsbTree.SmallChange = 10;
            this.vsbTree.TabIndex = 5;
            this.vsbTree.Visible = false;
            this.vsbTree.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vsbTree_Scroll);
            // 
            // lblNodeCount
            // 
            this.lblNodeCount.AutoSize = true;
            this.lblNodeCount.Location = new System.Drawing.Point(370, 377);
            this.lblNodeCount.Name = "lblNodeCount";
            this.lblNodeCount.Size = new System.Drawing.Size(113, 12);
            this.lblNodeCount.TabIndex = 8;
            this.lblNodeCount.Text = "Node Count: 0 \\ 10";
            // 
            // lblDeepestLevel
            // 
            this.lblDeepestLevel.AutoSize = true;
            this.lblDeepestLevel.Location = new System.Drawing.Point(669, 377);
            this.lblDeepestLevel.Name = "lblDeepestLevel";
            this.lblDeepestLevel.Size = new System.Drawing.Size(113, 12);
            this.lblDeepestLevel.TabIndex = 9;
            this.lblDeepestLevel.Text = "Deepest Level: N\\A";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(856, 25);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(138, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(42, 21);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // openTreeFileDlalog
            // 
            this.openTreeFileDlalog.FileName = "openFileDialog1";
            // 
            // VisualBinaryTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 411);
            this.Controls.Add(this.lblDeepestLevel);
            this.Controls.Add(this.lblNodeCount);
            this.Controls.Add(this.vsbTree);
            this.Controls.Add(this.hsbTree);
            this.Controls.Add(this.pbVisualTree);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.menuStrip1);
       //     this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(872, 450);
            this.MinimumSize = new System.Drawing.Size(872, 450);
            this.Name = "VisualBinaryTree";
            this.Text = "Visual Binary Tree";
            ((System.ComponentModel.ISupportInitialize)(this.pbVisualTree)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Timer tmrDraw;
        private System.Windows.Forms.PictureBox pbVisualTree;
        private System.Windows.Forms.ColorDialog elementColourDialog;
        private System.Windows.Forms.HScrollBar hsbTree;
        private System.Windows.Forms.VScrollBar vsbTree;
        private System.Windows.Forms.Label lblNodeCount;
        private System.Windows.Forms.Label lblDeepestLevel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openTreeFileDlalog;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
    }
}
