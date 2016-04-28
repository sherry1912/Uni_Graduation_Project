namespace VisualBinaryTree.Forms
{
    partial class ChooseFile
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
            this.button_browse = new System.Windows.Forms.Button();
            this.filenameBox = new System.Windows.Forms.TextBox();
            this.button_FT = new System.Windows.Forms.Button();
            this.button_FT_BDD = new System.Windows.Forms.Button();
            this.button_UFT = new System.Windows.Forms.Button();
            this.button_FT_meta_BDD = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_UFT_BDD = new System.Windows.Forms.Button();
            this.button_UFT_meta_BDD = new System.Windows.Forms.Button();
            this.button_PI = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_browse
            // 
            this.button_browse.Location = new System.Drawing.Point(13, 28);
            this.button_browse.Name = "button_browse";
            this.button_browse.Size = new System.Drawing.Size(285, 23);
            this.button_browse.TabIndex = 0;
            this.button_browse.Text = "browse";
            this.button_browse.UseVisualStyleBackColor = true;
            this.button_browse.Click += new System.EventHandler(this.button_browse_Click);
            // 
            // filenameBox
            // 
            this.filenameBox.Location = new System.Drawing.Point(13, 57);
            this.filenameBox.Name = "filenameBox";
            this.filenameBox.Size = new System.Drawing.Size(285, 21);
            this.filenameBox.TabIndex = 1;
            // 
            // button_FT
            // 
            this.button_FT.Location = new System.Drawing.Point(12, 115);
            this.button_FT.Name = "button_FT";
            this.button_FT.Size = new System.Drawing.Size(286, 23);
            this.button_FT.TabIndex = 2;
            this.button_FT.Text = "ShowFaultTree";
            this.button_FT.UseVisualStyleBackColor = true;
            this.button_FT.Click += new System.EventHandler(this.button_FT_Click);
            // 
            // button_FT_BDD
            // 
            this.button_FT_BDD.Location = new System.Drawing.Point(13, 144);
            this.button_FT_BDD.Name = "button_FT_BDD";
            this.button_FT_BDD.Size = new System.Drawing.Size(286, 23);
            this.button_FT_BDD.TabIndex = 3;
            this.button_FT_BDD.Text = "ShowFaultTreeBDD";
            this.button_FT_BDD.UseVisualStyleBackColor = true;
            this.button_FT_BDD.Click += new System.EventHandler(this.button_FT_BDD_Click);
            // 
            // button_UFT
            // 
            this.button_UFT.Location = new System.Drawing.Point(13, 202);
            this.button_UFT.Name = "button_UFT";
            this.button_UFT.Size = new System.Drawing.Size(286, 23);
            this.button_UFT.TabIndex = 4;
            this.button_UFT.Text = "ShowUncertaintyFaultTree";
            this.button_UFT.UseVisualStyleBackColor = true;
            this.button_UFT.Click += new System.EventHandler(this.button_UFT_Click);
            // 
            // button_FT_meta_BDD
            // 
            this.button_FT_meta_BDD.Location = new System.Drawing.Point(12, 173);
            this.button_FT_meta_BDD.Name = "button_FT_meta_BDD";
            this.button_FT_meta_BDD.Size = new System.Drawing.Size(285, 23);
            this.button_FT_meta_BDD.TabIndex = 5;
            this.button_FT_meta_BDD.Text = "ShowFaultTreeMetaBDD";
            this.button_FT_meta_BDD.UseVisualStyleBackColor = true;
            this.button_FT_meta_BDD.Click += new System.EventHandler(this.button_FT_meta_BDD_Click);
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(13, 86);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(285, 23);
            this.button_ok.TabIndex = 6;
            this.button_ok.Text = "ok";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_UFT_BDD
            // 
            this.button_UFT_BDD.Location = new System.Drawing.Point(12, 231);
            this.button_UFT_BDD.Name = "button_UFT_BDD";
            this.button_UFT_BDD.Size = new System.Drawing.Size(285, 23);
            this.button_UFT_BDD.TabIndex = 7;
            this.button_UFT_BDD.Text = "ShowUncertaintyFaultTreeBDD";
            this.button_UFT_BDD.UseVisualStyleBackColor = true;
            this.button_UFT_BDD.Click += new System.EventHandler(this.button_UFT_BDD_Click);
            // 
            // button_UFT_meta_BDD
            // 
            this.button_UFT_meta_BDD.Location = new System.Drawing.Point(13, 263);
            this.button_UFT_meta_BDD.Name = "button_UFT_meta_BDD";
            this.button_UFT_meta_BDD.Size = new System.Drawing.Size(285, 23);
            this.button_UFT_meta_BDD.TabIndex = 8;
            this.button_UFT_meta_BDD.Text = "ShowUncertaintyFaultTreeMetaBDD";
            this.button_UFT_meta_BDD.UseVisualStyleBackColor = true;
            this.button_UFT_meta_BDD.Click += new System.EventHandler(this.button_UFT_meta_BDD_Click);
            // 
            // button_PI
            // 
            this.button_PI.Location = new System.Drawing.Point(12, 293);
            this.button_PI.Name = "button_PI";
            this.button_PI.Size = new System.Drawing.Size(286, 23);
            this.button_PI.TabIndex = 9;
            this.button_PI.Text = "ShowPrimeImplicant";
            this.button_PI.UseVisualStyleBackColor = true;
            this.button_PI.Click += new System.EventHandler(this.button_PI_Click);
            // 
            // ChooseFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 343);
            this.Controls.Add(this.button_PI);
            this.Controls.Add(this.button_UFT_meta_BDD);
            this.Controls.Add(this.button_UFT_BDD);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.button_FT_meta_BDD);
            this.Controls.Add(this.button_UFT);
            this.Controls.Add(this.button_FT_BDD);
            this.Controls.Add(this.button_FT);
            this.Controls.Add(this.filenameBox);
            this.Controls.Add(this.button_browse);
            this.Name = "ChooseFile";
            this.Text = "ChooseFaultTreeFile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_browse;
        private System.Windows.Forms.TextBox filenameBox;
        private System.Windows.Forms.Button button_FT;
        private System.Windows.Forms.Button button_FT_BDD;
        private System.Windows.Forms.Button button_UFT;
        private System.Windows.Forms.Button button_FT_meta_BDD;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_UFT_BDD;
        private System.Windows.Forms.Button button_UFT_meta_BDD;
        private System.Windows.Forms.Button button_PI;
    }
}