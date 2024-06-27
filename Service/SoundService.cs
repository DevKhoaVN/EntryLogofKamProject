using NAudio;
using NAudio.Wave;
using System.Threading;

namespace EntryLogManagement.Service
{
    public class SoundService
    {
        public void PlaySound()
        {

            try
            {
                using(var audioFile = new AudioFileReader("C:\\Users\\khoav\\OneDrive\\Tài liệu\\ADO.NET\\SESSION\\Mail\\Alter.wav"))
                using (var outputDevice = new WaveOutEvent())
                {
                      outputDevice.Init(audioFile);
                      outputDevice.Play();

                     int IsCount = 0;

                       while(outputDevice.PlaybackState == PlaybackState.Playing && IsCount <= 10)
                       {
                          Thread.Sleep(1000);
                          IsCount++;
                       }

                       outputDevice.Stop();
                }
            
             }catch(Exception ex)
             {
                System.Console.WriteLine("Error Sound : " + ex.Message);
             }
        }
    }
}