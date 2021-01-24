using Pomodoro.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Model
{
    public class Duration : ViewModelBase
    {
        private int _workMinutes = 6;
        private int _shortBreakMinutes = 5;
        private int _longBreakMinutes = 20;

        public int WorkMinutes
        {
            get => _workMinutes;
            set
            {
                if (value == _workMinutes)
                    return;
                _workMinutes = value;
                OnPropertyChanged();
            }
        }

        public int ShortBreakMinutes
        {
            get => _shortBreakMinutes;
            set
            {
                _shortBreakMinutes = value;
                OnPropertyChanged();
            }
        }
        public int LongBreakMinutes
        {
            get => _longBreakMinutes;
            set
            {
                _longBreakMinutes = value;
                OnPropertyChanged();
            }
        }

    }
}
