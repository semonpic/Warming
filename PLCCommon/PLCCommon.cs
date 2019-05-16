using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Net.NetworkInformation;
using WiseTech;

namespace PLCconnect
{
    public partial class PLCCommon : Form
    {
        static bool StopScan = false;
        static Exception socketexception1;

        public delegate void StopEvent();
        public static event StopEvent StopEventStart;
        public PLCCommon()
        {
            InitializeComponent();

        }
        static IPAddress ServerAddress1 = IPAddress.Parse("192.168.0.1");
        static Thread PlcThread;

        private static object lockWrite = new object();
        public static void PLC_WRITE(string SendAddress, string word,string TextNum)
        {
            lock (lockWrite)
            {
                try
                {
                    PLC_WRITE0(SendAddress, word, TextNum);
                }
                catch (Exception err)
                {
                    ATS.LCSCommon.WriteAppErrorLog(err);
                }
            }
        }
        private static void PLC_WRITE0(string SendAddress, string word, string TextNum)
        {
            TcpClient WRITE_DEMO_TCP = new TcpClient();
            NetworkStream SevStr_WRITE;
            IPAddress ServerAddress1 = IPAddress.Parse("192.168.0.2");
            IPEndPoint endpoint = new IPEndPoint(ServerAddress1, 2001);
            string command = TransLengthToString(word.ToUpper());
            string TextNumber = TransLengthToString(TextNum);//PlcWriteLength(command);
            if (SendAddress == "1770" || SendAddress == "1772")
            {
                TextNumber = "0002";
            }
            string TotalLength = PlcTotalLength(command).ToUpper();
            string Sendcommend = "500000FF03FF00" + TotalLength + "0010" + "1401" + "0000" + "D*00" + SendAddress + TextNumber + command;
            string ReceivedData = "";
            byte[] OutStream = Encoding.ASCII.GetBytes(Sendcommend);
            byte[] inStream = new byte[WRITE_DEMO_TCP.ReceiveBufferSize];


            try
            {

                //WRITE_DEMO_TCP.Connect(endpoint);
                if (!WRITE_DEMO_TCP.ConnectAsync(ServerAddress1, 2001).Wait(1000))
                {
                    throw socketexception1; // connection failure
                }
                SevStr_WRITE = WRITE_DEMO_TCP.GetStream();
                SevStr_WRITE.Write(OutStream, 0, OutStream.Length);

                SevStr_WRITE.Flush();

                if (SevStr_WRITE.CanRead)
                {

                    int iSecond = 0;
                    while (WRITE_DEMO_TCP.GetStream().DataAvailable == false && iSecond <= 10)  //DataAvailable 指示NetworkStream 上是否有可用的數據。如果可以在Stream上讀取數據，則為 true
                    {
                        Application.DoEvents();                     //處理目前在訊息佇列中的所有Windows訊息
                        Thread.Sleep(100);                         //Delay0.1 seconds
                        iSecond++;
                    }

                }
                while (SevStr_WRITE.DataAvailable)
                {
                    SevStr_WRITE.Read(inStream, 0, System.Convert.ToInt32(WRITE_DEMO_TCP.ReceiveBufferSize));
                    ReceivedData = Encoding.ASCII.GetString(inStream, 0, inStream.Length);
                    ReceivedData = ReceivedData.Replace("\0", "");
                    //textBox1.Text = ReceivedData;
                }
            }

            catch (Exception err) 
            {
                ATS.LCSCommon.WriteAppErrorLog(err);
            }

            WRITE_DEMO_TCP.Close();
            WRITE_DEMO_TCP.Dispose();

        }

        public static string PLC_READ(string SendAddress)
        {
            TcpClient READ_DEMO_TCP = new TcpClient();
            NetworkStream SevStr_READ;
            IPAddress ServerAddress1 = IPAddress.Parse("192.168.0.2");
            IPEndPoint endpoint = new IPEndPoint(ServerAddress1, 2000);
            string Sendcommend = "500000FF03FF00" + "0018" + "0010" + "0401" + "0000" + "D*00" + SendAddress + "0008";
            string ReceivedData = "";
            byte[] OutStream = Encoding.ASCII.GetBytes(Sendcommend);
            byte[] inStream = new byte[READ_DEMO_TCP.ReceiveBufferSize];
            try
            {
                if (!READ_DEMO_TCP.ConnectAsync(ServerAddress1, 2000).Wait(1000))
                {
                    throw socketexception1; // connection failure
                }
                //ClientSocket_welding.Connect(endpoint);
                SevStr_READ = READ_DEMO_TCP.GetStream();
                SevStr_READ.Write(OutStream, 0, OutStream.Length);
                SevStr_READ.Flush();
                if (SevStr_READ.CanRead)
                {

                    int iSecond = 0;
                    while (READ_DEMO_TCP.GetStream().DataAvailable == false && iSecond <= 20)  //DataAvailable 指示NetworkStream 上是否有可用的數據。如果可以在Stream上讀取數據，則為 true
                    {
                        Application.DoEvents();                     //處理目前在訊息佇列中的所有Windows訊息
                        Thread.Sleep(100);                         //Delay0.1 seconds
                        iSecond++;
                    }

                }
                while (SevStr_READ.DataAvailable)
                {
                    SevStr_READ.Read(inStream, 0, System.Convert.ToInt32(READ_DEMO_TCP.ReceiveBufferSize));
                    ReceivedData = Encoding.ASCII.GetString(inStream, 0, inStream.Length);
                    ReceivedData = ReceivedData.Replace("\0", "");
                    return Trans16To10(ReceivedData.Substring(22));
                   
                }


            }

            catch (Exception err) 
            {
                ATS.LCSCommon.WriteAppErrorLog(err);
                return "Fail";
            }
            READ_DEMO_TCP.Close();
            
            return null;



        }


        static TcpClient READ_DEMO_TCP = null;
        static NetworkStream SevStr_READ;
        static IPAddress ServerAddress_02;
        public static List<string>ScanPLC_READ(string SendAddress,string number)
        {
            if (READ_DEMO_TCP == null)
            {
                READ_DEMO_TCP = new TcpClient();
                ServerAddress_02 = IPAddress.Parse("192.168.0.2");
                IPEndPoint endpoint = new IPEndPoint(ServerAddress1, 2000);
            }

            string ReadNumber = TransLengthToString(Trans16(number));
            string Sendcommend = "500000FF03FF00" + "0018" + "0010" + "0401" + "0000" + "D*00" + SendAddress + ReadNumber;
            string ReceivedData = "";
            byte[] OutStream = Encoding.ASCII.GetBytes(Sendcommend);
            
            try
            {
                if (READ_DEMO_TCP.Connected == false)
                {
                    if (!READ_DEMO_TCP.ConnectAsync(ServerAddress_02, 2000).Wait(1000))
                    {
                        throw socketexception1; // connection failure
                    }
                }
                byte[] inStream = new byte[READ_DEMO_TCP.ReceiveBufferSize];
                //ClientSocket_welding.Connect(endpoint);
                SevStr_READ = READ_DEMO_TCP.GetStream();
                SevStr_READ.Write(OutStream, 0, OutStream.Length);
                SevStr_READ.Flush();
                if (SevStr_READ.CanRead)
                {

                    int iSecond = 0;
                    while (READ_DEMO_TCP.GetStream().DataAvailable == false && iSecond <= 30)  //DataAvailable 指示NetworkStream 上是否有可用的數據。如果可以在Stream上讀取數據，則為 true
                    {
                        Application.DoEvents();                     //處理目前在訊息佇列中的所有Windows訊息
                        Thread.Sleep(100);                         //Delay0.1 seconds
                        iSecond++;
                    }

                }
                while (SevStr_READ.DataAvailable)
                {

                    SevStr_READ.ReadAsync(inStream, 0, System.Convert.ToInt32(READ_DEMO_TCP.ReceiveBufferSize));
                   // SevStr_READ.Read(inStream, 0, System.Convert.ToInt32(READ_DEMO_TCP.ReceiveBufferSize));
                    ReceivedData = Encoding.ASCII.GetString(inStream, 0, inStream.Length);
                    ReceivedData = ReceivedData.Replace("\0", "");
                    //READ_DEMO_TCP.Close();//wyz
                    return Trans16To10List(ReceivedData.Substring(22));

                }


            }

            catch (Exception err) 
            {
                READ_DEMO_TCP = new TcpClient();
                ServerAddress_02 = IPAddress.Parse("192.168.0.2");
                IPEndPoint endpoint = new IPEndPoint(ServerAddress1, 2000);
                ATS.LCSCommon.WriteAppErrorLog(err);
                return null;
            }
            
            READ_DEMO_TCP.Close();
            READ_DEMO_TCP.Dispose();

            return null;



        }


        #region PLC字元轉換
        private static string PlcWriteLength(string SendWord)
        {
            string length = Convert.ToInt32(SendWord.Length).ToString();
            length = TransLengthToString(length);
            return length;
        }
        private static string PlcTotalLength(string SendWord)
        {
            string number = (24 + SendWord.Length).ToString();
            number = Trans16(number);
            number = TransLengthToString(number);
            return number;
        }
        public static string TransLengthToString(string SendWord)
        {
            int length = SendWord.Length;
            if (SendWord.Length < 4)
            {
                for (int i = 0; i < (4 - length); i++)
                {
                    SendWord = "0" + SendWord;
                }
            }
            return SendWord;
        }

        internal static string TransLenghtByString(string SendWord)
        {
            string TotalSend = "";
            for (int i = 0; i < SendWord.Length; i++)
            {
                TotalSend += PLCCommon.TransLengthToString(PLCCommon.Trans16(SendWord[i]));
            }
            return TotalSend;
        }

        #endregion
        #region 轉換16位元
        public static string Trans16(string SendWord)
        {
            return Convert.ToString(Convert.ToInt32(SendWord), 16);
        }
        internal static string Trans16(int SendWord)
        {
            return Convert.ToString(SendWord, 16);
        }
        #endregion
        #region 轉換16成10
        internal static string Trans16To10(string SendWord)
        {
            List<string> SendwordArray = new List<string>();
            for(int i =0;i<SendWord.Length/4;i++)
            {

                SendwordArray.Add(Convert.ToInt64(SendWord.Substring((i * 4), 4), 16).ToString());
            }

            return (Convert.ToInt32(SendWord ,16).ToString());
        }
        #endregion

        internal static List<string> Trans16To10List(string SendWord)
        {
            List<string> SendwordArray = new List<string>();
            for (int i = 0; i < SendWord.Length / 4; i++)
            {
                SendwordArray.Add(Convert.ToInt64(SendWord.Substring((i * 4), 4), 16).ToString());
              
            }

            return SendwordArray;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //WriteInClod.WriteOperator("2", "JackMing");
        }


        public static void ShowErrorInformation(string Text, string Title)
        {
            MessageBox.Show(Text, Title);
        }

        
        public static void StratSacnPlcStatus()
        {
            PlcThread = new Thread(new ThreadStart(PlcThreadTask));
            PlcThread.IsBackground = true;
            PlcThread.SetApartmentState(ApartmentState.STA);
            PlcThread.Priority = ThreadPriority.AboveNormal;
            PlcThread.Start();
        }

        public static void StopScanPlcStatus()
        {
            PlcThread.Abort();
        }

        private static void  PlcThreadTask()
        {
            do
            {
                try
                {
                    ReadSystemStatus.ScanStatus();
                }
                catch(Exception err)
                {
                    ATS.LCSCommon.WriteAppErrorLog(err);
                }
            }
            while (StopScan == false);
        }

        internal static void TaskStop()
        {
            if (StopEventStart != null)
            {
                StopEventStart();
            }
        }


      
    }
}
