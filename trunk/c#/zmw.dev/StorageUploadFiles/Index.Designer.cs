namespace StorageUploadFiles
{
    partial class Index
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
            this.Account = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.OK = new System.Windows.Forms.Button();
            this.Https = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Account
            // 
            this.Account.Location = new System.Drawing.Point(118, 45);
            this.Account.Multiline = true;
            this.Account.Name = "Account";
            this.Account.Size = new System.Drawing.Size(249, 21);
            this.Account.TabIndex = 0;
            this.Account.Text = "Account";
            this.Account.TextChanged += new System.EventHandler(this.Account_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(118, 101);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(249, 19);
            this.textBox2.TabIndex = 1;
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(292, 218);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 2;
            this.OK.Text = "button1";
            this.OK.UseVisualStyleBackColor = true;
            // 
            // Https
            // 
            this.Https.AutoSize = true;
            this.Https.Location = new System.Drawing.Point(310, 150);
            this.Https.Name = "Https";
            this.Https.Size = new System.Drawing.Size(52, 16);
            this.Https.TabIndex = 3;
            this.Https.Text = "Https";
            this.Https.UseVisualStyleBackColor = true;
            this.Https.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 296);
            this.Controls.Add(this.Https);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.Account);
            this.Name = "Index";
            this.Text = "Storage";
            this.Load += new System.EventHandler(this.Index_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Account;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.CheckBox Https;
    }
}