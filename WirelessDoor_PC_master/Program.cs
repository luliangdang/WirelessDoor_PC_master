using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WirelessDoor_PC_master
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new LogForm());
            while (true)
            {
                LogForm logform = new LogForm();
                logform.ShowDialog();

                //登录成功，进入主界面
                if (logform.DialogResult == DialogResult.OK)
                {
                    logform.DialogResult = DialogResult.None;
                    //Application.Run(new MainForm());
                    return;
                }
                //未注册，进入注册界面
                else if (logform.DialogResult == DialogResult.Yes)
                {
                    logform.DialogResult = DialogResult.None;
                    Application.Run(new RegistForm());
                }
                //关闭界面，退出程序
                else if (logform.DialogResult == DialogResult.Cancel)
                {
                    //释放界面资源
                    logform.Dispose();
                    return;
                }
            }
        }
    }
}
