namespace Defining_Consuming_Events
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreateNewTank = new System.Windows.Forms.Button();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnAddWater = new System.Windows.Forms.Button();
            this.txtMaxAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMinAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCurrentLevel = new System.Windows.Forms.TextBox();
            this.btnUseWater = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Amount";
            // 
            // btnCreateNewTank
            // 
            this.btnCreateNewTank.Location = new System.Drawing.Point(16, 114);
            this.btnCreateNewTank.Name = "btnCreateNewTank";
            this.btnCreateNewTank.Size = new System.Drawing.Size(305, 21);
            this.btnCreateNewTank.TabIndex = 1;
            this.btnCreateNewTank.Text = "Create New Tank";
            this.btnCreateNewTank.UseVisualStyleBackColor = true;
            this.btnCreateNewTank.Click += new System.EventHandler(this.btnCreateNewTank_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(92, 10);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(229, 20);
            this.txtAmount.TabIndex = 2;
            // 
            // btnAddWater
            // 
            this.btnAddWater.Location = new System.Drawing.Point(16, 141);
            this.btnAddWater.Name = "btnAddWater";
            this.btnAddWater.Size = new System.Drawing.Size(305, 62);
            this.btnAddWater.TabIndex = 3;
            this.btnAddWater.Text = "Add Water";
            this.btnAddWater.UseVisualStyleBackColor = true;
            this.btnAddWater.Click += new System.EventHandler(this.btnAddWater_Click);
            this.btnAddWater.MouseEnter += new System.EventHandler(this.btnAddWater_MouseEnter);
            this.btnAddWater.MouseLeave += new System.EventHandler(this.btnAddWater_MouseLeave);
            // 
            // txtMaxAmount
            // 
            this.txtMaxAmount.Location = new System.Drawing.Point(92, 36);
            this.txtMaxAmount.Name = "txtMaxAmount";
            this.txtMaxAmount.Size = new System.Drawing.Size(229, 20);
            this.txtMaxAmount.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Max Amount";
            // 
            // txtMinAmount
            // 
            this.txtMinAmount.Location = new System.Drawing.Point(92, 62);
            this.txtMinAmount.Name = "txtMinAmount";
            this.txtMinAmount.Size = new System.Drawing.Size(229, 20);
            this.txtMinAmount.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Min Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Current Level:";
            // 
            // txtCurrentLevel
            // 
            this.txtCurrentLevel.Enabled = false;
            this.txtCurrentLevel.Location = new System.Drawing.Point(92, 88);
            this.txtCurrentLevel.Name = "txtCurrentLevel";
            this.txtCurrentLevel.Size = new System.Drawing.Size(229, 20);
            this.txtCurrentLevel.TabIndex = 9;
            // 
            // btnUseWater
            // 
            this.btnUseWater.Location = new System.Drawing.Point(16, 209);
            this.btnUseWater.Name = "btnUseWater";
            this.btnUseWater.Size = new System.Drawing.Size(305, 62);
            this.btnUseWater.TabIndex = 10;
            this.btnUseWater.Text = "Use Water";
            this.btnUseWater.UseVisualStyleBackColor = true;
            this.btnUseWater.Click += new System.EventHandler(this.btnUseWater_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 342);
            this.Controls.Add(this.btnUseWater);
            this.Controls.Add(this.txtCurrentLevel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMinAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMaxAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddWater);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.btnCreateNewTank);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreateNewTank;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnAddWater;
        private System.Windows.Forms.TextBox txtMaxAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMinAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCurrentLevel;
        private System.Windows.Forms.Button btnUseWater;
    }
}

