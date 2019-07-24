using System;

namespace PomidoroNet
{
    class MyTimer : System.Windows.Forms.Timer
    {
        private int _initial;
        private int _remain;
        private bool _run;

        public MyTimer(EventHandler e)
        {
            base.Tick += e;
            base.Interval = 1000;
            base.Enabled = true;
            base.Start();
        }

        public override bool Enabled
        {
            get => _run;
            set => _run = value;
        }

//        public override int Interval
//        {
//            get => _initial;
//            set => _initial = value;
//        }
    }
}