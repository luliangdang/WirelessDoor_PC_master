namespace WirelessDoor_PC_master
{
    partial class RegistForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tbPhotoPath = new System.Windows.Forms.TextBox();
            this.btCamera = new System.Windows.Forms.Button();
            this.cbCamera = new System.Windows.Forms.ComboBox();
            this.btShoot = new System.Windows.Forms.Button();
            this.btGetPhoto = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.vspUserPhoto = new AForge.Controls.VideoSourcePlayer();
            this.pbUserPhoto = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btRegist = new System.Windows.Forms.Button();
            this.dtBirthday = new System.Windows.Forms.DateTimePicker();
            this.tbMail = new System.Windows.Forms.TextBox();
            this.tbQQ = new System.Windows.Forms.TextBox();
            this.tbTel = new System.Windows.Forms.TextBox();
            this.rbWoman = new System.Windows.Forms.RadioButton();
            this.rbMan = new System.Windows.Forms.RadioButton();
            this.tbCheck = new System.Windows.Forms.TextBox();
            this.tbPasswd = new System.Windows.Forms.TextBox();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserPhoto)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 346);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbPhotoPath);
            this.splitContainer1.Panel2.Controls.Add(this.btCamera);
            this.splitContainer1.Panel2.Controls.Add(this.cbCamera);
            this.splitContainer1.Panel2.Controls.Add(this.btShoot);
            this.splitContainer1.Panel2.Controls.Add(this.btGetPhoto);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(419, 346);
            this.splitContainer1.SplitterDistance = 274;
            this.splitContainer1.TabIndex = 0;
            // 
            // tbPhotoPath
            // 
            this.tbPhotoPath.Location = new System.Drawing.Point(22, 317);
            this.tbPhotoPath.Name = "tbPhotoPath";
            this.tbPhotoPath.Size = new System.Drawing.Size(100, 21);
            this.tbPhotoPath.TabIndex = 7;
            // 
            // btCamera
            // 
            this.btCamera.Location = new System.Drawing.Point(31, 229);
            this.btCamera.Name = "btCamera";
            this.btCamera.Size = new System.Drawing.Size(75, 23);
            this.btCamera.TabIndex = 6;
            this.btCamera.Text = "打开摄像头";
            this.btCamera.UseVisualStyleBackColor = true;
            this.btCamera.Click += new System.EventHandler(this.btCamera_Click);
            // 
            // cbCamera
            // 
            this.cbCamera.FormattingEnabled = true;
            this.cbCamera.Location = new System.Drawing.Point(11, 203);
            this.cbCamera.Name = "cbCamera";
            this.cbCamera.Size = new System.Drawing.Size(121, 20);
            this.cbCamera.TabIndex = 5;
            // 
            // btShoot
            // 
            this.btShoot.Location = new System.Drawing.Point(31, 258);
            this.btShoot.Name = "btShoot";
            this.btShoot.Size = new System.Drawing.Size(75, 23);
            this.btShoot.TabIndex = 4;
            this.btShoot.Text = "拍照";
            this.btShoot.UseVisualStyleBackColor = true;
            this.btShoot.Click += new System.EventHandler(this.btShoot_Click);
            // 
            // btGetPhoto
            // 
            this.btGetPhoto.Location = new System.Drawing.Point(31, 287);
            this.btGetPhoto.Name = "btGetPhoto";
            this.btGetPhoto.Size = new System.Drawing.Size(75, 23);
            this.btGetPhoto.TabIndex = 3;
            this.btGetPhoto.Text = "添加照片";
            this.btGetPhoto.UseVisualStyleBackColor = true;
            this.btGetPhoto.Click += new System.EventHandler(this.btGetPhoto_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.vspUserPhoto);
            this.groupBox1.Controls.Add(this.pbUserPhoto);
            this.groupBox1.Location = new System.Drawing.Point(5, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(133, 193);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "照片";
            // 
            // vspUserPhoto
            // 
            this.vspUserPhoto.Location = new System.Drawing.Point(6, 22);
            this.vspUserPhoto.Name = "vspUserPhoto";
            this.vspUserPhoto.Size = new System.Drawing.Size(120, 160);
            this.vspUserPhoto.TabIndex = 1;
            this.vspUserPhoto.Text = "videoSourcePlayer1";
            this.vspUserPhoto.VideoSource = null;
            // 
            // pbUserPhoto
            // 
            this.pbUserPhoto.Location = new System.Drawing.Point(6, 21);
            this.pbUserPhoto.Name = "pbUserPhoto";
            this.pbUserPhoto.Size = new System.Drawing.Size(120, 160);
            this.pbUserPhoto.TabIndex = 0;
            this.pbUserPhoto.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btRegist);
            this.groupBox2.Controls.Add(this.dtBirthday);
            this.groupBox2.Controls.Add(this.tbMail);
            this.groupBox2.Controls.Add(this.tbQQ);
            this.groupBox2.Controls.Add(this.tbTel);
            this.groupBox2.Controls.Add(this.rbWoman);
            this.groupBox2.Controls.Add(this.rbMan);
            this.groupBox2.Controls.Add(this.tbCheck);
            this.groupBox2.Controls.Add(this.tbPasswd);
            this.groupBox2.Controls.Add(this.tbUserName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(267, 339);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "个人信息";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(211, 191);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(11, 12);
            this.label14.TabIndex = 50;
            this.label14.Text = "*";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(211, 137);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(11, 12);
            this.label13.TabIndex = 49;
            this.label13.Text = "*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(211, 87);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 12);
            this.label12.TabIndex = 48;
            this.label12.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(211, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 12);
            this.label11.TabIndex = 47;
            this.label11.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(211, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 46;
            this.label10.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(102, 241);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 12);
            this.label9.TabIndex = 45;
            this.label9.Text = "带*为必填项目";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(42, 222);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 44;
            this.label8.Text = "生日：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 43;
            this.label7.Text = "邮箱：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(54, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 42;
            this.label6.Text = "QQ：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 41;
            this.label5.Text = "电话：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 40;
            this.label4.Text = "性别：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 39;
            this.label3.Text = "确认密码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 38;
            this.label2.Text = "输入密码：";
            // 
            // btRegist
            // 
            this.btRegist.Location = new System.Drawing.Point(104, 276);
            this.btRegist.Name = "btRegist";
            this.btRegist.Size = new System.Drawing.Size(75, 23);
            this.btRegist.TabIndex = 37;
            this.btRegist.Text = "注册";
            this.btRegist.UseVisualStyleBackColor = true;
            // 
            // dtBirthday
            // 
            this.dtBirthday.Location = new System.Drawing.Point(89, 216);
            this.dtBirthday.Name = "dtBirthday";
            this.dtBirthday.Size = new System.Drawing.Size(116, 21);
            this.dtBirthday.TabIndex = 36;
            this.dtBirthday.Value = new System.DateTime(2019, 1, 28, 0, 0, 0, 0);
            // 
            // tbMail
            // 
            this.tbMail.Location = new System.Drawing.Point(89, 188);
            this.tbMail.Name = "tbMail";
            this.tbMail.Size = new System.Drawing.Size(116, 21);
            this.tbMail.TabIndex = 35;
            // 
            // tbQQ
            // 
            this.tbQQ.Location = new System.Drawing.Point(89, 161);
            this.tbQQ.Name = "tbQQ";
            this.tbQQ.Size = new System.Drawing.Size(116, 21);
            this.tbQQ.TabIndex = 34;
            // 
            // tbTel
            // 
            this.tbTel.Location = new System.Drawing.Point(89, 134);
            this.tbTel.Name = "tbTel";
            this.tbTel.Size = new System.Drawing.Size(116, 21);
            this.tbTel.TabIndex = 33;
            // 
            // rbWoman
            // 
            this.rbWoman.AutoSize = true;
            this.rbWoman.Location = new System.Drawing.Point(170, 112);
            this.rbWoman.Name = "rbWoman";
            this.rbWoman.Size = new System.Drawing.Size(35, 16);
            this.rbWoman.TabIndex = 32;
            this.rbWoman.TabStop = true;
            this.rbWoman.Text = "女";
            this.rbWoman.UseVisualStyleBackColor = true;
            // 
            // rbMan
            // 
            this.rbMan.AutoSize = true;
            this.rbMan.Location = new System.Drawing.Point(89, 112);
            this.rbMan.Name = "rbMan";
            this.rbMan.Size = new System.Drawing.Size(35, 16);
            this.rbMan.TabIndex = 31;
            this.rbMan.TabStop = true;
            this.rbMan.Text = "男";
            this.rbMan.UseVisualStyleBackColor = true;
            // 
            // tbCheck
            // 
            this.tbCheck.Location = new System.Drawing.Point(89, 84);
            this.tbCheck.Name = "tbCheck";
            this.tbCheck.Size = new System.Drawing.Size(116, 21);
            this.tbCheck.TabIndex = 30;
            this.tbCheck.UseSystemPasswordChar = true;
            // 
            // tbPasswd
            // 
            this.tbPasswd.Location = new System.Drawing.Point(89, 57);
            this.tbPasswd.Name = "tbPasswd";
            this.tbPasswd.Size = new System.Drawing.Size(116, 21);
            this.tbPasswd.TabIndex = 29;
            this.tbPasswd.UseSystemPasswordChar = true;
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(89, 30);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(116, 21);
            this.tbUserName.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 27;
            this.label1.Text = "姓名：";
            // 
            // RegistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 346);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistForm";
            this.Text = "RegistForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RegistForm_FormClosed);
            this.Load += new System.EventHandler(this.RegistForm_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbUserPhoto)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pbUserPhoto;
        private System.Windows.Forms.Button btShoot;
        private System.Windows.Forms.Button btGetPhoto;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cbCamera;
        private System.Windows.Forms.Button btCamera;
        private AForge.Controls.VideoSourcePlayer vspUserPhoto;
        private System.Windows.Forms.TextBox tbPhotoPath;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btRegist;
        private System.Windows.Forms.DateTimePicker dtBirthday;
        private System.Windows.Forms.TextBox tbMail;
        private System.Windows.Forms.TextBox tbQQ;
        private System.Windows.Forms.TextBox tbTel;
        private System.Windows.Forms.RadioButton rbWoman;
        private System.Windows.Forms.RadioButton rbMan;
        private System.Windows.Forms.TextBox tbCheck;
        private System.Windows.Forms.TextBox tbPasswd;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label label1;
    }
}