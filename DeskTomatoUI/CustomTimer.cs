using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace DeskTomatoUI
{
    public class CustomTimer
    {
        private DispatcherTimer _timer;
        private EventHandler _timerTick;
        private TimeSpan _interval;
        private bool _isTimerRunning;

        public CustomTimer(EventHandler timerTick)
        {
            _interval = TimeSpan.FromMilliseconds(1000);
            _timerTick = timerTick;
            _isTimerRunning = false;
        }

        public void Start()
        {
            _timer = new DispatcherTimer { Interval = _interval };
            _timer.Tick += _timerTick;
            _timer.Start();
            _isTimerRunning = true;
        }

        public void Stop()
        {
            _timer.Stop();
            _timer = null;
            _isTimerRunning = false;
        }

        public bool IsTimerRunning()
        {
            return _isTimerRunning;
        }
    }
}