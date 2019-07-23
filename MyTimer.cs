namespace PomidoroNet
{
    class MyTimer: System.Windows.Forms.Timer
    {
        private int _initial;
        private int _remain;
        private bool _run;
        public override bool Enabled
        {
            get => _run;
            set => _run=value;
        }
        
    }
}