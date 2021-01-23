using Newtonsoft.Json;
using Pomodoro.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Service
{
    public class DataService : IDataService
    {

        private string _saveFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Pomodoro/";
        private string _saveName = "settings.json";

        public Duration LoadSettings()
        {
            if (!File.Exists(Path.Combine(_saveFolder, _saveName)))
            {
                var d = new Duration();
                SaveSettings(d);
                return d;
            }
            else
            {
                string json = File.ReadAllText(Path.Combine(_saveFolder, _saveName));
                return JsonConvert.DeserializeObject<Duration>(json);
            }
        }

        public void SaveSettings(Duration duration)
        {
            Directory.CreateDirectory(_saveFolder);
            string json = JsonConvert.SerializeObject(duration, Formatting.Indented);
            File.WriteAllText(Path.Combine(_saveFolder, _saveName), json);
        }
    }
}
