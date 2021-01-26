using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pomodoro.Service
{
    public class SoundService : ISoundService
    {
        private readonly string _sound = @"Audio\household_clock_digital_alarm_beeping_004-zapsplat.mp3";

        public void PlaySound()
        {
            Task.Run(() =>
            {
                using (var output = new WaveOutEvent())
                using (var player = new Mp3FileReader(_sound))
                {
                    output.Volume = 0.1f;
                    output.Init(player);
                    output.Play();
                    while (output.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(500);
                    }
                }
            });
        }

       
}
}
