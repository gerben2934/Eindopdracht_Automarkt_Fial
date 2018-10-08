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
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.BidTextBox = new System.Windows.Forms.TextBox();
            this.BidButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.Location = new System.Drawing.Point(40, 27);
            this.MessageTextBox.Multiline = true;
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.Size = new System.Drawing.Size(464, 403);
            this.MessageTextBox.TabIndex = 0;
            // 
            // BidTextBox
            // 
            this.BidTextBox.Location = new System.Drawing.Point(710, 236);
            this.BidTextBox.Name = "BidTextBox";
            this.BidTextBox.Size = new System.Drawing.Size(228, 26);
            this.BidTextBox.TabIndex = 1;
            // 
            // BidButton
            // 
            this.BidButton.Location = new System.Drawing.Point(750, 311);
            this.BidButton.Name = "BidButton";
            this.BidButton.Size = new System.Drawing.Size(152, 53);
            this.BidButton.TabIndex = 2;
            this.BidButton.Text = "Send Bid";
            this.BidButton.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(654, 58);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(350, 26);
            this.textBox1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 479);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BidButton);
            this.Controls.Add(this.BidTextBox);
            this.Controls.Add(this.MessageTextBox);
            this.Name = "Form1";
            this.Text = "Car auction";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MessageTextBox;
        private System.Windows.Forms.TextBox BidTextBox;
        private System.Windows.Forms.Button BidButton;
        private System.Windows.Forms.TextBox textBox1;
    }
}

