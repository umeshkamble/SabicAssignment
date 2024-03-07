using Assignment2.Services.DependencyServies;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Assignment2.ViewModels
{
    public class AudioRecordingViewModel : BaseViewModel
    {
        #region Propertise
        public ISpeechService SpeechService { get; set; }

        private ObservableCollection<string> recordedFiles;

        public ObservableCollection<string> RecordedFiles
        {
            get { return recordedFiles; }
            set { SetProperty(ref recordedFiles, value); }
        }

        #endregion

        #region Constructor
        public AudioRecordingViewModel()
        {
            Title = "Voice Recording";
            SpeechService = DependencyService.Get<ISpeechService>();
            RecordedFiles = new ObservableCollection<string>();
        }
        #endregion

        #region Methods
        public async Task CheckAndStartRecording()
        {
            var microphoneStatus = await CheckAndRequestMicrophonePermission();
            var speeachStatus= await CheckAndRequestSpeeachPermission();
            if (microphoneStatus == PermissionStatus.Granted && speeachStatus == PermissionStatus.Granted)
            {
                string audioFile = string.Empty;
                SpeechService.FinalResults += (arg) =>
                {
                    if (!string.IsNullOrEmpty(arg))
                    {
                        RecordedFiles.Add(arg);
                    }
                    SpeechService.StartListening();
                };
            }
            else
            {
                await Shell.Current.DisplayAlert("Alert", "Microphone permission is needed!!!", "OK");
            }
        }
        private async Task<PermissionStatus> CheckAndRequestMicrophonePermission()
        {
            try
            {
                var status = await Permissions.CheckStatusAsync<Permissions.Microphone>();

                if (status == PermissionStatus.Granted)
                    return status;

                if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
                {
                    return status;
                }
                status = await Permissions.RequestAsync<Permissions.Microphone>();
                return status;
            }
            catch (Exception er)
            {
                Console.WriteLine(er.StackTrace);
                return PermissionStatus.Denied;
            }
        }
        private async Task<PermissionStatus> CheckAndRequestSpeeachPermission()
        {
            try
            {
                var status = await Permissions.CheckStatusAsync<Permissions.Speech>();

                if (status == PermissionStatus.Granted)
                    return status;

                if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
                {
                    return status;
                }
                status = await Permissions.RequestAsync<Permissions.Speech>();
                return status;
            }
            catch (Exception er)
            {
                Console.WriteLine(er.StackTrace);
                return PermissionStatus.Denied;
            }
        }

        #endregion

    }
}