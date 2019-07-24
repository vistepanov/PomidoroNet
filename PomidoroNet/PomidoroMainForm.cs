using System;
using System.Drawing;
using System.Windows.Forms;
using PomidoroNet.Properties;

namespace PomidoroNet
{
    public partial class PomidoroMainForm : Form
    {
        private int _interval;
        private bool _timerOn;
        private bool _showBalloon;
        private readonly Icon _pomidoroIcon;
        private readonly MyTimer _mt;

        public PomidoroMainForm()
        {
            InitializeComponent();
            _mt= new MyTimer(TimerEventProcessor);

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PomidoroMainForm));
            _pomidoroIcon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));

            _timerOn = false;
            _showBalloon = false;
            _interval = 25 * 60;

//            _mt.Tick += TimerEventProcessor;
//            _mt.Interval = 1000;
//            _mt.Start();
        }

        private void PomidoroMainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized) return;
            trayIcon.Visible = true;
            Visible = false;
        }
        private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            _showBalloon = !_showBalloon;
        }
        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Visible = true;
            _showBalloon = false;
            WindowState = FormWindowState.Normal;
            BringToFront();
            CenterToScreen();
        }

        private void StartTimer_Click(object sender, EventArgs e)
        {
            if (_timerOn)
            {
                _timerOn = false;
                ButtonStartTimer.Text = Resources.btn_Timer_Start;//btn_Timer_Stop
            }
            else
            {
                var initialTimer = ParseTime(timerValue.Text);
                _interval = initialTimer;
                _timerOn = true;
                ButtonStartTimer.Text = Resources.btn_Timer_Stop;//btn_Timer_Stop
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
            if (_interval > 0) return;
            SetDefaultIcon();
            TrayIcon_MouseDoubleClick(null,null);
            ButtonStartTimer.PerformClick();
        }

        private void SetDefaultIcon()
        {
            trayIcon.Icon = _pomidoroIcon;
        }

        private string GetTime()
        {
            var min = _interval / 60;
            var sec = _interval % 60;
            var text = min + " : " + ((sec < 10) ? "0" : "") + sec;
            return text;
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
        private void StartTimer(int n)
        {
            _interval = n * 60;
            timerValue.Text = GetTime();
            ButtonStartTimer.PerformClick();
        }

        private void CreateTextIcon()
        {
            // based on https://stackoverflow.com/questions/36379547/writing-text-to-the-system-tray-instead-of-an-icon/
            var str = (_interval / 60).ToString();
            var fontToUse = new Font("Microsoft Sans Serif", 16, FontStyle.Regular, GraphicsUnit.Pixel);
            var brushToUse = new SolidBrush(Color.White);
            var brushToFill = new SolidBrush(Color.Green);
            var bitmapText = new Bitmap(16, 16);
            Graphics g = System.Drawing.Graphics.FromImage(bitmapText);

            g.Clear(Color.Transparent);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            var p = (_interval % 60) * 10 / 35;
            g.FillRectangle(brushToFill, 0, 16-p, 16, p);
            g.DrawString(str, fontToUse, brushToUse, -4, -2);
            IntPtr hIcon = (bitmapText.GetHicon());
            trayIcon.Icon = System.Drawing.Icon.FromHandle(hIcon);
            //DestroyIcon(hIcon.ToInt32);
        }

        private void ButtonAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"PomidoroNet Copyright (C) 2019 Vladimir Stepanov(vladimir@stepanov.it)

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.", 
                "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}