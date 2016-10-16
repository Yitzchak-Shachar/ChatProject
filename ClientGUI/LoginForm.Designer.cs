namespace ClientGUI
{
    partial class LoginForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.nickNameTxtbx = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.ColorBtn = new System.Windows.Forms.Button();
            this.colorChkbx = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.serverIPTxtbx = new System.Windows.Forms.TextBox();
            this.serverPortlbl = new System.Windows.Forms.Label();
            this.serverPortTxtbx = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Nickname";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "User Color";
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(106, 114);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(75, 23);
            this.ConnectBtn.TabIndex = 2;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // nickNameTxtbx
            // 
            this.nickNameTxtbx.Location = new System.Drawing.Point(113, 53);
            this.nickNameTxtbx.Name = "nickNameTxtbx";
            this.nickNameTxtbx.Size = new System.Drawing.Size(148, 20);
            this.nickNameTxtbx.TabIndex = 3;
            // 
            // ColorBtn
            // 
            this.ColorBtn.Location = new System.Drawing.Point(174, 82);
            this.ColorBtn.Name = "ColorBtn";
            this.ColorBtn.Size = new System.Drawing.Size(75, 23);
            this.ColorBtn.TabIndex = 2;
            this.ColorBtn.Text = "Choose";
            this.ColorBtn.UseVisualStyleBackColor = true;
            this.ColorBtn.Click += new System.EventHandler(this.ColorBtn_Click);
            // 
            // colorChkbx
            // 
            this.colorChkbx.AutoSize = true;
            this.colorChkbx.BackColor = System.Drawing.SystemColors.Window;
            this.colorChkbx.Enabled = false;
            this.colorChkbx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorChkbx.Location = new System.Drawing.Point(131, 88);
            this.colorChkbx.Name = "colorChkbx";
            this.colorChkbx.Size = new System.Drawing.Size(12, 11);
            this.colorChkbx.TabIndex = 4;
            this.colorChkbx.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Server address";
            // 
            // serverIPTxtbx
            // 
            this.serverIPTxtbx.Location = new System.Drawing.Point(113, 22);
            this.serverIPTxtbx.Name = "serverIPTxtbx";
            this.serverIPTxtbx.Size = new System.Drawing.Size(71, 20);
            this.serverIPTxtbx.TabIndex = 6;
            this.serverIPTxtbx.Text = "127.0.0.1";
            // 
            // serverPortlbl
            // 
            this.serverPortlbl.AutoSize = true;
            this.serverPortlbl.Location = new System.Drawing.Point(195, 26);
            this.serverPortlbl.Name = "serverPortlbl";
            this.serverPortlbl.Size = new System.Drawing.Size(26, 13);
            this.serverPortlbl.TabIndex = 5;
            this.serverPortlbl.Text = "Port";
            // 
            // serverPortTxtbx
            // 
            this.serverPortTxtbx.Location = new System.Drawing.Point(227, 22);
            this.serverPortTxtbx.Name = "serverPortTxtbx";
            this.serverPortTxtbx.Size = new System.Drawing.Size(34, 20);
            this.serverPortTxtbx.TabIndex = 6;
            this.serverPortTxtbx.Text = "9000";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 151);
            this.Controls.Add(this.serverPortTxtbx);
            this.Controls.Add(this.serverIPTxtbx);
            this.Controls.Add(this.serverPortlbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.colorChkbx);
            this.Controls.Add(this.nickNameTxtbx);
            this.Controls.Add(this.ColorBtn);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.TextBox nickNameTxtbx;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button ColorBtn;
        private System.Windows.Forms.CheckBox colorChkbx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox serverIPTxtbx;
        private System.Windows.Forms.Label serverPortlbl;
        private System.Windows.Forms.TextBox serverPortTxtbx;
    }
}