using Pomodoro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Service
{
    public interface IDataService
    {
        void SaveSettings(Settings duration);
        Settings LoadSettings();
    }
}
