using Pomodoro.Properties;
using Pomodoro.ViewModel;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Pomodoro.Service
{
    public class TimerService : ViewModelBase, ITimerService
    {

        public TimerService()
        {
            _time = TimeSpan.FromSeconds(0);
            TimerCreate();
        }

        private TimeSpan _time;
        private DispatcherTimer _timer;
        public event EventHandler TimerEnded;

        public string Time
        {
            get
            {
                return _time.ToString();
            }
        }

        private void TimerCreate()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += _timer_Tick;
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            _time = new TimeSpan(_time.Ticks - TimeSpan.TicksPerSecond);
            OnPropertyChanged(nameof(Time));
            if (_time.Ticks < 0)
            {
                _timer.Stop();
                TimerEnded?.Invoke(this, EventArgs.Empty);
            }
        }

        public void TimerSet(int minutes)
        {
            if (_timer.IsEnabled)
            {
                _timer.Stop();
            }
            _time = TimeSpan.FromMinutes(minutes);
            OnPropertyChanged(nameof(Time));
            _timer.Start();
        }

        public void TimerReset()
        {
            _timer.Stop();
            _time = TimeSpan.FromSeconds(0);
            OnPropertyChanged(nameof(Time));
        }



    }
}
