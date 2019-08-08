namespace Lambda_Expressions
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
            this.btnEvenPositive = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInteger = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnEvenPositive
            // 
            this.btnEvenPositive.Location = new System.Drawing.Point(12, 145);
            this.btnEvenPositive.Name = "btnEvenPositive";
            this.btnEvenPositive.Size = new System.Drawing.Size(260, 34);
            this.btnEvenPositive.TabIndex = 0;
            this.btnEvenPositive.Text = "Check if even and positive";
            this.btnEvenPositive.UseVisualStyleBackColor = true;
            this.btnEvenPositive.Click += new System.EventHandler(this.btnEvenPositive_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(260, 101);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter Integer";
            // 
            // txtInteger
            // 
            this.txtInteger.Location = new System.Drawing.Point(83, 119);
            this.txtInteger.Name = "txtInteger";
            this.txtInteger.Size = new System.Drawing.Size(113, 20);
            this.txtInteger.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.txtInteger);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnEvenPositive);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEvenPositive;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInteger;
    }
}

