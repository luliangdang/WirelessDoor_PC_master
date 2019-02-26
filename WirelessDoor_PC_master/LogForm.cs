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
        //数据库信息
        //string host = "localhost";
        string host = "47.100.28.6";
        string database = "room";
        string username = "root";
        //string passwd = "Dll960220";
        string passwd = "LL960220";

        public LogForm()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.None;
        }

        /// <summary>
        /// 登录操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_login_Click(object sender, EventArgs e)
        {
            if (txBox_username.Equals("") || txBox_passwd.Equals(""))
            {
                MessageBox.Show("用户名或密码不能为空！");
            }
            else if (txBox_username.Text != "" && txBox_passwd.Text != "")
            {
                MySqlConnection myconn = new MySqlConnection("Host =" + host
                                            + ";Database="+database
                                            +";Username="+username
                                            +";Password="+passwd + ";");
                try
                {
                    //开启连接
                    myconn.Open();
                    //新建SQL指令
                    MySqlCommand mycom = myconn.CreateCommand();
                    //构造SQL指令
                    string sql = string.Format("SELECT * FROM userinfo WHERE authority=" + txBox_username.Text +";");

                    //MessageBox.Show(sql);
                    mycom.CommandText = sql;

                    mycom.CommandType = CommandType.Text;
                    //执行查询指令
                    MySqlDataReader reader = mycom.ExecuteReader();
                    
                    if (reader.Read())
                    {
                        //MessageBox.Show(reader[0].ToString());
                        if (reader.GetString(3).ToString() == txBox_passwd.Text)
                        {
                            //跳转界面
                            this.DialogResult = DialogResult.OK;
                            this.Hide();
                            MainForm mainForm = new MainForm(txBox_username.Text, reader.GetString(1));
                            mainForm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("用户名或密码错误！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("用户名不存在！");
                    }
                    //释放reader的资源
                    reader.Dispose();
                    reader.Close();
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
        /// 限制只能输入数字、大小字母、下划线
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
