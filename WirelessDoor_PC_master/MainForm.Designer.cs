namespace WirelessDoor_PC_master
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dgvRoom = new System.Windows.Forms.DataGridView();
            this.roomName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roomState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.netState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.预约ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询预约记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.个人信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.预约信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rTbox_reason = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_reserv = new System.Windows.Forms.Button();
            this.textBox_reservTel = new System.Windows.Forms.TextBox();
            this.lbreseverTel = new System.Windows.Forms.Label();
            this.textBox_reservname = new System.Windows.Forms.TextBox();
            this.lbResever = new System.Windows.Forms.Label();
            this.endTimePicker = new System.Windows.Forms.DateTimePicker();
            this.lboverTime = new System.Windows.Forms.Label();
            this.beginTimePicker = new System.Windows.Forms.DateTimePicker();
            this.cbRoomName = new System.Windows.Forms.ComboBox();
            this.lbbeginTime = new System.Windows.Forms.Label();
            this.lbRoomName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoom)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRoom
            // 
            this.dgvRoom.AllowUserToAddRows = false;
            this.dgvRoom.AllowUserToDeleteRows = false;
            this.dgvRoom.AllowUserToOrderColumns = true;
            this.dgvRoom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.roomName,
            this.roomState,
            this.netState});
            this.dgvRoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRoom.Location = new System.Drawing.Point(0, 0);
            this.dgvRoom.Name = "dgvRoom";
            this.dgvRoom.ReadOnly = true;
            this.dgvRoom.RowTemplate.Height = 23;
            this.dgvRoom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoom.Size = new System.Drawing.Size(493, 202);
            this.dgvRoom.TabIndex = 0;
            // 
            // roomName
            // 
            this.roomName.HeaderText = "会议室名称";
            this.roomName.Name = "roomName";
            this.roomName.ReadOnly = true;
            // 
            // roomState
            // 
            this.roomState.HeaderText = "状态";
            this.roomState.Name = "roomState";
            this.roomState.ReadOnly = true;
            // 
            // netState
            // 
            this.netState.HeaderText = "网络状态";
            this.netState.Name = "netState";
            this.netState.ReadOnly = true;
            // 
            // 预约ToolStripMenuItem
            // 
            this.预约ToolStripMenuItem.Name = "预约ToolStripMenuItem";
            this.预约ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.预约ToolStripMenuItem.Text = "预约";
            this.预约ToolStripMenuItem.Click += new System.EventHandler(this.预约ToolStripMenuItem_Click);
            // 
            // 查询预约记录ToolStripMenuItem
            // 
            this.查询预约记录ToolStripMenuItem.Name = "查询预约记录ToolStripMenuItem";
            this.查询预约记录ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.查询预约记录ToolStripMenuItem.Text = "查询预约记录";
            this.查询预约记录ToolStripMenuItem.Click += new System.EventHandler(this.查询预约记录ToolStripMenuItem_Click);
            // 
            // 修改信息ToolStripMenuItem
            // 
            this.修改信息ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.个人信息ToolStripMenuItem,
            this.预约信息ToolStripMenuItem});
            this.修改信息ToolStripMenuItem.Name = "修改信息ToolStripMenuItem";
            this.修改信息ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.修改信息ToolStripMenuItem.Text = "修改信息";
            // 
            // 个人信息ToolStripMenuItem
            // 
            this.个人信息ToolStripMenuItem.Name = "个人信息ToolStripMenuItem";
            this.个人信息ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.个人信息ToolStripMenuItem.Text = "个人信息";
            this.个人信息ToolStripMenuItem.Click += new System.EventHandler(this.个人信息ToolStripMenuItem_Click);
            // 
            // 预约信息ToolStripMenuItem
            // 
            this.预约信息ToolStripMenuItem.Name = "预约信息ToolStripMenuItem";
            this.预约信息ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.预约信息ToolStripMenuItem.Text = "预约信息";
            this.预约信息ToolStripMenuItem.Click += new System.EventHandler(this.预约信息ToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.预约ToolStripMenuItem,
            this.查询预约记录ToolStripMenuItem,
            this.修改信息ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(493, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvRoom);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rTbox_reason);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.bt_reserv);
            this.splitContainer1.Panel2.Controls.Add(this.textBox_reservTel);
            this.splitContainer1.Panel2.Controls.Add(this.lbreseverTel);
            this.splitContainer1.Panel2.Controls.Add(this.textBox_reservname);
            this.splitContainer1.Panel2.Controls.Add(this.lbResever);
            this.splitContainer1.Panel2.Controls.Add(this.endTimePicker);
            this.splitContainer1.Panel2.Controls.Add(this.lboverTime);
            this.splitContainer1.Panel2.Controls.Add(this.beginTimePicker);
            this.splitContainer1.Panel2.Controls.Add(this.cbRoomName);
            this.splitContainer1.Panel2.Controls.Add(this.lbbeginTime);
            this.splitContainer1.Panel2.Controls.Add(this.lbRoomName);
            this.splitContainer1.Size = new System.Drawing.Size(493, 431);
            this.splitContainer1.SplitterDistance = 202;
            this.splitContainer1.TabIndex = 2;
            // 
            // rTbox_reason
            // 
            this.rTbox_reason.Location = new System.Drawing.Point(16, 146);
            this.rTbox_reason.Name = "rTbox_reason";
            this.rTbox_reason.Size = new System.Drawing.Size(152, 67);
            this.rTbox_reason.TabIndex = 10;
            this.rTbox_reason.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "申请理由";
            // 
            // bt_reserv
            // 
            this.bt_reserv.Location = new System.Drawing.Point(396, 62);
            this.bt_reserv.Name = "bt_reserv";
            this.bt_reserv.Size = new System.Drawing.Size(75, 65);
            this.bt_reserv.TabIndex = 12;
            this.bt_reserv.Text = "预约";
            this.bt_reserv.UseVisualStyleBackColor = true;
            this.bt_reserv.Click += new System.EventHandler(this.bt_reserv_Click);
            // 
            // textBox_reservTel
            // 
            this.textBox_reservTel.Location = new System.Drawing.Point(215, 106);
            this.textBox_reservTel.Name = "textBox_reservTel";
            this.textBox_reservTel.ReadOnly = true;
            this.textBox_reservTel.Size = new System.Drawing.Size(154, 21);
            this.textBox_reservTel.TabIndex = 9;
            // 
            // lbreseverTel
            // 
            this.lbreseverTel.AutoSize = true;
            this.lbreseverTel.Location = new System.Drawing.Point(213, 90);
            this.lbreseverTel.Name = "lbreseverTel";
            this.lbreseverTel.Size = new System.Drawing.Size(29, 12);
            this.lbreseverTel.TabIndex = 8;
            this.lbreseverTel.Text = "电话";
            // 
            // textBox_reservname
            // 
            this.textBox_reservname.Location = new System.Drawing.Point(16, 106);
            this.textBox_reservname.Name = "textBox_reservname";
            this.textBox_reservname.ReadOnly = true;
            this.textBox_reservname.Size = new System.Drawing.Size(152, 21);
            this.textBox_reservname.TabIndex = 7;
            // 
            // lbResever
            // 
            this.lbResever.AutoSize = true;
            this.lbResever.Location = new System.Drawing.Point(14, 90);
            this.lbResever.Name = "lbResever";
            this.lbResever.Size = new System.Drawing.Size(41, 12);
            this.lbResever.TabIndex = 6;
            this.lbResever.Text = "预约人";
            // 
            // endTimePicker
            // 
            this.endTimePicker.CustomFormat = "yyyy-MM-dd HH:mm";
            this.endTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endTimePicker.Location = new System.Drawing.Point(215, 62);
            this.endTimePicker.Name = "endTimePicker";
            this.endTimePicker.Size = new System.Drawing.Size(154, 21);
            this.endTimePicker.TabIndex = 5;
            // 
            // lboverTime
            // 
            this.lboverTime.AutoSize = true;
            this.lboverTime.Location = new System.Drawing.Point(213, 43);
            this.lboverTime.Name = "lboverTime";
            this.lboverTime.Size = new System.Drawing.Size(77, 12);
            this.lboverTime.TabIndex = 4;
            this.lboverTime.Text = "预约结束时间";
            // 
            // beginTimePicker
            // 
            this.beginTimePicker.CustomFormat = "yyyy-MM-dd HH:mm";
            this.beginTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.beginTimePicker.Location = new System.Drawing.Point(14, 62);
            this.beginTimePicker.MinDate = new System.DateTime(2019, 1, 29, 0, 0, 0, 0);
            this.beginTimePicker.Name = "beginTimePicker";
            this.beginTimePicker.Size = new System.Drawing.Size(154, 21);
            this.beginTimePicker.TabIndex = 3;
            this.beginTimePicker.Value = new System.DateTime(2019, 1, 29, 0, 0, 0, 0);
            this.beginTimePicker.MouseCaptureChanged += new System.EventHandler(this.beginTime_MouseCaptureChanged);
            // 
            // cbRoomName
            // 
            this.cbRoomName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRoomName.FormattingEnabled = true;
            this.cbRoomName.Location = new System.Drawing.Point(59, 16);
            this.cbRoomName.Name = "cbRoomName";
            this.cbRoomName.Size = new System.Drawing.Size(121, 20);
            this.cbRoomName.TabIndex = 2;
            // 
            // lbbeginTime
            // 
            this.lbbeginTime.AutoSize = true;
            this.lbbeginTime.Location = new System.Drawing.Point(12, 43);
            this.lbbeginTime.Name = "lbbeginTime";
            this.lbbeginTime.Size = new System.Drawing.Size(77, 12);
            this.lbbeginTime.TabIndex = 1;
            this.lbbeginTime.Text = "预约开始时间";
            // 
            // lbRoomName
            // 
            this.lbRoomName.AutoSize = true;
            this.lbRoomName.Location = new System.Drawing.Point(12, 19);
            this.lbRoomName.Name = "lbRoomName";
            this.lbRoomName.Size = new System.Drawing.Size(41, 12);
            this.lbRoomName.TabIndex = 0;
            this.lbRoomName.Text = "会议室";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(493, 456);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "智能会议室管理预约系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoom)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRoom;
        private System.Windows.Forms.ToolStripMenuItem 预约ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询预约记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 个人信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 预约信息ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox cbRoomName;
        private System.Windows.Forms.Label lbbeginTime;
        private System.Windows.Forms.Label lbRoomName;
        private System.Windows.Forms.DateTimePicker beginTimePicker;
        private System.Windows.Forms.DateTimePicker endTimePicker;
        private System.Windows.Forms.Label lboverTime;
        private System.Windows.Forms.Button bt_reserv;
        private System.Windows.Forms.TextBox textBox_reservTel;
        private System.Windows.Forms.Label lbreseverTel;
        private System.Windows.Forms.RichTextBox rTbox_reason;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_reservname;
        private System.Windows.Forms.Label lbResever;
        private System.Windows.Forms.DataGridViewTextBoxColumn roomName;
        private System.Windows.Forms.DataGridViewTextBoxColumn roomState;
        private System.Windows.Forms.DataGridViewTextBoxColumn netState;
    }
}