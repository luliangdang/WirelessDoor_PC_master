using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WirelessDoor_PC_master
{
    public partial class ReservationForm : Form
    {
        //数据库信息
        string database = "room";
        string username = "root";
        string passwd = "Dll960220";
        //string passwd = "LL960220";

        string userName = null;

        public ReservationForm(string str1)
        {
            InitializeComponent();
            userName = str1;
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
            ReLoadDataGridView();
        }

        /// <summary>
        /// 重载dataGridView数据
        /// </summary>
        private void ReLoadDataGridView()
        {
            MySqlConnection myconn = new MySqlConnection("Host =localhost" +
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
                    dgvReservation.Rows[index].Cells[0].Value = reader.GetString(1);   //会议室名称
                    dgvReservation.Rows[index].Cells[1].Value = reader.GetString(3);   //处理状况
                    dgvReservation.Rows[index].Cells[2].Value = reader.GetString(4);   //验证码
                    dgvReservation.Rows[index].Cells[3].Value = reader.GetString(7);   //开始时间
                    dgvReservation.Rows[index].Cells[4].Value = reader.GetString(8);   //结束时间
                    dgvReservation.Rows[index].Cells[5].Value = reader.GetString(9);   //申请理由
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
    }
}
