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

        private double _minutes = 5, _seconds = 0;

        public string Time
        {
            get { return string.Format("{0:00}:{1:00}", _minutes, _seconds); }
        }

        public BreakTimerViewModel(IEventAggregator eventAggregator, IWindowManager windowManager)
        {
            _eventAggregator = eventAggregator;
            _windowManager = windowManager;
        }

        public void Edit()
        {
            _eventAggregator.Subscribe(this);
            _windowManager.ShowDialog(IoC.Get<EditViewModel>());
        }

        public void Handle(string[] message)
        {
            _minutes = double.Parse(message[0]);
            _seconds = double.Parse(message[1]);
            NotifyOfPropertyChange(() => Time);

            _eventAggregator.Unsubscribe(this);
        }
    }
}
