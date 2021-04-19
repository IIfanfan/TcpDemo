using HslCommunication.Serial;
using RP.ScoutRobot.Common;
using RP.ScoutRobot.Communication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TcpDemo
{
    public partial class Form1 : Form
    {
        private bool boolClose;
        Socket socketSend;
        public Form1()
        {
            InitializeComponent();
        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
            LoglistBox.Items.Clear();
          
        }
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="str"></param>
        void ShowMsg(string str)
        {
            writeListBox(str);
        }
        /// <summary>
        /// socket发送
        /// </summary>
        /// <param name="msg"></param>
        void send(string msg)
        {
            writeListBox("发送内容：" + msg);
            try
            {
                //byte[] buffer = new byte[1024 * 1024 * 3];
                //buffer = Encoding.UTF8.GetBytes(msg)
                /**
                 * 
                 * 接触网
                SocketDateStruct data = new SocketDateStruct();
                data.devId = "ID133";
                data.temperature = -12;
                data.valueB = 11;
                data.accelerationX = 33;
                data.accelerationY = 44;
                data.accelerationZ = 55;
                data.pitchAngle = 180;
                data.rollAngle = 120;
                data.headingAngle = 90;
                //data.isAlarm = 1;
                //byte[] sendStruct = MarshalHelper.StructToBytes(data);
                //byte[] mybtye = SoftCRC16.CRC16(sendStruct);
                //socketSend.Send(mybtye);

                byte[] zhaiTeacherDate = new byte[] { 0x00, 0x0D, 0xC9, 0x42, 0x01, 0x47, 0x7F, 0xEF, 0x00, 0x00, 0x03, 0xB2, 0xCF, 0x00, 0x3B, 0x00, 0x79, 0x00, 0x5C, 0x00, 0x20, 0xF9, 0x24, 0x3D, 0x00, 0x00, 0x00, 0xF2, 0xFF };
                byte[] mybtye = SoftCRC16.CRC16(zhaiTeacherDate);
                socketSend.Send(mybtye);
                */
                //byte[] zhaiTeacherDate = new byte[] { 0x00, 0x0D};
                //byte[] mybtye = SoftCRC16.CRC16(zhaiTeacherDate);
                //socketSend.Send(mybtye);

                //Array.Copy(sendStruct, sendStruct.Length, mybtye,0,  mybtye.Length);
                //发送数据
                //byte[] sendData = new byte[sendStruct.Length + 2];

                //sendData[sendData.Length - 1] = DataCheck(sendData);

                //Agv测试
                R_CarStatus r_CarStatus = new R_CarStatus();
                r_CarStatus.AgvCarId = "123";
                r_CarStatus.CarAction = 1;
                r_CarStatus.CarState = 1;
                r_CarStatus.PositionX = 12.01f;
                 
                byte[] sendStruct = MarshalHelper.StructToBytes(r_CarStatus);
                sendStruct[0] = 255;
                sendStruct[1] = 3;
                sendStruct[2] = 0;
                sendStruct[5] = 49;
                byte[] mybtye = SoftCRC16.CRC16(sendStruct);
                socketSend.Send(mybtye);
            }
            catch { }
        }

        /// <summary>
        /// 通信结果枚举
        /// </summary>
        public enum CommunicationResultEnum
        {
            /// <summary>
            /// 成功
            /// </summary>
            Success = 1,
            /// <summary>
            /// 未连接
            /// </summary>
            NoConnection = 2,
            /// <summary>
            /// 接收超时
            /// </summary>
            RecieveTimeout = 3,
            /// <summary>
            /// 接收数据异常
            /// </summary>
            RecieveException = 4,
            /// <summary>
            /// 数据错误
            /// </summary>
            DataError = 5,
            /// <summary>
            /// 校验错误
            /// </summary>
            CheckError = 6,
            /// <summary>
            /// 数据格式错误
            /// </summary>
            FormatError = 7
        }
        /// <summary>
        /// 接收小车状态结构体
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct R_CarStatus
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
            public string AgvCarId;//Agv小车编号
            public byte CarState;  //小车运行状态
            public byte PlayState;  //动作运行状态
            public byte CarAction;  //执行动作状态
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
            public string MapId;//地图标识
            public float PositionX;  //坐标X
            public float PositionY;  //坐标Y
            public float PositionZ;  //坐标Z
            public float RollAngle;  //横滚角
            public float RotationAngle;  //旋转角
            public float PitchAngle;  //俯仰角
        }

        /// <summary>
        /// AGV小车命令枚举
        /// </summary>
        public enum AGVCommandEnum
        {
            /// <summary>
            /// 上传参数
            /// </summary>
            UploadParameter = 1,
            /// <summary>
            /// 下发参数
            /// </summary>
            DownloadParameter = 2,
            /// <summary>
            /// 小车状态
            /// </summary>
            CarStatus = 3,
            /// <summary>
            /// 小车硬件状态
            /// </summary>
            HardwareStatus = 4,
            /// <summary>
            /// 小车动作
            /// </summary>
            CarAction = 5,
            /// <summary>
            /// 上传小车地图
            /// </summary>
            UploadMap = 6,
            /// <summary>
            /// 下发小车地图
            /// </summary>
            DownloadMap = 7,
            /// <summary>
            /// 导航
            /// </summary>
            Navigation = 8
        }
        /// <summary>
        /// 接收数据结果
        /// </summary>
        public class RecieveResult
        {
            /// <summary>
            /// 通信结果
            /// </summary>
            public CommunicationResultEnum Result { get; set; }

            /// <summary>
            /// 命令
            /// </summary>
            public AGVCommandEnum Command { get; set; }

            /// <summary>
            /// 数据
            /// </summary>
            public object Data { get; set; }

            /// <summary>
            /// 生成错误结果
            /// </summary>
            /// <param name="result"></param>
            /// <returns></returns>
            public static RecieveResult ErrorResult(CommunicationResultEnum result)
            {
                return new RecieveResult()
                {
                    Result = result,
                };
            }
        }


        /// <summary>
        /// 计算校验和
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte DataCheck(byte[] data)
        {
            int crc = 0;
            for (int i = 0; i < data.Length - 1; i++)
            {
                crc += data[i];
            }

            return (byte)(crc % 256);
        }
        /// <summary>
        /// 接收服务端返回的消息
        /// </summary>
        void Received()
        {
            while (true)
            {
                byte[] buffer = new byte[1024 * 1024 * 3];
                //实际接收到的有效字节数
                int len = socketSend.Receive(buffer);
                if (len == 0)
                {
                    break;
                }
                string str = Encoding.UTF8.GetString(buffer, 0, len);
               
                ShowMsg("收到" + socketSend.RemoteEndPoint + ":" + str);

                Thread.Sleep(2);
            }
        }
        public void writeListBox(string s)
        {
            this.Invoke((MethodInvoker)delegate {
                if (LoglistBox.Items.Count >= 50)
                    LoglistBox.Items.Clear();
                LoglistBox.Items.Add(s);
            });

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (boolClose)
            {
                socketSend.Disconnect(boolClose);
            }
        }
        /// <summary>
        /// 连接服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnection_Click(object sender, EventArgs e)
        {
            try
            {
                //创建客户端Socket，获得远程ip和端口号
                socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ip = IPAddress.Parse(txtIp.Text);
                IPEndPoint point = new IPEndPoint(ip, Convert.ToInt32(txtPort.Text));
                socketSend.Connect(point);
                writeListBox("连接成功!");

                //开启新的线程，不停的接收服务器发来的消息
                Thread c_thread = new Thread(Received);
                c_thread.IsBackground = true;
                c_thread.Start();
                boolClose = true;

            }
            catch (Exception)
            {
                writeListBox("连接失败,关闭界面重新连接！！");
                boolClose = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            socketSend.Disconnect(boolClose);
            writeListBox("连接断开！！");
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            send(txtSendMessage.Text);
        }
    }
}
