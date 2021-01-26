using Autofac;
using Pomodoro.Service;
using Pomodoro.ViewModel;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Startup
{
    public class Boostrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<TimerService>().As<ITimerService>();
            builder.RegisterType<DataService>().As<IDataService>();
            builder.RegisterType<SoundService>().As<ISoundService>();
            return builder.Build();
        }
    }
}
