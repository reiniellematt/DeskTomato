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
        private int _minutes = 25, _seconds = 25;

        private string _time;

        public string Time
        {
            get { return _time; }
            set
            {
                _time = value;
                NotifyOfPropertyChange(() => Time);
            }
        }

        public MainTimerViewModel()
        {
            Time = $"{ _minutes }:{ _seconds }";
        }
    }
}
