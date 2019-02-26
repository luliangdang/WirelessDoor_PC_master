namespace WirelessDoor_PC_master
{
    partial class LogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogForm));
            this.lable1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txBox_username = new System.Windows.Forms.TextBox();
            this.txBox_passwd = new System.Windows.Forms.TextBox();
            this.bt_login = new System.Windows.Forms.Button();
            this.bt_regist = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            this.lable1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lable1.Location = new System.Drawing.Point(93, 101);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(53, 12);
            this.lable1.TabIndex = 0;
            this.lable1.Text = "登录账号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(107, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码";
            // 
            // txBox_username
            // 
            this.txBox_username.Location = new System.Drawing.Point(152, 98);
            this.txBox_username.Name = "txBox_username";
            this.txBox_username.Size = new System.Drawing.Size(174, 21);
            this.txBox_username.TabIndex = 2;
            this.txBox_username.WordWrap = false;
            this.txBox_username.TextChanged += new System.EventHandler(this.txBox_username_TextChanged);
            // 
            // txBox_passwd
            // 
            this.txBox_passwd.Location = new System.Drawing.Point(152, 135);
            this.txBox_passwd.Name = "txBox_passwd";
            this.txBox_passwd.Size = new System.Drawing.Size(174, 21);
            this.txBox_passwd.TabIndex = 3;
            this.txBox_passwd.UseSystemPasswordChar = true;
            // 
            // bt_login
            // 
            this.bt_login.Location = new System.Drawing.Point(152, 178);
            this.bt_login.Name = "bt_login";
            this.bt_login.Size = new System.Drawing.Size(75, 23);
            this.bt_login.TabIndex = 6;
            this.bt_login.Text = "登录";
            this.bt_login.UseVisualStyleBackColor = true;
            this.bt_login.Click += new System.EventHandler(this.bt_login_Click);
            // 
            // bt_regist
            // 
            this.bt_regist.Location = new System.Drawing.Point(251, 178);
            this.bt_regist.Name = "bt_regist";
            this.bt_regist.Size = new System.Drawing.Size(75, 23);
            this.bt_regist.TabIndex = 7;
            this.bt_regist.Text = "注册";
            this.bt_regist.UseVisualStyleBackColor = true;
            this.bt_regist.Click += new System.EventHandler(this.bt_regist_Click);
            // 
            // LogForm
            // 
            this.AcceptButton = this.bt_login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImage = global::WirelessDoor_PC_master.Properties.Resources.login;
            this.ClientSize = new System.Drawing.Size(463, 299);
            this.Controls.Add(this.bt_regist);
            this.Controls.Add(this.bt_login);
            this.Controls.Add(this.txBox_passwd);
            this.Controls.Add(this.txBox_username);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lable1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LogForm";
            this.Text = "智能会议室管理预约系统";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lable1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txBox_username;
        private System.Windows.Forms.TextBox txBox_passwd;
        private System.Windows.Forms.Button bt_login;
        private System.Windows.Forms.Button bt_regist;
    }
}

