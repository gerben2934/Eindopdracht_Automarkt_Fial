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

        public TextBox MessageTextBox { get; set; }
        public TextBox UsernameTextBox { get; set; }
        public Button ConnectButton { get; set; }
        public TextBox BidTextBox { get; set; }

        public Form1()
        {
            InitializeComponent();
            this.MessageTextBox = messageTextBox;
            this.UsernameTextBox = usernameLabel;
            this.ConnectButton = connectButton;
            this.BidTextBox = bidTextBox;

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
            messageTextBox.Invoke((Action)(() =>
            {
                messageTextBox.AppendText("\r\n" + message + "\r\n");
            }));
        }

        private void UsernameLabel_TextChanged(object sender, EventArgs e)
        {

        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            ConnectButton.Enabled = false;
            Thread thread = new Thread(ClientThread);
            thread.Start(new Client(username));

            messageTextBox.AppendText(username + " is verbonden!");
        }

        private void bidButton_Click(object sender, EventArgs e)
        {
            if (connectButton.Enabled == false)
            {

            }
            else
            {
                MessageBox.Show("Maak eerst verbinding!", "Error!");
            }
        }
    }
}
