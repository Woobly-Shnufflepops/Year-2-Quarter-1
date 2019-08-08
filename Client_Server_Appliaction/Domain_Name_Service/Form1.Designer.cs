namespace Domain_Name_Service
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnLocalComputer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDomainName = new System.Windows.Forms.TextBox();
            this.btnGetIPAddresses = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(409, 204);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // btnLocalComputer
            // 
            this.btnLocalComputer.Location = new System.Drawing.Point(13, 222);
            this.btnLocalComputer.Name = "btnLocalComputer";
            this.btnLocalComputer.Size = new System.Drawing.Size(408, 31);
            this.btnLocalComputer.TabIndex = 1;
            this.btnLocalComputer.Text = "Get Local Computer Name && IP Address";
            this.btnLocalComputer.UseVisualStyleBackColor = true;
            this.btnLocalComputer.Click += new System.EventHandler(this.btnLocalComputer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter Domain Name";
            // 
            // txtDomainName
            // 
            this.txtDomainName.Location = new System.Drawing.Point(13, 276);
            this.txtDomainName.Name = "txtDomainName";
            this.txtDomainName.Size = new System.Drawing.Size(408, 20);
            this.txtDomainName.TabIndex = 3;
            // 
            // btnGetIPAddresses
            // 
            this.btnGetIPAddresses.Location = new System.Drawing.Point(12, 302);
            this.btnGetIPAddresses.Name = "btnGetIPAddresses";
            this.btnGetIPAddresses.Size = new System.Drawing.Size(409, 36);
            this.btnGetIPAddresses.TabIndex = 4;
            this.btnGetIPAddresses.Text = "Find IP Address of the Domain Name";
            this.btnGetIPAddresses.UseVisualStyleBackColor = true;
            this.btnGetIPAddresses.Click += new System.EventHandler(this.btnGetIPAddresses_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 350);
            this.Controls.Add(this.btnGetIPAddresses);
            this.Controls.Add(this.txtDomainName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLocalComputer);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnLocalComputer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDomainName;
        private System.Windows.Forms.Button btnGetIPAddresses;
    }
}

