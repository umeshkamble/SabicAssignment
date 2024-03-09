using Assignment3.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment3.Views
{
    public partial class ConfigurationPage : ContentPage
    {
        ConfigurationViewModel viewModel;
        public ConfigurationPage()
        {
            InitializeComponent();
            BindingContext = viewModel=new ConfigurationViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
}