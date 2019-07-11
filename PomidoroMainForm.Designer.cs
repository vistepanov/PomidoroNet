namespace PomidoroNet
{
    partial class PomidoroMainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PomidoroMainForm));
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.startTimer = new System.Windows.Forms.Button();
            this.timerValue = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "PonidoroNet";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseClick);
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseDoubleClick);
            // 
            // startTimer
            // 
            this.startTimer.Location = new System.Drawing.Point(127, 12);
            this.startTimer.Name = "startTimer";
            this.startTimer.Size = new System.Drawing.Size(104, 44);
            this.startTimer.TabIndex = 0;
            this.startTimer.Text = "Start";
            this.startTimer.UseVisualStyleBackColor = true;
            this.startTimer.Click += new System.EventHandler(this.StartTimer_Click);
            // 
            // timerValue
            // 
            this.timerValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.timerValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timerValue.Location = new System.Drawing.Point(12, 37);
            this.timerValue.MaxLength = 7;
            this.timerValue.Name = "timerValue";
            this.timerValue.Size = new System.Drawing.Size(100, 19);
            this.timerValue.TabIndex = 1;
            this.timerValue.Text = "25 : 00";
            this.timerValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.timerValue.WordWrap = false;
            this.timerValue.TextChanged += new System.EventHandler(this.TimerValue_TextChanged);
            // 
            // PomidoroMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(243, 140);
            this.Controls.Add(this.timerValue);
            this.Controls.Add(this.startTimer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PomidoroMainForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PomidoroNet";
            this.Resize += new System.EventHandler(this.PomidoroMainForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.Button startTimer;
        private System.Windows.Forms.TextBox timerValue;
        private System.Windows.Forms.Timer timer1;
    }
}

