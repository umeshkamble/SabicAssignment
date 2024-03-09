using Assignment3.Models;
using Assignment3.ViewModels;
using Assignment3.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment3.Views
{
    public partial class ConfigurationListPage : ContentPage
    {
        ConfigurationListViewModel _viewModel;

        public ConfigurationListPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ConfigurationListViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}