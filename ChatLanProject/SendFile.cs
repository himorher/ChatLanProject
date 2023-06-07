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
    public partial class SendFile : Form
    {
        string path;
        public SendFile()
        {
            InitializeComponent();
        }
        private void sendfile(string fn)
        {
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("192.168.237.254"), 51000); // dia chi server;
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            string fileName = fn;
            byte[] fileNameByte = Encoding.ASCII.GetBytes(fileName);
            byte[] fileNameLen = BitConverter.GetBytes(fileNameByte.Length);
            byte[] fileData = File.ReadAllBytes(fileName);
            byte[] clientData = new byte[4 + fileData.Length + fileNameByte.Length];

            fileNameLen.CopyTo(clientData, 0);
            fileNameByte.CopyTo(clientData, 4);
            fileData.CopyTo(clientData, 4 + fileNameByte.Length);
            client.Connect(ipe);
            client.Send(clientData);
            client.Close();
        }
        private void button1_Click(object sender, EventArgs e) //button browse
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            path = openFileDialog.FileName;
            textBox1.Text = path;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] files = path.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            if (files != null && files.Length != 0)
            {
                //Console.WriteLine(files[0]);
                MessageBox.Show("Đã gửi file thành công");
                sendfile(files[0]);

            }
        }
    }
}
