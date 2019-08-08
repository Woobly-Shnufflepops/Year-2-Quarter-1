namespace Nested_Tasks_Powers
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
            this.btnPrintNums = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(13, 13);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(411, 160);
            this.listBox1.TabIndex = 0;
            // 
            // btnPrintNums
            // 
            this.btnPrintNums.Location = new System.Drawing.Point(13, 180);
            this.btnPrintNums.Name = "btnPrintNums";
            this.btnPrintNums.Size = new System.Drawing.Size(170, 43);
            this.btnPrintNums.TabIndex = 1;
            this.btnPrintNums.Text = "Print numbers to screen";
            this.btnPrintNums.UseVisualStyleBackColor = true;
            this.btnPrintNums.Click += new System.EventHandler(this.btnPrintNums_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 365);
            this.Controls.Add(this.btnPrintNums);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnPrintNums;
    }
}

