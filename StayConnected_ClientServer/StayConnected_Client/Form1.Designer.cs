namespace StayConnected_Client
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.rchtxtbxResponse = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRequest = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPortNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSendReceive = new System.Windows.Forms.Button();
            this.btnCloseConnection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(12, 250);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(337, 30);
            this.btnConnect.TabIndex = 17;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // rchtxtbxResponse
            // 
            this.rchtxtbxResponse.Location = new System.Drawing.Point(12, 164);
            this.rchtxtbxResponse.Name = "rchtxtbxResponse";
            this.rchtxtbxResponse.Size = new System.Drawing.Size(337, 80);
            this.rchtxtbxResponse.TabIndex = 16;
            this.rchtxtbxResponse.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Response from server";
            // 
            // txtRequest
            // 
            this.txtRequest.Location = new System.Drawing.Point(15, 95);
            this.txtRequest.Name = "txtRequest";
            this.txtRequest.Size = new System.Drawing.Size(334, 20);
            this.txtRequest.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Request to server";
            // 
            // txtPortNumber
            // 
            this.txtPortNumber.Location = new System.Drawing.Point(110, 32);
            this.txtPortNumber.Name = "txtPortNumber";
            this.txtPortNumber.Size = new System.Drawing.Size(131, 20);
            this.txtPortNumber.TabIndex = 12;
            this.txtPortNumber.Text = "8000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Server Port No";
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(110, 6);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(239, 20);
            this.txtIPAddress.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Server IP Address";
            // 
            // btnSendReceive
            // 
            this.btnSendReceive.Location = new System.Drawing.Point(12, 286);
            this.btnSendReceive.Name = "btnSendReceive";
            this.btnSendReceive.Size = new System.Drawing.Size(337, 30);
            this.btnSendReceive.TabIndex = 18;
            this.btnSendReceive.Text = "Send/Receive";
            this.btnSendReceive.UseVisualStyleBackColor = true;
            this.btnSendReceive.Click += new System.EventHandler(this.btnSendReceive_Click);
            // 
            // btnCloseConnection
            // 
            this.btnCloseConnection.Location = new System.Drawing.Point(12, 322);
            this.btnCloseConnection.Name = "btnCloseConnection";
            this.btnCloseConnection.Size = new System.Drawing.Size(337, 30);
            this.btnCloseConnection.TabIndex = 19;
            this.btnCloseConnection.Text = "Close Connection with Server";
            this.btnCloseConnection.UseVisualStyleBackColor = true;
            this.btnCloseConnection.Click += new System.EventHandler(this.btnCloseConnection_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 364);
            this.Controls.Add(this.btnCloseConnection);
            this.Controls.Add(this.btnSendReceive);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.rchtxtbxResponse);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRequest);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPortNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIPAddress);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.RichTextBox rchtxtbxResponse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRequest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPortNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSendReceive;
        private System.Windows.Forms.Button btnCloseConnection;
    }
}

