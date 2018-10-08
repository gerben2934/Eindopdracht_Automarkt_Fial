using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientGUI;

namespace Presentation
{
    public partial class Form1 : Form
    {

        private static Form1 instance;
        private TcpClient serverClient;

        public TextBox MessageTetTextBox { get; set; }

        public Form1()
        {
            InitializeComponent();
            this.MessageTetTextBox = MessageTextBox;

            MessageTextBox.AppendText("Bieding is gestart!!");

            Thread thread = new Thread(ClientThread);
            thread.Start(new Client("Ralph"));
        }

        public static Form1 GetInstance()
        {
            if (instance == null)
                instance = new Form1();
            return instance;
        }

        static void ClientThread(object obj)
        {
            Client client = obj as Client;
            client.Receive();
        }

        public void SendClient(TcpClient client)
        {
            serverClient = client;
        }

        public void UpdateTextBox(string message)
        {
            MessageTextBox.Invoke((Action)(() =>
            {
                MessageTextBox.AppendText("\r\n" + message + "\r\n");
            }));
        }
    }
}
