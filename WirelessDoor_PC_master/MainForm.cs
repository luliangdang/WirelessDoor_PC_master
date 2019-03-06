using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using MySql.Data.MySqlClient;
using qcloudsms_csharp;
using qcloudsms_csharp.json;
using qcloudsms_csharp.httpclient;

namespace WirelessDoor_PC_master
{
    public partial class MainForm : Form
    {
        /***********************
         * 全局变量定义
        ***********************/
        //服务器地址
        IPAddress[] HOST = Dns.GetHostAddresses("k806034232.6655.la");
        //服务器端口号
        private const int port = 8086;

        //登录用户号
        string userID = null;
        string personName = null;

        //数据库信息
        string host = "***.***.**.*";
        string database = "room";
        string username = "root";
        string passwd = "*******";

        //短信发送appid
        int appid = **********;
        string appkey = "********************************";
        int[] templateId = { 265637, 270334, 265636, 266224 };
        string smsSign = "***";

        // 创建用于接收服务端消息的 线程；
        Thread threadClient = null;
        //socket连接对象
        Socket sockClient = null;
        //服务器连接成功标志
        bool client_flag = false;

        //发送请求标志
        bool post_flag = false;

        /// <summary>
        /// 窗体生成函数
        /// </summary>
        /// <param name="str"></param>
        public MainForm(string str1, string str2)
        {
            InitializeComponent();
            userID = str1;
            personName = str2;
            beginTimePicker.MinDate = Convert.ToDateTime(DateTime.Now);
            endTimePicker.MinDate = Convert.ToDateTime(DateTime.Now);
        }

        /// <summary>
        /// 界面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            ReLoadDataGridView();
            textBox_reservname.Text = personName;
            textBox_reservTel.Text = userID;
            Connect_Sever();
            MessageBox.Show("登录成功!\r\n" + personName + ",欢迎来到会议室预约系统！");
        }

        /// <summary>
        /// 连接服务器
        /// </summary>
        private void Connect_Sever()
        {
            IPEndPoint endPoint = new IPEndPoint(HOST[0], port);
            //IPEndPoint endPoint = new IPEndPoint(HOST, port);
            //创建socket连接对象
            sockClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                /* 连接服务器 */
                sockClient.Connect(endPoint);
                threadClient = new Thread(RecvMsg);
                threadClient.IsBackground = true;
                threadClient.Start();
                //MessageBox.Show("服务器连接成功！！");
                client_flag = true;
            }
            catch (SocketException)
            {
                sockClient.Close();
                client_flag = false;
            }
        }

        /// <summary>
        /// 关闭窗体触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client_flag == true)
            {
                //关闭与服务器的连接
                sockClient.Dispose();
                sockClient.Close();
            }
        }

        /// <summary>
        /// 重载数据表格内容
        /// </summary>
        private void ReLoadDataGridView()
        {
            MySqlConnection myconn = new MySqlConnection("Host=" + host +
                                                         ";Database=" + database +
                                                         ";Username=" + username +
                                                         ";Password=" + passwd + ";");
            dgvRoom.Rows.Clear();
            cbRoomName.Items.Clear();
            try
            {
                //连接数据库
                myconn.Open();
                //新建SQL指令
                MySqlCommand mycom = myconn.CreateCommand();
                string sql = string.Format("SELECT * FROM roominfo;");
                mycom.CommandText = sql;

                mycom.CommandType = CommandType.Text;
                //执行查询指令
                MySqlDataReader reader = mycom.ExecuteReader();
                while (reader.Read())
                {
                    int index = dgvRoom.Rows.Add();
                    dgvRoom.Rows[index].Cells[0].Value = reader.GetString(1);
                    dgvRoom.Rows[index].Cells[1].Value = reader.GetString(2);
                    dgvRoom.Rows[index].Cells[2].Value = reader.GetString(3);
                    cbRoomName.Items.Add(reader.GetString(1));
                }

                //释放reader的资源
                reader.Dispose();
                reader.Close();
                //关闭数据库，防止数据库被锁定
                myconn.Dispose();
                myconn.Close();
            }
            catch (MySqlException se)
            {
                MessageBox.Show(se.ToString());
                //关闭数据库，防止数据库被锁定
                myconn.Dispose();
                myconn.Close();
            }
        }

        /// <summary>
        /// socket数据接收回调函数
        /// </summary>
        void RecvMsg()
        {
            while (true)
            {
                // 定义一个2M的缓存区；
                byte[] arrMsgRec = new byte[1024 * 1024 * 2];
                // 将接受到的数据存入到输入  arrMsgRec中；
                int length = -1;
                string strMsg = null;
                try
                {
                    //接收数据，并计算数据长度
                    length = sockClient.Receive(arrMsgRec);
                    strMsg = System.Text.Encoding.UTF8.GetString(arrMsgRec, 0, length);
                    DecoData(strMsg);
                }
                catch (SocketException se)
                {
                    MessageBox.Show(se.ToString());
                    return;
                }
                /*
                if (strMsg.IndexOf("OK",0) != -1 && post_flag == true)
                {
                    post_flag = false;
                    
                    string[] param = new string[4];

                    param[0] = cbRoomName.Text;
                    param[1] = beginTimePicker.Value.ToString();
                    param[2] = endTimePicker.Value.ToString();
                    param[3] = "123456";
                    MessageBox.Show(param.ToString());
                    SmsSend(textBox_reservTel.Text, 0, param);
                    
                    MessageBox.Show("您的预约请求已发送，请等待管理员处理！");
                }
                */
            }
        }

        /// <summary>
        /// 解析接收数据
        /// </summary>
        /// <param name="message"></param>
        private void DecoData(string message)
        {
            MySqlConnection myconn = new MySqlConnection("Host=" + host +
                                                         ";Database=" + database +
                                                         ";Username=" + username +
                                                         ";Password=" + passwd + ";");
            string data = message;
            int CMD = Convert.ToUInt16(data.Substring(2,1));
            string userGet = data.Substring(3,11);
            string msg = data.Substring(14);
            if (userGet == userID)
            {
                switch (CMD)
                {
                    case 1:     //预约请求
                        {
                            if (msg.IndexOf("OK", 0) != -1 && post_flag == true)
                            {
                                post_flag = false;
                                MessageBox.Show("您的预约请求已发送，请等待管理员处理！");
                                cbRoomName.Text = "";
                                beginTimePicker.Value = System.DateTime.Now;
                                endTimePicker.Value = System.DateTime.Now;
                                //textBox_reservname.Text = "";
                                //textBox_reservTel.Text = "";
                                rTbox_reason.Text = "";
                            }
                            break;
                        }
                    case 2:     //修改请求
                        {
                            break;
                        }
                    case 3:     //取消请求
                        {
                            break;
                        }
                    default:    break;
                }
            }
        }

        /// <summary>
        /// beginTime数据改变触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void beginTime_MouseCaptureChanged(object sender, EventArgs e)
        {
            endTimePicker.MinDate = beginTimePicker.Value;
            endTimePicker.Value = beginTimePicker.Value;
        }

        /// <summary>
        /// 发送通知短信
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="templateNumber"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        private bool SmsSend(string phoneNumber, int templateNumber, string[] param)
        {
            bool res = false;
            try
            {
                SmsSingleSender ssender = new SmsSingleSender(appid, appkey);
                var result = ssender.sendWithParam("86", phoneNumber,templateId[templateNumber], param, smsSign, "", "");  // 签名参数未提供或者为空时，会使用默认签名发送短信
                res = true;
            }
            catch (JSONException e)
            {
                MessageBox.Show(e.ToString());
            }
            catch (HTTPException e)
            {
                MessageBox.Show(e.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return res;
        }

        /// <summary>
        /// 检查预约信息
        /// </summary>
        /// <returns></returns>
        private bool CheckMessage()
        {
            bool res = true;

            if (cbRoomName.Text == "")
            {
                res = false;
                MessageBox.Show("请正确选择会议室！");
                return res;
            }
            /*
            if (textBox_reservname.Text == "")
            {
                res = false;
                MessageBox.Show("预约人姓名不得为空！");
                return res;
            }
            if (textBox_reservTel.Text == "")
            {
                res = false;
                MessageBox.Show("预约电话不得为空！");
                return res;
            }
            */
            if (endTimePicker.Value.Subtract(beginTimePicker.Value) < System.TimeSpan.FromMinutes(5))
            {
                res = false;
                MessageBox.Show("预约时间小于5分钟！");
                return res;
            }
            return res;
        }

        /// <summary>
        /// 预约按钮按下触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 预约ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (client_flag == true && CheckMessage())
            {
                MySqlConnection myconn = new MySqlConnection("Host=" + host +
                                                         ";Database=" + database +
                                                         ";Username=" + username +
                                                         ";Password=" + passwd + ";");
                try
                {
                    //连接数据库
                    myconn.Open();
                    //新建SQL指令
                    MySqlCommand mycom = myconn.CreateCommand();
                    string sql = string.Format("SELECT roomID FROM roominfo WHERE roomName=\""+cbRoomName.Text.ToString()+"\";");
                    //MessageBox.Show(sql);
                    mycom.CommandText = sql;

                    mycom.CommandType = CommandType.Text;
                    //执行查询指令
                    MySqlDataReader reader = mycom.ExecuteReader();
                    if (reader.Read())
                    {
                        string roomID = reader.GetUInt16(0).ToString().PadLeft(4, '0');
                        //MessageBox.Show(roomID);
                        string userName = textBox_reservname.Text;
                        //MessageBox.Show(userID);
                        string userTel = textBox_reservTel.Text;
                        //MessageBox.Show(userTel);
                        string beginTime = beginTimePicker.Value.ToString("yyyyMMddHHmmss");
                        //MessageBox.Show(beginTime);
                        string endTime = endTimePicker.Value.ToString("yyyyMMddHHmmss");
                        //MessageBox.Show(endTime);
                        string reason = rTbox_reason.Text;

                        //释放reader的资源
                        reader.Dispose();
                        reader.Close();
                        //关闭数据库，防止数据库被锁定
                        myconn.Dispose();
                        myconn.Close();

                        //需要发送的信息
                        string strMsg = '@' + "P1" + roomID + userTel + userName + beginTime + endTime + reason + "\r\n";
                        byte[] arrSendMsg = System.Text.Encoding.UTF8.GetBytes(strMsg);
                        //MessageBox.Show(strMsg);
                        sockClient.Send(arrSendMsg);
                        post_flag = true;
                        //等待超时时间
                        int timeout = 0;
                        //等待预约应答
                        while (post_flag == true)
                        {
                            timeout++;
                            Thread.Sleep(1000);
                            if (timeout > 5)
                            {
                                post_flag = false;
                                MessageBox.Show("数据接收超时，服务器停机！");
                                break;
                            }
                        }
                        if (timeout < 6)
                        {
                            myconn.Open();

                            sql = "INSERT INTO reservationinfo values(@roomID,@roomName,@roomState,@msgState,@passwd,@authority,@userName,@beginTime,@endTime,@reason)";

                            mycom.CommandText = sql;
                            mycom.Parameters.AddRange(new[] {
                                                  new MySqlParameter("@roomID",roomID),
                                                  new MySqlParameter("roomName",cbRoomName.Text),
                                                  new MySqlParameter("@roomState",null),
                                                  new MySqlParameter("@msgState","未处理"),
                                                  new MySqlParameter("@passwd",null),
                                                  new MySqlParameter("@authority",userTel),
                                                  new MySqlParameter("@userName",userName),
                                                  new MySqlParameter("@beginTime",beginTime),
                                                  new MySqlParameter("@endTime",endTime),
                                                  new MySqlParameter("@reason",reason)
                                                  });

                            MySqlTransaction transacter = myconn.BeginTransaction();
                            mycom.Transaction = transacter;

                            mycom.ExecuteNonQuery();//执行查询
                            transacter.Commit();//提交
                            mycom.Dispose();//释放reader使用的资源，防止database is lock异常产生
                            transacter.Dispose();//释放reader使用的资源，防止database is lock异常产生
                        }
                        //关闭数据库，防止数据库被锁定
                        myconn.Dispose();
                        myconn.Close();
                    }
                }
                catch (MySqlException se)
                {
                    MessageBox.Show(se.ToString());
                    //关闭数据库，防止数据库被锁定
                    myconn.Dispose();
                    myconn.Close();
                }
            }
            else if(client_flag == false)
            {
                MessageBox.Show("尚未连接服务器，预约失败！\r\n请重新登录！");
            }
        }

        /// <summary>
        /// 预约按钮触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_reserv_Click(object sender, EventArgs e)
        {
            预约ToolStripMenuItem_Click(sender, e);
        }

        /// <summary>
        /// 查询预约记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 查询预约记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReservationForm reservationForm = new ReservationForm(userID, personName, sockClient);
            reservationForm.ShowDialog();
        }

        /// <summary>
        /// 修改个人信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlConnection myconn = new MySqlConnection("Host=" + host +
                                                         ";Database=" + database +
                                                         ";Username=" + username +
                                                         ";Password=" + passwd + ";");
            try
            {
                //连接数据库
                myconn.Open();
                //新建SQL指令
                MySqlCommand mycom = myconn.CreateCommand();
                string sql = string.Format("SELECT userName FROM userinfo WHERE tel=\"" + userID + "\";");
                //MessageBox.Show(sql);
                mycom.CommandText = sql;
                mycom.CommandType = CommandType.Text;
                //执行查询指令
                MySqlDataReader reader = mycom.ExecuteReader();

                if (reader.Read())
                {
                    personName = reader.GetString(0);
                }

                //释放reader的资源
                reader.Dispose();
                reader.Close();
                //关闭数据库，防止数据库被锁定
                myconn.Dispose();
                myconn.Close();
                PersonForm personForm = new PersonForm(personName, userID);
                personForm.ShowDialog();
            }
            catch (MySqlException se)
            {
                MessageBox.Show(se.ToString());
                //关闭数据库，防止数据库被锁定
                myconn.Dispose();
                myconn.Close();
            }
        }

        /// <summary>
        /// 修改预约信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 预约信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReservationForm reservationForm = new ReservationForm(userID, personName, sockClient);
            reservationForm.ShowDialog();
        }
    }
}
