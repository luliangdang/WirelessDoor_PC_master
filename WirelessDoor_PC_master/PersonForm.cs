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
    public partial class PersonForm : Form
    {
        //数据库信息
        string host = "47.100.28.6";
        string database = "room";
        string username = "root";
        //string passwd = "Dll960220";
        string passwd = "LL960220";

        string Passwd = null;
        string QQ = null;
        string Mail = null;

        public PersonForm(string userName, string userID)
        {
            InitializeComponent();
            tbUserName.Text = userName;
            tbTel.Text = userID;
        }

        private void PersonForm_Load(object sender, EventArgs e)
        {
            Laod_Date();
        }

        private void Laod_Date()
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
                string sql = string.Format("SELECT * FROM userinfo WHERE tel=\""+ tbTel.Text +"\";");
                mycom.CommandText = sql;

                mycom.CommandType = CommandType.Text;
                //执行查询指令
                MySqlDataReader reader = mycom.ExecuteReader();

                if (reader.Read())
                {
                    Passwd = reader.GetString(3);
                    Mail = reader.GetString(7);
                    QQ = reader.GetString(6);

                    tbQQ.Text = QQ;
                    tbMail.Text = Mail;
                    dtBirthday.Value = Convert.ToDateTime(reader.GetString(8));
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
                MessageBox.Show(sqle.ToString());
                //关闭数据库，防止数据库被锁定
                myconn.Dispose();
                myconn.Close();
            }
        }

        private void btSet_Click(object sender, EventArgs e)
        {
            MySqlConnection myconn = new MySqlConnection("Host=" + host +
                                                         ";Database=" + database +
                                                         ";Username=" + username +
                                                         ";Password=" + passwd + ";");
            if (tbPasswd.Text == tbCheck.Text && tbPasswd.Text != "" && tbCheck.Text != "")
            {
                try
                {
                    //连接数据库
                    myconn.Open();
                    //新建SQL指令
                    MySqlCommand mycom = myconn.CreateCommand();
                    string sql = string.Format("");
                    //更新密码
                    sql = "UPDATE userinfo SET passwd=\"" + tbPasswd.Text + "\" WHERE tel=\"" + tbTel.Text + "\";";
                    //MessageBox.Show(sql);
                    mycom.CommandText = sql;

                    //MySqlTransaction transacter = myconn.BeginTransaction();
                    //mycom.Transaction = transacter;

                    mycom.ExecuteNonQuery();//执行查询
                    //transacter.Commit();//提交
                    myconn.Close();

                    myconn.Open();
                    mycom = myconn.CreateCommand();
                    //更新QQ
                    sql = "UPDATE userinfo SET qq=\"" + tbQQ.Text + "\" WHERE tel=\"" + tbTel.Text + "\";";
                    //MessageBox.Show(sql);
                    mycom.CommandText = sql;

                    mycom.ExecuteNonQuery();//执行查询
                    //transacter.Commit();//提交
                    myconn.Close();

                    //连接数据库
                    myconn.Open();
                    //新建SQL指令
                    mycom = myconn.CreateCommand();
                    //更新邮箱
                    sql = "UPDATE userinfo SET email=\"" + tbMail.Text + "\" WHERE tel=\"" + tbTel.Text + "\";";
                    //MessageBox.Show(sql);
                    mycom.CommandText = sql;

                    //MySqlTransaction transacter = myconn.BeginTransaction();
                    //mycom.Transaction = transacter;

                    mycom.ExecuteNonQuery();//执行查询
                    //transacter.Commit();//提交
                    myconn.Close();

                    myconn.Open();
                    mycom = myconn.CreateCommand();
                    //更新生日
                    sql = "UPDATE userinfo SET birthday=\"" + dtBirthday.Value.ToString("yyyy年MM月dd日") + "\" WHERE tel=\"" + tbTel.Text + "\";";
                    //MessageBox.Show(sql);
                    mycom.CommandText = sql;

                    mycom.ExecuteNonQuery();//执行查询
                    //transacter.Commit();//提交

                    mycom.Dispose();//释放reader使用的资源，防止database is lock异常产生
                    //关闭数据库，防止数据库被锁定
                    myconn.Dispose();
                    myconn.Close();
                    MessageBox.Show("个人信息修改成功!");
                    tbPasswd.Text = "";
                    tbCheck.Text = "";
                }
                catch (MySqlException se)
                {
                    //MessageBox.Show(se.ToString());
                    //关闭数据库，防止数据库被锁定
                    myconn.Dispose();
                    myconn.Close();
                    MessageBox.Show("个人信息修改失败!");
                }
            }
            else
            {
                MessageBox.Show("两次密码输入不一致！");
                tbPasswd.Text = "";
                tbCheck.Text = "";
            }


        }
    }
}
