using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Speech;
using Android.Views;
using Android.Widget;
using Assignment2.Services.DependencyServies;
using Java.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(Assignment2.Droid.DependencyServices.SpeechRecognizerService))]
namespace Assignment2.Droid.DependencyServices
{
    public class SpeechRecognizerService: Java.Lang.Object, IRecognitionListener, ISpeechService
    {
        SpeechRecognizer speechRecognizer;
        public Action<string> FinalResults { get ; set; }

        public SpeechRecognizerService()
        {
            speechRecognizer = SpeechRecognizer.CreateSpeechRecognizer(Platform.AppContext.ApplicationContext);
            speechRecognizer.SetRecognitionListener(this);
            StartListening();
        }

        public void StartListening() {
            try
            {
                speechRecognizer.StartListening(CreateSpeechIntent(true));
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.StackTrace);
               
            }
        }

        protected virtual Intent CreateSpeechIntent(bool partialResults)
        {
            var intent = new Intent(RecognizerIntent.ActionRecognizeSpeech);
            intent.PutExtra(RecognizerIntent.ExtraLanguagePreference, Java.Util.Locale.Default);
            intent.PutExtra(RecognizerIntent.ExtraLanguage, Java.Util.Locale.Default);
            intent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);
            intent.PutExtra(RecognizerIntent.ExtraCallingPackage, Android.App.Application.Context.PackageName);
          
            intent.PutExtra(RecognizerIntent.ExtraPartialResults, partialResults);

            return intent;
        }
        public void OnResults(Bundle results)
        {
            try
            {
                var matches = results.GetStringArrayList(SpeechRecognizer.ResultsRecognition);
                if (matches != null && matches.Count > 0)
                {
                    FinalResults?.Invoke(matches[0]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

        }

        public void OnBeginningOfSpeech()
        {
        }

        public void OnBufferReceived(byte[] buffer)
        {
           
        }

        public void OnEndOfSpeech()
        {
        }

        public void OnError([GeneratedEnum] SpeechRecognizerError error)
        {
        }

        public void OnEvent(int eventType, Bundle @params)
        {
        }

        public void OnPartialResults(Bundle partialResults)
        {
        }

        public void OnReadyForSpeech(Bundle @params)
        {
        }

        public void Disposed()
        {
        }

        public void DisposeUnlessReferenced()
        {
        }

        public void Finalized()
        {
        }

        public void OnRmsChanged(float rmsdB)
        {
        }

        public void SetJniIdentityHashCode(int value)
        {
        }

        public void SetJniManagedPeerState(JniManagedPeerStates value)
        {
        }

        public void SetPeerReference(JniObjectReference reference)
        {
        }

    }
}