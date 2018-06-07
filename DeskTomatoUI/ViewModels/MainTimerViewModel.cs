using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskTomatoUI.ViewModels
{
    public class MainTimerViewModel : Screen
    {
        private CustomTimer _timer;

        private int _minutes = 0, _seconds = 2;

        public string Time
        {
            get { return string.Format("{0:00}:{1:00}", _minutes, _seconds); }
        }
        public bool CanStart
        {
            get
            {
                return !_timer.IsTimerRunning() && (_minutes > 0 || _seconds > 0);
            }
        }
        public bool CanStop
        {
            get
            {
                return _timer.IsTimerRunning() && (_minutes > 0 || _seconds > 0);
            }
        }
        public bool CanReset
        {
            get
            {
                return !_timer.IsTimerRunning();
            }
        }

        public MainTimerViewModel()
        {
            _timer = new CustomTimer(TimerTick);
        }

        public void Start()
        {
            _timer.Start();
            NotifyOfPropertyChange(() => CanStart);
            NotifyOfPropertyChange(() => CanStop);
            NotifyOfPropertyChange(() => CanReset);
        }

        public void Stop()
        {
            _timer.Stop();
            NotifyOfPropertyChange(() => CanStart);
            NotifyOfPropertyChange(() => CanStop);
            NotifyOfPropertyChange(() => CanReset);
        }

        public void Reset()
        {
            _minutes = 25;
            _seconds = 0;
            NotifyOfPropertyChange(() => Time);
            NotifyOfPropertyChange(() => CanStart);
        }

        private void TimerTick(object sender, EventArgs e)
        {
            _seconds--;

            if (_seconds < 0)
            {
                _minutes--;
                _seconds = 59;
            }

            if (_minutes == 0 && _seconds == 0)
            {
                _timer.Stop();
                NotifyOfPropertyChange(() => CanStop);
                NotifyOfPropertyChange(() => CanReset);
            }

            NotifyOfPropertyChange(() => Time);
        }
    }
}