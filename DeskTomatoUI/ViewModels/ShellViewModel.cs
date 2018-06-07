﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskTomatoUI.ViewModels
{
    public class ShellViewModel : Conductor<Screen>
    {
        public ShellViewModel()
        {
            ActivateItem(IoC.Get<BreakTimerViewModel>());
        }
    }
}