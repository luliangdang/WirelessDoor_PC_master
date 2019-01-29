using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WirelessDoor_PC_master
{
    public partial class ReservationForm : Form
    {
        //数据库信息
        //string host = "localhost";
        string host = "47.100.28.6";
        string database = "room";
        string username = "root";
        //string passwd = "Dll960220";
        string passwd = "LL960220";

        string userID = null;
        string userName = null;
        Socket socket = null;

        string getBeginTime = null;
        string getEndTime = null;

        //发送请求标志
        bool post_flag = false;

        public ReservationForm()
        {
            InitializeComponent();
        }

        public ReservationForm(string str1, Socket socketClient)
        {
            InitializeComponent();
            userName = str1;
            this.socket = socketClient;
            dtBeginTime.MinDate = Convert.ToDateTime(DateTime.Now);
            dtBeginTime.Value = DateTime.Now;
            dtEndTime.MinDate = Convert.ToDateTime(DateTime.Now);
            dtEndTime.Value = DateTime.Now;
        }

        public ReservationForm(string userid, string UserName, Socket socketClient)
        {
            InitializeComponent();
            userID = userid;
            userName = UserName;
            this.socket = socketClient;
            dtBeginTime.MinDate = Convert.ToDateTime(DateTime.Now);
            dtBeginTime.Value = DateTime.Now;
            dtEndTime.MinDate = Convert.ToDateTime(DateTime.Now);
            dtEndTime.Value = DateTime.Now;
        }

        /// <summary>
        /// 显示日志
        /// </summary>
        /// <param name="str"></param>
        void ShowMsg(string str)
        {
            if (rtLogo.Text != "") { rtLogo.Text += "\r\n"; }
            rtLogo.Text += DateTime.Now.ToString("HH:mm:ss:") + str;
            rtLogo.Select(rtLogo.Text.Length, 0);//将光标设置到最末尾
            rtLogo.ScrollToCaret();  //将滚动条设置到光标处
        }

        private void ReservationForm_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            ReLoadDataGridView();
        }

        /// <summary>
        /// 重载dataGridView数据
        /// </summary>
        private void ReLoadDataGridView()
        {
            MySqlConnection myconn = new MySqlConnection("Host=" + host +
                                                         ";Database=" + database +
                                                         ";Username=" + username +
                                                         ";Password=" + passwd + ";");
            dgvReservation.Rows.Clear();
            try
            {
                //连接数据库
                myconn.Open();
                //新建SQL指令
                MySqlCommand mycom = myconn.CreateCommand();
                string sql = string.Format("SELECT * FROM reservationinfo WHERE userName=\""+ userName +"\";");
                mycom.CommandText = sql;

                mycom.CommandType = CommandType.Text;
                //执行查询指令
                MySqlDataReader reader = mycom.ExecuteReader();

                while (reader.Read())
                {
                    int index = dgvReservation.Rows.Add();
                    dgvReservation.Rows[index].Cells[0].Value = reader.GetString(1);        //会议室名称
                    dgvReservation.Rows[index].Cells[1].Value = reader.GetString(3);        //处理状况
                    if (Convert.IsDBNull(reader["roomState"]))
                    {
                        dgvReservation.Rows[index].Cells[2].Value = "无";                   //申请结果
                    }
                    else dgvReservation.Rows[index].Cells[2].Value = reader.GetString(2);
                    dgvReservation.Rows[index].Cells[3].Value = reader.GetString(7);        //开始时间
                    dgvReservation.Rows[index].Cells[4].Value = reader.GetString(8);        //结束时间
                    dgvReservation.Rows[index].Cells[5].Value = reader.GetString(9);        //申请理由
                }

                //释放reader的资源
                reader.Dispose();
                reader.Close();
                //关闭数据库，防止数据库被锁定
                myconn.Dispose();
                myconn.Close();
            }
            catch (MySqlException sqle)
            {
                ShowMsg(sqle.ToString());
                //关闭数据库，防止数据库被锁定
                myconn.Dispose();
                myconn.Close();
            }
        }

        /// <summary>
        /// 表格双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvReservation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvReservation.CurrentRow.Index;
            if (DateTime.Now.Subtract(Convert.ToDateTime(dgvReservation.Rows[index].Cells[4].Value.ToString())) > System.TimeSpan.FromMinutes(0))
            {
                ShowMsg("预约记录已过期");
            }
            else
            {
                tbRoomName.Text = dgvReservation.Rows[index].Cells[0].Value.ToString();
                getBeginTime = dgvReservation.Rows[index].Cells[3].Value.ToString();
                getEndTime = dgvReservation.Rows[index].Cells[4].Value.ToString();
                dtBeginTime.Value = DateTime.Parse(dgvReservation.Rows[index].Cells[3].Value.ToString());
                dtEndTime.Value = DateTime.Parse(dgvReservation.Rows[index].Cells[4].Value.ToString());
                rtReason.Text = dgvReservation.Rows[index].Cells[5].Value.ToString();
                ShowMsg("数据读取成功");
            }
        }

        /// <summary>
        /// 修改预约信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSet_Click(object sender, EventArgs e)
        {
            if (dtEndTime.Value.Subtract(dtBeginTime.Value) < System.TimeSpan.FromMinutes(30))
            {
                MessageBox.Show("预约时间小于30分钟！");
                return;
            }

            if (rtReason.Text != "" && tbRoomName.Text != "")
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
                    string sql = string.Format("SELECT roomID FROM roominfo WHERE roomName=\"" + tbRoomName.Text + "\";");
                    //MessageBox.Show(sql);
                    mycom.CommandText = sql;

                    mycom.CommandType = CommandType.Text;
                    //执行查询指令
                    MySqlDataReader reader = mycom.ExecuteReader();
                    if (reader.Read())
                    {
                        string roomID = reader.GetUInt16(0).ToString().PadLeft(4, '0');
                        //MessageBox.Show(roomID);
                        string beginTime = dtBeginTime.Value.ToString("yyyy-MM-dd HH:mm");
                        //MessageBox.Show(beginTime);
                        string endTime = dtEndTime.Value.ToString("yyyy-MM-dd HH:mm");
                        //MessageBox.Show(endTime);
                        string reason = rtReason.Text;

                        //释放reader的资源
                        reader.Dispose();
                        reader.Close();
                        //关闭数据库，防止数据库被锁定
                        myconn.Dispose();
                        myconn.Close();

                        //需要发送的信息
                        string strMsg = '@' + "P1" + roomID + userID + userName + beginTime + endTime + reason + "\r\n";
                        byte[] arrSendMsg = System.Text.Encoding.UTF8.GetBytes(strMsg);
                        //MessageBox.Show(strMsg);
                        socket.Send(arrSendMsg);

                        myconn.Open();

                        sql = "UPDATE reservationinfo SET roomState=NULL" +
                              " WHERE roomID=" + int.Parse(roomID) + " and " +
                              "userName=\"" + userName + "\"" + " and " +
                              "beginTime=\"" + getBeginTime + "\";";

                        mycom.CommandText = sql;

                        mycom.ExecuteNonQuery();//执行查询
                        //关闭数据库，防止数据库被锁定
                        myconn.Close();

                        myconn.Open();

                        sql = "UPDATE reservationinfo SET msgState=\"未处理\"" +
                              " WHERE roomID=" + int.Parse(roomID) + " and " +
                              "userName=\"" + userName + "\"" + " and " +
                              "beginTime=\"" + getBeginTime + "\";";
                        //ShowMsg(sql);
                        mycom.CommandText = sql;

                        mycom.ExecuteNonQuery();//执行查询
                        //关闭数据库，防止数据库被锁定
                        myconn.Close();

                        myconn.Open();

                        sql = "UPDATE reservationinfo SET passwd=NULL" + 
                              " WHERE roomID=" + int.Parse(roomID) + " and " +
                              "userName=\"" + userName + "\"" + " and " +
                              "endTime=\"" + getEndTime + "\";";
                        //ShowMsg(sql);
                        mycom.CommandText = sql;

                        mycom.ExecuteNonQuery();//执行查询
                        //关闭数据库，防止数据库被锁定
                        myconn.Close();

                        myconn.Open();

                        sql = "UPDATE reservationinfo SET beginTIme=\"" + dtBeginTime.Value.ToString("yyyy-MM-dd HH:mm") + "\"" +
                              " WHERE roomID=" + int.Parse(roomID) + " and " +
                              "userName=\"" + userName + "\"" + " and " +
                              "endTime=\"" + getEndTime + "\";";
                        //ShowMsg(sql);
                        mycom.CommandText = sql;

                        mycom.ExecuteNonQuery();//执行查询
                        //关闭数据库，防止数据库被锁定
                        myconn.Close();

                        myconn.Open();

                        sql = "UPDATE reservationinfo SET endTime=\"" + dtEndTime.Value.ToString("yyyy-MM-dd HH:mm") + "\"" +
                              " WHERE roomID=" + int.Parse(roomID) + " and " +
                              "userName=\"" + userName + "\"" + " and " +
                              "endTime=\"" + getEndTime + "\";";
                        //ShowMsg(sql);
                        mycom.CommandText = sql;

                        mycom.ExecuteNonQuery();//执行查询
                        mycom.Dispose();
                        //关闭数据库，防止数据库被锁定
                        myconn.Dispose();
                        myconn.Close();
                        getBeginTime = null;
                        getEndTime = null;
                        tbRoomName.Text = null;
                        dtBeginTime.Value = DateTime.Now;
                        dtEndTime.Value = DateTime.Now;
                        rtReason.Text = null;
                        ReLoadDataGridView();
                        ShowMsg("预约信息修改成功");
                    }
                    else
                    {
                        //释放reader的资源
                        reader.Dispose();
                        reader.Close();
                        //关闭数据库，防止数据库被锁定
                        myconn.Dispose();
                        myconn.Close();
                    }
                }
                catch (MySqlException se)
                {
                    ShowMsg(se.ToString());
                    //MessageBox.Show(se.ToString());
                    //关闭数据库，防止数据库被锁定
                    myconn.Dispose();
                    myconn.Close();
                }
            }

        }
    }
}
