using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Sockets;
using MySql.Data.MySqlClient;
using Baidu.Aip.Face;
using AForge.Video.DirectShow;
using AForge.Video;
using System.IO;
using Newtonsoft.Json;

namespace WirelessDoor_PC_master
{
    public partial class RegistForm : Form
    {
        //照片路径
        string photoPath = null;
        //摄像头设备
        private FilterInfoCollection videoDevices;
        //视频数据流
        private VideoCaptureDevice videoSource;

        IPAddress[] HOST = Dns.GetHostAddresses("************");
        private const int port = 8086;
        //数据库信息
        string host = "***.**.**.*";
        string database = "room";
        string username = "root";
        string passwd = "********";


        public RegistForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegistForm_Load(object sender, EventArgs e)
        {
            try
            {
                // 枚举所有视频输入设备
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (videoDevices.Count == 0)
                {
                    MessageBox.Show("未找到摄像头！");
                    btCamera.Enabled = false;
                    btShoot.Enabled = false;
                }
                else
                {
                    foreach (FilterInfo device in videoDevices)
                    {
                        cbCamera.Items.Add(device.Name);
                    }
                    cbCamera.SelectedIndex = 0;
                    btCamera.Enabled = true;
                    btShoot.Enabled = false;
                }
            }
            catch (Exception)
            {
                cbCamera.Items.Add("No local capture devices");
                videoDevices = null;
            }
        }

        /// <summary>
        /// 关闭窗体事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegistForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            vspUserPhoto.Dispose();
            this.DialogResult = DialogResult.OK;
            this.Dispose();
            LogForm logform = new LogForm();
            logform.ShowDialog();
        }

        /// <summary>
        /// 检查输入注册信息的正确性
        /// </summary>
        /// <returns></returns>
        private bool CheckInput()
        {
            MySqlConnection myconn = new MySqlConnection("Host=" + host +
                                                         ";Database=" + database +
                                                         ";Username=" + username +
                                                         ";Password=" + passwd + ";");
            bool res = false;
            //用户名不可为空
            if (tbUserName.Text == "")
            {
                res = true;
                label9.Text = "用户名不可为空！";
                label9.ForeColor = Color.Red;
                label10.ForeColor = Color.Red;
                return res;
            }
            //密码不可为空
            if (tbPasswd.Text == "")
            {
                res = true; label9.Text = "密码不可为空！";
                label9.ForeColor = Color.Red;
                label11.ForeColor = Color.Red;
                return res;
            }
            //两次输入密码不一致
            if (tbPasswd.Text != tbCheck.Text)
            {
                res = true;
                label9.Text = "两次密码不一致！";
                label9.ForeColor = Color.Red;
                label11.ForeColor = Color.Red;
                label12.ForeColor = Color.Red;
                return res;
            }
            //电话不可为空
            if (tbTel.Text == "")
            {
                res = true;
                label9.Text = "电话不可为空！";
                label9.ForeColor = Color.Red;
                label13.ForeColor = Color.Red;
                return res;
            }
            //电话长度不是11位
            if (tbTel.Text.Length != 11)
            {
                res = true;
                label9.Text = "电话长度错误！";
                label9.ForeColor = Color.Red;
                label13.ForeColor = Color.Red;
                return res;
            }
            //邮箱不可为空
            if (tbMail.Text == "")
            {
                res = true;
                label9.Text = "邮箱不可为空！";
                label9.ForeColor = Color.Red;
                label14.ForeColor = Color.Red;
                return res;
            }
            if (photoPath == null)
            {
                res = true;
                label9.Text = "未选择照片！";
                label9.ForeColor = Color.Red;
                return res;
            }
            try
            {
                //开启连接
                myconn.Open();
                //新建SQL指令
                MySqlCommand mycom = myconn.CreateCommand();
                //添加SQL指令
                //mycom.CommandText = "SELECT * FROM user";
                //执行查询
                //MySqlDataAdapter adap = new MySqlDataAdapter(mycom);
                //构造SQL指令
                string sql = string.Format("SELECT * FROM userInfo ");
                mycom.CommandText = sql;

                mycom.CommandType = CommandType.Text;
                //执行查询
                MySqlDataReader reader = mycom.ExecuteReader();
                bool check_tel = false;
                bool check_mail = false;
                bool check_userName = false;
                while (reader.Read())
                {
                    if (tbUserName.Text == reader[1].ToString())
                    {
                        check_userName = true;
                        break;
                    }
                    else if (tbTel.Text == reader[2].ToString())
                    {
                        check_tel = true;
                        break;
                    }
                    else if (tbMail.Text == reader[7].ToString())
                    {
                        check_mail = true;
                        break;
                    }
                }
                //释放资源，防止数据库锁住
                myconn.Dispose();
                //关闭连接
                myconn.Close();
                if (check_userName == true)
                {
                    res = true;
                    label9.Text = "用户名已注册！";
                    label9.ForeColor = Color.Red;
                    label10.ForeColor = Color.Red;
                    return res;
                }
                else if (check_tel == true)
                {
                    res = true;
                    label9.Text = "该电话已注册！";
                    label9.ForeColor = Color.Red;
                    label13.ForeColor = Color.Red;
                    return res;
                }
                else if (check_mail == true)
                {
                    res = true;
                    label9.Text = "该邮箱已注册！";
                    label9.ForeColor = Color.Red;
                    label14.ForeColor = Color.Red;
                    return res;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
                //释放资源，防止数据库锁住
                myconn.Dispose();
                //关闭连接
                myconn.Close();
            }
            return res;
        }

        /// <summary>
        /// 点击注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btRegist_Click(object sender, EventArgs e)
        {
            // 设置APPID/AK/SK
            var APP_ID = "14976181";
            var API_KEY = "v6gNCmUGTHzdkUVP0XI7ksaG";
            var SECRET_KEY = "YPqgbFV9T0qmEGbnvMKYGPHeGw5exW5F";

            var client = new Baidu.Aip.Face.Face(API_KEY, SECRET_KEY);
            client.Timeout = 60000;  // 修改超时时间
                                     //输入值检测返回值
            bool res = true;
            label9.Text = "带*为必填项";
            label9.ForeColor = Color.Black;
            label10.ForeColor = Color.Black;
            label11.ForeColor = Color.Black;
            label12.ForeColor = Color.Black;
            label13.ForeColor = Color.Black;
            label14.ForeColor = Color.Black;
            res = CheckInput();
            if (res == false)
            {
                MySqlConnection myconn = new MySqlConnection("Host=" + host +
                                                         ";Database=" + database +
                                                         ";Username=" + username +
                                                         ";Password=" + passwd + ";");
                FileStream fs = File.OpenRead(tbPhotoPath.Text); //OpenRead
                int filelength = 0;
                filelength = (int)fs.Length; //获得文件长度 
                Byte[] imgData64 = new Byte[filelength]; //建立一个字节数组 
                fs.Read(imgData64, 0, filelength); //按字节流读取 
                                                   //System.Drawing.Image result = System.Drawing.Image.FromStream(fs);
                fs.Close();
                //图片转BASE64码
                var image = Convert.ToBase64String(imgData64);
                //文件格式
                var imageType = "BASE64";
                //注册人脸用户组
                var groupId = "User";
                //注册人脸用户号
                var userId = tbTel.Text;
                //人脸注册返回结果
                bool userAddCheck = false;

                try
                {
                    // 如果有可选参数
                    var options = new Dictionary<string, object>{
                                                                {"quality_control", "NORMAL"},
                                                                {"liveness_control", "LOW"}
                                                                };
                    // 调用人脸注册，可能会抛出网络等异常，请使用try/catch捕获
                    var get_result = client.UserAdd(image, imageType, groupId, userId, options);
                    string index_resilt = get_result.ToString();
                    MessageBox.Show(index_resilt);
                    //判断注册情况
                    int index_add = index_resilt.IndexOf("SUCCESS");
                    int index_exist = index_resilt.IndexOf("exist");
                    //注册成功，添加人脸图片
                    if (index_add != -1 || index_exist != -1)
                    {
                        //添加人脸图片
                        get_result = client.UserUpdate(image, imageType, groupId, userId, options);
                        MessageBox.Show(get_result.ToString());
                        index_resilt = get_result.ToString();
                        int index_update = index_resilt.IndexOf("SUCCESS");
                        if (index_update != -1)
                        {
                            userAddCheck = true;    //人脸图片添加成功
                        }
                    }
                }
                catch (FieldAccessException face_ex)
                {
                    MessageBox.Show(face_ex.ToString());
                }

                string sex = null;
                if (rbMan.Checked == Enabled)
                {
                    sex = rbMan.Text;
                }
                else if (rbWoman.Checked == Enabled)
                {
                    sex = rbWoman.Text;
                }

                if (userAddCheck == true)
                {
                    myconn.Open();
                    MySqlTransaction transaction = myconn.BeginTransaction();//事务必须在try外面赋值不然catch里的
                    try
                    {
                        string sql = "SELECT count(*) FROM userInfo";

                        //开启连接
                        MySqlCommand cmd = new MySqlCommand(sql, myconn);

                        Object get_count = cmd.ExecuteScalar();
                        int count = int.Parse(get_count.ToString()) + 1;
                        cmd.CommandText = "insert into userInfo values(@userID,@userName,@authority,@passwd,@sex,@tel,@qq,@email,@birthday,@recodeDate);";
                        cmd.Parameters.AddRange(new[] {
                                            new MySqlParameter("@userID",count),                    //用户序号
                                            new MySqlParameter("@userName",tbUserName.Text),        //用户名
                                            new MySqlParameter("@authority",tbTel.Text),            //用户识别号
                                            new MySqlParameter("@passwd",tbPasswd.Text),            //用户密码
                                            new MySqlParameter("@sex",sex),                         //性别
                                            new MySqlParameter("@tel",tbTel.Text),                  //电话（识别码）
                                            new MySqlParameter("@qq",tbQQ.Text),                    //QQ
                                            new MySqlParameter("@email",tbMail.Text),               //邮箱
                                            new MySqlParameter("@birthday",dtBirthday.Value.ToString("yyyy年MM月dd日")),
                                            new MySqlParameter("recodeDate",DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分"))
                                            });
                        //MessageBox.Show(cmd.CommandText.ToString());
                        cmd.ExecuteNonQuery();
                        //事务要么回滚要么提交，即Rollback()与Commit()只能执行一个
                        transaction.Commit();

                        label9.Text = "信息正确，注册成功！";
                        label9.ForeColor = Color.Black;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        transaction.Rollback();//事务ExecuteNonQuery()执行失败报错，username被设置unique
                                               //关闭连接，以免数据库被锁
                        myconn.Dispose();
                        myconn.Close();
                        label9.Text = "注册失败！";
                        label9.ForeColor = Color.Red;
                    }
                    finally
                    {
                        //关闭连接，以免数据库被锁
                        myconn.Dispose();
                        myconn.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 打开摄像头预览信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCamera_Click(object sender, EventArgs e)
        {
            videoSource = new VideoCaptureDevice(videoDevices[cbCamera.SelectedIndex].MonikerString);
            //videoSource.DesiredFrameSize = new Size(120, 160);
            //videoSource.DesiredFrameRate = 1;

            vspUserPhoto.VideoSource = videoSource;
            vspUserPhoto.Visible = true;
            pbUserPhoto.Visible = false;
            vspUserPhoto.Start();
            btCamera.Enabled = false;
            btShoot.Enabled = true;
        }

        /// <summary>
        /// 使用图片文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btGetPhoto_Click(object sender, EventArgs e)
        {
            //设置对话框的标题
            openFileDialog1.Title = "选择一张图片";
            //固定打开对话框选择路径
            openFileDialog1.InitialDirectory = @"C:\Users\Administrator";
            //设置打开文件类型
            openFileDialog1.Filter = "JPGE格式(*.jpge)|*.jpg|bmp格式(*.bmp)|*.bmp|All files (*.*)|*.* ";
            //默认选择类型
            openFileDialog1.FilterIndex = 1;
            //每次固定打开相同文件路径
            openFileDialog1.RestoreDirectory = true;
            //打开对话框
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //加载图片
                tbPhotoPath.Text = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                Image bitmap = new Bitmap(tbPhotoPath.Text);
                vspUserPhoto.Visible = false;
                pbUserPhoto.Visible = true;
                //pbUserPhoto.ImageLocation = tbPhotoPath.Text;
                //等比例缩放图片
                bitmap = Zoom_Image(bitmap, 120, 160);
                bitmap.Save(@".\picture\photo.bmp");
                //显示图片查看
                pbUserPhoto.Image = bitmap;
                photoPath = tbPhotoPath.Text;
            }
        }

        /// <summary>
        /// 等比例缩放
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="towidth"></param>
        /// <param name="toheight"></param>
        /// <returns></returns>
        private Image Zoom_Image(Image bitmap, int towidth, int toheight)
        {
            int x = 0;
            int y = 0;
            int ow = bitmap.Width;
            int oh = bitmap.Height;

            //缩放照片
            if ((double)bitmap.Width / (double)bitmap.Height > (double)towidth / (double)toheight)
            {
                oh = bitmap.Height;
                ow = bitmap.Height * towidth / toheight;
                y = 0;
                x = (bitmap.Width - ow) / 2;
            }
            else
            {
                ow = bitmap.Width;
                oh = bitmap.Width * 160 / towidth;
                x = 0;
                y = (bitmap.Height - oh) / 2;
            }

            //新建一个bmp图片
            Image toBitmap = new System.Drawing.Bitmap(towidth, toheight);
            //新建一个画板
            Graphics g = System.Drawing.Graphics.FromImage(toBitmap);
            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //清空画布并以透明背景色填充
            g.Clear(Color.Transparent);
            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(bitmap, new Rectangle(0, 0, towidth, toheight),
                new Rectangle(x, y, ow, oh),
                GraphicsUnit.Pixel);

            return toBitmap;
        }

        /// <summary>
        /// 点击拍照
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btShoot_Click(object sender, EventArgs e)
        {
            try
            {
                //摄像头设备运行中
                if (vspUserPhoto.IsRunning)
                {
                    //获取一张图片
                    Image originalImage = vspUserPhoto.GetCurrentVideoFrame();
                    //设置照片宽度和高度
                    int towidth = 120;
                    int toheight = 160;
                    
                    int x = 0;
                    int y = 0;
                    int ow = originalImage.Width;
                    int oh = originalImage.Height;
                    //缩放照片
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * 160 / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    //新建一个bmp图片
                    Image bitmap = new System.Drawing.Bitmap(towidth, toheight);
                    //新建一个画板
                    Graphics g = System.Drawing.Graphics.FromImage(bitmap);
                    //设置高质量插值法
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                    //设置高质量,低速度呈现平滑程度
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    //清空画布并以透明背景色填充
                    g.Clear(Color.Transparent);
                    //在指定位置并且按指定大小绘制原图片的指定部分
                    g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
                        new Rectangle(x, y, ow, oh),
                        GraphicsUnit.Pixel);
                    //显示照片
                    //bitmap.SetResolution(120, 160);
                    vspUserPhoto.Visible = false;
                    pbUserPhoto.Visible = true;
                    //拍照完成后关摄像头并刷新同时关窗体
                    if (vspUserPhoto != null && vspUserPhoto.IsRunning)
                    {
                        vspUserPhoto.SignalToStop();
                        vspUserPhoto.WaitForStop();
                        vspUserPhoto.Stop();
                        btCamera.Enabled = true;
                        btShoot.Enabled = false;
                    }
                    photoPath = @".\picture\photo.bmp";
                    if (File.Exists(photoPath))
                    {
                        File.Delete(photoPath);
                    }
                    //保存图片并显示图片
                    bitmap.Save(photoPath);
                    pbUserPhoto.ImageLocation = photoPath;
                    tbPhotoPath.Text = pbUserPhoto.ImageLocation;
                }
            }
            //报错处理
            catch (Exception)
            {
                vspUserPhoto.SignalToStop();
                vspUserPhoto.WaitForStop();
                vspUserPhoto.Stop();
                btCamera.Enabled = true;
                btShoot.Enabled = false;
            }
        }

        /// <summary>
        /// 限制TextBox只能输入中文和数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextChangedChinese(object sender, EventArgs e)
        {
            TextBox tbInput = (TextBox)sender;
            var reg = new Regex("^[\u2E80-\u9FFF]*$");
            var str = tbInput.Text.Trim();
            var sb = new StringBuilder();
            if (!reg.IsMatch(str))
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (reg.IsMatch(str[i].ToString()))
                    {
                        sb.Append(str[i].ToString());
                    }
                }
                tbInput.Text = sb.ToString();
                //定义输入焦点在最后一个字符
                tbInput.SelectionStart = tbInput.Text.Length;
            }
        }

        /// <summary>
        /// 限制只能输入数字、大小字母、下划线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextChangedNumber(object sender, EventArgs e)
        {
            TextBox tbInput = (TextBox)sender;
            var reg = new Regex("^[0-9A-Za-z_]*$");
            var str = tbInput.Text.Trim();
            var sb = new StringBuilder();
            if (!reg.IsMatch(str))
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (reg.IsMatch(str[i].ToString()))
                    {
                        sb.Append(str[i].ToString());
                    }
                }
                tbInput.Text = sb.ToString();
                //定义输入焦点在最后一个字符
                tbInput.SelectionStart = tbInput.Text.Length;
            }
        }
    }
}
