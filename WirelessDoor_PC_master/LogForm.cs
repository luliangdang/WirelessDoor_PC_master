using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using MySql.Data.MySqlClient;

namespace WirelessDoor_PC_master
{
    public partial class LogForm : Form
    {
        IPAddress[] HOST = Dns.GetHostAddresses("k806034232.6655.la");
        private const int port = 8086;
        string database = "room";
        String username = "root";
        string passwd = "Dll960220";

        public LogForm()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.None;
        }

        //登录操作
        private void bt_login_Click(object sender, EventArgs e)
        {
            if (txBox_username.Equals("") || txBox_passwd.Equals(""))
            {
                MessageBox.Show("用户名或密码不能为空！");
            }
            else if (txBox_username.Text != "" && txBox_passwd.Text != "")
            {
                MySqlConnection myconn = new MySqlConnection("Host =localhost"
                                            + ";Database="+database
                                            +";Username="+username
                                            +";Password="+passwd + ";");
                try
                {
                    //开启连接
                    myconn.Open();
                    //新建SQL指令
                    MySqlCommand mycom = myconn.CreateCommand();
                    //添加SQL指令
                    mycom.CommandText = "SELECT * FROM user";
                    //执行查询
                    MySqlDataAdapter adap = new MySqlDataAdapter(mycom);
                    //构造SQL指令
                    string sql = string.Format("SELECT * FROM user ");

                    mycom.CommandText = sql;

                    mycom.CommandType = CommandType.Text;

                    MySqlDataReader reader = mycom.ExecuteReader();

                    int i = 0;
                    while (reader.Read())
                    {
                        if (reader[2].ToString() == txBox_username.Text && reader[3].ToString() == txBox_passwd.Text)
                        {
                            MessageBox.Show("登录成功！");
                            MessageBox.Show(reader[1].ToString());
                            //跳转界面
                            this.DialogResult = DialogResult.OK;
                            this.Hide();
                            i = 0;
                            break;
                        }
                        
                        //listView1.Items.Add(sdr[0].ToString());
                        //listView1.Items[i].SubItems.Add(sdr[1].ToString());
                        i++;
                    }
                    if (i != 0)
                    {
                        MessageBox.Show("用户名或密码错误！");
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    //释放资源，防止数据库锁住
                    myconn.Dispose();
                    //关闭连接
                    myconn.Close();
                }
                
            }
        }

        /// <summary>
        /// 限制TextBox输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextChangeNum(object sender, EventArgs e)
        {
            TextBox tbInput = (TextBox)sender;
            var reg = new Regex("^[0-9]*$");
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
                tbInput.SelectionStart = tbInput.Text.Length;    //定义输入焦点在最后一个字符
            }
        }

        /// <summary>
        /// 限制TextBox只能输入数字和a-z、A-Z、下划线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextChangedHex(object sender, EventArgs e)
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

        /// <summary>
        /// 限制TextBox只能输入中文和数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextChangedChinese(object sender, EventArgs e)
        {
            TextBox tbInput = (TextBox)sender;
            var reg = new Regex("^[\u2E80-\u9FFF0-9]*$");
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
        /// 限制文本框输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txBox_username_TextChanged(object sender, EventArgs e)
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

        /// <summary>
        /// 注册操作，进入注册界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_regist_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Hide();
        }
    }
}
