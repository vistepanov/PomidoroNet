using System;

namespace PomidoroNet
{
    class MyTimer : System.Windows.Forms.Timer
    {
        private bool _run;

        public MyTimer(EventHandler e)
        {
            base.Tick += e;
            base.Interval = 1000;
            base.Enabled = true;
            base.Start();
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

//        public override int Interval
//        {
//            get => _initial;
//            set => _initial = value;
//        }
        public void StartTimer(int seconds)
        {
            InitialTimer = seconds;
            RemainTimer = seconds;
            _run = true;
        }
    }
}