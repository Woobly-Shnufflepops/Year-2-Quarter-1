namespace Powers_Task_Cancellation_Lab_Assignment
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
            this.btnRunTask = new System.Windows.Forms.Button();
            this.rchtxtbxFileOutput = new System.Windows.Forms.RichTextBox();
            this.btnCancelTask = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRunTask
            // 
            this.btnRunTask.Location = new System.Drawing.Point(13, 279);
            this.btnRunTask.Name = "btnRunTask";
            this.btnRunTask.Size = new System.Drawing.Size(188, 33);
            this.btnRunTask.TabIndex = 0;
            this.btnRunTask.Text = "Run Task";
            this.btnRunTask.UseVisualStyleBackColor = true;
            this.btnRunTask.Click += new System.EventHandler(this.btnRunTask_Click);
            // 
            // rchtxtbxFileOutput
            // 
            this.rchtxtbxFileOutput.Location = new System.Drawing.Point(13, 13);
            this.rchtxtbxFileOutput.Name = "rchtxtbxFileOutput";
            this.rchtxtbxFileOutput.Size = new System.Drawing.Size(526, 260);
            this.rchtxtbxFileOutput.TabIndex = 1;
            this.rchtxtbxFileOutput.Text = "";
            // 
            // btnCancelTask
            // 
            this.btnCancelTask.Location = new System.Drawing.Point(351, 279);
            this.btnCancelTask.Name = "btnCancelTask";
            this.btnCancelTask.Size = new System.Drawing.Size(188, 33);
            this.btnCancelTask.TabIndex = 2;
            this.btnCancelTask.Text = "Cancel Task";
            this.btnCancelTask.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 429);
            this.Controls.Add(this.btnCancelTask);
            this.Controls.Add(this.rchtxtbxFileOutput);
            this.Controls.Add(this.btnRunTask);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRunTask;
        private System.Windows.Forms.RichTextBox rchtxtbxFileOutput;
        private System.Windows.Forms.Button btnCancelTask;
    }
}

