using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class TimeRemainingController : IExecute
    {
        private readonly List<ITimeRemaining> _timeRemainnigs;

        public TimeRemainingController() {
            _timeRemainnigs = TimeRemainingExtension.TimeRemainings;
        }

        public void Execute() {
            for (var i = 0; i < _timeRemainnigs.Count; i++) {
                var obj = _timeRemainnigs[i];
                obj.CurrentTime -= Time.deltaTime;
                if (obj.CurrentTime <= 0.0f) {
                    obj.Method?.Invoke();
                    if (!obj.IsRepeating)
                        obj.Remove();
                    else
                        obj.CurrentTime = obj.Time;
                }
            }
        }
    }
}