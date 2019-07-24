using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LyncStatus;
using PomidoroNet.Properties;

namespace PomidoroNet
{
    public partial class PomidoroMainForm : Form
    {
        private bool _showBalloon;
        private readonly Icon _pomidoroIcon;
        private readonly MyTimer _mt;
        private List<IMessengerStatus> _messengers;

        public PomidoroMainForm()
        {
            InitializeComponent();
            _showBalloon = false;
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(PomidoroMainForm));
            _pomidoroIcon = (Icon) resources.GetObject("trayIcon.Icon");

            _mt = new MyTimer(TimerEventProcessor);
            _messengers = FindPlugin();
        }

        private List<IMessengerStatus> FindPlugin()
        {
            var list = new List<IMessengerStatus> {new Lync13Status()};
            return list;
        }


        private void Stop()
        {
            _mt.Enabled = false;
        }

        private void Start()
        {
            _mt.StartTimer(ParseTime(timerValue.Text));
        }

        private static int ParseTime(string timerValueText)
        {
            var timeArray = timerValueText.Split(':');
            int min;
            var sec = 0;

            switch (timeArray.Length)
            {
                case 1:
                    int.TryParse(timeArray[0], out min);
                    break;
                case 2:
                    int.TryParse(timeArray[0], out min);
                    int.TryParse(timeArray[1], out sec);
                    break;
                default:
                    return 0;
            }

            return min * 60 + sec;
        }

        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            if (!_mt.Enabled) return;
            _mt.RemainTimer--;

            trayIcon.BalloonTipText = GetTime();
            if (_showBalloon)
            {
                SetDefaultIcon();
                timerValue.Text = GetTime();
                trayIcon.ShowBalloonTip(1);
            }
            else
            {
                CreateTextIcon();
            }

            if (_mt.RemainTimer > 0) return;
            SetDefaultIcon();
            TrayIcon_MouseDoubleClick(null, null);
            ButtonStartTimer.PerformClick();
        }

        private void SetDefaultIcon()
        {
            trayIcon.Icon = _pomidoroIcon;
        }

        private string GetTime()
        {
            var min = _mt.RemainTimer / 60;
            var sec = _mt.RemainTimer % 60;
            var text = min + " : " + ((sec < 10) ? "0" : "") + sec;
            return text;
        }

        private void StartTimer(int n)
        {
            _mt.RemainTimer = n * 60;
            timerValue.Text = GetTime();
            ButtonStartTimer.PerformClick();
        }

        private void CreateTextIcon()
        {
            // based on https://stackoverflow.com/questions/36379547/writing-text-to-the-system-tray-instead-of-an-icon/
            var str = (_mt.RemainTimer / 60).ToString();
            var fontToUse = new Font("Microsoft Sans Serif", 16, FontStyle.Regular, GraphicsUnit.Pixel);
            var brushToUse = new SolidBrush(Color.White);
            var brushToFill = new SolidBrush(Color.Green);
            var bitmapText = new Bitmap(16, 16);
            Graphics g = Graphics.FromImage(bitmapText);

            g.Clear(Color.Transparent);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            var p = (_mt.RemainTimer % 60) * 10 / 35;
            g.FillRectangle(brushToFill, 0, 16 - p, 16, p);
            g.DrawString(str, fontToUse, brushToUse, -4, -2);
            IntPtr hIcon = (bitmapText.GetHicon());
            trayIcon.Icon = Icon.FromHandle(hIcon);
            //DestroyIcon(hIcon.ToInt32);
        }

        #region Form Events

        private void PomidoroMainForm_Resize(object sender, EventArgs e)
        {
            Visible = (WindowState != FormWindowState.Minimized);
        }

        private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            _showBalloon = !_showBalloon;
        }

        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _showBalloon = false;
            WindowState = FormWindowState.Normal;
            CenterToScreen();
            BringToFront();
        }

        private void StartTimer_Click(object sender, EventArgs e)
        {
            if (_mt.Enabled)
            {
                Stop();
                ButtonStartTimer.Text = Resources.btn_Timer_Start; //btn_Timer_Stop
            }
            else
            {
                ButtonStartTimer.Text = Resources.btn_Timer_Stop; //btn_Timer_Stop
                WindowState = FormWindowState.Minimized;
                Start();
            }
        }

        private void ButtonT25_Click(object sender, EventArgs e)
        {
            StartTimer(25);
        }


        private void ButtonT10_Click(object sender, EventArgs e)
        {
            StartTimer(10);
        }

        private void ButtonT5_Click(object sender, EventArgs e)
        {
            StartTimer(5);
        }

        private void ButtonAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Resources.AboutText,
                Resources.AboutHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

    }
}