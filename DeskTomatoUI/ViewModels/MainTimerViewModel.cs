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

        private int _minutes = 25, _seconds = 0;

        public string Time
        {
            get { return string.Format("{0:00}:{1:00}", _minutes, _seconds); }
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
        }

        public void Stop()
        {
            _timer.Stop();
            NotifyOfPropertyChange(() => CanStart);
            NotifyOfPropertyChange(() => CanStop);
        }

        public bool CanStart
        {
            get
            {
                return !_timer.IsTimerRunning();
            }
        }

        public bool CanStop
        {
            get
            {
                return _timer.IsTimerRunning();
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            _seconds--;

            if (_seconds < 0)
            {
                _minutes--;
                _seconds = 59;
                NotifyOfPropertyChange(() => Time);
            }

            NotifyOfPropertyChange(() => Time);
        }
    }
}