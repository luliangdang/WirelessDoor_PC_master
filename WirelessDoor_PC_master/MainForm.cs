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
using System.Data.SQLite;
using System.Net;
using System.Net.Sockets;
using MySql.Data.MySqlClient;

namespace WirelessDoor_PC_master
{
    public partial class MainForm : Form
    {
        /***********************
         * 全局变量定义
        ***********************/
        IPAddress[] HOST = Dns.GetHostAddresses("k806034232.6655.la");
        private const int port = 8086;
        string userID = null;
        //NetworkStream stream = null;//网络流

        // 创建用于接收服务端消息的 线程；
        Thread threadClient = null;
        //socket连接对象
        Socket sockClient = null;

        //预约请求标志
        bool post_flag = false;

        public MainForm()
        {
            InitializeComponent();
            beginTimePicker.MinDate = Convert.ToDateTime(DateTime.Now);
        }

        /// <summary>
        /// 界面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            /*
            if (!Directory.Exists(Environment.CurrentDirectory + @"\dataBase"))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + @"\dataBase");//目录不存在，建立目录
            }
            if (!Directory.Exists(Environment.CurrentDirectory + @"\picture"))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + @"\picture");//目录不存在，建立目录
            }
            */
            //创建数据库
            CreatDataBase();
            ReLoadDataGridView();
            Connect_Sever();
        }

        /// <summary>
        /// 连接服务器
        /// </summary>
        private void Connect_Sever()
        {
            IPEndPoint endPoint = new IPEndPoint(HOST[0], port);
            sockClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sockClient.Connect(endPoint);
                threadClient = new Thread(RecvMsg);
                threadClient.IsBackground = true;
                threadClient.Start();
                MessageBox.Show("服务器连接成功！！");
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.ToString()+"登录失败！");
                //this.Close();
            }
        }

        /// <summary>
        /// 关闭窗体触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //关闭与服务器的连接
            sockClient.Dispose();
            sockClient.Close();
        }

        /// <summary>
        /// 重载数据表格内容
        /// </summary>
        private void ReLoadDataGridView()
        {
            //新建一个SQLite数据库对象
            SQLiteConnection conn = null;
            //数据库路径
            string dbPath = "Data Source =" + Environment.CurrentDirectory + @"\dataBase\roomInformation.db";
            //创建数据库实例，指定文件位置
            conn = new SQLiteConnection(dbPath);
            //清空表格
            dgvRoom.Rows.Clear();
            try
            {
                //打开数据库，若不存在自动创建
                conn.Open();
                string sql = "SELECT COUNT(*) FROM room";
                SQLiteCommand cmdQ = new SQLiteCommand(sql, conn);
                //获取数据总行数
                int RowCount = Convert.ToInt32(cmdQ.ExecuteScalar());
                //释放reader使用的资源，防止database is lock异常产生
                cmdQ.Dispose();
                sql = "SELECT * FROM room";
                cmdQ = new SQLiteCommand(sql, conn);
                SQLiteDataReader reader = cmdQ.ExecuteReader();
                while (reader.Read())
                {
                    int index = dgvRoom.Rows.Add();

                    dgvRoom.Rows[index].Cells[0].Value = reader.GetString(1);
                    dgvRoom.Rows[index].Cells[1].Value = reader.GetString(2);
                    dgvRoom.Rows[index].Cells[2].Value = reader.GetString(3);
                    dgvRoom.Rows[index].Cells[3].Value = reader.GetString(4);
                }
                //释放reader使用的资源，防止database is lock异常产生
                reader.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        /// <summary>
        /// 创建数据库，初始化
        /// </summary>
        private void CreatDataBase()
        {
            SQLiteConnection conn = null;
            string dbPath = "Data Source =" + Environment.CurrentDirectory + @".\dataBase\personalInformation.db";
            //创建数据库实例，指定文件位置
            conn = new SQLiteConnection(dbPath);
            try
            {
                //打开数据库，若文件不存在会自动创建
                conn.Open();
                //sqlite指令语句
                string sql = "CREATE TABLE IF NOT EXISTS user(" +
                             "userID INTEGER PRIMARY KEY," +        //用户序号
                             "userName VARCHAR(6)," +               //用户名
                             "authority TINYINT," +                 //登录名
                             "passwd VARCHAR(20)," +                //密码
                             "sex VARCHAR(2)," +                    //性别
                             "tel VARCHAR(20)," +                   //电话
                             "qq VARCHAR(20)," +                    //qq
                             "email VARCHAR(20)," +                 //邮箱
                             "birthday VARCHAR(20)," +              //生日
                             "recodeDate VARCHAR(20));";              //注册时间
                SQLiteCommand cmdCreateTable = new SQLiteCommand(sql, conn);
                //如果表不存在，创建人员信息表 
                cmdCreateTable.ExecuteNonQuery();
                //关闭数据库，防止资源占用
                conn.Close();

                dbPath = "Data Source =" + Environment.CurrentDirectory + @".\dataBase\roomInformation.db";
                //创建数据库实例，指定文件位置  
                conn = new SQLiteConnection(dbPath);
                //打开数据库，若文件不存在会自动创建
                conn.Open();
                //sqlite指令语句
                sql = "CREATE TABLE IF NOT EXISTS room(" +
                      "roomID INTEGER PRIMARY KEY," +
                      "roomName VARCHAR(6)," +
                      "roomState TINYINT," +
                      "beginTime VARCHAR(20)," +
                      "endTime VARCHAR(20));";
                cmdCreateTable = new SQLiteCommand(sql, conn);
                //如果表不存在，创建人员信息表 
                cmdCreateTable.ExecuteNonQuery();
                //关闭数据库，防止资源占用
                conn.Close();

                dbPath = "Data Source =" + Environment.CurrentDirectory + @".\dataBase\reciveInformation.db";
                //创建数据库实例，指定文件位置  
                conn = new SQLiteConnection(dbPath);
                //打开数据库，若文件不存在会自动创建
                conn.Open();
                //sqlite指令语句
                sql = "CREATE TABLE IF NOT EXISTS recive(" +
                      "num INTEGER PRIMARY KEY," +
                      "codeID VARCHAR(6)," +
                      "userName VARCHAR(6)," +
                      "time VARCHAR(20));";
                cmdCreateTable = new SQLiteCommand(sql, conn);
                //如果表不存在，创建人员信息表 
                cmdCreateTable.ExecuteNonQuery();
                //关闭数据库，防止资源占用
                conn.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
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
                }
                catch (SocketException se)
                {
                    MessageBox.Show(se.ToString());
                    return;
                }
                if (strMsg == "ok" && post_flag == true)
                {
                    post_flag = false;
                    MessageBox.Show("您的预约请求已发送，请等待管理员处理！");
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
        /// 预约按钮按下触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 预约ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string roomID = cbRoomName.Text;
            //MessageBox.Show(roomID);
            string userID = textBox_reservname.Text;
            //MessageBox.Show(userID);
            string userTel = textBox_reservTel.Text;
            //MessageBox.Show(userTel);
            string beginTime = beginTimePicker.Value.ToString();
            //MessageBox.Show(beginTime);
            string endTime = endTimePicker.Value.ToString();
            //MessageBox.Show(endTime);

            //需要发送的信息
            string strMsg ='@'+ "PC" + '@' + roomID + '@' + userID + '@' + beginTime + '@' + endTime + "\r\n";
            byte[] arrSendMsg = System.Text.Encoding.UTF8.GetBytes(strMsg);
            MessageBox.Show(strMsg);
            sockClient.Send(arrSendMsg);
            post_flag = true;

        }

        /// <summary>
        /// 数据表格双击单元格触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvRoom_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string room_num = dgvRoom.CurrentCell.Value.ToString();
            //cbRoomName.Text = 
            MessageBox.Show(dgvRoom.CurrentCell.Value.ToString());
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

    }
}
