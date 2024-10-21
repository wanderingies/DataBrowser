namespace DataBrowser.Ctrls
{
    partial class RegionView
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonExport = new System.Windows.Forms.Button();
            this.comboBoxVersion = new System.Windows.Forms.ComboBox();
            this.checkedListBoxRegion = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxTrans = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ColumnTarget = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxInst = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSrcInst = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxLevelLmt = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(200, 412);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkedListBoxRegion);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(192, 386);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "region";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.checkedListBoxTrans);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 386);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "trans";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTarget,
            this.ColumnX,
            this.ColumnY,
            this.ColumnZ});
            this.dataGridView.Location = new System.Drawing.Point(202, 22);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(837, 291);
            this.dataGridView.TabIndex = 1;
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(964, 319);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(75, 23);
            this.buttonExport.TabIndex = 2;
            this.buttonExport.Text = "导出";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.ButtonExportClick);
            // 
            // comboBoxVersion
            // 
            this.comboBoxVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVersion.FormattingEnabled = true;
            this.comboBoxVersion.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBoxVersion.Location = new System.Drawing.Point(837, 320);
            this.comboBoxVersion.Name = "comboBoxVersion";
            this.comboBoxVersion.Size = new System.Drawing.Size(121, 20);
            this.comboBoxVersion.TabIndex = 3;
            // 
            // checkedListBoxRegion
            // 
            this.checkedListBoxRegion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxRegion.FormattingEnabled = true;
            this.checkedListBoxRegion.Location = new System.Drawing.Point(3, 3);
            this.checkedListBoxRegion.Name = "checkedListBoxRegion";
            this.checkedListBoxRegion.Size = new System.Drawing.Size(186, 380);
            this.checkedListBoxRegion.TabIndex = 0;
            this.checkedListBoxRegion.SelectedIndexChanged += new System.EventHandler(this.CheckedListBoxRegionSelectedIndexChanged);
            // 
            // checkedListBoxTrans
            // 
            this.checkedListBoxTrans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxTrans.FormattingEnabled = true;
            this.checkedListBoxTrans.Location = new System.Drawing.Point(3, 3);
            this.checkedListBoxTrans.Name = "checkedListBoxTrans";
            this.checkedListBoxTrans.Size = new System.Drawing.Size(186, 380);
            this.checkedListBoxTrans.TabIndex = 0;
            this.checkedListBoxTrans.SelectedIndexChanged += new System.EventHandler(this.CheckedListBoxTransSelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(205, 324);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "目标";
            // 
            // ColumnTarget
            // 
            this.ColumnTarget.HeaderText = "名称";
            this.ColumnTarget.Name = "ColumnTarget";
            // 
            // ColumnX
            // 
            this.ColumnX.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnX.HeaderText = "坐标(X)";
            this.ColumnX.Name = "ColumnX";
            // 
            // ColumnY
            // 
            this.ColumnY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnY.HeaderText = "坐标(Y)";
            this.ColumnY.Name = "ColumnY";
            // 
            // ColumnZ
            // 
            this.ColumnZ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnZ.HeaderText = "坐标(Z)";
            this.ColumnZ.Name = "ColumnZ";
            // 
            // textBoxInst
            // 
            this.textBoxInst.Location = new System.Drawing.Point(240, 320);
            this.textBoxInst.Name = "textBoxInst";
            this.textBoxInst.Size = new System.Drawing.Size(100, 21);
            this.textBoxInst.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(346, 324);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "当前";
            // 
            // textBoxSrcInst
            // 
            this.textBoxSrcInst.Location = new System.Drawing.Point(381, 320);
            this.textBoxSrcInst.Name = "textBoxSrcInst";
            this.textBoxSrcInst.Size = new System.Drawing.Size(100, 21);
            this.textBoxSrcInst.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(487, 324);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "等级限制";
            // 
            // textBoxLevelLmt
            // 
            this.textBoxLevelLmt.Location = new System.Drawing.Point(546, 320);
            this.textBoxLevelLmt.Name = "textBoxLevelLmt";
            this.textBoxLevelLmt.Size = new System.Drawing.Size(100, 21);
            this.textBoxLevelLmt.TabIndex = 9;
            // 
            // RegionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxLevelLmt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxSrcInst);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxInst);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxVersion);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.tabControl1);
            this.Name = "RegionView";
            this.Size = new System.Drawing.Size(1042, 412);
            this.Load += new System.EventHandler(this.FormLoad);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.ComboBox comboBoxVersion;
        private System.Windows.Forms.CheckedListBox checkedListBoxRegion;
        private System.Windows.Forms.CheckedListBox checkedListBoxTrans;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTarget;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnX;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnY;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnZ;
        private System.Windows.Forms.TextBox textBoxInst;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSrcInst;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxLevelLmt;
    }
}
