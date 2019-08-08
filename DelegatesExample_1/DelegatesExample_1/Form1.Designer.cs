namespace DelegatesExample_1
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
            this.btnCallDelegate = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnOddMethod = new System.Windows.Forms.Button();
            this.btnMinMax = new System.Windows.Forms.Button();
            this.btnDelegateDivider = new System.Windows.Forms.Button();
            this.btnNuAndMu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCallDelegate
            // 
            this.btnCallDelegate.Location = new System.Drawing.Point(12, 114);
            this.btnCallDelegate.Name = "btnCallDelegate";
            this.btnCallDelegate.Size = new System.Drawing.Size(128, 31);
            this.btnCallDelegate.TabIndex = 0;
            this.btnCallDelegate.Text = "Call Add Method";
            this.btnCallDelegate.UseVisualStyleBackColor = true;
            this.btnCallDelegate.Click += new System.EventHandler(this.btnCallDelegate_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(262, 96);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // btnOddMethod
            // 
            this.btnOddMethod.Location = new System.Drawing.Point(146, 114);
            this.btnOddMethod.Name = "btnOddMethod";
            this.btnOddMethod.Size = new System.Drawing.Size(128, 31);
            this.btnOddMethod.TabIndex = 2;
            this.btnOddMethod.Text = "Call Odd Method";
            this.btnOddMethod.UseVisualStyleBackColor = true;
            this.btnOddMethod.Click += new System.EventHandler(this.btnOddMethod_Click);
            // 
            // btnMinMax
            // 
            this.btnMinMax.Location = new System.Drawing.Point(12, 151);
            this.btnMinMax.Name = "btnMinMax";
            this.btnMinMax.Size = new System.Drawing.Size(128, 31);
            this.btnMinMax.TabIndex = 3;
            this.btnMinMax.Text = "Call Min Max Method";
            this.btnMinMax.UseVisualStyleBackColor = true;
            this.btnMinMax.Click += new System.EventHandler(this.btnMinMax_Click);
            // 
            // btnDelegateDivider
            // 
            this.btnDelegateDivider.Location = new System.Drawing.Point(146, 151);
            this.btnDelegateDivider.Name = "btnDelegateDivider";
            this.btnDelegateDivider.Size = new System.Drawing.Size(128, 31);
            this.btnDelegateDivider.TabIndex = 4;
            this.btnDelegateDivider.Text = "Call Delegate divider";
            this.btnDelegateDivider.UseVisualStyleBackColor = true;
            this.btnDelegateDivider.Click += new System.EventHandler(this.btnDelegateDivider_Click);
            // 
            // btnNuAndMu
            // 
            this.btnNuAndMu.Location = new System.Drawing.Point(12, 188);
            this.btnNuAndMu.Name = "btnNuAndMu";
            this.btnNuAndMu.Size = new System.Drawing.Size(262, 31);
            this.btnNuAndMu.TabIndex = 5;
            this.btnNuAndMu.Text = "Call Nu and Mu Delegates";
            this.btnNuAndMu.UseVisualStyleBackColor = true;
            this.btnNuAndMu.Click += new System.EventHandler(this.btnNuAndMu_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 261);
            this.Controls.Add(this.btnNuAndMu);
            this.Controls.Add(this.btnDelegateDivider);
            this.Controls.Add(this.btnMinMax);
            this.Controls.Add(this.btnOddMethod);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnCallDelegate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCallDelegate;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnOddMethod;
        private System.Windows.Forms.Button btnMinMax;
        private System.Windows.Forms.Button btnDelegateDivider;
        private System.Windows.Forms.Button btnNuAndMu;
    }
}

