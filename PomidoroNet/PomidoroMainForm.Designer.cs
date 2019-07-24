namespace PomidoroNet
{
    public partial class PomidoroMainForm
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
            this.ButtonStartTimer = new System.Windows.Forms.Button();
            this.timerValue = new System.Windows.Forms.TextBox();
            this.buttonT25 = new System.Windows.Forms.Button();
            this.buttonT10 = new System.Windows.Forms.Button();
            this.buttonT5 = new System.Windows.Forms.Button();
            this.ButtonAbout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "PomidoroNet";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseClick);
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseDoubleClick);
            // 
            // ButtonStartTimer
            // 
            this.ButtonStartTimer.Location = new System.Drawing.Point(146, 37);
            this.ButtonStartTimer.Name = "ButtonStartTimer";
            this.ButtonStartTimer.Size = new System.Drawing.Size(85, 28);
            this.ButtonStartTimer.TabIndex = 0;
            this.ButtonStartTimer.Text = "Start";
            this.ButtonStartTimer.UseVisualStyleBackColor = true;
            this.ButtonStartTimer.Click += new System.EventHandler(this.StartTimer_Click);
            // 
            // timerValue
            // 
            this.timerValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.timerValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timerValue.Location = new System.Drawing.Point(40, 40);
            this.timerValue.MaxLength = 7;
            this.timerValue.Name = "timerValue";
            this.timerValue.Size = new System.Drawing.Size(100, 19);
            this.timerValue.TabIndex = 1;
            this.timerValue.Text = "25 : 00";
            this.timerValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.timerValue.WordWrap = false;
            // 
            // buttonT25
            // 
            this.buttonT25.Location = new System.Drawing.Point(12, 71);
            this.buttonT25.Name = "buttonT25";
            this.buttonT25.Size = new System.Drawing.Size(47, 26);
            this.buttonT25.TabIndex = 2;
            this.buttonT25.Text = "25";
            this.buttonT25.UseVisualStyleBackColor = true;
            this.buttonT25.Click += new System.EventHandler(this.ButtonT25_Click);
            // 
            // buttonT10
            // 
            this.buttonT10.Location = new System.Drawing.Point(65, 71);
            this.buttonT10.Name = "buttonT10";
            this.buttonT10.Size = new System.Drawing.Size(47, 26);
            this.buttonT10.TabIndex = 3;
            this.buttonT10.Text = "10";
            this.buttonT10.UseVisualStyleBackColor = true;
            this.buttonT10.Click += new System.EventHandler(this.ButtonT10_Click);
            // 
            // buttonT5
            // 
            this.buttonT5.Location = new System.Drawing.Point(118, 71);
            this.buttonT5.Name = "buttonT5";
            this.buttonT5.Size = new System.Drawing.Size(47, 26);
            this.buttonT5.TabIndex = 4;
            this.buttonT5.Text = "5";
            this.buttonT5.UseVisualStyleBackColor = true;
            this.buttonT5.Click += new System.EventHandler(this.ButtonT5_Click);
            // 
            // ButtonAbout
            // 
            this.ButtonAbout.Location = new System.Drawing.Point(176, 71);
            this.ButtonAbout.Name = "ButtonAbout";
            this.ButtonAbout.Size = new System.Drawing.Size(55, 26);
            this.ButtonAbout.TabIndex = 5;
            this.ButtonAbout.Text = "?";
            this.ButtonAbout.UseVisualStyleBackColor = true;
            this.ButtonAbout.Click += new System.EventHandler(this.ButtonAbout_Click);
            // 
            // PomidoroMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(243, 140);
            this.Controls.Add(this.ButtonAbout);
            this.Controls.Add(this.buttonT5);
            this.Controls.Add(this.buttonT10);
            this.Controls.Add(this.buttonT25);
            this.Controls.Add(this.timerValue);
            this.Controls.Add(this.ButtonStartTimer);
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
        private System.Windows.Forms.Button ButtonStartTimer;
        private System.Windows.Forms.TextBox timerValue;
        private System.Windows.Forms.Button buttonT25;
        private System.Windows.Forms.Button buttonT10;
        private System.Windows.Forms.Button buttonT5;
        private System.Windows.Forms.Button ButtonAbout;
    }
}

