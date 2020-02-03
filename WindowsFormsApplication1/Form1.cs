using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoIt;
using System.IO;
using System.Speech;
using System.Speech.Synthesis;
using System.Threading;
using SharpOSC;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private int Radar = 0;
        private int Action = 0;
        private int Angle = 0;
        private int Person = 0;
        private int Iteration;
        private SpeechSynthesizer speaker;

        private int prevRadar = 0;
        private int prevAction = 0;
        private int prevAngle = 0;
        private int prevPerson = 0;
        private int prevIteration = 0;
        private string prevFileName = "";
        private bool filelock = false;
        private int num_devices = 6;

        // Receive buffer.  
        private static byte[] buffer = new byte[100];
        //Client Handling Sockets
        private static List<Socket> clients;
        //Client Listening Socket
        private static Socket _socket;
        //Local EndPoint
        private static IPEndPoint localEndPoint;
        //Socket Number for device; 99 for local;100 for not available
        private Socket _server = null;
        private bool isAlive = false;
        private bool heartbeat = false;
        private bool notPingedYet = true;
        Process SDRGUI;
        Process RFBeamGUI;
        private bool RFAction = false; //Lock for thread until RFBeam GUI inputs are done
        private bool Ancortek58Action= false; // Lock for thread until Ancortek is done

        public Form1()
        {
            InitializeComponent();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            button5.Enabled = false;

        //    SDRGUI = Process.Start(@"C:\Program Files (x86)\Ancortek SDR\SDR-GUI.exe", "");
         //   RFBeamGUI = Process.Start(@"C:\Program Files (x86)\RFbeam\ST200_SignalExplorer\ST200.exe", "");
       //     Thread.Sleep(500);
        //    GetRadarWindow();
    /*        AutoItX.MouseClick("left", 145, 80);
            AutoItX.Sleep(200);
            AutoItX.Send("{DOWN}");
            AutoItX.Send("{DOWN}");
            AutoItX.Send("{DOWN}");
            AutoItX.Sleep(200);
            AutoItX.Send("{ENTER}");
            AutoItX.Sleep(200);
            AutoItX.MouseClick("left", 76 , 110);
            
            AutoItX.MouseClick("left", 131 , 705);*/
            

            PopulatePerson();
            PopulateMotion();
            speaker = new SpeechSynthesizer();
            speaker.Rate = 1;
            speaker.Volume = 100;
         //   record_RFBeam(4, 0, 0, 3);
            // speaker.Speak("Specify Action");
        }

        private static void GetAppWindow()
        {
            _WinWaitActivate("Radar", "Action:", 15);
        }
        private void GetRadarWindow()
        {
            SetForegroundWindow(SDRGUI.MainWindowHandle);

        }
        private void Get77Window()
        {
            _WinWaitActivate("mmWave Studio 1.0.0.0", "", 15);
        }
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Person = listBox1.SelectedIndex;
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Action = listBox2.SelectedIndex;
        }
        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Angle = listBox3.SelectedIndex;
        }
      
        private void PopulatePerson() {

            string[] lines = System.IO.File.ReadAllLines(repo.Text+"names.txt");
            try
            {
                listBox1.Items.Clear();


                for (int index = 0; index < lines.Length; index++)
                {

                    listBox1.Items.Add(lines[index]);
                }

            }
            catch
            {
            }

        }
        private void PopulateMotion()
        {

            string[] lines = System.IO.File.ReadAllLines(repo.Text + "motions.txt");
            try
            {
                listBox2.Items.Clear();


                for (int index = 0; index < lines.Length; index++)
                {

                    listBox2.Items.Add(lines[index]);
                }

            }
            catch
            {
            }

        }


        //Get Iteration and update Iteration from file
        private int GetIteration(int Radar_n, int Action_n, int Angle_n, int Person_n) {
            while (filelock) Thread.Sleep(100);
            filelock = true;
            string path = Directory.GetCurrentDirectory();
            string[] lines = System.IO.File.ReadAllLines(repo.Text + Person_n.ToString() + ".txt");
            int it = 0;
            for (int i = 0; i < lines.Length; i++) {
                string[] words = lines[i].Split();
                if (Convert.ToInt32(words[0]) == Radar_n && Convert.ToInt32(words[1]) == Action_n && Convert.ToInt32(words[2]) == Angle_n) {
                    it = Convert.ToInt32(words[3]);
                    
                    words[3] = (it+1).ToString();
                    lines[i] = words[0] + ' ' + words[1] + ' ' + words[2] + ' ' + words[3];
                    System.Diagnostics.Debug.WriteLine(lines[i]);
                }

                System.IO.File.WriteAllLines(repo.Text + Person_n.ToString() + ".txt", lines);

            }
            filelock = false;
            return it;
        }


        //Add New Subject
        private void button1_Click(object sender, EventArgs e)
        { //Function for adding new subject
            
            DialogResult dr = new DialogResult();
            Form2 frm2 = new Form2();
            dr = frm2.ShowDialog();
            if (dr == DialogResult.OK) {
                using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(repo.Text + "names.txt", true))
                {
                    file.WriteLine(frm2.name);

                }
                PopulatePerson(); //update Names on Form

                //Create new Iteration Log for new subject
                int person_num = listBox1.Items.Count;

                int action_num = listBox2.Items.Count;
                int angle_num = listBox3.Items.Count;
                int radar_num = num_devices;

                FileStream F = new FileStream(repo.Text + (person_num - 1).ToString() + ".txt", FileMode.Create, FileAccess.ReadWrite, FileShare.Write);
                StreamWriter writer = new StreamWriter(F);
                for (int i = 0; i < radar_num; i++) {
                    for (int j = 0; j < action_num; j++) {
                        for (int k = 0; k < angle_num; k++) {
                            string text = i.ToString() + " " + j.ToString() + " " + k.ToString() + " " + 0.ToString();
                            writer.WriteLine(text);

                        }
                    }
                }
                writer.Close();
            }


        }


        private void label4_Click(object sender, EventArgs e)
        {

        }


        private static void _WinWaitActivate(string title, string text, int timeout=0) {
            AutoItX.WinWait(title, text, timeout);
            if (AutoItX.WinActive(title, text)==0) {
                AutoItX.WinActivate(title, text);
            }
            AutoItX.WinWaitActive(title, text, timeout);
        }


        //Start Recording
        private void button2_Click(object sender, EventArgs e)
        {
            //Actual Code
            //  GetIteration();
            /* GetRadarWindow();
             int seconds = Convert.ToInt32(textBox1.Text);
             AutoItX.MouseClick("left", 145, 400);
           //  AutoItX.Sleep(100);
             AutoItX.Send("^a");
             AutoItX.Send(seconds.ToString());
             AutoItX.MouseClick("left", 131, 470);
             Thread.Sleep(1000 * seconds);
             _WinWaitActivate("Save Recorded Session", "", 15);
             string name = getzero(Radar.ToString()) + getzero(Action.ToString()) + getzero(Angle.ToString()) + getzero(Person.ToString()) + "_" + getzero(Iteration.ToString());
             prevAction = Action;
             prevAngle = Angle;
             prevPerson = Person;
             prevIteration = Iteration;
             prevRadar = Radar;
             prevFileName = name +".dat";
             AutoItX.Send(name);

             for (int i = 0; i < 6; i++) {
                 AutoItX.Send("{TAB}");
             }
             AutoItX.Send("{ENTER}");
             AutoItX.Send(repo.Text);
             AutoItX.Send("{ENTER}");
             for (int i = 0; i < 9; i++){
                 AutoItX.Send("{TAB}");
             }
             AutoItX.Send("{ENTER}");
             _WinWaitActivate("Radar", "Action:", 15);
             speaker.Speak("Recording Complete");
             button5.Enabled = true;*/
            Get77Window();
            record_RFBeam(0, 0, 0, 0, 10, "212");
        }


        private string getzero(string s) {
            if (s.Length == 1) {
                return "0" + s;
            }
            else return s;
        }


        //Delayed Start Recording
        private void button3_Click(object sender, EventArgs e)
        {
            int delay = Convert.ToInt32(textBox2.Text);
            System.Threading.Thread.Sleep(delay * 1000);
            speaker.Speak("Perform action after the beep");
            System.Threading.Thread.Sleep(200);
            Console.Beep();
            button2_Click( sender,  e);
        }
        
        
        //Add New Action
        private void button4_Click(object sender, EventArgs e)
        { // Function for adding new gesture

            DialogResult dr = new DialogResult();
            Form2 frm2 = new Form2();
            dr = frm2.ShowDialog();
            if (dr == DialogResult.OK)
            {
                using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(repo.Text + "motions.txt", true))
                {
                    file.WriteLine(frm2.name);

                }
                PopulateMotion(); //update motions on Form

                //Add new iteration log for every subject for new motion
                int person_num = listBox1.Items.Count;
                int action_num = listBox2.Items.Count;
                int angle_num = listBox3.Items.Count;
                int radar_num = num_devices;

                for (int i = 0; i < person_num; i++) {
                    string path = repo.Text + i.ToString() + ".txt";
                    using (StreamWriter sw = File.AppendText(path))
                    {   for(int j=0; j < angle_num; j++)
                        {
                            for (int k = 0; k < radar_num; k++) {
                                string text = k.ToString() + " " + (action_num-1).ToString() + " " + j.ToString() + " " + 0.ToString();
                                sw.WriteLine(text);
                            }
                        }
                    }
                }
            }
        }


        //Delete Previous Recording
        private void button5_Click(object sender, EventArgs e)
        {
            string path = repo.Text + prevFileName;
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            string[] lines = System.IO.File.ReadAllLines(repo.Text+ prevPerson.ToString() + ".txt");

            for (int i = 0; i < lines.Length; i++)
            {
                string[] words = lines[i].Split();
                if (Convert.ToInt32(words[0]) == prevRadar && Convert.ToInt32(words[1]) == prevAction && Convert.ToInt32(words[2]) == prevAngle)
                {
                    prevIteration = Convert.ToInt32(words[3]);

                    words[3] = (prevIteration -1 ).ToString();
                    lines[i] = words[0] + ' ' + words[1] + ' ' + words[2] + ' ' + words[3];

                }

                System.IO.File.WriteAllLines(repo.Text + prevPerson.ToString() + ".txt", lines);

            }

            button5.Enabled = false; 



        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }


        //Heartbeat Thread
    

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void NetworkEnableButton_Click(object sender, EventArgs e)
        {
            NetworkEnableButton.Enabled = false;
            NetworkDisableButton.Enabled = true;
            NetworkStatusLabel.Text = "Connecting...";
            NetworkStatusLabel.BackColor = Color.Orange;
            NetLog("Connecting to server...");
            groupBox3.Enabled = false;
            
            IPAddress addr = IPAddress.Parse(ipBox.Text);
           
            NetLog("Server IPv4 Address: " + addr.ToString());
            NetLog("Port: 11000");
           
            SetupClient();
        }

        private void NetworkDisableButton_Click(object sender, EventArgs e)
        {
            NetworkEnableButton.Enabled = true;
            NetworkDisableButton.Enabled = false;
            NetworkStatusLabel.Text = "Disconnected";
            NetworkStatusLabel.BackColor = Color.Red;
            NetLog("Disconnected from server...");
            groupBox3.Enabled = true;
            heartbeat = false;  
            
        }

        //TCP Socket Client Setup
        private  void SetupClient() {
            isAlive = true;
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = IPAddress.Parse(ipBox.Text);
            localEndPoint = new IPEndPoint(ipAddress, 11000);
           
            _socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _socket.BeginConnect(localEndPoint, new AsyncCallback(ConnectCallback), _socket);

            heartbeat = true;
            
         //   var th = new Thread(HeartbeatThread);
         //   th.Start();
            
        }



        private void ConnectCallback(IAsyncResult AR) {
            Socket client = (Socket)AR.AsyncState;
            if (isAlive)
            {
                client.EndConnect(AR);
                Invoke(new Action(() =>
                {
                    NetworkStatusLabel.Text = "Connected";
                    NetworkStatusLabel.BackColor = Color.LawnGreen;
                }));
                Receive(client);
                byte[] sendBuffer = new byte[100];
                ushort command = 15;
                ushort send_size = 0;
                if (Ancortek58.Checked) send_size++;
                if (Kinect.Checked) send_size++;
                if (RFBeam.Checked) send_size++;
                if (LeapMotion.Checked) send_size++;
                ushort[] device_codes = new ushort[4];
                device_codes[0] = 5;
                device_codes[1] = 4;
                device_codes[2] = 2;
                device_codes[3] = 9;
                Buffer.BlockCopy(BitConverter.GetBytes((ushort)command), 0, sendBuffer, 0, 2);
                Buffer.BlockCopy(BitConverter.GetBytes((ushort)send_size), 0, sendBuffer, 2, 2);
                int j = 0;
                if (Ancortek58.Checked)
                {
                    Buffer.BlockCopy(BitConverter.GetBytes((ushort)device_codes[0]), 0, sendBuffer, 4 + j * 2, 2);
                    j++;
                }
               
                if (RFBeam.Checked)
                {
                    Buffer.BlockCopy(BitConverter.GetBytes((ushort)device_codes[1]), 0, sendBuffer, 4 + j * 2, 2);
                    j++;
                }
                if (Kinect.Checked)
                {
                    Buffer.BlockCopy(BitConverter.GetBytes((ushort)device_codes[2]), 0, sendBuffer, 4 + j * 2, 2);
                    j++;
                }
                if (LeapMotion.Checked)
                {
                    Buffer.BlockCopy(BitConverter.GetBytes((ushort)device_codes[3]), 0, sendBuffer, 4 + j * 2, 2);
                    j++;
                }

                Send(_socket, sendBuffer);
            }

        }

        private void Send(Socket client, byte[] data) {
            
            client.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), client);
        }


        private void SendCallback(IAsyncResult AR) {
            try
            {
                Socket client = (Socket)AR.AsyncState;
                int bytesSent = client.EndSend(AR);
                if (!isAlive) {
                    client.Shutdown(SocketShutdown.Both);
                    client.Close();
                }
                

            }
            catch (Exception ex) {

            }
        }

        private  void  NetLog(string text) {
            Invoke(new Action(()=>
                {
                NetworkLog.Text = NetworkLog.Text + "\r\n" + text;
            }));
        }

        private void Receive(Socket server)
        {
            try
            {
                
                
                // Begin receiving the data from the remote device.  
                server.BeginReceive(buffer, 0, buffer.Length, 0,
                    new AsyncCallback(ReceiveCallback), server );
            }
            catch (Exception e)
            {
                
            }
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            Socket server = (Socket)ar.AsyncState;
            _server = server;
            if (isAlive && _server.Connected)
            {
                // Retrieve the state object and the client socket   
                // from the asynchronous state object.  

                
                // Read data from the remote device.  
                int bytesRead = server.EndReceive(ar);
                if (bytesRead > 0)
                {
                    byte[] data = new byte[bytesRead];
                    Array.Copy(buffer, data, bytesRead);
                    ushort command = BitConverter.ToUInt16(data, 0);

                    byte[] datas = BitConverter.GetBytes((ushort)1);
                    if ((int)command == 2)
                    {
                        Invoke(new Action(() =>
                        {
                            NetworkEnableButton.Enabled = true;
                            NetworkDisableButton.Enabled = false;
                            NetworkStatusLabel.Text = "Disconnected";
                            NetworkStatusLabel.BackColor = Color.Red;
                            NetLog("Disconnected from server...");
                            groupBox3.Enabled = true;
                            heartbeat = false;
                        }));

                        return;
                    }

                    Receive(_server);
                    if ((int)command == 1)
                    {
                        if (heartbeat) Send(_server, datas);
                        else
                        {
                            Send(_server, BitConverter.GetBytes((ushort)2));
                            isAlive = false;
                        }
                    }
                    if ((int)command == 20)
                    {
                        ushort size = BitConverter.ToUInt16(data, 2);
                        ushort[] inf = new ushort[size+4];
                        NetLog("Request from server to start recording for: ");
                        for (int x = 0; x < size + 2; x++)
                        {
                            inf[x] = BitConverter.ToUInt16(data,  x * 2);
                            NetLog(inf[x].ToString());
                        }
                        ;
                        if (inf[5] == 5)
                        {
                            Thread thread = new Thread(() => record_Acortek58(inf[5], inf[3], inf[4], inf[2]));
                            thread.Start();
                        }
                        if (inf[5] == 4) {
                            long it = BitConverter.ToInt64(data, 14);
                            NetLog("Iteration:" + it.ToString());
                            Thread thread = new Thread(() => record_RFBeam(inf[5], inf[3], inf[4], inf[2],inf[6], it.ToString()));
                            thread.Start();
                        }
                        if (inf[5] == 9) {
                            Thread thread = new Thread(() => Record_Kinect(inf[5], inf[3], inf[4], inf[2], inf[6], inf[7]));
                            thread.Start();
                        }
                        if (inf[5] == 10) {
                            Thread thread = new Thread(() => Record_LeapMotion(inf[5], inf[3], inf[4], inf[2], inf[6], inf[7]));
                            thread.Start();
                        }

                    }

                }
            }
           
        }

        private void Record_Kinect(int dev, int ac, int an, int per, int it, int sec)
        { //to be filled
            string path = @"C:\Users\Sevgi\Documents\BodyBasics-WPF\bin\AnyCPU\Debug";// BodyBasics-WPF.exe";
            Process kinect;
            kinect = new Process();
            kinect.StartInfo.FileName = "cmd.exe";
            kinect.StartInfo.RedirectStandardInput = true;
            kinect.StartInfo.UseShellExecute = false;
            kinect.Start();
            string name = repo.Text + getzero((dev).ToString()) + getzero(ac.ToString()) + getzero(an.ToString()) + getzero(per.ToString()) + "_" + getzero(it.ToString()) + ".txt";
            using (StreamWriter sw = kinect.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    sw.WriteLine(@"cd " + path);
                    sw.WriteLine("BodyBasics-WPF.exe " + sec + " " + name);
                }
            }



        }

        private void Record_LeapMotion(int dev, int ac, int an, int per, int it, int sec)
        { //to be filled
            string name = getzero(dev.ToString()) + getzero(ac.ToString()) + getzero(an.ToString()) + getzero(per.ToString()) + "_" + getzero("11");
            Get77Window();
            Thread.Sleep(500);
            AutoItX.Send("{ENTER}");
            Thread.Sleep(sec);
            AutoItX.Send("{ENTER}");
            Thread.Sleep(1000);
            AutoItX.Send("{ENTER}");
            Thread.Sleep(300);
            for (int i = 0; i < 4; i++)
            {
                AutoItX.Send("{TAB}");
            }
            AutoItX.Send(name);
            for (int i = 0; i < 4; i++)
            {
                AutoItX.Send("{TAB}");
            }
            AutoItX.Send("{ENTER}");


        }

        private void record_Acortek58(int Radar_n,int Action_n, int Angle_n, int Person_n) {
            string name = getzero(Radar_n.ToString()) + getzero(Action_n.ToString()) + getzero(Angle_n.ToString()) + getzero(Person_n.ToString()) + "_" + getzero("11");
            Get77Window();
            Thread.Sleep(500);
            AutoItX.Send("{ENTER}");
            Thread.Sleep(10*1000);
            AutoItX.Send("{ENTER}");
            Thread.Sleep(1000);
            AutoItX.Send("{ENTER}");
            Thread.Sleep(300);
            for (int i = 0; i < 4; i++)
            {
                AutoItX.Send("{TAB}");
            }
            AutoItX.Send(name);
            for (int i = 0; i < 4; i++)
            {
                AutoItX.Send("{TAB}");
            }
            AutoItX.Send("{ENTER}");
        }

        private void RFBeamC_Click(object sender, EventArgs e)
        {

        }

        private void record_RFBeam(int Radar_n, int Action_n, int Angle_n, int Person_n, int seconds, String it) {
            string name = repo.Text + getzero(Radar_n.ToString()) + getzero(Action_n.ToString()) + getzero(Angle_n.ToString()) + getzero(Person_n.ToString()) + "_" +it + ".bin";
            Get77Window();
          /*   for (int i = 0; i < 33; i++)
            {
                AutoItX.Send("{TAB}");
            }
            AutoItX.Send("^a");
            AutoItX.Send((seconds*25).ToString());
            AutoItX.Send("{TAB}");
            AutoItX.Send("{TAB}");
            AutoItX.Send("{ENTER}");
            Thread.Sleep(100);
            for (int i = 0; i < 36; i++)
            {
                AutoItX.Send("+{TAB}");
            }*/
            AutoItX.Send(name);
            for (int i = 0; i < 4; i++)
            {
                AutoItX.Send("+{TAB}");
            }
            Thread.Sleep(100);
            AutoItX.Send("{ENTER}");
            Thread.Sleep(100);
            AutoItX.Send("{ENTER}");
            Thread.Sleep(100);
            AutoItX.Send("{TAB}");
            AutoItX.Send("{TAB}");
            /*       Thread.Sleep(1860);
                   AutoItX.Send("{ENTER}");
                   System.Diagnostics.Debug.WriteLine(seconds.ToString());
                   Thread.Sleep(seconds * 1000);
                   AutoItX.Send("{ENTER}");
                   Thread.Sleep(1000);
                   AutoItX.Send("{ENTER}");
                   Thread.Sleep(300);
                   for (int i = 0; i < 4; i++)
                   {
                       AutoItX.Send("{TAB}");
                   }
                   AutoItX.Send(name);
                   for (int i = 0; i < 4; i++)
                   {
                       AutoItX.Send("{TAB}");
                   }
                   AutoItX.Send("{ENTER}");*/
        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }
    }
}
