using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Pomodoro.Service;
using Prism.Events;
using Pomodoro.Model;

namespace Pomodoro.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ITimerService _timer;
        private readonly IDataService _data;
        private int _repetitions;

        public MainViewModel(ITimerService timer,IDataService data)
        {
            WindowTitle = "Pomodoro";
            StartCommand = new DelegateCommand(OnStartExecute);
            ResetCommand = new DelegateCommand(OnResetExecute);
            _timer = timer;
            _data = data;
            _timer.TimerEnded += _currentTimer_TimerEnded;
            Repetitions = 1;
            Settings = _data.LoadSettings();
        }

        public string WindowTitle { get; set; }
        public ITimerService Timer => _timer;
        public ICommand StartCommand { get; }
        public ICommand ResetCommand { get; }
        public Duration Settings { get; set; }

        public int Repetitions
        {
            get => _repetitions;
            set
            {
                _repetitions = value;
                OnPropertyChanged();
            }
        }

        private void OnResetExecute()
        {
            _timer.TimerReset();
            Repetitions = 1;
        }

        private void OnStartExecute()
        {
            ManageTimer();
        }

        private void ManageTimer()
        {
            if (Repetitions % 2 != 0)
            {
                Timer.TimerSet(Settings.WorkMinutes);
            }
            else if (Repetitions % 8 == 0)
            {
                Timer.TimerSet(Settings.LongBreakMinutes);
            }
            else
            {
                Timer.TimerSet(Settings.ShortBreakMinutes);
            }
        }

        private void _currentTimer_TimerEnded(object sender, EventArgs e)
        {
            Repetitions += 1;
            ManageTimer();
        }

    }
}
