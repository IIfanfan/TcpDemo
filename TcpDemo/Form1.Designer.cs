namespace TcpDemo
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.LoglistBox = new System.Windows.Forms.ListBox();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnConnection = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtSendMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoglistBox
            // 
            this.LoglistBox.FormattingEnabled = true;
            this.LoglistBox.HorizontalScrollbar = true;
            this.LoglistBox.ItemHeight = 12;
            this.LoglistBox.Location = new System.Drawing.Point(412, 23);
            this.LoglistBox.Name = "LoglistBox";
            this.LoglistBox.ScrollAlwaysVisible = true;
            this.LoglistBox.Size = new System.Drawing.Size(479, 424);
            this.LoglistBox.TabIndex = 6;
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(119, 23);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(100, 21);
            this.txtIp.TabIndex = 7;
            this.txtIp.Text = "192.168.1.249";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "ip地址";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "端口号";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(119, 67);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 21);
            this.txtPort.TabIndex = 9;
            this.txtPort.Text = "10002";
            // 
            // btnConnection
            // 
            this.btnConnection.Location = new System.Drawing.Point(58, 116);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(90, 33);
            this.btnConnection.TabIndex = 11;
            this.btnConnection.Text = "连接";
            this.btnConnection.UseVisualStyleBackColor = true;
            this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(178, 116);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 33);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "断开";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtSendMessage
            // 
            this.txtSendMessage.Location = new System.Drawing.Point(58, 232);
            this.txtSendMessage.Name = "txtSendMessage";
            this.txtSendMessage.Size = new System.Drawing.Size(100, 21);
            this.txtSendMessage.TabIndex = 9;
            this.txtSendMessage.Text = "1234";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(178, 225);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(90, 33);
            this.btnSend.TabIndex = 11;
            this.btnSend.Text = "发送消息";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 536);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnConnection);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSendMessage);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIp);
            this.Controls.Add(this.LoglistBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LoglistBox;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnConnection;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtSendMessage;
        private System.Windows.Forms.Button btnSend;
    }
}

