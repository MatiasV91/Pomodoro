using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Service
{
    public interface ITimerService : INotifyPropertyChanged
    {
        event EventHandler TimerEnded;
        string Time { get; }
        void TimerSet(int minutes);
        void TimerReset();
    }
}
