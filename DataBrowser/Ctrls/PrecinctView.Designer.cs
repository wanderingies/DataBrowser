namespace DataBrowser.Ctrls
{
    partial class PrecinctView
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
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxVersion = new System.Windows.Forms.TextBox();
            this.textBoxPKProtect = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxDomain = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPriority = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxCityPosY = new System.Windows.Forms.TextBox();
            this.textBoxCityPosZ = new System.Windows.Forms.TextBox();
            this.textBoxCityPosX = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxSrcInst = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDstInst = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxMusicInter = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxMusicLoop = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridViewPoints = new System.Windows.Forms.DataGridView();
            this.ColumnX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewMark = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewSound = new System.Windows.Forms.DataGridView();
            this.ColumnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSound = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonExport = new System.Windows.Forms.Button();
            this.comboBoxVersion = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSound)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkedListBox
            // 
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Location = new System.Drawing.Point(3, 3);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(120, 404);
            this.checkedListBox.TabIndex = 0;
            this.checkedListBox.SelectedIndexChanged += new System.EventHandler(this.ListBoxSelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBoxVersion);
            this.groupBox1.Controls.Add(this.textBoxPKProtect);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBoxDomain);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxPriority);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxId);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(129, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(910, 54);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "区域信息";
            // 
            // textBoxVersion
            // 
            this.textBoxVersion.Location = new System.Drawing.Point(50, 20);
            this.textBoxVersion.Name = "textBoxVersion";
            this.textBoxVersion.ReadOnly = true;
            this.textBoxVersion.Size = new System.Drawing.Size(100, 21);
            this.textBoxVersion.TabIndex = 10;
            // 
            // textBoxPKProtect
            // 
            this.textBoxPKProtect.Location = new System.Drawing.Point(638, 20);
            this.textBoxPKProtect.Name = "textBoxPKProtect";
            this.textBoxPKProtect.Size = new System.Drawing.Size(100, 21);
            this.textBoxPKProtect.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(591, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "PK保护";
            // 
            // textBoxDomain
            // 
            this.textBoxDomain.Location = new System.Drawing.Point(332, 20);
            this.textBoxDomain.Name = "textBoxDomain";
            this.textBoxDomain.Size = new System.Drawing.Size(100, 21);
            this.textBoxDomain.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(297, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "领域";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "版本";
            // 
            // textBoxPriority
            // 
            this.textBoxPriority.Location = new System.Drawing.Point(485, 20);
            this.textBoxPriority.Name = "textBoxPriority";
            this.textBoxPriority.Size = new System.Drawing.Size(100, 21);
            this.textBoxPriority.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(438, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "优先级";
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(191, 20);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(100, 21);
            this.textBoxId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "编号";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.textBoxCityPosY);
            this.groupBox2.Controls.Add(this.textBoxCityPosZ);
            this.groupBox2.Controls.Add(this.textBoxCityPosX);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBoxSrcInst);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBoxDstInst);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(129, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(910, 54);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "传送信息";
            // 
            // textBoxCityPosY
            // 
            this.textBoxCityPosY.Location = new System.Drawing.Point(544, 20);
            this.textBoxCityPosY.Name = "textBoxCityPosY";
            this.textBoxCityPosY.Size = new System.Drawing.Size(100, 21);
            this.textBoxCityPosY.TabIndex = 11;
            // 
            // textBoxCityPosZ
            // 
            this.textBoxCityPosZ.Location = new System.Drawing.Point(438, 20);
            this.textBoxCityPosZ.Name = "textBoxCityPosZ";
            this.textBoxCityPosZ.Size = new System.Drawing.Size(100, 21);
            this.textBoxCityPosZ.TabIndex = 10;
            // 
            // textBoxCityPosX
            // 
            this.textBoxCityPosX.Location = new System.Drawing.Point(332, 20);
            this.textBoxCityPosX.Name = "textBoxCityPosX";
            this.textBoxCityPosX.Size = new System.Drawing.Size(100, 21);
            this.textBoxCityPosX.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(297, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "坐标";
            // 
            // textBoxSrcInst
            // 
            this.textBoxSrcInst.Location = new System.Drawing.Point(191, 20);
            this.textBoxSrcInst.Name = "textBoxSrcInst";
            this.textBoxSrcInst.Size = new System.Drawing.Size(100, 21);
            this.textBoxSrcInst.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(156, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "当前";
            // 
            // textBoxDstInst
            // 
            this.textBoxDstInst.Location = new System.Drawing.Point(50, 20);
            this.textBoxDstInst.Name = "textBoxDstInst";
            this.textBoxDstInst.Size = new System.Drawing.Size(100, 21);
            this.textBoxDstInst.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "目标";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxMusicInter);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.comboBoxMusicLoop);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(129, 123);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(308, 54);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "音乐信息";
            // 
            // textBoxMusicInter
            // 
            this.textBoxMusicInter.Location = new System.Drawing.Point(191, 20);
            this.textBoxMusicInter.Name = "textBoxMusicInter";
            this.textBoxMusicInter.Size = new System.Drawing.Size(100, 21);
            this.textBoxMusicInter.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(156, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 8;
            this.label10.Text = "时间";
            // 
            // comboBoxMusicLoop
            // 
            this.comboBoxMusicLoop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMusicLoop.FormattingEnabled = true;
            this.comboBoxMusicLoop.Items.AddRange(new object[] {
            "NONE",
            "WHOLE",
            "SKIPFIRST"});
            this.comboBoxMusicLoop.Location = new System.Drawing.Point(50, 20);
            this.comboBoxMusicLoop.Name = "comboBoxMusicLoop";
            this.comboBoxMusicLoop.Size = new System.Drawing.Size(100, 20);
            this.comboBoxMusicLoop.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 6;
            this.label9.Text = "循环";
            // 
            // dataGridViewPoints
            // 
            this.dataGridViewPoints.AllowUserToAddRows = false;
            this.dataGridViewPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPoints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnX,
            this.ColumnY,
            this.ColumnZ});
            this.dataGridViewPoints.Location = new System.Drawing.Point(129, 183);
            this.dataGridViewPoints.MultiSelect = false;
            this.dataGridViewPoints.Name = "dataGridViewPoints";
            this.dataGridViewPoints.RowHeadersVisible = false;
            this.dataGridViewPoints.RowTemplate.Height = 23;
            this.dataGridViewPoints.Size = new System.Drawing.Size(263, 224);
            this.dataGridViewPoints.TabIndex = 4;
            // 
            // ColumnX
            // 
            this.ColumnX.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnX.HeaderText = "X";
            this.ColumnX.Name = "ColumnX";
            // 
            // ColumnY
            // 
            this.ColumnY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnY.HeaderText = "Y";
            this.ColumnY.Name = "ColumnY";
            // 
            // ColumnZ
            // 
            this.ColumnZ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnZ.HeaderText = "Z";
            this.ColumnZ.Name = "ColumnZ";
            // 
            // dataGridViewMark
            // 
            this.dataGridViewMark.AllowUserToAddRows = false;
            this.dataGridViewMark.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMark.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn2});
            this.dataGridViewMark.Location = new System.Drawing.Point(398, 183);
            this.dataGridViewMark.MultiSelect = false;
            this.dataGridViewMark.Name = "dataGridViewMark";
            this.dataGridViewMark.RowHeadersVisible = false;
            this.dataGridViewMark.RowTemplate.Height = 23;
            this.dataGridViewMark.Size = new System.Drawing.Size(641, 109);
            this.dataGridViewMark.TabIndex = 5;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "名称";
            this.ColumnName.Name = "ColumnName";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "坐标(X)";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "坐标(Y)";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "坐标(Z)";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewSound
            // 
            this.dataGridViewSound.AllowUserToAddRows = false;
            this.dataGridViewSound.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSound.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnType,
            this.ColumnSound});
            this.dataGridViewSound.Location = new System.Drawing.Point(398, 298);
            this.dataGridViewSound.Name = "dataGridViewSound";
            this.dataGridViewSound.RowHeadersVisible = false;
            this.dataGridViewSound.RowTemplate.Height = 23;
            this.dataGridViewSound.Size = new System.Drawing.Size(641, 109);
            this.dataGridViewSound.TabIndex = 6;
            // 
            // ColumnType
            // 
            this.ColumnType.HeaderText = "类型";
            this.ColumnType.Name = "ColumnType";
            // 
            // ColumnSound
            // 
            this.ColumnSound.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnSound.HeaderText = "音乐";
            this.ColumnSound.Name = "ColumnSound";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.buttonExport);
            this.groupBox4.Controls.Add(this.comboBoxVersion);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Location = new System.Drawing.Point(443, 123);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(596, 54);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "导出";
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(515, 19);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(75, 23);
            this.buttonExport.TabIndex = 8;
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
            "5",
            "6",
            "7"});
            this.comboBoxVersion.Location = new System.Drawing.Point(51, 20);
            this.comboBoxVersion.Name = "comboBoxVersion";
            this.comboBoxVersion.Size = new System.Drawing.Size(100, 20);
            this.comboBoxVersion.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 6;
            this.label11.Text = "版本";
            // 
            // PrecinctView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.dataGridViewSound);
            this.Controls.Add(this.dataGridViewMark);
            this.Controls.Add(this.dataGridViewPoints);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkedListBox);
            this.Name = "PrecinctView";
            this.Size = new System.Drawing.Size(1042, 412);
            this.Load += new System.EventHandler(this.FormLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSound)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPriority;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxSrcInst;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDstInst;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxCityPosX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxCityPosY;
        private System.Windows.Forms.TextBox textBoxCityPosZ;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxDomain;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxPKProtect;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBoxMusicLoop;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxMusicInter;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dataGridViewPoints;
        private System.Windows.Forms.DataGridView dataGridViewMark;
        private System.Windows.Forms.DataGridView dataGridViewSound;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSound;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnX;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnY;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.ComboBox comboBoxVersion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxVersion;
    }
}
