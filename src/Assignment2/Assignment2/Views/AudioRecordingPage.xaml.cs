using Assignment2.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment2.Views
{
    public partial class AudioRecordingPage : ContentPage
    {
        private readonly AudioRecordingViewModel viewModel;
        public AudioRecordingPage()
        {
            InitializeComponent();
            viewModel = new AudioRecordingViewModel();
             this.BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if(viewModel != null )
            {
             await   viewModel.CheckAndStartRecording();
            }

        }
    }
}