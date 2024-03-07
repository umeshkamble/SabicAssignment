using Assignment2.Services.DependencyServies;
using System;
using Xamarin.Forms;
using static Xamarin.Essentials.Permissions;
using WinSpeechRecognizer = Windows.Media.SpeechRecognition.SpeechRecognizer;

[assembly: Dependency(typeof(Assignment2.UWP.DependencyServices.SpeechRecognizerService))]
namespace Assignment2.UWP.DependencyServices
{
    public class SpeechRecognizerService : ISpeechService
    {
        WinSpeechRecognizer winSpeechRecognizer;
        public Action<string> FinalResults { get ; set; }


        public SpeechRecognizerService()
        {
            winSpeechRecognizer = new WinSpeechRecognizer();
            StartListening();
        }

        public async void StartListening()
        {
            try
            {
                await winSpeechRecognizer.CompileConstraintsAsync();
                var result = await winSpeechRecognizer.RecognizeAsync();

                FinalResults?.Invoke(result?.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

        }
    }
}
