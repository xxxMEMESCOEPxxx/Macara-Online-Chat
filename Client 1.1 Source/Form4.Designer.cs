
namespace ChatClient
{
    partial class Form4
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("How To Use");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Room IP");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Username");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Previous Server");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("How to connect", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("How to disconnect");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("How to send a message");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Help", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode5,
            treeNode6,
            treeNode7});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(3, 13);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node1";
            treeNode1.Tag = "use";
            treeNode1.Text = "How To Use";
            treeNode2.Name = "Node4";
            treeNode2.Tag = "roomip";
            treeNode2.Text = "Room IP";
            treeNode3.Name = "Node5";
            treeNode3.Tag = "username";
            treeNode3.Text = "Username";
            treeNode4.Name = "Node6";
            treeNode4.Tag = "preserv";
            treeNode4.Text = "Previous Server";
            treeNode5.Name = "Node3";
            treeNode5.Tag = "conn";
            treeNode5.Text = "How to connect";
            treeNode6.Name = "Node0";
            treeNode6.Tag = "disscon";
            treeNode6.Text = "How to disconnect";
            treeNode7.Name = "Node1";
            treeNode7.Tag = "msgsend";
            treeNode7.Text = "How to send a message";
            treeNode8.Name = "Node0";
            treeNode8.Tag = "help";
            treeNode8.Text = "Help";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode8});
            this.treeView1.Size = new System.Drawing.Size(287, 420);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(306, 13);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(497, 420);
            this.listBox1.TabIndex = 1;
            // 
            // Form4
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.treeView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form4";
            this.Text = "Help";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ListBox listBox1;
    }
}