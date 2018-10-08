using System.Windows.Forms;

namespace Presentation
{
    partial class Form1
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
            this.SuspendLayout();
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(82, 256);
            this.messageTextBox.Multiline = true;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.ReadOnly = true;
            this.messageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.messageTextBox.Size = new System.Drawing.Size(454, 345);
            this.messageTextBox.TabIndex = 0;
            // 
            // bidTextBox
            // 
            this.bidTextBox.Location = new System.Drawing.Point(743, 404);
            this.bidTextBox.Name = "bidTextBox";
            this.bidTextBox.Size = new System.Drawing.Size(228, 26);
            this.bidTextBox.TabIndex = 1;
            // 
            // bidButton
            // 
            this.bidButton.Location = new System.Drawing.Point(786, 474);
            this.bidButton.Name = "bidButton";
            this.bidButton.Size = new System.Drawing.Size(152, 53);
            this.bidButton.TabIndex = 2;
            this.bidButton.Text = "Send Bid";
            this.bidButton.UseVisualStyleBackColor = true;
            this.bidButton.Click += new System.EventHandler(this.bidButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(86, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(356, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Vul gebruikersnaam in om te verbinden:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(274, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(697, 46);
            this.label2.TabIndex = 4;
            this.label2.Text = "Welkom bij de enige echte car auction";
            // 
            // usernameLabel
            // 
            this.usernameLabel.Location = new System.Drawing.Point(493, 145);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(163, 26);
            this.usernameLabel.TabIndex = 5;
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(743, 138);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(101, 41);
            this.connectButton.TabIndex = 6;
            this.connectButton.Text = "Verbind";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(672, 292);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(400, 37);
            this.label3.TabIndex = 7;
            this.label3.Text = "Vul bedrag in om te bieden";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 636);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bidButton);
            this.Controls.Add(this.bidTextBox);
            this.Controls.Add(this.messageTextBox);
            this.Name = "Form1";
            this.Text = "Car auction";
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
    }
}

