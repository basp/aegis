namespace Aegis
{
    using System;

    public class Stopwatch
    {
        private DateTime started;
        private bool isStarted = false;

        private Stopwatch()
        {
        }

        public static Stopwatch Create(bool start = false)
        {
            var swatch = new Stopwatch();
            if (start)
            {
                swatch.Start();
            }

            return swatch;
        }

        public void Start()
        {
            if (this.isStarted)
            {
                return;
            }

            this.started = DateTime.UtcNow;
            this.isStarted = true;
        }

        public TimeSpan Stop()
        {
            this.isStarted = false;
            var now = DateTime.UtcNow;
            var dur = now - this.started;
            return dur;
        }

        public TimeSpan Lap()
        {
            var dur = this.Stop();
            this.Start();
            return dur;
        }
    }
}
