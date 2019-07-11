using System;
using System.Windows.Forms;

namespace PomidoroNet
{
    public partial class PomidoroMainForm : Form
    {
        private int _interval;
        private bool _timerOn;

        public PomidoroMainForm()
        {
            InitializeComponent();
            _timerOn = false;
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
                Text = "Start";
            }
            else
            {
                _timerOn = true;
                Text = "Stop";
                WindowState = FormWindowState.Minimized;
            }
        }

        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            if (!_timerOn) return;
            _interval--;
            timerValue.Text = GetTime();
            trayIcon.BalloonTipText = GetTime();
            trayIcon.ShowBalloonTip(1);
            if (_interval <= 0) _timerOn = false;
        }

        private string GetTime()
        {
            var min = _interval / 60;
            var sec = _interval % 60;
            return min + " : " + sec;
        }

        private void TimerValue_TextChanged(object sender, EventArgs e)
        {
//            int.TryParse(Text, out var value);
//            Text = value.ToString();
        }
    }
}