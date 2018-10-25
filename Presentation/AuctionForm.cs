using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientGUI;
using SharedData;
using SharedData.Packets;

namespace Presentation
{
    public partial class AuctionForm : Form
    {
        private static AuctionForm instance;
        private Client _client;

        public AuctionForm()
        {
            InitializeComponent();
        }

        public static AuctionForm GetInstance()
        {
            instance = instance ?? new AuctionForm();
            return instance;
        }

        public void UpdateCar(Car car)
        {
            UpdateLabel(BrandLabel, car.Brand);
            UpdateLabel(ModelLabel, car.Model);
            UpdateLabel(DescriptionLabel, car.Description);
            UpdateLabel(MillageLabel, car.Mileage.ToString() + " km");
            UpdateLabel(ColorLabel, car.Color);
            UpdateLabel(YearLabel, car.Year.ToString());
            UpdateLabel(FuelTypeLabel, car.CarFuelType.ToString());
        }
        private void UpdateLabel(Label label, string text)
        {
            label.Invoke(new MethodInvoker(delegate { label.Text = text; }));
            //Console.WriteLine("Nieuwe text: " + label.Text);
        }

        private void UpdateTextBox(TextBox textBox, string text)
        {
            textBox.Invoke(new MethodInvoker(delegate { messageTextBox.AppendText("\r\n" + text + "\r\n"); }));
            //Console.WriteLine("Nieuwe text: " + label.Text);
        }

        public void UpdateTextBox(string message)
        {
            UpdateTextBox(messageTextBox, message);
        }

        public void UpdateTimeBox(string message)
        {
            instance.messageTextBox.Invoke((Action)(() => { textBoxTimeMessage.Text = message; }));
            if (message.Equals("00:00"))
            {
                instance.Bieden.Enabled = false;
            }
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            instance.connectButton.Enabled = false;
            _client = new Client(instance.usernameLabel.Text);

            instance.messageTextBox.AppendText("Je neemt deel aan deze veiling!");
            instance.Bieden.Enabled = true;
        }

        private void bidButton_ClickAsync(object sender, EventArgs e)
        {
            if (connectButton.Enabled == false)
            {
                string amountS = instance.bidTextBox.Text;
                amountS = System.Text.RegularExpressions.Regex.Replace(amountS, "[^0-9.]", "");
                if(amountS.Length == 0)
                {
                    MessageBox.Show(null, "Bedrag invullen!", "Vul een bedrag in!");
                    return;
                }
                int amountI = Convert.ToInt32(amountS);
                instance.bidTextBox.Text = "";
                Bid bid = new Bid(_client.Username, _client.CurrentCar.CarID, amountI, DateTime.Now);
                MessageUtil.SendMessage(new BidMessage(bid), _client.Socket.GetStream());
            }
            else
            {
                MessageBox.Show("Maak eerst verbinding!", "Error!");
            }
        }
    }
}