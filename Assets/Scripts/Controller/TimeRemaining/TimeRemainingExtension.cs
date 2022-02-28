using System.Collections.Generic;

namespace Platformer
{
    public static partial class TimeRemainingExtension
    {
        private static  readonly List<ITimeRemaining> _timeRemainings = new List<ITimeRemaining>(10);
        public static List<ITimeRemaining> TimeRemainings => _timeRemainings;

        public static void Add(this ITimeRemaining value) {
            if (_timeRemainings.Contains(value))
                return;

            value.CurrentTime = value.Time;
            _timeRemainings.Add(value);
        }


        public static void Remove(this ITimeRemaining value) {
            if (!_timeRemainings.Contains(value))
                return;
            _timeRemainings.Remove(value);
        }
    }
}