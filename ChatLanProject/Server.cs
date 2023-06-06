using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Logging;
using System.IO;

namespace ChatLanProject
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
        }
        IPEndPoint ipe = new IPEndPoint(IPAddress.Any, 55000);
        Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<Socket> listClient = new List<Socket>();

        void connect() // hàm dùng để kết nối với các client
        {
            server.Bind(ipe);
            Thread listen = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        server.Listen(100);
                        Socket client = server.Accept();
                        //listView1.Items.Add("Client is connected");
                        listClient.Add(client);
                        Thread receive_thr = new Thread(receive);
                        receive_thr.Start(client);
                    }
                }
                catch
                {
                    IPEndPoint ipe = new IPEndPoint(IPAddress.Any, 55000);
                    Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                }

            });
            listen.Start();
        }
        void receive(object obj) // hàm nhận message cùng với đó là gửi message đó cho các client còn lại.
        {
            // Socket cli = obj as Socket;
            Socket cli = (Socket)obj;
            try
            {
                byte[] data = new byte[1024 * 200];
                while (true)
                {
                    //byte[] data = new byte[1024 * 200];
                    cli.Receive(data);
                    string mess = Encoding.UTF8.GetString(data);
                    byte[] temp = data[1..];
                    
                    if (mess[0] == '*')
                    {
                       //string[] newmess = mess.Split(new string[] { "*" }, StringSplitOptions.RemoveEmptyEntries);
                        string mess_new = Encoding.UTF8.GetString(data);
                        //string.Join("", newmess);
                        listView1.Items.Add(mess_new);
                        
                        foreach (Socket item in listClient)
                        {
                            if (item != null && item != cli) item.Send(temp);
                        }
                    }
                    else
                    {
                        doChat(cli, data);
                    }

                }
            }
            catch
            {
                listClient.Remove(cli);
                cli.Close();
            }
        }
        void doChat(Socket clientSocket, byte[] data) //nhan file va xu ly
        {
            try
            {
                //byte[] clientData = new byte[1024 * 1024 * 5];
                //clientSocket.Receive(clientData);
                //int receivedBytesLen = clientSocket.Receive(clientData);
                string mess = Encoding.UTF8.GetString(data);
                listView1.Items.Add(mess);
                int fileNameLen = BitConverter.ToInt32(data, 0);
                string fileName = Encoding.ASCII.GetString(data, 4, fileNameLen);
                string name = Path.GetFileName(fileName);
                using (var file = File.Create("D:\\test\\" + name))
                {
                    file.Write(data, 4 + fileNameLen, data.Length - 4 - fileNameLen);
                }
                //BinaryWriter bWrite = new BinaryWriter(File.Open(fileName, FileMode.Create));
                //bWrite.Write(clientData, 4 + fileNameLen, receivedBytesLen - 4 - fileNameLen);
                listView1.Items.Add("file sent!");
                //bWrite.Close();
                clientSocket.Close();
                //[0]filenamelen[4]filenamebyte[*]filedata   
                listView1.Items.Add("getting files..");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Add("Server is ready...");
            connect();
        }
    }
}
