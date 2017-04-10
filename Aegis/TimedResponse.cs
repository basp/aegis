namespace Aegis
{
    using System;

    public abstract class TimedResponse
    {
        protected TimedResponse(TimeSpan duration)
        {
            this.Duration = duration;
        }

        public TimeSpan Duration { get; }
    }
}
