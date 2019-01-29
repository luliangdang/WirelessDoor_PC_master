namespace WirelessDoor_PC_master
{
    partial class ReservationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReservationForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvReservation = new System.Windows.Forms.DataGridView();
            this.roomName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.msgState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jieguo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.beginTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btSet = new System.Windows.Forms.Button();
            this.rtReason = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbRoomName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtLogo = new System.Windows.Forms.RichTextBox();
            this.dtBeginTime = new System.Windows.Forms.DateTimePicker();
            this.dtEndTime = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservation)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(587, 371);
            this.splitContainer1.SplitterDistance = 142;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvReservation);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(581, 136);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "预约信息";
            // 
            // dgvReservation
            // 
            this.dgvReservation.AllowUserToAddRows = false;
            this.dgvReservation.AllowUserToDeleteRows = false;
            this.dgvReservation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReservation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.roomName,
            this.msgState,
            this.jieguo,
            this.beginTime,
            this.endTime,
            this.reason});
            this.dgvReservation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReservation.Location = new System.Drawing.Point(3, 17);
            this.dgvReservation.Name = "dgvReservation";
            this.dgvReservation.ReadOnly = true;
            this.dgvReservation.RowTemplate.Height = 23;
            this.dgvReservation.Size = new System.Drawing.Size(575, 116);
            this.dgvReservation.TabIndex = 0;
            this.dgvReservation.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReservation_CellDoubleClick);
            // 
            // roomName
            // 
            this.roomName.HeaderText = "会议室名称";
            this.roomName.Name = "roomName";
            this.roomName.ReadOnly = true;
            // 
            // msgState
            // 
            this.msgState.HeaderText = "处理状态";
            this.msgState.Name = "msgState";
            this.msgState.ReadOnly = true;
            // 
            // jieguo
            // 
            this.jieguo.HeaderText = "申请结果";
            this.jieguo.Name = "jieguo";
            this.jieguo.ReadOnly = true;
            // 
            // beginTime
            // 
            this.beginTime.HeaderText = "开始时间";
            this.beginTime.Name = "beginTime";
            this.beginTime.ReadOnly = true;
            // 
            // endTime
            // 
            this.endTime.HeaderText = "结束时间";
            this.endTime.Name = "endTime";
            this.endTime.ReadOnly = true;
            // 
            // reason
            // 
            this.reason.HeaderText = "申请理由";
            this.reason.Name = "reason";
            this.reason.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtEndTime);
            this.groupBox3.Controls.Add(this.dtBeginTime);
            this.groupBox3.Controls.Add(this.btSet);
            this.groupBox3.Controls.Add(this.rtReason);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.tbRoomName);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(6, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(369, 219);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "修改信息";
            // 
            // btSet
            // 
            this.btSet.Location = new System.Drawing.Point(266, 143);
            this.btSet.Name = "btSet";
            this.btSet.Size = new System.Drawing.Size(75, 55);
            this.btSet.TabIndex = 9;
            this.btSet.Text = "修改";
            this.btSet.UseVisualStyleBackColor = true;
            this.btSet.Click += new System.EventHandler(this.btSet_Click);
            // 
            // rtReason
            // 
            this.rtReason.Location = new System.Drawing.Point(79, 128);
            this.rtReason.Name = "rtReason";
            this.rtReason.Size = new System.Drawing.Size(159, 82);
            this.rtReason.TabIndex = 8;
            this.rtReason.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "申请理由";
            // 
            // tbRoomName
            // 
            this.tbRoomName.Location = new System.Drawing.Point(78, 29);
            this.tbRoomName.Name = "tbRoomName";
            this.tbRoomName.ReadOnly = true;
            this.tbRoomName.Size = new System.Drawing.Size(154, 21);
            this.tbRoomName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "结束时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "开始时间";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "会议室名称";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtLogo);
            this.groupBox2.Location = new System.Drawing.Point(381, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 219);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "日志信息";
            // 
            // rtLogo
            // 
            this.rtLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtLogo.Location = new System.Drawing.Point(3, 17);
            this.rtLogo.Name = "rtLogo";
            this.rtLogo.ReadOnly = true;
            this.rtLogo.Size = new System.Drawing.Size(194, 199);
            this.rtLogo.TabIndex = 0;
            this.rtLogo.Text = "";
            // 
            // dtBeginTime
            // 
            this.dtBeginTime.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtBeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBeginTime.Location = new System.Drawing.Point(78, 63);
            this.dtBeginTime.MinDate = new System.DateTime(2019, 1, 29, 0, 0, 0, 0);
            this.dtBeginTime.Name = "dtBeginTime";
            this.dtBeginTime.Size = new System.Drawing.Size(154, 21);
            this.dtBeginTime.TabIndex = 10;
            this.dtBeginTime.Value = new System.DateTime(2019, 1, 29, 0, 0, 0, 0);
            // 
            // dtEndTime
            // 
            this.dtEndTime.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEndTime.Location = new System.Drawing.Point(78, 96);
            this.dtEndTime.MinDate = new System.DateTime(2019, 1, 29, 0, 0, 0, 0);
            this.dtEndTime.Name = "dtEndTime";
            this.dtEndTime.Size = new System.Drawing.Size(154, 21);
            this.dtEndTime.TabIndex = 11;
            this.dtEndTime.Value = new System.DateTime(2019, 1, 29, 0, 0, 0, 0);
            // 
            // ReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 371);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReservationForm";
            this.Text = "个人预约信息";
            this.Load += new System.EventHandler(this.ReservationForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservation)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvReservation;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rtLogo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbRoomName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btSet;
        private System.Windows.Forms.RichTextBox rtReason;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn roomName;
        private System.Windows.Forms.DataGridViewTextBoxColumn msgState;
        private System.Windows.Forms.DataGridViewTextBoxColumn jieguo;
        private System.Windows.Forms.DataGridViewTextBoxColumn beginTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn endTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn reason;
        private System.Windows.Forms.DateTimePicker dtEndTime;
        private System.Windows.Forms.DateTimePicker dtBeginTime;
    }
}