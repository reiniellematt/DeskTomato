using Caliburn.Micro;
using DeskTomatoUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFNotification.Services;

namespace DeskTomatoUI
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override void Configure()
        {
            _container.Singleton<IWindowManager, WindowManager>();
            _container.Singleton<IEventAggregator, EventAggregator>();
            _container.Singleton<INotificationDialogService, NotificationDialogService>();

            _container.RegisterPerRequest(typeof(ShellViewModel), null, typeof(ShellViewModel));
            _container.RegisterPerRequest(typeof(MainTimerViewModel), null, typeof(MainTimerViewModel));
            _container.RegisterPerRequest(typeof(BreakTimerViewModel), null, typeof(BreakTimerViewModel));
            _container.RegisterPerRequest(typeof(EditViewModel), null, typeof(EditViewModel));
        }

        protected override object GetInstance(Type serviceType, string key)
        {
            return _container.GetInstance(serviceType, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _container.GetAllInstances(serviceType);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
