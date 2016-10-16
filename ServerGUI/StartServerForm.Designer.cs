namespace ServerGUI
{
    partial class StartServerForm
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
            this.serverPortTxtbx = new System.Windows.Forms.TextBox();
            this.serverIPTxtbx = new System.Windows.Forms.TextBox();
            this.serverPortlbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.StartBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // serverPortTxtbx
            // 
            this.serverPortTxtbx.Location = new System.Drawing.Point(115, 52);
            this.serverPortTxtbx.Name = "serverPortTxtbx";
            this.serverPortTxtbx.Size = new System.Drawing.Size(34, 20);
            this.serverPortTxtbx.TabIndex = 10;
            this.serverPortTxtbx.Text = "9000";
            // 
            // serverIPTxtbx
            // 
            this.serverIPTxtbx.Location = new System.Drawing.Point(115, 26);
            this.serverIPTxtbx.Name = "serverIPTxtbx";
            this.serverIPTxtbx.Size = new System.Drawing.Size(71, 20);
            this.serverIPTxtbx.TabIndex = 11;
            this.serverIPTxtbx.Text = "127.0.0.1";
            // 
            // serverPortlbl
            // 
            this.serverPortlbl.AutoSize = true;
            this.serverPortlbl.Location = new System.Drawing.Point(31, 56);
            this.serverPortlbl.Name = "serverPortlbl";
            this.serverPortlbl.Size = new System.Drawing.Size(59, 13);
            this.serverPortlbl.TabIndex = 8;
            this.serverPortlbl.Text = "Server port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Server address";
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(83, 84);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(75, 23);
            this.StartBtn.TabIndex = 7;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // StartServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 129);
            this.Controls.Add(this.serverPortTxtbx);
            this.Controls.Add(this.serverIPTxtbx);
            this.Controls.Add(this.serverPortlbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.StartBtn);
            this.Name = "StartServerForm";
            this.Text = "Start server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox serverPortTxtbx;
        private System.Windows.Forms.TextBox serverIPTxtbx;
        private System.Windows.Forms.Label serverPortlbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button StartBtn;
    }
}