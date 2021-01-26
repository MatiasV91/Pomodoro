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

        private readonly string _saveFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Pomodoro/";
        private readonly string _saveName = "settings.json";

        public Settings LoadSettings()
        {
            if (!File.Exists(Path.Combine(_saveFolder, _saveName)))
            {
                var s = new Settings();
                SaveSettings(s);
                return s;
            }
            else
            {
                string json = File.ReadAllText(Path.Combine(_saveFolder, _saveName));
                return JsonConvert.DeserializeObject<Settings>(json);
            }
        }

        public void SaveSettings(Settings duration)
        {
            Directory.CreateDirectory(_saveFolder);
            string json = JsonConvert.SerializeObject(duration, Formatting.Indented);
            File.WriteAllText(Path.Combine(_saveFolder, _saveName), json);
        }
    }
}
