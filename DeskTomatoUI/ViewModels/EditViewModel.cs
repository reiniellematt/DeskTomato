using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DeskTomatoUI.ViewModels
{
    public class EditViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;

        private string _minutes = "5";
        private string _seconds = "0";

        public string Minutes
        {
            get { return _minutes; }
            set
            {
                _minutes = value;
                NotifyOfPropertyChange(() => Minutes);
            }
        }
        public string Seconds
        {
            get { return _seconds; }
            set
            {
                _seconds = value;
                NotifyOfPropertyChange(() => Seconds);
            }
        }

        public EditViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public void Ok()
        {
            string validationMessage = ValidateForm();

            if (validationMessage.Length > 0)
            {
                MessageBox.Show(validationMessage, "Edit Break Time Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _eventAggregator.PublishOnUIThread(Minutes);
            _eventAggregator.PublishOnUIThread(Seconds);
            TryClose();
        }

        public void Cancel()
        {
            TryClose();
        }

        private string ValidateForm()
        {
            string output = string.Empty;

            bool isMinutesFieldValid = double.TryParse(Minutes, out double minutes);
            bool isSecondsFieldValid = double.TryParse(Seconds, out double seconds);

            if (!isMinutesFieldValid)
            {
                return "Enter a valid number in the minutes field.";
            }

            if (!isSecondsFieldValid)
            {
                return "Enter a valid number in the minutes field.";
            }

            if (seconds > 59)
            {
                return "The seconds field cannot be greater than 59!";
            }

            return output;
        }
    }
}
