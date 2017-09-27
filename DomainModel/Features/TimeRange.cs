using System;

namespace DomainModel.Features
{
    public class TimeRange
    {
        public TimeRange(DateTime start, DateTime finish)
        {
            Start = start;
            Finish = finish;
        }

        public DateTime Start { get; }
        public DateTime Finish { get; }
    }
}