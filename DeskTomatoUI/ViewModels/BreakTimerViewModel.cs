using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskTomatoUI.ViewModels
{
    internal class BreakTimerViewModel : Screen, IHandle<string[]>
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IWindowManager _windowManager;

        private CustomTimer _timer;
        private double _minutes = 5, _seconds = 0;
        private double _newMinutes = 5, _newSeconds = 0;


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

        public BreakTimerViewModel(IEventAggregator eventAggregator, IWindowManager windowManager)
        {
            _eventAggregator = eventAggregator;
            _windowManager = windowManager;

            _timer = new CustomTimer(TimerTick);
        }

        public void Edit()
        {
            _eventAggregator.Subscribe(this);
            _windowManager.ShowDialog(IoC.Get<EditViewModel>());
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
            _minutes = _newMinutes;
            _seconds = _newSeconds;
            NotifyOfPropertyChange(() => Time);
            NotifyOfPropertyChange(() => CanStart);
        }

        public void Handle(string[] message)
        {
            _newMinutes = double.Parse(message[0]);
            _newSeconds = double.Parse(message[1]);

            _minutes = _newMinutes;
            _seconds = _newMinutes;
            NotifyOfPropertyChange(() => Time);

            _eventAggregator.Unsubscribe(this);
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