namespace Powers_Task_Cancellation_Simple
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnRunTask = new System.Windows.Forms.Button();
            this.btnCancelTask = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(13, 13);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(538, 212);
            this.listBox1.TabIndex = 0;
            // 
            // btnRunTask
            // 
            this.btnRunTask.Location = new System.Drawing.Point(13, 232);
            this.btnRunTask.Name = "btnRunTask";
            this.btnRunTask.Size = new System.Drawing.Size(199, 57);
            this.btnRunTask.TabIndex = 1;
            this.btnRunTask.Text = "Run Task";
            this.btnRunTask.UseVisualStyleBackColor = true;
            this.btnRunTask.Click += new System.EventHandler(this.btnRunTask_Click);
            // 
            // btnCancelTask
            // 
            this.btnCancelTask.Location = new System.Drawing.Point(352, 231);
            this.btnCancelTask.Name = "btnCancelTask";
            this.btnCancelTask.Size = new System.Drawing.Size(199, 57);
            this.btnCancelTask.TabIndex = 2;
            this.btnCancelTask.Text = "Cancel Task";
            this.btnCancelTask.UseVisualStyleBackColor = true;
            this.btnCancelTask.Click += new System.EventHandler(this.btnCancelTask_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 433);
            this.Controls.Add(this.btnCancelTask);
            this.Controls.Add(this.btnRunTask);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnRunTask;
        private System.Windows.Forms.Button btnCancelTask;
    }
}

