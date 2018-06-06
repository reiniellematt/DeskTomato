using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskTomatoUI.ViewModels
{
    class BreakTimerViewModel : Screen
    {
        private IEventAggregator _eventAggregator;

        private double _minutes = 5, _seconds = 0;

        public string Time
        {
            get { return string.Format("{0:00}:{1:00}", _minutes, _seconds); }
        }

        public BreakTimerViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }
    }
}
