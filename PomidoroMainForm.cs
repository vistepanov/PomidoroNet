using System;
using System.Windows.Forms;

namespace PomidoroNet
{
    public partial class PomidoroMainForm : Form
    {
        private int _interval;
        private bool _timerOn;
        private bool _showBalloon;

        public PomidoroMainForm()
        {
            InitializeComponent();
            _timerOn = false;
            _showBalloon = false;
            _interval = 25 * 60;

            timer1.Tick += new EventHandler(TimerEventProcessor);
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState != FormWindowState.Minimized) return;
            WindowState = FormWindowState.Normal;
            Visible = true;
        }

        private void PomidoroMainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized) return;
            trayIcon.Visible = true;
            Visible = false;
        }

        private void StartTimer_Click(object sender, EventArgs e)
        {
            if (_timerOn)
            {
                _timerOn = false;
                startTimer.Text = "Start";
            }
            else
            {
                var initialTimer = ParseTime(timerValue.Text);
                _timerOn = true;
                startTimer.Text = "Stop";
                WindowState = FormWindowState.Minimized;
            }
        }

        private int ParseTime(string timerValueText)
        {
            var timeArray = timerValueText.Split(':');
            var min = 0;
            var sec = 0;

            if (timeArray.Length == 0) return 0;
            if (timeArray.Length == 1)
            {
                int.TryParse(timeArray[0], out min);
            } else if (timeArray.Length == 2)
            {
                int.TryParse(timeArray[0], out min);
                int.TryParse(timeArray[1], out sec);
            }

            return min * 60 + sec;
        }

        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            if (!_timerOn) return;
            _interval--;
            timerValue.Text = GetTime();
            trayIcon.BalloonTipText = GetTime();
            if (_showBalloon)
                trayIcon.ShowBalloonTip(1);
            if (_interval <= 0)
            {
                _timerOn = false;
                WindowState = FormWindowState.Normal;
            }
        }

        private string GetTime()
        {
            var min = _interval / 60;
            var sec = _interval % 60;
            var text = min + " : " + ((sec < 10) ? "0" : "") + sec;
            return text;
        }

        private void TimerValue_TextChanged(object sender, EventArgs e)
        {
//            int.TryParse(Text, out var value);
//            Text = value.ToString();
        }

        private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            _showBalloon = !_showBalloon;
        }
    }
}