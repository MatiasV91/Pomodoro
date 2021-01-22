using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Pomodoro.Service;
using Prism.Events;

namespace Pomodoro.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private int _reps = 1;
        private int _workMinutes = 6;
        private int _shortBreakMinutes = 5;
        private int _longBreakMinutes = 20;
        private ITimerService _currentTimer;

        public MainViewModel(ITimerService currentTimer,IEventAggregator eventAggregator)
        {
            StartCommand = new DelegateCommand(OnStartExecute);
            ResetCommand = new DelegateCommand(OnResetExecute);
            _currentTimer = currentTimer;
            _currentTimer.TimerEnded += _currentTimer_TimerEnded;
        }

        public ITimerService Timer
        {
            get
            {
                return _currentTimer;
            }
            set
            {
                _currentTimer = value;
            }
        }

        public ICommand StartCommand { get; }
        public ICommand ResetCommand { get; }


        private void OnResetExecute()
        {
            throw new NotImplementedException();
        }

        private void OnStartExecute()
        {
            ManageTimer();
        }

        private void ManageTimer()
        {
            if (_reps % 2 != 0)
            {
                Timer.TimerSet(_workMinutes);
            }
            else if (_reps % 8 == 0)
            {
                Timer.TimerSet(_longBreakMinutes);
            }
            else
            {
                Timer.TimerSet(_shortBreakMinutes);
            }
        }

        private void _currentTimer_TimerEnded(object sender, EventArgs e)
        {
            _reps += 1;
            ManageTimer();
        }

    }
}
