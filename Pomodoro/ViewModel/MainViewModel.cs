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
        private readonly ISoundService _sound;
        private int _repetitions;
        private string _tittle;


        public MainViewModel(ITimerService timer, IDataService data,ISoundService sound)
        {
            WindowTitle = "Pomodoro";
            Tittle = "Timer";
            StartCommand = new DelegateCommand(OnStartExecute);
            ResetCommand = new DelegateCommand(OnResetExecute);
            SaveSettingsCommand = new DelegateCommand(OnSaveSettingsExecute);
            _timer = timer;
            _data = data;
            _sound = sound;
            _timer.TimerEnded += _currentTimer_TimerEnded;
            Repetitions = 1;
            Settings = _data.LoadSettings();
        }

        public string WindowTitle { get; set; }
        public ITimerService Timer => _timer;
        public ICommand StartCommand { get; }
        public ICommand ResetCommand { get; }
        public ICommand SaveSettingsCommand { get; }
        public Settings Settings { get; set; }

        public string Tittle
        {
            get => _tittle; 
            set
            {
                _tittle = value;
                OnPropertyChanged();
            }
        }

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
            Tittle = "Timer";
        }

        private void OnStartExecute()
        {
            OnResetExecute();
            ManageTimer();
        }

        private void ManageTimer()
        {
            if (Repetitions % 2 != 0)
            {
                Timer.TimerSet(Settings.WorkMinutes);
                Tittle = "Work";
            }
            else if (Repetitions % 8 == 0)
            {
                Tittle = "Long Break";
                Timer.TimerSet(Settings.LongBreakMinutes);
            }
            else
            {
                Tittle = "Short Break";
                Timer.TimerSet(Settings.ShortBreakMinutes);
            }
        }

        private void _currentTimer_TimerEnded(object sender, EventArgs e)
        {
            Repetitions += 1;
            if (Settings.PlaySound) _sound.PlaySound();
            ManageTimer();
        }

        private void OnSaveSettingsExecute()
        {
            _data.SaveSettings(Settings);
        }

    }
}
