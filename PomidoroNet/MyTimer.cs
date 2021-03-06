﻿using System;

namespace PomidoroNet
{
    class MyTimer : System.Windows.Forms.Timer
    {
        private bool _run;

        public MyTimer(EventHandler e)
        {
            Tick += e;
            Interval = 1000;
            base.Enabled = true;
            Start();
            _run = false;
        }

        /// <summary>Gets or sets whether the timer is running.</summary>
        /// <returns>
        /// <see langword="true" /> if the timer is currently enabled; otherwise, <see langword="false" />. The default is <see langword="false" />.</returns>
        public override bool Enabled
        {
            get => _run;
            set => _run = value;
        }

        public int InitialTimer { get; set; }
        public int RemainTimer { get; set; }

        public int Minutes()
        {
            return RemainTimer / 60;
        }
        public int Seconds()
        {
            return RemainTimer % 60;
        }

        public bool ReduceTimer()
        {
            RemainTimer--;
            return RemainTimer > 0;
        }
        public void StartTimer(int seconds)
        {
            InitialTimer = seconds;
            RemainTimer = seconds;
            _run = true;
        }

        public void PauseTimer()
        {
            _run = false;
        }
        public void ResetTimer()
        {
            RemainTimer = InitialTimer;
        }

        public void StopTimer()
        {
            RemainTimer = 0;
            _run = false;
        }
    }
}