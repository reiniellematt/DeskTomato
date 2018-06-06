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
        private int _minutes = 25, _seconds = 0;

        public string Time
        {
            get { return string.Format("{0:00}:{1:00}", _minutes, _seconds); }
        }

        public MainTimerViewModel()
        {
        }
    }
}
