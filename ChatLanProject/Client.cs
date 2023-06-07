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

namespace ChatLanProject
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }
        IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("192.168.237.254"), 55000); // dia chi server;
        Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        void send(string s) // gui tin nhan
        {
            //s = textBox2.Text; message cần gửi
            string mess = "*" + textBox1.Text + ": " + s; // format = name: mess
            byte[] data = Encoding.UTF8.GetBytes(mess);
            client.Send(data);
        }

        //void receive() // nhan tin nhan
        //{
        //    try
        //    {
        //        while (true)
        //        {
        //            byte[] data = new byte[1024 * 200];
        //            client.Receive(data);
        //            string mess = Encoding.UTF8.GetString(data);
        //            listView1.Items.Add(mess);
        //        }
        //    }
        //    catch
        //    {
        //        Close();
        //    }
        //}
        private void button2_Click(object sender, EventArgs e) //button connect
        {
            CheckForIllegalCrossThreadCalls = false;
            if (textBox1.Text != "")
            {
                try
                {
                    client.Connect(ipe);
                    send(" is connected");
                }
                catch
                {
                    MessageBox.Show("Kết nối lỗi!");
                    return;
                }
                Thread listen = new Thread(receive);
                listen.Start();
                button2.Text = "Connected";
                button2.Enabled = false;
                textBox1.Enabled = false;
            }
            else MessageBox.Show("Vui lòng nhập tên!");
        }

        private void button1_Click(object sender, EventArgs e) //button send
        {
            if (textBox2.Text != "")
            {
                send(textBox2.Text);
                listView1.Items.Add(textBox1.Text + ": " + textBox2.Text);
                textBox2.Clear();
            }
            else MessageBox.Show("Vui lòng nhập tin nhắn!");
        }

        private void button3_Click(object sender, EventArgs e) //button disconnect
        {
            
            send("is disconnected");
            Close();
        }

        private void button4_Click(object sender, EventArgs e) //button attach file
        {
            SendFile client_Send_File = new SendFile();
            client_Send_File.Show();
        }
        void receive() // hàm nhận message cùng với đó là gửi message đó cho các client còn lại.
        {
            try
            {                
                while (true)
                {
                    byte[] data = new byte[1024 * 10 * 1024];
                    //byte[] data = new byte[1024 * 200];
                    client.Receive(data);
                    string mess = Encoding.UTF8.GetString(data);
                    byte[] temp = data[1..];

                    if (mess[0] == '*')
                    {
                        //string[] newmess = mess.Split(new string[] { "*" }, StringSplitOptions.RemoveEmptyEntries);
                        string mess_new = Encoding.UTF8.GetString(temp);
                        //string.Join("", newmess);
                        listView1.Items.Add(mess_new);
                    }
                    else
                    {
                        doChat(client, data);
                    }
                }
            }
            catch 
            {
                client.Close();
            }
        }
        //            try
        //    {
        //        byte[] data = new byte[1024 * 2000 * 1024];
        //        while (true)
        //        {
        //            //byte[] data = new byte[1024 * 200];
        //            client.Receive(data);
        //            string mess = Encoding.UTF8.GetString(data);
        //            byte[] temp = data[1..];

        //            if (mess[0] == '*')
        //            {
        //                //string[] newmess = mess.Split(new string[] { "*" }, StringSplitOptions.RemoveEmptyEntries);
        //                string mess_new = Encoding.UTF8.GetString(temp);
        //                //string.Join("", newmess);
        //                listView1.Items.Add(mess_new);

        //                //foreach (Socket item in listClient)
        //                //{
        //                //    if (item != null && item != cli) item.Send(temp);
        //                //}
        //            }
        //            else
        //            {
        //                doChat(client, data);
        //            }

        //        }
        //    }
        //    catch
        //    {
        //        //listClient.Remove(cli);
        //        //client.Shutdown(SocketShutdown.Both);
        //    }
        //}
        void doChat(Socket clientSocket, byte[] data) //nhan file va xu ly
        {
            try
            {
                listView1.Items.Add("Xử lý file..");
                string mess = Encoding.UTF8.GetString(data);
                //listView1.Items.Add(mess);
                int fileNameLen = BitConverter.ToInt32(data, 0);
                string fileName = Encoding.ASCII.GetString(data, 4, fileNameLen);
                string name = Path.GetFileName(fileName);
                using (var file = File.Create("D:\\testClient\\" + name))
                {
                    file.Write(data, 4 + fileNameLen, data.Length - 4 - fileNameLen);
                }
                clientSocket.Close();
                //[0]filenamelen[4]filenamebyte[*]filedata   
                listView1.Items.Add("Client đã gửi nhận file thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
