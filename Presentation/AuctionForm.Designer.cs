using System.Windows.Forms;

namespace Presentation
{
    partial class AuctionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.bidTextBox = new System.Windows.Forms.TextBox();
            this.bidButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.userCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(55, 166);
            this.messageTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.messageTextBox.Multiline = true;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.ReadOnly = true;
            this.messageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.messageTextBox.Size = new System.Drawing.Size(304, 341);
            this.messageTextBox.TabIndex = 0;
            this.messageTextBox.WordWrap = false;
            // 
            // bidTextBox
            // 
            this.bidTextBox.Location = new System.Drawing.Point(464, 253);
            this.bidTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bidTextBox.Name = "bidTextBox";
            this.bidTextBox.Size = new System.Drawing.Size(153, 20);
            this.bidTextBox.TabIndex = 1;
            // 
            // bidButton
            // 
            this.bidButton.Enabled = false;
            this.bidButton.Location = new System.Drawing.Point(495, 320);
            this.bidButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bidButton.Name = "bidButton";
            this.bidButton.Size = new System.Drawing.Size(101, 34);
            this.bidButton.TabIndex = 2;
            this.bidButton.Text = "Send Bid";
            this.bidButton.UseVisualStyleBackColor = true;
            this.bidButton.Click += new System.EventHandler(this.bidButton_ClickAsync);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 94);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Vul gebruikersnaam in om te verbinden:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(123, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(494, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = "Welkom bij de Nederlandse Auto Veiling";
            // 
            // usernameLabel
            // 
            this.usernameLabel.Location = new System.Drawing.Point(329, 94);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(110, 20);
            this.usernameLabel.TabIndex = 5;
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(455, 90);
            this.connectButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(67, 27);
            this.connectButton.TabIndex = 6;
            this.connectButton.Text = "Verbind";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(420, 183);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(272, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "Vul bedrag in om te bieden";
            // 
            // userCount
            // 
            this.userCount.AutoSize = true;
            this.userCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.userCount.Location = new System.Drawing.Point(57, 125);
            this.userCount.Name = "userCount";
            this.userCount.Size = new System.Drawing.Size(92, 17);
            this.userCount.TabIndex = 8;
            this.userCount.Text = "Deelnemers: ";
            // 
            // AuctionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 543);
            this.Controls.Add(this.userCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bidButton);
            this.Controls.Add(this.bidTextBox);
            this.Controls.Add(this.messageTextBox);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AuctionForm";
            this.Text = "Auto veiling";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.TextBox bidTextBox;
        private System.Windows.Forms.Button bidButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox usernameLabel;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label label3;
        private Label userCount;
    }
}

