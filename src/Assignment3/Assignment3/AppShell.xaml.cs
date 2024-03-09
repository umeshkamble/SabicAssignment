using Assignment3.ViewModels;
using Assignment3.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Assignment3
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(PreviewFormPage), typeof(PreviewFormPage));
            Routing.RegisterRoute(nameof(ConfigurationPage), typeof(ConfigurationPage));
        }
    }
}
