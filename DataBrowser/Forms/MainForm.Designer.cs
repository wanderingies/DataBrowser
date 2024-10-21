namespace DataBrowser.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("g1", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("g2", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("1");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("2");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("3");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("4");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("5");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("6");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("7");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("8");
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("9");
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.treeViewFilelist = new System.Windows.Forms.TreeView();
            this.listView = new System.Windows.Forms.ListView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxMaplist = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxBlock = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxCondition = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxShowmodel = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.treeViewFilelist, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.listView, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.textBox1, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(834, 450);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // treeViewFilelist
            // 
            this.treeViewFilelist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewFilelist.Location = new System.Drawing.Point(3, 3);
            this.treeViewFilelist.Name = "treeViewFilelist";
            this.treeViewFilelist.Size = new System.Drawing.Size(194, 412);
            this.treeViewFilelist.TabIndex = 0;
            // 
            // listView
            // 
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.GridLines = true;
            listViewGroup1.Header = "g1";
            listViewGroup1.Name = "listViewGroup1";
            listViewGroup2.Header = "g2";
            listViewGroup2.Name = "listViewGroup2";
            this.listView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.listView.HideSelection = false;
            listViewItem3.Group = listViewGroup1;
            listViewItem4.Group = listViewGroup1;
            listViewItem5.Group = listViewGroup2;
            listViewItem6.Group = listViewGroup2;
            listViewItem7.Group = listViewGroup2;
            listViewItem8.Group = listViewGroup2;
            listViewItem9.Group = listViewGroup2;
            this.listView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9});
            this.listView.Location = new System.Drawing.Point(203, 3);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(628, 412);
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 424);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(194, 21);
            this.textBox1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.comboBoxMaplist);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.comboBoxBlock);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.comboBoxCondition);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.comboBoxShowmodel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(203, 421);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(628, 26);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 7, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "列表";
            // 
            // comboBoxMaplist
            // 
            this.comboBoxMaplist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMaplist.FormattingEnabled = true;
            this.comboBoxMaplist.Location = new System.Drawing.Point(31, 3);
            this.comboBoxMaplist.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.comboBoxMaplist.Name = "comboBoxMaplist";
            this.comboBoxMaplist.Size = new System.Drawing.Size(121, 20);
            this.comboBoxMaplist.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 7, 0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "地块";
            // 
            // comboBoxBlock
            // 
            this.comboBoxBlock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBlock.FormattingEnabled = true;
            this.comboBoxBlock.Location = new System.Drawing.Point(183, 3);
            this.comboBoxBlock.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.comboBoxBlock.Name = "comboBoxBlock";
            this.comboBoxBlock.Size = new System.Drawing.Size(121, 20);
            this.comboBoxBlock.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(306, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 7, 0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "筛选";
            // 
            // comboBoxCondition
            // 
            this.comboBoxCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCondition.FormattingEnabled = true;
            this.comboBoxCondition.Location = new System.Drawing.Point(335, 3);
            this.comboBoxCondition.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.comboBoxCondition.Name = "comboBoxCondition";
            this.comboBoxCondition.Size = new System.Drawing.Size(121, 20);
            this.comboBoxCondition.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(458, 7);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 7, 0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "显示";
            // 
            // comboBoxShowmodel
            // 
            this.comboBoxShowmodel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShowmodel.FormattingEnabled = true;
            this.comboBoxShowmodel.Location = new System.Drawing.Point(487, 3);
            this.comboBoxShowmodel.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.comboBoxShowmodel.Name = "comboBoxShowmodel";
            this.comboBoxShowmodel.Size = new System.Drawing.Size(121, 20);
            this.comboBoxShowmodel.TabIndex = 15;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 450);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataBrowser";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.TreeView treeViewFilelist;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxMaplist;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxBlock;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxCondition;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxShowmodel;
    }
}

