using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.Remoting.Messaging;
namespace MyDelegateBeginInvoke
{
    public partial class DelegateForm : Form
    {
        private bool flag;
        private ManualResetEvent mTimeoutObject;
        private delegate bool ConfigWarnInfoForTelNumsHandler(out string statusString);
        public DelegateForm()
        {
            InitializeComponent();
            InitVariable();
        }

        private void InitVariable()
        {
            flag = false;
            mTimeoutObject = new ManualResetEvent(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flag = false;
            label1.Text = "启动";
            ConfigWarnInfoForTelNumsHandler configWarnInfoForTelNumsHandler = ConfigWarnInfoForTelNumsHandlerProcess;
            string statusString = string.Empty;
            configWarnInfoForTelNumsHandler.BeginInvoke(out statusString, ConfigWarnInfoForTelNumsHandlerProcessCallBack, null);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            flag = true;
            mTimeoutObject.Reset();
        }

        private bool ConfigWarnInfoForTelNumsHandlerProcess(out string statusString)
        {
            mTimeoutObject.Reset();
            if (mTimeoutObject.WaitOne(10000))//等待5秒
            {
                if (flag)
                {
                    statusString = "成功";
                    return true;
                }
                else
                {
                    statusString = "失败";
                    return false;
                }
            }
            else
            {
                statusString = "超时";
                return false;
            }
        }

        private void ConfigWarnInfoForTelNumsHandlerProcessCallBack(IAsyncResult ar)
        {
            if (InvokeRequired)
            {
                Invoke(new AsyncCallback(ConfigWarnInfoForTelNumsHandlerProcessCallBack), ar);
            }
            else
            {
               ConfigWarnInfoForTelNumsHandler configWarnInfoForTelNumsAction = ((AsyncResult)ar).AsyncDelegate
                   as ConfigWarnInfoForTelNumsHandler;
               string failureStatus = string.Empty;
               //当使用BeginInvoke异步调用方法时，如果方法未执行完，EndInvoke方法就会一直阻塞，直到被调用的方法执行完毕
               if (configWarnInfoForTelNumsAction.EndInvoke(out failureStatus, ar))
               {
                   label1.Text = "预警手机号信息配置成功！";
               }
               else
               {
                   label1.Text = "预警手机号信息配置失败！"+failureStatus;
               }
            }
        }

    }
}
