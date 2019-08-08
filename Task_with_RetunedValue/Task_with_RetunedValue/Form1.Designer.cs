namespace Task_with_RetunedValue
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
            this.btnRunTaskWithReturnValue = new System.Windows.Forms.Button();
            this.btnUILockCheck = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(13, 13);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(520, 186);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // btnRunTaskWithReturnValue
            // 
            this.btnRunTaskWithReturnValue.Location = new System.Drawing.Point(13, 206);
            this.btnRunTaskWithReturnValue.Name = "btnRunTaskWithReturnValue";
            this.btnRunTaskWithReturnValue.Size = new System.Drawing.Size(220, 45);
            this.btnRunTaskWithReturnValue.TabIndex = 1;
            this.btnRunTaskWithReturnValue.Text = "Run a Task with a return value";
            this.btnRunTaskWithReturnValue.UseVisualStyleBackColor = true;
            this.btnRunTaskWithReturnValue.Click += new System.EventHandler(this.btnRunTaskWithReturnValue_Click);
            // 
            // btnUILockCheck
            // 
            this.btnUILockCheck.Location = new System.Drawing.Point(313, 205);
            this.btnUILockCheck.Name = "btnUILockCheck";
            this.btnUILockCheck.Size = new System.Drawing.Size(220, 45);
            this.btnUILockCheck.TabIndex = 2;
            this.btnUILockCheck.Text = "Click to check if UI is locked";
            this.btnUILockCheck.UseVisualStyleBackColor = true;
            this.btnUILockCheck.Click += new System.EventHandler(this.btnUILockCheck_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(310, 253);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "x=?";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 257);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(220, 45);
            this.button1.TabIndex = 4;
            this.button1.Text = "Use ContinueWith To avoid locking the UI because of the Task.Result property";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 395);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUILockCheck);
            this.Controls.Add(this.btnRunTaskWithReturnValue);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnRunTaskWithReturnValue;
        private System.Windows.Forms.Button btnUILockCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}

