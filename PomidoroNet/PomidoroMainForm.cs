using LyncStatus;
using PomidoroInterfaces;
using PomidoroNet.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PomidoroNet
{
    public partial class PomidoroMainForm : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern bool DestroyIcon(IntPtr handle);

        private bool _showBalloon;
        private readonly Icon _pomidoroIcon;
        private readonly MyTimer _mt;
        private readonly List<IMessengerStatus> _messengers;
        private int _blink;
        private IntPtr _hIcon;

        public PomidoroMainForm()
        {
            InitializeComponent();
            _showBalloon = false;
            _blink = 0;
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(PomidoroMainForm));
            _pomidoroIcon = (Icon) resources.GetObject("trayIcon.Icon");

            _mt = new MyTimer(TimerEventProcessor);
            _messengers = FindPlugin();
        }

        private List<IMessengerStatus> FindPlugin()
        {
            var list = new List<IMessengerStatus> {new Lync13Status()};
            foreach (IMessengerStatus messenger in list) messenger.GetInitialStatus();
            return list;
        }


        private void Stop()
        {
            ButtonStartTimer.Text = Resources.btn_Timer_Start; //btn_Timer_Stop
            _mt.StopTimer();
            SetDefaultIcon();

            RestoreStatus();
        }

        private void Start()
        {
            ButtonStartTimer.Text = Resources.btn_Timer_Stop; //btn_Timer_Stop
            _mt.StartTimer(ParseTime(timerValue.Text));
            SetStatus(MessengerStatus.DoNotDisturb);
            WindowState = FormWindowState.Minimized;
        }

        private void RestoreStatus()
        {
            foreach (IMessengerStatus messenger in _messengers) messenger.RestoreInitialStatus();
        }
        private void SetStatus(MessengerStatus status)
        {
            foreach (IMessengerStatus messenger in _messengers)
            {
                messenger.SetStatus(status);
            }
        }
        private void SetText(string text)
        {
            foreach (IMessengerStatus messenger in _messengers)
            {
                messenger.SetText(text);
            }
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
            if (_blink > 0)
            {
                MakeBlink();
                return;
            }

            if (!_mt.Enabled) return;

            var time = GetTime();
            trayIcon.BalloonTipText = time;
            timerValue.Text = time;
            SetText(time);
            if (_showBalloon)
            {
                SetDefaultIcon();
                trayIcon.ShowBalloonTip(1);
            }
            else
            {

                try
                {
                    DestroyIcon(_hIcon);
                    _hIcon = CreateTextIcon(_mt.Minutes(), _mt.Seconds());
                    trayIcon.Icon = Icon.FromHandle(_hIcon);
                }
                catch
                {
                    SetDefaultIcon();
                }
            }

            if (_mt.ReduceTimer()) return;
            TrayIcon_MouseDoubleClick(null, null);
            _mt.ResetTimer();
            timerValue.Text = GetTime();
            _blink = 4;
            Stop();
        }

        private void MakeBlink()
        {
            _blink--;
            FormBorderStyle = (_blink % 2 == 0) ? FormBorderStyle.Fixed3D : FormBorderStyle.FixedSingle;
        }

        private void SetDefaultIcon()
        {
            trayIcon.Icon = _pomidoroIcon;
        }

        private string GetTime()
        {
            var min = _mt.Minutes();
            var sec = _mt.Seconds();
            var text = min + " : " + ((sec < 10) ? "0" : "") + sec;
            return text;
        }

        private void StartTimer(int n)
        {
            _mt.RemainTimer = n * 60;
            timerValue.Text = GetTime();
            Start();
        }

        private IntPtr CreateTextIcon(int minutes, int second)
        {
            // based on https://stackoverflow.com/questions/36379547/writing-text-to-the-system-tray-instead-of-an-icon/
            var str = minutes.ToString();
            var fontToUse = new Font("Microsoft Sans Serif", 16, FontStyle.Regular, GraphicsUnit.Pixel);
            var brushToUse = new SolidBrush(Color.White);
            var brushToFill = new SolidBrush(Color.Green);
            var bitmapText = new Bitmap(16, 16);
            Graphics g = Graphics.FromImage(bitmapText);

            g.Clear(Color.Transparent);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            var p = second * 10 / 35;
            g.FillRectangle(brushToFill, 0, 16 - p, 16, p);
            g.DrawString(str, fontToUse, brushToUse, -4, -2);
            return bitmapText.GetHicon();
        }
        private void ShowWindow()
        {
            Visible = true;
            WindowState = FormWindowState.Normal;
            CenterToScreen();
            BringToFront();
            Activate();
        }


        #region Form Events

        private void PomidoroMainForm_Resize(object sender, EventArgs e)
        {
            Visible = (WindowState != FormWindowState.Minimized);
        }

        private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (!_mt.Enabled)
            {
                _showBalloon = false;
                ShowWindow();
                return;
            }
            _showBalloon = !_showBalloon;
        }

        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _showBalloon = false;
            ShowWindow();
        }

        private void StartTimer_Click(object sender, EventArgs e)
        {
            if (_mt.Enabled)
            {
                Stop();
            }
            else
            {
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


        private void PomidoroMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        #endregion
    }
}