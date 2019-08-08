namespace List_Extension_Methods
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
            this.btnFirstOddNegative = new System.Windows.Forms.Button();
            this.btn7charAorB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFirstOddNegative
            // 
            this.btnFirstOddNegative.Location = new System.Drawing.Point(70, 226);
            this.btnFirstOddNegative.Name = "btnFirstOddNegative";
            this.btnFirstOddNegative.Size = new System.Drawing.Size(125, 23);
            this.btnFirstOddNegative.TabIndex = 0;
            this.btnFirstOddNegative.Text = "First Odd Negative";
            this.btnFirstOddNegative.UseVisualStyleBackColor = true;
            this.btnFirstOddNegative.Click += new System.EventHandler(this.btnFirstOddNegative_Click);
            // 
            // btn7charAorB
            // 
            this.btn7charAorB.Location = new System.Drawing.Point(70, 197);
            this.btn7charAorB.Name = "btn7charAorB";
            this.btn7charAorB.Size = new System.Drawing.Size(125, 23);
            this.btn7charAorB.TabIndex = 1;
            this.btn7charAorB.Text = "7+ characters, a or b";
            this.btn7charAorB.UseVisualStyleBackColor = true;
            this.btn7charAorB.Click += new System.EventHandler(this.btn7charAorB_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btn7charAorB);
            this.Controls.Add(this.btnFirstOddNegative);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFirstOddNegative;
        private System.Windows.Forms.Button btn7charAorB;
    }
}

